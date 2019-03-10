namespace GeneratorUI
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
            this.txtPathSource = new System.Windows.Forms.TextBox();
            this.txtPathTarget = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rdCode = new System.Windows.Forms.RadioButton();
            this.rdRandon = new System.Windows.Forms.RadioButton();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtOption = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOption = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblNameActual = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 266);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPathSource
            // 
            this.txtPathSource.Location = new System.Drawing.Point(110, 44);
            this.txtPathSource.Name = "txtPathSource";
            this.txtPathSource.Size = new System.Drawing.Size(184, 21);
            this.txtPathSource.TabIndex = 15;
            // 
            // txtPathTarget
            // 
            this.txtPathTarget.Location = new System.Drawing.Point(110, 81);
            this.txtPathTarget.Name = "txtPathTarget";
            this.txtPathTarget.Size = new System.Drawing.Size(184, 21);
            this.txtPathTarget.TabIndex = 16;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(300, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 23);
            this.button2.TabIndex = 17;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(300, 42);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(25, 23);
            this.button3.TabIndex = 18;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Orig. de Datos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Destino";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Trade Gothic LT Std", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(25, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 15);
            this.label7.TabIndex = 21;
            this.label7.Text = "Configuracion Archivos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Tipo Report.";
            // 
            // rdCode
            // 
            this.rdCode.AutoSize = true;
            this.rdCode.Location = new System.Drawing.Point(203, 186);
            this.rdCode.Name = "rdCode";
            this.rdCode.Size = new System.Drawing.Size(59, 17);
            this.rdCode.TabIndex = 29;
            this.rdCode.TabStop = true;
            this.rdCode.Text = "Codigo";
            this.rdCode.UseVisualStyleBackColor = true;
            this.rdCode.CheckedChanged += new System.EventHandler(this.rdCode_CheckedChanged);
            // 
            // rdRandon
            // 
            this.rdRandon.AutoSize = true;
            this.rdRandon.Location = new System.Drawing.Point(110, 186);
            this.rdRandon.Name = "rdRandon";
            this.rdRandon.Size = new System.Drawing.Size(70, 17);
            this.rdRandon.TabIndex = 28;
            this.rdRandon.TabStop = true;
            this.rdRandon.Text = "Aleatorio";
            this.rdRandon.UseVisualStyleBackColor = true;
            this.rdRandon.CheckedChanged += new System.EventHandler(this.rdRandon_CheckedChanged);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(110, 150);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(71, 21);
            this.txtYear.TabIndex = 27;
            this.txtYear.Text = "2018";
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtOption
            // 
            this.txtOption.Location = new System.Drawing.Point(110, 221);
            this.txtOption.Name = "txtOption";
            this.txtOption.Size = new System.Drawing.Size(100, 21);
            this.txtOption.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Año";
            // 
            // lblOption
            // 
            this.lblOption.AutoSize = true;
            this.lblOption.Location = new System.Drawing.Point(31, 223);
            this.lblOption.Name = "lblOption";
            this.lblOption.Size = new System.Drawing.Size(41, 13);
            this.lblOption.TabIndex = 23;
            this.lblOption.Text = "Codigo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Mes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Trade Gothic LT Std", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 15);
            this.label8.TabIndex = 31;
            this.label8.Text = "Parametros";
            // 
            // cboMonth
            // 
            this.cboMonth.FormattingEnabled = true;
            this.cboMonth.Items.AddRange(new object[] {
            "Ene",
            "Feb",
            "Mar",
            "Abr",
            "May",
            "Jun",
            "Jul",
            "Ago",
            "Set",
            "Oct",
            "Nov",
            "Dic"});
            this.cboMonth.Location = new System.Drawing.Point(245, 150);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(80, 21);
            this.cboMonth.TabIndex = 32;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(176, 11);
            this.progressBar1.TabIndex = 33;
            // 
            // lblNameActual
            // 
            this.lblNameActual.AutoSize = true;
            this.lblNameActual.Location = new System.Drawing.Point(12, 8);
            this.lblNameActual.Name = "lblNameActual";
            this.lblNameActual.Size = new System.Drawing.Size(15, 13);
            this.lblNameActual.TabIndex = 34;
            this.lblNameActual.Text = "{}";
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(164, 9);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(24, 13);
            this.lblProgress.TabIndex = 35;
            this.lblProgress.Text = "0/0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblProgress);
            this.panel1.Controls.Add(this.lblNameActual);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Location = new System.Drawing.Point(13, 258);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(196, 41);
            this.panel1.TabIndex = 36;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 329);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboMonth);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rdCode);
            this.Controls.Add(this.rdRandon);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtOption);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblOption);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtPathTarget);
            this.Controls.Add(this.txtPathSource);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Trade Gothic LT Std", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Generador Dateame";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtPathSource;
        private System.Windows.Forms.TextBox txtPathTarget;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdCode;
        private System.Windows.Forms.RadioButton rdRandon;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtOption;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOption;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboMonth;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblNameActual;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Panel panel1;
    }
}

