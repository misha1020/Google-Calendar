namespace GoogleAPI
{
    partial class FormCalendar
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btAuth = new System.Windows.Forms.Button();
            this.btRelog = new System.Windows.Forms.Button();
            this.lvEvents = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFinishTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btDelete = new System.Windows.Forms.Button();
            this.btInsert = new System.Windows.Forms.Button();
            this.btUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAuth
            // 
            this.btAuth.Location = new System.Drawing.Point(518, 68);
            this.btAuth.Name = "btAuth";
            this.btAuth.Size = new System.Drawing.Size(150, 50);
            this.btAuth.TabIndex = 1;
            this.btAuth.Text = "Log In / Load events";
            this.btAuth.UseVisualStyleBackColor = true;
            this.btAuth.Click += new System.EventHandler(this.btAuth_Click);
            // 
            // btRelog
            // 
            this.btRelog.Location = new System.Drawing.Point(517, 12);
            this.btRelog.Name = "btRelog";
            this.btRelog.Size = new System.Drawing.Size(150, 50);
            this.btRelog.TabIndex = 2;
            this.btRelog.Text = "Relogin";
            this.btRelog.UseVisualStyleBackColor = true;
            this.btRelog.Click += new System.EventHandler(this.btRelogin_Click);
            // 
            // lvEvents
            // 
            this.lvEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chLocation,
            this.chStartTime,
            this.chFinishTime});
            this.lvEvents.FullRowSelect = true;
            this.lvEvents.Location = new System.Drawing.Point(12, 12);
            this.lvEvents.MultiSelect = false;
            this.lvEvents.Name = "lvEvents";
            this.lvEvents.Size = new System.Drawing.Size(500, 400);
            this.lvEvents.TabIndex = 3;
            this.lvEvents.UseCompatibleStateImageBehavior = false;
            this.lvEvents.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 45;
            // 
            // chLocation
            // 
            this.chLocation.Text = "Location";
            // 
            // chStartTime
            // 
            this.chStartTime.Text = "Start Time";
            this.chStartTime.Width = 62;
            // 
            // chFinishTime
            // 
            this.chFinishTime.Text = "Finish Time";
            this.chFinishTime.Width = 71;
            // 
            // btDelete
            // 
            this.btDelete.Location = new System.Drawing.Point(518, 362);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(150, 50);
            this.btDelete.TabIndex = 4;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btInsert
            // 
            this.btInsert.Location = new System.Drawing.Point(518, 250);
            this.btInsert.Name = "btInsert";
            this.btInsert.Size = new System.Drawing.Size(150, 50);
            this.btInsert.TabIndex = 5;
            this.btInsert.Text = "Insert";
            this.btInsert.UseVisualStyleBackColor = true;
            this.btInsert.Click += new System.EventHandler(this.btInsert_Click);
            // 
            // btUpdate
            // 
            this.btUpdate.Location = new System.Drawing.Point(518, 306);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(150, 50);
            this.btUpdate.TabIndex = 6;
            this.btUpdate.Text = "Update";
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // FormCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 434);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.btInsert);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.lvEvents);
            this.Controls.Add(this.btRelog);
            this.Controls.Add(this.btAuth);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormCalendar";
            this.Text = "Google Calendar";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btAuth;
        private System.Windows.Forms.Button btRelog;
        private System.Windows.Forms.ListView lvEvents;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chStartTime;
        private System.Windows.Forms.ColumnHeader chFinishTime;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btInsert;
        private System.Windows.Forms.Button btUpdate;
        private System.Windows.Forms.ColumnHeader chLocation;
    }
}

