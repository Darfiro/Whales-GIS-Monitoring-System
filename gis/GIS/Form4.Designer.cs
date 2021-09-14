namespace GIS
{
    partial class Form4
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gender = new System.Windows.Forms.ComboBox();
            this.specie = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ageUp = new System.Windows.Forms.NumericUpDown();
            this.weigthUpDown = new System.Windows.Forms.NumericUpDown();
            this.chipBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateSpotted = new System.Windows.Forms.DateTimePicker();
            this.pondBox = new System.Windows.Forms.ComboBox();
            this.lonBox = new System.Windows.Forms.TextBox();
            this.latBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.goBackBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.weigthUpDown)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gender);
            this.groupBox1.Controls.Add(this.specie);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ageUp);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 234);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о ките";
            // 
            // gender
            // 
            this.gender.FormattingEnabled = true;
            this.gender.Location = new System.Drawing.Point(18, 80);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(121, 24);
            this.gender.TabIndex = 11;
            // 
            // specie
            // 
            this.specie.FormattingEnabled = true;
            this.specie.Location = new System.Drawing.Point(18, 40);
            this.specie.Name = "specie";
            this.specie.Size = new System.Drawing.Size(121, 24);
            this.specie.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Вес (кг.)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Возраст";
            // 
            // ageUp
            // 
            this.ageUp.Location = new System.Drawing.Point(19, 137);
            this.ageUp.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.ageUp.Name = "ageUp";
            this.ageUp.Size = new System.Drawing.Size(120, 22);
            this.ageUp.TabIndex = 2;
            // 
            // weigthUpDown
            // 
            this.weigthUpDown.Location = new System.Drawing.Point(32, 211);
            this.weigthUpDown.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.weigthUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.weigthUpDown.Name = "weigthUpDown";
            this.weigthUpDown.Size = new System.Drawing.Size(120, 22);
            this.weigthUpDown.TabIndex = 5;
            this.weigthUpDown.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // chipBox
            // 
            this.chipBox.AutoSize = true;
            this.chipBox.Location = new System.Drawing.Point(512, 24);
            this.chipBox.Name = "chipBox";
            this.chipBox.Size = new System.Drawing.Size(80, 21);
            this.chipBox.TabIndex = 6;
            this.chipBox.Text = "Маячок";
            this.chipBox.UseVisualStyleBackColor = true;
            this.chipBox.CheckedChanged += new System.EventHandler(this.chipBox_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateSpotted);
            this.groupBox2.Controls.Add(this.pondBox);
            this.groupBox2.Controls.Add(this.lonBox);
            this.groupBox2.Controls.Add(this.latBox);
            this.groupBox2.Location = new System.Drawing.Point(236, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 232);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Информация о встрече";
            // 
            // dateSpotted
            // 
            this.dateSpotted.Location = new System.Drawing.Point(16, 186);
            this.dateSpotted.Name = "dateSpotted";
            this.dateSpotted.Size = new System.Drawing.Size(219, 22);
            this.dateSpotted.TabIndex = 3;
            this.dateSpotted.ValueChanged += new System.EventHandler(this.dateSpotted_ValueChanged);
            // 
            // pondBox
            // 
            this.pondBox.FormattingEnabled = true;
            this.pondBox.Location = new System.Drawing.Point(16, 140);
            this.pondBox.Name = "pondBox";
            this.pondBox.Size = new System.Drawing.Size(219, 24);
            this.pondBox.TabIndex = 2;
            this.pondBox.Text = "Водоем";
            // 
            // lonBox
            // 
            this.lonBox.Location = new System.Drawing.Point(16, 91);
            this.lonBox.Name = "lonBox";
            this.lonBox.Size = new System.Drawing.Size(219, 22);
            this.lonBox.TabIndex = 1;
            this.lonBox.Text = "Долгота";
            // 
            // latBox
            // 
            this.latBox.Location = new System.Drawing.Point(16, 40);
            this.latBox.Name = "latBox";
            this.latBox.Size = new System.Drawing.Size(219, 22);
            this.latBox.TabIndex = 0;
            this.latBox.Text = "Широта";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(512, 75);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(147, 42);
            this.saveBtn.TabIndex = 8;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(512, 229);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 17);
            this.lblError.TabIndex = 9;
            // 
            // goBackBtn
            // 
            this.goBackBtn.Location = new System.Drawing.Point(512, 137);
            this.goBackBtn.Name = "goBackBtn";
            this.goBackBtn.Size = new System.Drawing.Size(147, 42);
            this.goBackBtn.TabIndex = 10;
            this.goBackBtn.Text = "Назад";
            this.goBackBtn.UseVisualStyleBackColor = true;
            this.goBackBtn.Click += new System.EventHandler(this.goBackBtn_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 264);
            this.Controls.Add(this.goBackBtn);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.chipBox);
            this.Controls.Add(this.weigthUpDown);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод данных";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ageUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.weigthUpDown)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown ageUp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown weigthUpDown;
        private System.Windows.Forms.CheckBox chipBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateSpotted;
        private System.Windows.Forms.ComboBox pondBox;
        private System.Windows.Forms.TextBox lonBox;
        private System.Windows.Forms.TextBox latBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button goBackBtn;
        private System.Windows.Forms.ComboBox specie;
        private System.Windows.Forms.ComboBox gender;
    }
}