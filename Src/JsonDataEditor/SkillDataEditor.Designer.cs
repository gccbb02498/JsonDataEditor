using System.IO;

namespace JsonDataEditor {
    partial class  SkillDataEditor{
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent() {
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.SelectOpition = new System.Windows.Forms.ComboBox();
			this.Openfilebtn = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.editBox = new System.Windows.Forms.TextBox();
			this.skillDataView = new System.Windows.Forms.DataGridView();
			this.Save = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.Dataviewbtn = new System.Windows.Forms.Button();
			this.Createbtn = new System.Windows.Forms.Button();
			this.AddDatabtn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.skillDataView)).BeginInit();
			this.SuspendLayout();
			// 
			// SelectOpition
			// 
			this.SelectOpition.FormattingEnabled = true;
			this.SelectOpition.Location = new System.Drawing.Point(641, 12);
			this.SelectOpition.Name = "SelectOpition";
			this.SelectOpition.Size = new System.Drawing.Size(121, 20);
			this.SelectOpition.TabIndex = 0;
			this.SelectOpition.Visible = false;
			this.SelectOpition.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// Openfilebtn
			// 
			this.Openfilebtn.Location = new System.Drawing.Point(86, 348);
			this.Openfilebtn.Name = "Openfilebtn";
			this.Openfilebtn.Size = new System.Drawing.Size(75, 23);
			this.Openfilebtn.TabIndex = 1;
			this.Openfilebtn.Text = "Load";
			this.Openfilebtn.UseVisualStyleBackColor = true;
			this.Openfilebtn.Click += new System.EventHandler(this.Openfilebtn_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "json|*.json|所有檔案|*.*";
			this.openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
			this.openFileDialog.RestoreDirectory = true;
			// 
			// editBox
			// 
			this.editBox.Location = new System.Drawing.Point(419, 273);
			this.editBox.Multiline = true;
			this.editBox.Name = "editBox";
			this.editBox.Size = new System.Drawing.Size(343, 149);
			this.editBox.TabIndex = 2;
			// 
			// skillDataView
			// 
			this.skillDataView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
			this.skillDataView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.skillDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.skillDataView.DefaultCellStyle = dataGridViewCellStyle2;
			this.skillDataView.Location = new System.Drawing.Point(419, 38);
			this.skillDataView.Name = "skillDataView";
			this.skillDataView.RowTemplate.Height = 24;
			this.skillDataView.Size = new System.Drawing.Size(343, 214);
			this.skillDataView.TabIndex = 3;
			this.skillDataView.Visible = false;
			// 
			// Save
			// 
			this.Save.Location = new System.Drawing.Point(183, 348);
			this.Save.Name = "Save";
			this.Save.Size = new System.Drawing.Size(75, 23);
			this.Save.TabIndex = 4;
			this.Save.Text = "Save";
			this.Save.UseVisualStyleBackColor = true;
			this.Save.Visible = false;
			this.Save.Click += new System.EventHandler(this.Save_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "json|*.json|所有檔案|*.*";
			this.saveFileDialog.InitialDirectory = "C:\\Users\\andrew.chi\\source\\repos\\JsonDataEditor";
			// 
			// Dataviewbtn
			// 
			this.Dataviewbtn.Enabled = false;
			this.Dataviewbtn.Location = new System.Drawing.Point(288, 348);
			this.Dataviewbtn.Name = "Dataviewbtn";
			this.Dataviewbtn.Size = new System.Drawing.Size(75, 23);
			this.Dataviewbtn.TabIndex = 5;
			this.Dataviewbtn.Text = "shonoff dataview";
			this.Dataviewbtn.UseVisualStyleBackColor = true;
			this.Dataviewbtn.Click += new System.EventHandler(this.ShonDataview_Click);
			// 
			// Createbtn
			// 
			this.Createbtn.Location = new System.Drawing.Point(86, 399);
			this.Createbtn.Name = "Createbtn";
			this.Createbtn.Size = new System.Drawing.Size(75, 23);
			this.Createbtn.TabIndex = 6;
			this.Createbtn.Text = "Creat";
			this.Createbtn.UseVisualStyleBackColor = true;
			this.Createbtn.Click += new System.EventHandler(this.Create_Click);
			// 
			// AddDatabtn
			// 
			this.AddDatabtn.Location = new System.Drawing.Point(183, 399);
			this.AddDatabtn.Name = "AddDatabtn";
			this.AddDatabtn.Size = new System.Drawing.Size(75, 23);
			this.AddDatabtn.TabIndex = 7;
			this.AddDatabtn.Text = "Adddata";
			this.AddDatabtn.UseVisualStyleBackColor = true;
			this.AddDatabtn.Visible = false;
			this.AddDatabtn.Click += new System.EventHandler(this.AddData_Click);
			// 
			// SkillDataEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.AddDatabtn);
			this.Controls.Add(this.Createbtn);
			this.Controls.Add(this.Dataviewbtn);
			this.Controls.Add(this.Save);
			this.Controls.Add(this.skillDataView);
			this.Controls.Add(this.editBox);
			this.Controls.Add(this.Openfilebtn);
			this.Controls.Add(this.SelectOpition);
			this.Name = "SkillDataEditor";
			this.Text = "SkillDataEditor";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SkillDataEditor_FormClosed);
			this.Load += new System.EventHandler(this.SkillDataEditor_Load);
			((System.ComponentModel.ISupportInitialize)(this.skillDataView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectOpition;
        private System.Windows.Forms.Button Openfilebtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox editBox;
        private System.Windows.Forms.DataGridView skillDataView;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button Dataviewbtn;
        private System.Windows.Forms.Button Createbtn;
        private System.Windows.Forms.Button AddDatabtn;
    }
}

