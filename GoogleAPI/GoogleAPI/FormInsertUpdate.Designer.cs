namespace GoogleAPI
{
    partial class FormInsertUpdate
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
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.tbSummary = new System.Windows.Forms.TextBox();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.tbLocation = new System.Windows.Forms.TextBox();
            this.gbDescription = new System.Windows.Forms.GroupBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.btInsertUpdate = new System.Windows.Forms.Button();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.gbStartTime = new System.Windows.Forms.GroupBox();
            this.dtpStartHour = new System.Windows.Forms.DateTimePicker();
            this.gbEndTime = new System.Windows.Forms.GroupBox();
            this.dtpEndHour = new System.Windows.Forms.DateTimePicker();
            this.gbSummary.SuspendLayout();
            this.gbLocation.SuspendLayout();
            this.gbDescription.SuspendLayout();
            this.gbStartTime.SuspendLayout();
            this.gbEndTime.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSummary
            // 
            this.gbSummary.Controls.Add(this.tbSummary);
            this.gbSummary.Location = new System.Drawing.Point(12, 12);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(200, 50);
            this.gbSummary.TabIndex = 0;
            this.gbSummary.TabStop = false;
            this.gbSummary.Text = "Summary";
            // 
            // tbSummary
            // 
            this.tbSummary.Location = new System.Drawing.Point(6, 19);
            this.tbSummary.Name = "tbSummary";
            this.tbSummary.Size = new System.Drawing.Size(188, 20);
            this.tbSummary.TabIndex = 0;
            this.tbSummary.TextChanged += new System.EventHandler(this.tbSummary_TextChanged);
            // 
            // gbLocation
            // 
            this.gbLocation.Controls.Add(this.tbLocation);
            this.gbLocation.Location = new System.Drawing.Point(12, 68);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(200, 50);
            this.gbLocation.TabIndex = 1;
            this.gbLocation.TabStop = false;
            this.gbLocation.Text = "Location";
            // 
            // tbLocation
            // 
            this.tbLocation.Location = new System.Drawing.Point(6, 19);
            this.tbLocation.Name = "tbLocation";
            this.tbLocation.Size = new System.Drawing.Size(188, 20);
            this.tbLocation.TabIndex = 1;
            // 
            // gbDescription
            // 
            this.gbDescription.Controls.Add(this.tbDescription);
            this.gbDescription.Location = new System.Drawing.Point(12, 124);
            this.gbDescription.Name = "gbDescription";
            this.gbDescription.Size = new System.Drawing.Size(200, 100);
            this.gbDescription.TabIndex = 2;
            this.gbDescription.TabStop = false;
            this.gbDescription.Text = "Description";
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(6, 19);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(188, 75);
            this.tbDescription.TabIndex = 2;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Location = new System.Drawing.Point(6, 19);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(188, 20);
            this.dtpStartTime.TabIndex = 3;
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartTime_ValueChanged);
            // 
            // btInsertUpdate
            // 
            this.btInsertUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btInsertUpdate.Location = new System.Drawing.Point(12, 402);
            this.btInsertUpdate.Name = "btInsertUpdate";
            this.btInsertUpdate.Size = new System.Drawing.Size(200, 20);
            this.btInsertUpdate.TabIndex = 7;
            this.btInsertUpdate.Text = "Insert / Update";
            this.btInsertUpdate.UseVisualStyleBackColor = true;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(6, 19);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(188, 20);
            this.dtpEndTime.TabIndex = 5;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpEndTime_ValueChanged);
            // 
            // gbStartTime
            // 
            this.gbStartTime.Controls.Add(this.dtpStartHour);
            this.gbStartTime.Controls.Add(this.dtpStartTime);
            this.gbStartTime.Location = new System.Drawing.Point(12, 230);
            this.gbStartTime.Name = "gbStartTime";
            this.gbStartTime.Size = new System.Drawing.Size(200, 80);
            this.gbStartTime.TabIndex = 3;
            this.gbStartTime.TabStop = false;
            this.gbStartTime.Text = "Start Time";
            // 
            // dtpStartHour
            // 
            this.dtpStartHour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpStartHour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartHour.Location = new System.Drawing.Point(6, 45);
            this.dtpStartHour.Name = "dtpStartHour";
            this.dtpStartHour.ShowUpDown = true;
            this.dtpStartHour.Size = new System.Drawing.Size(188, 20);
            this.dtpStartHour.TabIndex = 4;
            this.dtpStartHour.ValueChanged += new System.EventHandler(this.dtpStartHour_ValueChanged);
            // 
            // gbEndTime
            // 
            this.gbEndTime.Controls.Add(this.dtpEndHour);
            this.gbEndTime.Controls.Add(this.dtpEndTime);
            this.gbEndTime.Location = new System.Drawing.Point(12, 316);
            this.gbEndTime.Name = "gbEndTime";
            this.gbEndTime.Size = new System.Drawing.Size(200, 80);
            this.gbEndTime.TabIndex = 5;
            this.gbEndTime.TabStop = false;
            this.gbEndTime.Text = "End Time";
            // 
            // dtpEndHour
            // 
            this.dtpEndHour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEndHour.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndHour.Location = new System.Drawing.Point(6, 45);
            this.dtpEndHour.Name = "dtpEndHour";
            this.dtpEndHour.ShowUpDown = true;
            this.dtpEndHour.Size = new System.Drawing.Size(188, 20);
            this.dtpEndHour.TabIndex = 6;
            this.dtpEndHour.ValueChanged += new System.EventHandler(this.dtpEndHour_ValueChanged);
            // 
            // FormInsertUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 429);
            this.Controls.Add(this.gbEndTime);
            this.Controls.Add(this.gbStartTime);
            this.Controls.Add(this.btInsertUpdate);
            this.Controls.Add(this.gbDescription);
            this.Controls.Add(this.gbLocation);
            this.Controls.Add(this.gbSummary);
            this.Name = "FormInsertUpdate";
            this.Text = "FormInsertUpdate";
            this.gbSummary.ResumeLayout(false);
            this.gbSummary.PerformLayout();
            this.gbLocation.ResumeLayout(false);
            this.gbLocation.PerformLayout();
            this.gbDescription.ResumeLayout(false);
            this.gbDescription.PerformLayout();
            this.gbStartTime.ResumeLayout(false);
            this.gbEndTime.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.GroupBox gbLocation;
        private System.Windows.Forms.GroupBox gbDescription;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Button btInsertUpdate;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.GroupBox gbStartTime;
        private System.Windows.Forms.GroupBox gbEndTime;
        private System.Windows.Forms.TextBox tbSummary;
        private System.Windows.Forms.TextBox tbLocation;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.DateTimePicker dtpStartHour;
        private System.Windows.Forms.DateTimePicker dtpEndHour;
    }
}