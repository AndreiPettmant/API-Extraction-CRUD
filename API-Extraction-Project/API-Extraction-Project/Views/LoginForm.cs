using DataBase;
using Microsoft.VisualBasic.Logging;
using System.Data;

namespace API_Extraction_Project
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
            DBModel.InitializeServers();

            UserForm userForm = new UserForm();
            userForm.Show();

            foreach (var server in DBModel.Servers)
            {
                cbServers.Items.Add(server.Key);
            }

            cbServers.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DBModel.dbUser = txtUserInput.Text;
                DBModel.dbPassword = txtPasswordInput.Text;
                DBModel.dbName = cbServers.SelectedItem.ToString();
                DBModel.dbIpServer = DBModel.Servers[cbServers.SelectedItem.ToString()];

                DBModel.Connect();

                if (DBModel.connection.State == ConnectionState.Open)
                {
                    if (HasPermission(DBModel.dbUser))
                    {
                        this.Hide();
                        UserForm userForm = new UserForm();
                        userForm.Show();
                    }
                }
            }
            catch (Exception exc)
            {

                MessageBox.Show($"{exc.Message}", "Failed to Connect", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          

        }

        bool HasPermission(string user)
        {
            try
            {
                DBModel.ClearParameters();
                DBModel.AddParameters("@permission_IN", 1);
                DBModel.AddParameters("@login_VC", user);

                DataSet dsResult = (DataSet)DBModel.Execute("usp_CheckUsersPermissions");

                if (dsResult is not null && dsResult.Tables.Count > 0 
                    && dsResult.Tables[0].Rows.Count > 0) 
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(string.Format("The user {0} doesn't have permission", user), "Permission Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Show();
                    return false;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erro ao verificar permissão: " + exc.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return false;
            }
        }

        private void chkBoxServerName_CheckedChanged(object sender, EventArgs e)
        {
            var selectedItem = cbServers.SelectedItem?.ToString();
            var selectedIndex = cbServers.SelectedIndex;

            cbServers.Items.Clear();

            foreach (var server in DBModel.Servers)
            {
                cbServers.Items.Add(chkBoxServerName.Checked ? server.Key : server.Value);
            }

            if (!string.IsNullOrEmpty(selectedItem))
            {
                if ((chkBoxServerName.Checked && DBModel.Servers.ContainsKey(selectedItem)) ||
                    (!chkBoxServerName.Checked && DBModel.Servers.ContainsValue(selectedItem)))
                {
                    cbServers.SelectedItem = selectedItem;
                }
                else
                {
                    // Se o item selecionado anteriormente não estiver disponível, manter o índice atual ou definir para o primeiro item
                    if (selectedIndex >= 0 && selectedIndex < cbServers.Items.Count)
                    {
                        cbServers.SelectedIndex = selectedIndex;
                    }
                    else
                    {
                        cbServers.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                cbServers.SelectedIndex = 0;
            }
        }


    }
}
