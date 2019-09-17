namespace JsonDataEditor {
    partial class MainGui {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.SkillDataBtn = new System.Windows.Forms.Button();
            this.MobDataBtn = new System.Windows.Forms.Button();
            this.ItemDataBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SkillDataBtn
            // 
            this.SkillDataBtn.Location = new System.Drawing.Point(467, 112);
            this.SkillDataBtn.Name = "SkillDataBtn";
            this.SkillDataBtn.Size = new System.Drawing.Size(75, 23);
            this.SkillDataBtn.TabIndex = 0;
            this.SkillDataBtn.Text = "SkillDataBtn";
            this.SkillDataBtn.UseVisualStyleBackColor = true;
            this.SkillDataBtn.Click += new System.EventHandler(this.SkillDataBtn_Click);
            // 
            // MobDataBtn
            // 
            this.MobDataBtn.Location = new System.Drawing.Point(467, 189);
            this.MobDataBtn.Name = "MobDataBtn";
            this.MobDataBtn.Size = new System.Drawing.Size(75, 23);
            this.MobDataBtn.TabIndex = 1;
            this.MobDataBtn.Text = "MobDataBtn";
            this.MobDataBtn.UseVisualStyleBackColor = true;
            this.MobDataBtn.Click += new System.EventHandler(this.MobDataBtn_Click);
            // 
            // ItemDataBtn
            // 
            this.ItemDataBtn.Location = new System.Drawing.Point(467, 257);
            this.ItemDataBtn.Name = "ItemDataBtn";
            this.ItemDataBtn.Size = new System.Drawing.Size(75, 23);
            this.ItemDataBtn.TabIndex = 2;
            this.ItemDataBtn.Text = "ItemDataBtn";
            this.ItemDataBtn.UseVisualStyleBackColor = true;
            this.ItemDataBtn.Click += new System.EventHandler(this.ItemDataBtn_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ItemDataBtn);
            this.Controls.Add(this.MobDataBtn);
            this.Controls.Add(this.SkillDataBtn);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SkillDataBtn;
        private System.Windows.Forms.Button MobDataBtn;
        private System.Windows.Forms.Button ItemDataBtn;
    }
}