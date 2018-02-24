namespace Wonder_Rabbit
{
    partial class Manual
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manual));
            this.manual_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // manual_TextBox
            // 
            this.manual_TextBox.BackColor = System.Drawing.Color.Khaki;
            this.manual_TextBox.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.manual_TextBox.Location = new System.Drawing.Point(-1, -1);
            this.manual_TextBox.Multiline = true;
            this.manual_TextBox.Name = "manual_TextBox";
            this.manual_TextBox.ReadOnly = true;
            this.manual_TextBox.Size = new System.Drawing.Size(530, 441);
            this.manual_TextBox.TabIndex = 0;
            this.manual_TextBox.Text = resources.GetString("manual_TextBox.Text");
            // 
            // Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 439);
            this.Controls.Add(this.manual_TextBox);
            this.Name = "Manual";
            this.Text = "Manual";
            this.Load += new System.EventHandler(this.Manual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox manual_TextBox;
    }
}