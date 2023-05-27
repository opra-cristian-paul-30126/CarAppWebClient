namespace CarAppWebClient
{
    partial class AdminToolsForm
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonBack = new System.Windows.Forms.Button();
            this.dataGridViewUsers = new System.Windows.Forms.DataGridView();
            this.buttonBan = new System.Windows.Forms.Button();
            this.buttonUnBan = new System.Windows.Forms.Button();
            this.checkBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(684, 39);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(65, 25);
            this.buttonSearch.TabIndex = 2;
            this.buttonSearch.Text = "Refresh";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(686, 390);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 23);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Inapoi";
            this.buttonBack.UseVisualStyleBackColor = true;
            // 
            // dataGridViewUsers
            // 
            this.dataGridViewUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsers.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewUsers.Name = "dataGridViewUsers";
            this.dataGridViewUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUsers.Size = new System.Drawing.Size(628, 401);
            this.dataGridViewUsers.TabIndex = 4;
            this.dataGridViewUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsers_CellClick);
            // 
            // buttonBan
            // 
            this.buttonBan.Location = new System.Drawing.Point(684, 166);
            this.buttonBan.Name = "buttonBan";
            this.buttonBan.Size = new System.Drawing.Size(75, 73);
            this.buttonBan.TabIndex = 6;
            this.buttonBan.Text = "BAN";
            this.buttonBan.UseVisualStyleBackColor = true;
            this.buttonBan.Click += new System.EventHandler(this.buttonBan_Click);
            // 
            // buttonUnBan
            // 
            this.buttonUnBan.Location = new System.Drawing.Point(684, 245);
            this.buttonUnBan.Name = "buttonUnBan";
            this.buttonUnBan.Size = new System.Drawing.Size(75, 73);
            this.buttonUnBan.TabIndex = 7;
            this.buttonUnBan.Text = "UNBAN";
            this.buttonUnBan.UseVisualStyleBackColor = true;
            this.buttonUnBan.Click += new System.EventHandler(this.buttonUnBan_Click);
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(684, 70);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(69, 17);
            this.checkBox.TabIndex = 8;
            this.checkBox.Text = "Banned?";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // AdminToolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 425);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.buttonUnBan);
            this.Controls.Add(this.buttonBan);
            this.Controls.Add(this.dataGridViewUsers);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonSearch);
            this.Name = "AdminToolsForm";
            this.Text = "AdminTools";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridView dataGridViewUsers;
        private System.Windows.Forms.Button buttonBan;
        private System.Windows.Forms.Button buttonUnBan;
        private System.Windows.Forms.CheckBox checkBox;
    }
}