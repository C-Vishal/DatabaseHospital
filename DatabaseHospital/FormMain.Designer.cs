namespace DatabaseHospital
{
    partial class fMain
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnLists = new System.Windows.Forms.Button();
            this.btnTickets = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnStat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConnect.Location = new System.Drawing.Point(46, 25);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(200, 40);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Установить соединение";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(46, 71);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(200, 40);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Разорвать соединение";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnLists
            // 
            this.btnLists.Enabled = false;
            this.btnLists.Location = new System.Drawing.Point(46, 157);
            this.btnLists.Name = "btnLists";
            this.btnLists.Size = new System.Drawing.Size(200, 40);
            this.btnLists.TabIndex = 2;
            this.btnLists.Text = "Изменение справочников";
            this.btnLists.UseVisualStyleBackColor = true;
            this.btnLists.Click += new System.EventHandler(this.btnLists_Click);
            // 
            // btnTickets
            // 
            this.btnTickets.Enabled = false;
            this.btnTickets.Location = new System.Drawing.Point(46, 203);
            this.btnTickets.Name = "btnTickets";
            this.btnTickets.Size = new System.Drawing.Size(200, 40);
            this.btnTickets.TabIndex = 3;
            this.btnTickets.Text = "Выдача номерков";
            this.btnTickets.UseVisualStyleBackColor = true;
            this.btnTickets.Click += new System.EventHandler(this.btnTickets_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Enabled = false;
            this.btnHistory.Location = new System.Drawing.Point(46, 249);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(200, 40);
            this.btnHistory.TabIndex = 4;
            this.btnHistory.Text = "Истории болезни";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(46, 387);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(200, 40);
            this.btnExit.TabIndex = 50;
            this.btnExit.Text = "Завершение работы";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(46, 341);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(90, 40);
            this.btnOptions.TabIndex = 51;
            this.btnOptions.Text = "Настройки";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnStat
            // 
            this.btnStat.Enabled = false;
            this.btnStat.Location = new System.Drawing.Point(156, 341);
            this.btnStat.Name = "btnStat";
            this.btnStat.Size = new System.Drawing.Size(90, 40);
            this.btnStat.TabIndex = 52;
            this.btnStat.Text = "Статистика";
            this.btnStat.UseVisualStyleBackColor = true;
            this.btnStat.Click += new System.EventHandler(this.btnStat_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(284, 439);
            this.Controls.Add(this.btnStat);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnTickets);
            this.Controls.Add(this.btnLists);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "База данных \"Поликлиника\"";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnLists;
        private System.Windows.Forms.Button btnTickets;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.Button btnStat;
    }
}

