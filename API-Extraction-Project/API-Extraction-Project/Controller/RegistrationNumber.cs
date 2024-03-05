using DataBase;
using System.Data;
using System.Data.SqlClient;

namespace API_Extraction_Project.Controller
{
    public class RegistrationNumber
    {
        public DataSet GetAllRegistrationsNumbers()
        {
			try
			{
				DataSet ds = new DataSet();
				DBModel.Connect();
				DBModel.ClearParameters();
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

				ds = DBModel.Execute("usp_GetAllRegistrationNumbers");
				return ds;
			}
			catch (Exception exc)
			{
                MessageBox.Show($"{exc.Message}", "Failed to retrieve information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return null; 
			}
        }

		public int UpdateSecondActivities(SecondaryActivities secondaryActivities, int headerCode, string registrationNumber)
		{
			try
			{
				int returnCode = 0;

				DBModel.Connect(); 
				DBModel.ClearParameters();

				DBModel.AddParameters("@header_IN", headerCode);
				DBModel.AddParameters("@registration_number_IN", registrationNumber);
				DBModel.AddParameters("@secondary_activities_VC", secondaryActivities.code);
				DBModel.AddParameters("@secondary_activities_description", secondaryActivities.text);
				DBModel.AddParameters("@registration_code_IN", 0, ParameterDirection.InputOutput);
				
				SqlParameter sqlParameter = new SqlParameter("@registration_code_IN", SqlDbType.Int);

                DBModel.Execute("usp_UpdateSecondActivities");

                return returnCode;
			}
			catch (Exception exc)
			{

                MessageBox.Show($"{exc.Message}", "Failed to execute procedure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return 0;
            }
		}

		public int UpdateRegistrationNumberHeader(Registration registration)
		{
			try
			{
                int returnCode = 0;

                DBModel.Connect();
                DBModel.ClearParameters();

                DBModel.AddParameters("@registration_number_VC", registration.registration_number);
                DBModel.AddParameters("@situation_VC", registration.situation);
                DBModel.AddParameters("@type_VC", registration.type);
                DBModel.AddParameters("@name_VC", registration.name);
                DBModel.AddParameters("@fantasy_name_VC", registration.fantasy_name);
                DBModel.AddParameters("@size_VC", registration.size);
                DBModel.AddParameters("@opening", registration.opening);
                DBModel.AddParameters("@legal_nature", registration.legal_nature);
                DBModel.AddParameters("@social_capital", registration.social_capital);
                DBModel.AddParameters("@main_activity", registration.main_activity[0].code);
                DBModel.AddParameters("@main_acitivity_description", registration.main_activity[0].text);
                DBModel.AddParameters("@registration_number_IN", 0, ParameterDirection.InputOutput);

                DBModel.AddParameters("@street_VC", registration.street);
                DBModel.AddParameters("@addres_number_VC", registration.addres_number);
                DBModel.AddParameters("@complement_VC", registration.complement);
                DBModel.AddParameters("@city_VC", registration.city);
                DBModel.AddParameters("@neighborhood_VC", registration.neighborhood);
                DBModel.AddParameters("@state_VC", registration.state);
                DBModel.AddParameters("@zip_code_VC", registration.zip_code);
                DBModel.AddParameters("@email_VC", registration.email);
                DBModel.AddParameters("@phone_VC", registration.phone);
                DBModel.AddParameters("@situation_date_VC", registration.situation_date);
                DBModel.AddParameters("@registration_number_VC", registration.registration_number);
                DBModel.AddParameters("@last_update_VC", registration.last_update);
                DBModel.AddParameters("@status_VC", registration.status);
                DBModel.AddParameters("@efr_VC", registration.efr);
                DBModel.AddParameters("@situation_reason_VC", registration.situation_reason);
                DBModel.AddParameters("@special_situation_VC", registration.special_situation);
                DBModel.AddParameters("@special_situation_date_VC", registration.special_situation_date);
                DBModel.AddParameters("@social_capital", registration.social_capital);

                DBModel.Execute("usp_UpdateRegistrationNumberHeader");
                SqlParameter sqlParameter = new SqlParameter("@registration_number_IN", SqlDbType.Int);
                returnCode = Convert.ToInt32(DBModel.Output["@registration_number_IN"]);
                return returnCode;

            }
            catch (Exception exc)
            { 
                MessageBox.Show($"{exc.Message}", "Failed to execute procedure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
		}

        public int UpdateRegistrationNumberQSA(Qsa qsa, int headerCode)
        {
            try
            {
                int returnCode = 0;

                DBModel.Connect();
                DBModel.ClearParameters();

                DBModel.AddParameters("@name_VC", qsa.name);
                DBModel.AddParameters("legal_representative_name_VC", qsa.legal_representative_name);
                DBModel.AddParameters("legal_representative_role_VC", qsa.legal_representative_role);
                DBModel.AddParameters("country_origin_VC", qsa.country_origin);

                DBModel.Execute("usp_UpdateRegistrationNumberQSA");

                SqlParameter sqlParameter = new SqlParameter();
                returnCode = Convert.ToInt32(sqlParameter.Value);
                return returnCode;
            }
            catch (Exception exc)
            {

                MessageBox.Show($"{exc.Message}", "Failed to execute procedure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 0;
            }
        }

        public int InsertInvalidRegistrationNumber(string invalidRegistrationNumber)
        {
            try
            {
                DBModel.Connect();
                DBModel.ClearParameters();

                DBModel.AddParameters("@invalid_registration_number_VC", invalidRegistrationNumber);
                DBModel.Execute("usp_InsertInvalidRegistrationNumber");
            }
            catch (Exception exc)
            {
                MessageBox.Show($"{exc.Message}", "Failed to execute procedure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return 0;
        }
    }
}
