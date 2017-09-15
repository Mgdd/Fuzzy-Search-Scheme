namespace SimpleCryptographer
{
    partial class FrmDataOwner
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEncryptedFilename = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFileDecrypt = new System.Windows.Forms.Button();
            this.btnFileEncrypt = new System.Windows.Forms.Button();
            this.BoxFileCrypt = new System.Windows.Forms.GroupBox();
            this.txtAlteredFile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnFileSelect = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.rchText = new System.Windows.Forms.RichTextBox();
            this.rchKeyWords = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rchKeyRepat = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dgvColFileIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColFileContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvColDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblRowsCount = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.BoxFileCrypt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(45, 15);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(243, 20);
            this.txtFile.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "File : ";
            // 
            // lblEncryptedFilename
            // 
            this.lblEncryptedFilename.AutoSize = true;
            this.lblEncryptedFilename.Location = new System.Drawing.Point(8, 48);
            this.lblEncryptedFilename.Name = "lblEncryptedFilename";
            this.lblEncryptedFilename.Size = new System.Drawing.Size(0, 13);
            this.lblEncryptedFilename.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // btnFileDecrypt
            // 
            this.btnFileDecrypt.Location = new System.Drawing.Point(100, 74);
            this.btnFileDecrypt.Name = "btnFileDecrypt";
            this.btnFileDecrypt.Size = new System.Drawing.Size(89, 25);
            this.btnFileDecrypt.TabIndex = 11;
            this.btnFileDecrypt.Text = "File-Decryption";
            this.btnFileDecrypt.UseVisualStyleBackColor = true;
            this.btnFileDecrypt.Click += new System.EventHandler(this.btnFileDecrypt_Click);
            // 
            // btnFileEncrypt
            // 
            this.btnFileEncrypt.Location = new System.Drawing.Point(7, 74);
            this.btnFileEncrypt.Name = "btnFileEncrypt";
            this.btnFileEncrypt.Size = new System.Drawing.Size(89, 25);
            this.btnFileEncrypt.TabIndex = 12;
            this.btnFileEncrypt.Text = "File-Encryption";
            this.btnFileEncrypt.UseVisualStyleBackColor = true;
            this.btnFileEncrypt.Click += new System.EventHandler(this.btnFileEncrypt_Click);
            // 
            // BoxFileCrypt
            // 
            this.BoxFileCrypt.Controls.Add(this.txtAlteredFile);
            this.BoxFileCrypt.Controls.Add(this.label9);
            this.BoxFileCrypt.Controls.Add(this.txtFile);
            this.BoxFileCrypt.Controls.Add(this.label1);
            this.BoxFileCrypt.Controls.Add(this.btnFileSelect);
            this.BoxFileCrypt.Controls.Add(this.lblEncryptedFilename);
            this.BoxFileCrypt.Controls.Add(this.label3);
            this.BoxFileCrypt.Controls.Add(this.btnFileEncrypt);
            this.BoxFileCrypt.Controls.Add(this.btnFileDecrypt);
            this.BoxFileCrypt.Location = new System.Drawing.Point(12, 12);
            this.BoxFileCrypt.Name = "BoxFileCrypt";
            this.BoxFileCrypt.Size = new System.Drawing.Size(400, 105);
            this.BoxFileCrypt.TabIndex = 15;
            this.BoxFileCrypt.TabStop = false;
            this.BoxFileCrypt.Text = "Encryption and Decryption for files";
            // 
            // txtAlteredFile
            // 
            this.txtAlteredFile.Location = new System.Drawing.Point(141, 44);
            this.txtAlteredFile.Name = "txtAlteredFile";
            this.txtAlteredFile.ReadOnly = true;
            this.txtAlteredFile.Size = new System.Drawing.Size(243, 20);
            this.txtAlteredFile.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Altered File Name : ";
            // 
            // btnFileSelect
            // 
            this.btnFileSelect.Location = new System.Drawing.Point(294, 13);
            this.btnFileSelect.Name = "btnFileSelect";
            this.btnFileSelect.Size = new System.Drawing.Size(64, 23);
            this.btnFileSelect.TabIndex = 16;
            this.btnFileSelect.Text = "Files..";
            this.btnFileSelect.UseVisualStyleBackColor = true;
            this.btnFileSelect.Click += new System.EventHandler(this.btnFileSelect_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblProgress);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(418, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(399, 71);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Progress";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(8, 55);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(0, 13);
            this.lblProgress.TabIndex = 1;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(9, 22);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(375, 20);
            this.progressBar1.TabIndex = 0;
            // 
            // rchText
            // 
            this.rchText.Location = new System.Drawing.Point(12, 135);
            this.rchText.Name = "rchText";
            this.rchText.Size = new System.Drawing.Size(400, 175);
            this.rchText.TabIndex = 23;
            this.rchText.Text = "";
            // 
            // rchKeyWords
            // 
            this.rchKeyWords.Location = new System.Drawing.Point(12, 333);
            this.rchKeyWords.Name = "rchKeyWords";
            this.rchKeyWords.Size = new System.Drawing.Size(400, 106);
            this.rchKeyWords.TabIndex = 24;
            this.rchKeyWords.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "The text in File :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Key Words :";
            // 
            // rchKeyRepat
            // 
            this.rchKeyRepat.Location = new System.Drawing.Point(418, 135);
            this.rchKeyRepat.Name = "rchKeyRepat";
            this.rchKeyRepat.Size = new System.Drawing.Size(400, 304);
            this.rchKeyRepat.TabIndex = 28;
            this.rchKeyRepat.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(418, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 29;
            this.label5.Text = "Ranking :";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvColFileIndex,
            this.dgvColTitle,
            this.dgvColFileContent,
            this.dgvColDate,
            this.dgvColType,
            this.dgvColUrl,
            this.dgvColDelete});
            this.dgv.Location = new System.Drawing.Point(12, 458);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(805, 166);
            this.dgv.TabIndex = 30;
            this.dgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellClick);
            // 
            // dgvColFileIndex
            // 
            this.dgvColFileIndex.HeaderText = "FileIndex";
            this.dgvColFileIndex.Name = "dgvColFileIndex";
            this.dgvColFileIndex.ReadOnly = true;
            this.dgvColFileIndex.Visible = false;
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
            // dgvColDate
            // 
            this.dgvColDate.HeaderText = "Date";
            this.dgvColDate.Name = "dgvColDate";
            this.dgvColDate.ReadOnly = true;
            // 
            // dgvColType
            // 
            this.dgvColType.HeaderText = "Type";
            this.dgvColType.Name = "dgvColType";
            this.dgvColType.ReadOnly = true;
            // 
            // dgvColUrl
            // 
            this.dgvColUrl.HeaderText = "Url";
            this.dgvColUrl.Name = "dgvColUrl";
            this.dgvColUrl.ReadOnly = true;
            // 
            // dgvColDelete
            // 
            this.dgvColDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvColDelete.HeaderText = "-";
            this.dgvColDelete.Image = global::SimpleCryptographer.Properties.Resources.del;
            this.dgvColDelete.Name = "dgvColDelete";
            this.dgvColDelete.ReadOnly = true;
            this.dgvColDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvColDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvColDelete.Width = 35;
            // 
            // lblRowsCount
            // 
            this.lblRowsCount.AutoSize = true;
            this.lblRowsCount.Location = new System.Drawing.Point(754, 633);
            this.lblRowsCount.Name = "lblRowsCount";
            this.lblRowsCount.Size = new System.Drawing.Size(64, 13);
            this.lblRowsCount.TabIndex = 31;
            this.lblRowsCount.Text = "عدد السجلات";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 628);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(116, 23);
            this.btnSearch.TabIndex = 32;
            this.btnSearch.Text = "Go to search form";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmDataOwner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 655);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblRowsCount);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rchKeyRepat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rchKeyWords);
            this.Controls.Add(this.rchText);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BoxFileCrypt);
            this.Name = "FrmDataOwner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Architecture Arabic Fuzzy Search Scheme";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.BoxFileCrypt.ResumeLayout(false);
            this.BoxFileCrypt.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEncryptedFilename;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFileDecrypt;
        private System.Windows.Forms.Button btnFileEncrypt;
        private System.Windows.Forms.GroupBox BoxFileCrypt;
        private System.Windows.Forms.Button btnFileSelect;
        private System.Windows.Forms.TextBox txtAlteredFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.RichTextBox rchText;
        private System.Windows.Forms.RichTextBox rchKeyWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rchKeyRepat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblRowsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColFileIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColFileContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvColUrl;
        private System.Windows.Forms.DataGridViewImageColumn dgvColDelete;
        private System.Windows.Forms.Button btnSearch;
    }
}

