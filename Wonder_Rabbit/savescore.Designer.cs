namespace Wonder_Rabbit
{
    partial class savescore
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rankTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(154, 206);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(258, 25);
            this.nameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "이름을 입력하세요";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(187, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(179, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "완료";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rankTextBox
            // 
            this.rankTextBox.Location = new System.Drawing.Point(12, 12);
            this.rankTextBox.Multiline = true;
            this.rankTextBox.Name = "rankTextBox";
            this.rankTextBox.ReadOnly = true;
            this.rankTextBox.Size = new System.Drawing.Size(567, 164);
            this.rankTextBox.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(486, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 51);
            this.button2.TabIndex = 4;
            this.button2.Text = "랭킹초기화";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // savescore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 304);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.rankTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "savescore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "savescore";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.savescore_FormClosing);
            this.Load += new System.EventHandler(this.savescore_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox rankTextBox;
        private System.Windows.Forms.Button button2;
    }
}