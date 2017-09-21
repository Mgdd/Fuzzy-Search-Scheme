namespace SimpleCryptographer
{
    partial class FrmDataUser
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
            this.lblRowsCount = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dgvColTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColFileContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColKeyWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColFuzzyPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRowsCount
            // 
            this.lblRowsCount.AutoSize = true;
            this.lblRowsCount.Location = new System.Drawing.Point(729, 464);
            this.lblRowsCount.Name = "lblRowsCount";
            this.lblRowsCount.Size = new System.Drawing.Size(73, 13);
            this.lblRowsCount.TabIndex = 33;
            this.lblRowsCount.Text = "No of rows : 0";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColTitle,
            this.dgvColFileContent,
            this.dgvColKeyWord,
            this.dgvColRank,
            this.dgvColFuzzyPercent});
            this.dgv.Location = new System.Drawing.Point(3, 65);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(805, 393);
            this.dgv.TabIndex = 32;
            // 
            // dgvColTitle
            // 
            this.dgvColTitle.HeaderText = "Title";
            this.dgvColTitle.Name = "dgvColTitle";
            this.dgvColTitle.ReadOnly = true;
            // 
            // dgvColFileContent
            // 
            this.dgvColFileContent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvColFileContent.HeaderText = "FileContent";
            this.dgvColFileContent.Name = "dgvColFileContent";
            this.dgvColFileContent.ReadOnly = true;
            // 
            // dgvColKeyWord
            // 
            this.dgvColKeyWord.HeaderText = "KeyWord";
            this.dgvColKeyWord.Name = "dgvColKeyWord";
            this.dgvColKeyWord.ReadOnly = true;
            // 
            // dgvColRank
            // 
            this.dgvColRank.HeaderText = "Rank";
            this.dgvColRank.Name = "dgvColRank";
            this.dgvColRank.ReadOnly = true;
            // 
            // dgvColFuzzyPercent
            // 
            this.dgvColFuzzyPercent.HeaderText = "FuzzyPercent";
            this.dgvColFuzzyPercent.Name = "dgvColFuzzyPercent";
            this.dgvColFuzzyPercent.ReadOnly = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(216, 23);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(358, 20);
            this.txtSearch.TabIndex = 34;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(3, 460);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 23);
            this.btnLogOut.TabIndex = 36;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(125, 20);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 37;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmDataUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 486);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblRowsCount);
            this.Controls.Add(this.dgv);
            this.Name = "FrmDataUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DataUser";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRowsCount;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColFileContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColKeyWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColRank;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColFuzzyPercent;
    }
}