using API_Extraction_Project.Controller;

namespace API_Extraction_Project
{
    public partial class UserForm : Form
    {
        ProgramEstatitics programEstatitics = new ProgramEstatitics();
        public static int interval = Convert.ToInt32(TimeSpan.FromSeconds(65).TotalMilliseconds);
        private bool executing = false;
        public TextBox TxTRemainingRegisters => txtRemainingRegisters;
        public TextBox TxtUpdatedRegisters => txtUpdatedRegisters;
        public TextBox TxtTotalRegisters => txtTotalRegisters;
        public TextBox TxtUpdatedPercentage => txtUpdatedPercentage;
        public TextBox TxtUpdatedRemainingPercentage => txtRemainingPercentage;
        public TextBox TxtStartTime => txtStartTime;
        public TextBox TxtEndTime => txtEndTime;
        public TextBox TxtRemainingTime => txtRemainingTime;

        public System.Windows.Forms.Timer TmrRemainingTimer => tmrRemainingTimer;

        public UserForm()
        {
            InitializeComponent();

            ChangeStatus("Stopped", Color.PaleVioletRed);
            btnStop.Enabled = false;

            programEstatitics.UpdateEstatitcs(this);
            programEstatitics.UpdateFinalTime(this, false);
        }

        private void ChangeStatus(string status, Color color)
        {
            txtStatus.Text = status;
            txtStatus.BackColor = color;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ChangeStatus("Updating", Color.PaleGreen);

            tmrCounter.Interval = interval;
            tmrCounter.Enabled = true;

            programEstatitics.UpdateFinalTime(this, true);
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            executing = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ChangeStatus("Stopped", Color.PaleVioletRed);
            tmrCounter.Stop();
            tmrRemainingTimer.Enabled = false;
            executing = false;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }

        private void tmrCounter_Tick(object sender, EventArgs e)
        {
            if (executing)
            {
                try
                {
                    tmrCounter.Enabled = true;
                    API.UpdateRegistrationNumber();
                    programEstatitics.UpdateEstatitcs(this);
                }
                catch (Exception exc)
                {
                    btnStop_Click(new object(), new MouseEventArgs(MouseButtons.Left, 1, 0, 0,0));
                    MessageBox.Show("Erro: " + exc.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
            }
        }
    }
}
