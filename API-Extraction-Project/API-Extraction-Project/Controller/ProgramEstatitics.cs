using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Windows.Forms.Timer;

namespace API_Extraction_Project.Controller
{
    public class ProgramEstatitics
    {
        RegistrationNumber registrationNumber = new RegistrationNumber();
        DataSet dataSet;
        static int step = 1;


        public void UpdateEstatitcs(UserForm userForm)
        {
            dataSet = registrationNumber.GetAllRegistrationsNumbers();

            if (dataSet.Tables[0].Rows.Count>1)
            {
                //GET INFO
                object notUpdatedRegistersQuantity = dataSet.Tables[0].Rows[0]["NotUpdatedQuantity"];
                object updatedRegistersQuantity = dataSet.Tables[0].Rows[0]["UpdatedQuantity"];
                object invalidRegistersQuantity = dataSet.Tables[0].Rows[0]["InvallidRegistersQuantity"];
                object totalRegistersQuantity = dataSet.Tables[0].Rows[0]["TotalRegisters"];
                object updatedPercentage = dataSet.Tables[0].Rows[0]["UpdatedPercentage"];
                object remainingPercentage = dataSet.Tables[0].Rows[0]["RemainingPercentage"];

                //CONVERT INFO
                int remainingRegisters = Convert.ToInt32(notUpdatedRegistersQuantity);
                int invalidRegisters = Convert.ToInt32(invalidRegistersQuantity);
                int updatedRegisters = Convert.ToInt32(updatedRegistersQuantity);

                //MATH
                int totalRemaining = remainingRegisters;
                int totalUpdated = updatedRegisters + invalidRegisters;

                //RENDER
                userForm.TxTRemainingRegisters.Text = totalRemaining.ToString(); 
                userForm.TxtUpdatedRegisters.Text = totalUpdated.ToString();
                userForm.TxtTotalRegisters.Text = totalRegistersQuantity.ToString();
                userForm.TxtUpdatedPercentage.Text = updatedPercentage.ToString();
                userForm.TxtUpdatedRemainingPercentage.Text = remainingPercentage.ToString();

                if (remainingRegisters <= 0)
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("All registers have been updated", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }
        public DateTime UpdateFinalTime(UserForm userForm, bool startTimer)
        {
            try
            {
                dataSet = registrationNumber.GetAllRegistrationsNumbers();

                object initalDateHour = dataSet.Tables[0].Rows[0]["InitialDateHour"];
                object finalDateHour = dataSet.Tables[0].Rows[0]["DataHoraFim_VC"];

                userForm.TxtStartTime.Text = initalDateHour.ToString();
                userForm.TxtEndTime.Text = finalDateHour.ToString();

                int totalRegisters = Convert.ToInt32(dataSet.Tables[0].Rows[0]["TotalRegisters"]);

                UpdateRemainingTime(Convert.ToDateTime(finalDateHour), userForm.TmrRemainingTimer, userForm.TxtRemainingTime, startTimer);

                return Convert.ToDateTime(finalDateHour);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return DateTime.MinValue;
            }
        }

        public Timer UpdateRemainingTime(DateTime finalHour, Timer tmrRemaining, TextBox txtRemainingTime, bool iniciarTimer)
        {
            TimeSpan diference = finalHour - DateTime.Now;

            txtRemainingTime.Text = diference.ToString(@"hh\:mm\:ss");
            tmrRemaining.Interval = step; // 1 segundo
            tmrRemaining.Tick += (sender, e) =>
            {
                diference = finalHour - DateTime.Now;
                txtRemainingTime.Text = diference.ToString(@"hh\:mm\:ss");
            };

            tmrRemaining.Enabled = iniciarTimer;

            return tmrRemaining;

        }
    }
}
