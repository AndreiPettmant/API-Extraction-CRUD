using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API_Extraction_Project.Controller
{
    public class API
    {
        public static int delay = 60000;

        public static void UpdateRegistrationNumber()
        {
            string regNumber = "";
            string json = "";
            int returnCode = 0;

            RegistrationNumber registrationNumber = new RegistrationNumber();
            DataSet dataSet = new DataSet();

            dataSet = registrationNumber.GetAllRegistrationsNumbers();

            foreach(DataRow dataRow in dataSet.Tables[0].Rows)
            {
                regNumber = dataRow["@registration_number_IN"].ToString();

                try
                {
                    json = JSONReader(regNumber);

                    var result = JsonConvert.DeserializeAnonymousType(json, new { status = "", message = "" });
                    if (result.message == "CNPJ Inválido")
                    {
                        registrationNumber.InsertInvalidRegistrationNumber(regNumber);
                    }
                    else
                    {
                        Registration company = JsonConvert.DeserializeObject<Registration>(json);
                        returnCode = registrationNumber.UpdateRegistrationNumberHeader(company);

                        foreach (var activity in company.secondary_activities ?? new List<SecondaryActivities>())
                        {
                            registrationNumber.UpdateSecondActivities(activity, returnCode, company.registration_number);
                        }

                        foreach (var associate in company.qsa ?? new List<Qsa>())
                        {
                            registrationNumber.UpdateRegistrationNumberQSA(associate, returnCode);
                        }
                    }
                }
                catch (Exception exc)
                {

                    MessageBox.Show($"{exc.Message}", "Failed to process Registratio Numbers", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        static string JSONReader(string cnpj)
        {

            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");

            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://receitaws.com.br/v1/cnpj/{cnpj}"),
                    Headers =
                {
                    { "Accept", "application/json" },
                },
                };

                using (var response = client.SendAsync(request).Result)
                {
                    response.EnsureSuccessStatusCode();
                    var body = response.Content.ReadAsStringAsync().Result;
                    return body;
                }
            }
        }
    }

    public class Registration
    {
        public string opening { get; set; }
        public string situation { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string fantasy_name { get; set; }
        public string size { get; set; }
        public string legal_nature { get; set; }
        public List<MainActivity> main_activity { get; set; }
        public List<SecondaryActivities> secondary_activities { get; set; }
        public List<Qsa> qsa { get; set; }
        public string street { get; set; }
        public string addres_number { get; set; }
        public string complement { get; set; }
        public string city { get; set; }
        public string neighborhood { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string situation_date { get; set; }
        public string registration_number { get; set; }
        public string last_update { get; set; }
        public string status { get; set; }
        public string efr { get; set; }
        public string situation_reason { get; set; }
        public string special_situation { get; set; }
        public string special_situation_date { get; set; }
        public string social_capital { get; set; }
        public Extra extra { get; set; }
        public Billing billing { get; set; }
    }

    public class Extra
    {

    }

    public class Billing
    {
        public bool free { get; set; }
        public bool database { get; set; }
    }

    public class MainActivity
    {
        public string code { get; set; }
        public string text { get; set; }
    }

    public class SecondaryActivities
    {
        public string code { get; set; }
        public string text { get; set; }
    }

    public class Qsa
    {
        public string name { get; set; }
        public string role { get; set; }
        public string legal_representative_name { get; set; }
        public string legal_representative_role { get; set; }
        public string country_origin { get; set; }
    }

}
