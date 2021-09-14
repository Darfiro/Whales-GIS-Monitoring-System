namespace GIS
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.showWhales = new System.Windows.Forms.Button();
            this.whaleId = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.specieWhale = new System.Windows.Forms.ComboBox();
            this.ChipRdBtn = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.GroupRdBtn = new System.Windows.Forms.RadioButton();
            this.infoBox = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.addBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(12, 296);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 20;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(1252, 747);
            this.map.TabIndex = 0;
            this.map.Zoom = 2D;
            // 
            // showWhales
            // 
            this.showWhales.Location = new System.Drawing.Point(280, 181);
            this.showWhales.Name = "showWhales";
            this.showWhales.Size = new System.Drawing.Size(198, 68);
            this.showWhales.TabIndex = 1;
            this.showWhales.Text = "Показать китов";
            this.showWhales.UseVisualStyleBackColor = true;
            this.showWhales.Click += new System.EventHandler(this.showWhales_Click);
            // 
            // whaleId
            // 
            this.whaleId.FormattingEnabled = true;
            this.whaleId.Location = new System.Drawing.Point(9, 54);
            this.whaleId.Name = "whaleId";
            this.whaleId.Size = new System.Drawing.Size(197, 24);
            this.whaleId.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.whaleId);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(234, 94);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Кит";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.specieWhale);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 100);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Вид кита";
            // 
            // specieWhale
            // 
            this.specieWhale.FormattingEnabled = true;
            this.specieWhale.Location = new System.Drawing.Point(9, 48);
            this.specieWhale.Name = "specieWhale";
            this.specieWhale.Size = new System.Drawing.Size(197, 24);
            this.specieWhale.TabIndex = 0;
            // 
            // ChipRdBtn
            // 
            this.ChipRdBtn.AutoSize = true;
            this.ChipRdBtn.Location = new System.Drawing.Point(6, 36);
            this.ChipRdBtn.Name = "ChipRdBtn";
            this.ChipRdBtn.Size = new System.Drawing.Size(165, 21);
            this.ChipRdBtn.TabIndex = 6;
            this.ChipRdBtn.TabStop = true;
            this.ChipRdBtn.Text = "По записям маячков";
            this.ChipRdBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.GroupRdBtn);
            this.groupBox3.Controls.Add(this.ChipRdBtn);
            this.groupBox3.Location = new System.Drawing.Point(252, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(260, 149);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Параметры отображения";
            // 
            // GroupRdBtn
            // 
            this.GroupRdBtn.AutoSize = true;
            this.GroupRdBtn.Location = new System.Drawing.Point(6, 78);
            this.GroupRdBtn.Name = "GroupRdBtn";
            this.GroupRdBtn.Size = new System.Drawing.Size(167, 21);
            this.GroupRdBtn.TabIndex = 8;
            this.GroupRdBtn.TabStop = true;
            this.GroupRdBtn.Text = "По встречам с китом";
            this.GroupRdBtn.UseVisualStyleBackColor = true;
            // 
            // infoBox
            // 
            this.infoBox.Location = new System.Drawing.Point(15, 29);
            this.infoBox.Name = "infoBox";
            this.infoBox.ReadOnly = true;
            this.infoBox.Size = new System.Drawing.Size(343, 228);
            this.infoBox.TabIndex = 8;
            this.infoBox.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.infoBox);
            this.groupBox4.Location = new System.Drawing.Point(558, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(377, 277);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Информация";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(998, 181);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(198, 68);
            this.addBtn.TabIndex = 10;
            this.addBtn.Text = "Добавить данные";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1279, 1055);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.map);
            this.Controls.Add(this.showWhales);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мониторинг китов";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl map;
        private System.Windows.Forms.Button showWhales;
        private System.Windows.Forms.ComboBox whaleId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox specieWhale;
        private System.Windows.Forms.RadioButton ChipRdBtn;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton GroupRdBtn;
        private System.Windows.Forms.RichTextBox infoBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button addBtn;
    }
}

