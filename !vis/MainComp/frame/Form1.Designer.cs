namespace frame
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.class11 = new MainComp.Class1();
            this.LabelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(949, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // class11
            // 
            this.class11.BackgroundColor = System.Drawing.Color.White;
            this.class11.ClckedButton = "";
            this.class11.Complexiti = 0;
            this.class11.CrossOutColor = System.Drawing.Color.Red;
            this.class11.DashColor = System.Drawing.Color.Black;
            this.class11.GuessedWord = "";
            this.class11.HiddenTextColor = System.Drawing.Color.Black;
            this.class11.Location = new System.Drawing.Point(12, 42);
            this.class11.Name = "class11";
            this.class11.PatColor = System.Drawing.Color.Blue;
            this.class11.SeparatorColor = System.Drawing.Color.Black;
            this.class11.Size = new System.Drawing.Size(1012, 736);
            this.class11.ssr = "";
            this.class11.TabIndex = 2;
            this.class11.Text = "class11";
            this.class11.TextAlfColor = System.Drawing.Color.White;
            this.class11.OnEndGame += new System.EventHandler(this.class11_OnEndGame);
            this.class11.OnWinGame += new System.EventHandler(this.class11_OnWinGame);
            this.class11.OnClickButton += new System.EventHandler(this.class11_OnClickButton);
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(807, 14);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(103, 13);
            this.LabelName.TabIndex = 3;
            this.LabelName.Text = "Имя пользоватея -";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 791);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.class11);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private MainComp.Class1 class11;
        private System.Windows.Forms.Label LabelName;
    }
}

