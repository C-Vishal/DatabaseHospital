namespace DatabaseHospital
{
    partial class fStat
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
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lCountDoctors = new System.Windows.Forms.Label();
            this.lCountPatients = new System.Windows.Forms.Label();
            this.lCountAddr = new System.Windows.Forms.Label();
            this.lCountHistory = new System.Windows.Forms.Label();
            this.lfirstRec = new System.Windows.Forms.Label();
            this.lLastRec = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(170, 232);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Общее количество врачей:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Общее количество пациентов:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(23, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(276, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "Количество обслуживаемых адресов:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(23, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(278, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Общее количество записей в истории:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(23, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Дата первой записи:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(23, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "Дата последней записи:";
            // 
            // lCountDoctors
            // 
            this.lCountDoctors.AutoSize = true;
            this.lCountDoctors.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCountDoctors.Location = new System.Drawing.Point(349, 27);
            this.lCountDoctors.Name = "lCountDoctors";
            this.lCountDoctors.Size = new System.Drawing.Size(17, 18);
            this.lCountDoctors.TabIndex = 7;
            this.lCountDoctors.Text = "0";
            // 
            // lCountPatients
            // 
            this.lCountPatients.AutoSize = true;
            this.lCountPatients.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCountPatients.Location = new System.Drawing.Point(349, 59);
            this.lCountPatients.Name = "lCountPatients";
            this.lCountPatients.Size = new System.Drawing.Size(17, 18);
            this.lCountPatients.TabIndex = 8;
            this.lCountPatients.Text = "0";
            // 
            // lCountAddr
            // 
            this.lCountAddr.AutoSize = true;
            this.lCountAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCountAddr.Location = new System.Drawing.Point(349, 93);
            this.lCountAddr.Name = "lCountAddr";
            this.lCountAddr.Size = new System.Drawing.Size(17, 18);
            this.lCountAddr.TabIndex = 9;
            this.lCountAddr.Text = "0";
            // 
            // lCountHistory
            // 
            this.lCountHistory.AutoSize = true;
            this.lCountHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lCountHistory.Location = new System.Drawing.Point(349, 128);
            this.lCountHistory.Name = "lCountHistory";
            this.lCountHistory.Size = new System.Drawing.Size(17, 18);
            this.lCountHistory.TabIndex = 10;
            this.lCountHistory.Text = "0";
            // 
            // lfirstRec
            // 
            this.lfirstRec.AutoSize = true;
            this.lfirstRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lfirstRec.Location = new System.Drawing.Point(349, 163);
            this.lfirstRec.Name = "lfirstRec";
            this.lfirstRec.Size = new System.Drawing.Size(17, 18);
            this.lfirstRec.TabIndex = 11;
            this.lfirstRec.Text = "0";
            // 
            // lLastRec
            // 
            this.lLastRec.AutoSize = true;
            this.lLastRec.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lLastRec.Location = new System.Drawing.Point(349, 196);
            this.lLastRec.Name = "lLastRec";
            this.lLastRec.Size = new System.Drawing.Size(17, 18);
            this.lLastRec.TabIndex = 12;
            this.lLastRec.Text = "0";
            // 
            // fStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(456, 267);
            this.ControlBox = false;
            this.Controls.Add(this.lLastRec);
            this.Controls.Add(this.lfirstRec);
            this.Controls.Add(this.lCountHistory);
            this.Controls.Add(this.lCountAddr);
            this.Controls.Add(this.lCountPatients);
            this.Controls.Add(this.lCountDoctors);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fStat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Статистика";
            this.Shown += new System.EventHandler(this.fStat_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lCountDoctors;
        private System.Windows.Forms.Label lCountPatients;
        private System.Windows.Forms.Label lCountAddr;
        private System.Windows.Forms.Label lCountHistory;
        private System.Windows.Forms.Label lfirstRec;
        private System.Windows.Forms.Label lLastRec;
    }
}