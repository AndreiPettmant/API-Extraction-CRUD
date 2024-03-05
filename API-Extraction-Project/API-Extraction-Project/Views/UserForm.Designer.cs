namespace API_Extraction_Project
{
    partial class UserForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnStart = new Button();
            btnStop = new Button();
            lblProgress = new Label();
            txtStatus = new TextBox();
            txtStartTime = new TextBox();
            txtRemainingTime = new TextBox();
            txtUpdatedRegisters = new TextBox();
            txtRemainingRegisters = new TextBox();
            txtEndTime = new TextBox();
            lblStatus = new Label();
            txtUpdatedPercentage = new TextBox();
            txtRemainingPercentage = new TextBox();
            txtTotalRegisters = new TextBox();
            lblStarTime = new Label();
            lblEndTime = new Label();
            panel1 = new Panel();
            lblTotalRegisters = new Label();
            lblRemainingPercentage = new Label();
            lblUpdatedPercentage = new Label();
            lblRemainingRegisters = new Label();
            lblUpdatedRegisters = new Label();
            lblRemainingTime = new Label();
            tmrRemainingTimer = new System.Windows.Forms.Timer(components);
            tmrCounter = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(12, 12);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(199, 59);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(12, 77);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(199, 62);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProgress.Location = new Point(261, 164);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(75, 21);
            lblProgress.TabIndex = 2;
            lblProgress.Text = "Progress";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(3, 20);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(152, 23);
            txtStatus.TabIndex = 3;
            // 
            // txtStartTime
            // 
            txtStartTime.Location = new Point(3, 60);
            txtStartTime.Name = "txtStartTime";
            txtStartTime.ReadOnly = true;
            txtStartTime.Size = new Size(152, 23);
            txtStartTime.TabIndex = 4;
            // 
            // txtRemainingTime
            // 
            txtRemainingTime.Location = new Point(207, 20);
            txtRemainingTime.Name = "txtRemainingTime";
            txtRemainingTime.ReadOnly = true;
            txtRemainingTime.Size = new Size(152, 23);
            txtRemainingTime.TabIndex = 7;
            // 
            // txtUpdatedRegisters
            // 
            txtUpdatedRegisters.Location = new Point(207, 60);
            txtUpdatedRegisters.Name = "txtUpdatedRegisters";
            txtUpdatedRegisters.ReadOnly = true;
            txtUpdatedRegisters.Size = new Size(152, 23);
            txtUpdatedRegisters.TabIndex = 8;
            // 
            // txtRemainingRegisters
            // 
            txtRemainingRegisters.Location = new Point(207, 101);
            txtRemainingRegisters.Name = "txtRemainingRegisters";
            txtRemainingRegisters.ReadOnly = true;
            txtRemainingRegisters.Size = new Size(152, 23);
            txtRemainingRegisters.TabIndex = 9;
            // 
            // txtEndTime
            // 
            txtEndTime.Location = new Point(3, 101);
            txtEndTime.Name = "txtEndTime";
            txtEndTime.ReadOnly = true;
            txtEndTime.Size = new Size(152, 23);
            txtEndTime.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(3, 3);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status:";
            // 
            // txtUpdatedPercentage
            // 
            txtUpdatedPercentage.Location = new Point(401, 20);
            txtUpdatedPercentage.Name = "txtUpdatedPercentage";
            txtUpdatedPercentage.ReadOnly = true;
            txtUpdatedPercentage.Size = new Size(152, 23);
            txtUpdatedPercentage.TabIndex = 11;
            // 
            // txtRemainingPercentage
            // 
            txtRemainingPercentage.Location = new Point(401, 60);
            txtRemainingPercentage.Name = "txtRemainingPercentage";
            txtRemainingPercentage.ReadOnly = true;
            txtRemainingPercentage.Size = new Size(152, 23);
            txtRemainingPercentage.TabIndex = 12;
            // 
            // txtTotalRegisters
            // 
            txtTotalRegisters.Location = new Point(401, 101);
            txtTotalRegisters.Name = "txtTotalRegisters";
            txtTotalRegisters.ReadOnly = true;
            txtTotalRegisters.Size = new Size(152, 23);
            txtTotalRegisters.TabIndex = 13;
            // 
            // lblStarTime
            // 
            lblStarTime.AutoSize = true;
            lblStarTime.Location = new Point(3, 46);
            lblStarTime.Name = "lblStarTime";
            lblStarTime.Size = new Size(61, 15);
            lblStarTime.TabIndex = 14;
            lblStarTime.Text = "Start time:";
            // 
            // lblEndTime
            // 
            lblEndTime.AutoSize = true;
            lblEndTime.Location = new Point(3, 86);
            lblEndTime.Name = "lblEndTime";
            lblEndTime.Size = new Size(59, 15);
            lblEndTime.TabIndex = 15;
            lblEndTime.Text = "End Time:";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblTotalRegisters);
            panel1.Controls.Add(lblRemainingPercentage);
            panel1.Controls.Add(lblUpdatedPercentage);
            panel1.Controls.Add(lblRemainingRegisters);
            panel1.Controls.Add(lblUpdatedRegisters);
            panel1.Controls.Add(lblRemainingTime);
            panel1.Controls.Add(lblEndTime);
            panel1.Controls.Add(lblStarTime);
            panel1.Controls.Add(txtTotalRegisters);
            panel1.Controls.Add(txtRemainingPercentage);
            panel1.Controls.Add(txtUpdatedPercentage);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(txtEndTime);
            panel1.Controls.Add(txtRemainingRegisters);
            panel1.Controls.Add(txtUpdatedRegisters);
            panel1.Controls.Add(txtRemainingTime);
            panel1.Controls.Add(txtStartTime);
            panel1.Controls.Add(txtStatus);
            panel1.Location = new Point(12, 201);
            panel1.Name = "panel1";
            panel1.Size = new Size(558, 137);
            panel1.TabIndex = 6;
            // 
            // lblTotalRegisters
            // 
            lblTotalRegisters.AutoSize = true;
            lblTotalRegisters.Location = new Point(401, 86);
            lblTotalRegisters.Name = "lblTotalRegisters";
            lblTotalRegisters.Size = new Size(85, 15);
            lblTotalRegisters.TabIndex = 21;
            lblTotalRegisters.Text = "Total Registers:";
            // 
            // lblRemainingPercentage
            // 
            lblRemainingPercentage.AutoSize = true;
            lblRemainingPercentage.Location = new Point(401, 46);
            lblRemainingPercentage.Name = "lblRemainingPercentage";
            lblRemainingPercentage.Size = new Size(129, 15);
            lblRemainingPercentage.TabIndex = 20;
            lblRemainingPercentage.Text = "Remaining Percentage:";
            // 
            // lblUpdatedPercentage
            // 
            lblUpdatedPercentage.AutoSize = true;
            lblUpdatedPercentage.Location = new Point(401, 3);
            lblUpdatedPercentage.Name = "lblUpdatedPercentage";
            lblUpdatedPercentage.Size = new Size(117, 15);
            lblUpdatedPercentage.TabIndex = 19;
            lblUpdatedPercentage.Text = "Updated Percentage:";
            // 
            // lblRemainingRegisters
            // 
            lblRemainingRegisters.AutoSize = true;
            lblRemainingRegisters.Location = new Point(207, 86);
            lblRemainingRegisters.Name = "lblRemainingRegisters";
            lblRemainingRegisters.Size = new Size(117, 15);
            lblRemainingRegisters.TabIndex = 18;
            lblRemainingRegisters.Text = "Remaining Registers:";
            // 
            // lblUpdatedRegisters
            // 
            lblUpdatedRegisters.AutoSize = true;
            lblUpdatedRegisters.Location = new Point(207, 46);
            lblUpdatedRegisters.Name = "lblUpdatedRegisters";
            lblUpdatedRegisters.Size = new Size(105, 15);
            lblUpdatedRegisters.TabIndex = 17;
            lblUpdatedRegisters.Text = "Updated Registers:";
            // 
            // lblRemainingTime
            // 
            lblRemainingTime.AutoSize = true;
            lblRemainingTime.Location = new Point(207, 3);
            lblRemainingTime.Name = "lblRemainingTime";
            lblRemainingTime.Size = new Size(96, 15);
            lblRemainingTime.TabIndex = 16;
            lblRemainingTime.Text = "Remaining Time:";
            // 
            // tmrCounter
            // 
            tmrCounter.Tick += tmrCounter_Tick;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 350);
            Controls.Add(lblProgress);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(panel1);
            Name = "UserForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UserForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private Label lblProgress;
        private TextBox txtStatus;
        private TextBox txtStartTime;
        private TextBox txtRemainingTime;
        private TextBox txtUpdatedRegisters;
        private TextBox txtRemainingRegisters;
        private TextBox txtEndTime;
        private Label lblStatus;
        private TextBox txtUpdatedPercentage;
        private TextBox txtRemainingPercentage;
        private TextBox txtTotalRegisters;
        private Label lblStarTime;
        private Label lblEndTime;
        private Panel panel1;
        private Label lblUpdatedRegisters;
        private Label lblRemainingTime;
        private Label lblRemainingRegisters;
        private Label lblUpdatedPercentage;
        private Label lblRemainingPercentage;
        private Label lblTotalRegisters;
        private System.Windows.Forms.Timer tmrRemainingTimer;
        private System.Windows.Forms.Timer tmrCounter;
    }
}