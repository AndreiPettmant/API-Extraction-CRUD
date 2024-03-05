using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
   public static class DBModel
    {
        public static SqlConnection connection = null;
        /// <summary>
        /// Data Base server IP, can be localhost.
        /// </summary>
        public static string dbIpServer = "0.0.0.0";

        /// <summary>
        /// Data Base name.
        /// </summary>
        public static string dbName = "dbCoolDBName";

        /// <summary>
        /// Data Base user name to access DB.
        /// </summary>
        public static string dbUser = "dbCoolUserName";

        /// <summary>
        /// Data Base password.
        /// </summary>
        public static string dbPassword = "123";

        /// <summary>
        /// Persist Security Info of the ConnectionString. Default True.
        /// </summary>
        public static bool persistCredential = true;
        
        /// <summary>
        /// Dictionary of Servers Available.
        /// </summary>
        public static Dictionary<string, string> Servers { get; private set; }

        /// <summary>
        /// Return all parameters values used.
        /// </summary>
        public static Dictionary<string, object> Output = new Dictionary<string, object>();

        private static List<SqlParameter> Parameters = new List<SqlParameter>();

        /// <summary>
        /// Initializes the list of servers.
        /// </summary>
        public static void InitializeServers()
        {
            Servers = new Dictionary<string, string>();

            Servers.Add("Cool Server 1", "1.1.1.1");
            Servers.Add("Cool Server 2", "2.2.2.2");
            Servers.Add("Cool Server 3", "3.3.3.3");
        }

        public static void Connect()
        {
            if (connection is null)
            {
                connection = new SqlConnection();
            }

            try
            {
                if (connection.State is ConnectionState.Open)
                {
                    connection.Close();
                }

                connection.ConnectionString = string.Format("Initial Catalog = {0}; " +
                    "Data Source = {1}; " +
                    "Uid = {2}; " +
                    "Pwd = {3}; " +
                    "persist security info = {4}; " +
                    "TrustServerCertificate=true", dbName, dbIpServer, dbUser, dbPassword, persistCredential);

                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                CancellationToken cancellationToken = cancellationTokenSource.Token;
                cancellationTokenSource.CancelAfter(5000);

                Task cancelationTokenTask = connection.OpenAsync(cancellationToken);

                cancelationTokenTask.Wait();

            }
            catch (SqlException error)
            {
                string message = error.Message;
                switch (error.Number)
                {
                    case 53:
                    case 18456:
                        message = "Falha ao conectar com banco de dados, verifique seu login.";
                        break;
                }
                throw new Exception(message);

            }
            catch (TaskCanceledException)
            {
                throw new Exception("Failed to connect to the database, please check your login credentials.");
            }
            catch (ObjectDisposedException)
            {
                throw new Exception("Failed to connect to the database, please check your login credentials.");
            }
            catch (AggregateException)
            {
                throw new Exception("Failed to connect to the database, please check your login credentials.");
            }
            catch (InvalidOperationException)
            {
                throw new Exception("Failed to connect to the database, please check your login credentials.");
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        /// <summary>
        /// Clear the list of parameters used in the execution of an stored procedure ou function.
        /// </summary>
        /// <exception cref="Exception">Specific error message.</exception>
        public static void ClearParameters()
        {
            try
            {
                Parameters.Clear();
                Output.Clear();
            }
            catch (Exception exc)
            {

                throw new Exception(exc.Message);
            }
        }

        /// <summary>
        /// Adds a parameter to execute the stored procedure or function. Remember to use ClearParameters before you start inserting parameters.
        /// </summary>
        /// <param name="name">Parameter Name.</param>
        /// <param name="value">Parameter Value.</param>
        /// <param name="direction">Parameter Direction.</param>
        /// <exception cref="Exception">Specific error message.</exception>
        /// 

        public static void AddParameters(string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            try
            {
                SqlParameter parameter;

                parameter = new SqlParameter(name, value);
                parameter.Direction = direction;

                Parameters.Add(parameter);
            }
            catch (Exception exc)
            {

               throw new Exception (exc.Message);
            }            
        }

        /// <summary>
        /// Executes the SQL command and returns a DataSet containing the return from the database. Remember to use ClearParameters and AddParameter, if necessary, before executing.
        /// </summary>
        /// <param name="sql">Name of the Stored Procedure or command in SQL.</param>
        /// <param name="type">Command type, by default Stored Procedure.</param>
        /// <returns>Contains a DataSet with the tables accessed by the Tables property. The Tables property is empty (Tables.Count == 0) if nothing is returned.</returns>
        /// <exception cref="Exception">Database failed to execute SQL or specific error message.</exception>
        /// 

        public static DataSet Execute(string sql, CommandType type = CommandType.StoredProcedure)
        {
            Connect();

            if (connection.State != ConnectionState.Open)
            {
                throw new Exception("Connection not estabilished");
            }

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sql, connection);
            adapter.SelectCommand.CommandType = type;
            adapter.SelectCommand.CommandTimeout = 3600;

            adapter.SelectCommand.Parameters.AddRange(Parameters.ToArray());

            DataSet execReturn = new DataSet();

            try
            {
                adapter.Fill(execReturn);
            }
            catch (SqlException exc)
            {

                throw new Exception(string.Format("{0} - {1}", exc.Message, exc.Procedure));
            }
            catch(Exception exc)
            {
                throw new Exception(string.Format("{0}", exc.Message));
            }

            try
            {
                Output.Clear();

                int iterateOutput = 0;

                while (iterateOutput < Parameters.Count) 
                {
                    if (Parameters[iterateOutput].Direction == ParameterDirection.Output || 
                        Parameters[iterateOutput].Direction == ParameterDirection.InputOutput) 
                    {
                        Output.Add(Parameters[iterateOutput].ParameterName, Parameters[iterateOutput].Value);
                    }

                    iterateOutput++;
                }
            }
            catch (Exception exc)
            {

                throw new Exception(exc.Message);
            }

            return execReturn;
        }
    }
}
