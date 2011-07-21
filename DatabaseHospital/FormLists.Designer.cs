namespace DatabaseHospital
{
    partial class fLists
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbTablePicker = new System.Windows.Forms.ComboBox();
            this.panelDoc = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDocAddresses = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panelButtons.SuspendLayout();
            this.panelDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Top;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.Size = new System.Drawing.Size(642, 318);
            this.DGV.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelButtons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelButtons.Controls.Add(this.btnSave);
            this.panelButtons.Controls.Add(this.btnRefresh);
            this.panelButtons.Controls.Add(this.cbTablePicker);
            this.panelButtons.Location = new System.Drawing.Point(6, 335);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(350, 32);
            this.panelButtons.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(267, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(186, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbTablePicker
            // 
            this.cbTablePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTablePicker.FormattingEnabled = true;
            this.cbTablePicker.Items.AddRange(new object[] {
            "Врачи",
            "Адреса",
            "Специализации",
            "Улицы",
            "Пациенты"});
            this.cbTablePicker.Location = new System.Drawing.Point(5, 5);
            this.cbTablePicker.Name = "cbTablePicker";
            this.cbTablePicker.Size = new System.Drawing.Size(174, 21);
            this.cbTablePicker.TabIndex = 0;
            this.cbTablePicker.SelectedIndexChanged += new System.EventHandler(this.cbTablePicker_SelectedIndexChanged);
            // 
            // panelDoc
            // 
            this.panelDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDoc.Controls.Add(this.button2);
            this.panelDoc.Controls.Add(this.btnDocAddresses);
            this.panelDoc.Location = new System.Drawing.Point(415, 335);
            this.panelDoc.Name = "panelDoc";
            this.panelDoc.Size = new System.Drawing.Size(215, 32);
            this.panelDoc.TabIndex = 2;
            this.panelDoc.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Расписание";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDocAddresses
            // 
            this.btnDocAddresses.Location = new System.Drawing.Point(3, 3);
            this.btnDocAddresses.Name = "btnDocAddresses";
            this.btnDocAddresses.Size = new System.Drawing.Size(100, 23);
            this.btnDocAddresses.TabIndex = 0;
            this.btnDocAddresses.Text = "Адреса";
            this.btnDocAddresses.UseVisualStyleBackColor = true;
            this.btnDocAddresses.Click += new System.EventHandler(this.btnDocAddresses_Click);
            // 
            // fLists
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 379);
            this.Controls.Add(this.panelDoc);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.DGV);
            this.Name = "fLists";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Изменение справочников базы данных";
            this.Shown += new System.EventHandler(this.fLists_Shown);
            this.Resize += new System.EventHandler(this.fLists_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panelButtons.ResumeLayout(false);
            this.panelDoc.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbTablePicker;
        private System.Windows.Forms.Panel panelDoc;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnDocAddresses;
    }
}