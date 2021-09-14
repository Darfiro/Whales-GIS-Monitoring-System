namespace GIS
{
    partial class Form3
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
            this.saveBtn = new System.Windows.Forms.Button();
            this.addMoreBtn = new System.Windows.Forms.Button();
            this.whales = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(667, 401);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(121, 37);
            this.saveBtn.TabIndex = 0;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // addMoreBtn
            // 
            this.addMoreBtn.Location = new System.Drawing.Point(12, 401);
            this.addMoreBtn.Name = "addMoreBtn";
            this.addMoreBtn.Size = new System.Drawing.Size(154, 37);
            this.addMoreBtn.TabIndex = 1;
            this.addMoreBtn.Text = "Добавить еще кита";
            this.addMoreBtn.UseVisualStyleBackColor = true;
            this.addMoreBtn.Click += new System.EventHandler(this.addMoreBtn_Click);
            // 
            // whales
            // 
            this.whales.FormattingEnabled = true;
            this.whales.ItemHeight = 16;
            this.whales.Location = new System.Drawing.Point(13, 13);
            this.whales.Name = "whales";
            this.whales.Size = new System.Drawing.Size(775, 372);
            this.whales.TabIndex = 2;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.whales);
            this.Controls.Add(this.addMoreBtn);
            this.Controls.Add(this.saveBtn);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Добавление данных";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addMoreBtn;
        private System.Windows.Forms.ListBox whales;
    }
}