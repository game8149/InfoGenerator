using Engines;
using System;
using System.Threading;
using System.Windows.Forms;

namespace GeneratorUI
{
    public partial class Form1 : Form
    {
        private Thread firstThreadBackground = null;
        private Thread secondThreadBackground = null;

        GeneratorReport run = new GeneratorReport();

        delegate void ThreadedAction(object[] parameters);

        private string fileSourcePath = string.Empty;
        private string targetPath = string.Empty;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.DefaultExt = ".xlsx";
        }

        void refreshProgressBar(object[] parameters)
        {
            if (progressBar1.InvokeRequired == false)
            {
                progressBar1.Maximum = (int)parameters[0];
                progressBar1.Value = (int)parameters[1];
                lblProgress.Text = (int)parameters[1] + "/" + (int)parameters[0];
                lblNameActual.Text = (string)parameters[2];
            }
            else
            {
                ThreadedAction refreshP = new ThreadedAction(refreshProgressBar);
                this.Invoke(refreshP, parameters);
            }
        }

        void ThreadUI()
        {
            secondThreadBackground = new Thread(new ThreadStart(run.Generate));
            secondThreadBackground.Start();

            while (!run.WorkFinished)
            {
                try
                {
                    ThreadedAction refreshP = new ThreadedAction(refreshProgressBar);
                    this.Invoke(refreshP, new object[] { new object[] { (int)run.TotalWork, (int)run.ProgressFinished, (string)run.NameActual } });
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resut = folderBrowserDialog1.ShowDialog();
            if (resut == DialogResult.OK)
            {
                targetPath = folderBrowserDialog1.SelectedPath;
                txtPathTarget.Text = targetPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult resut = openFileDialog1.ShowDialog();
            if (resut == DialogResult.OK)
            {
                fileSourcePath =openFileDialog1.FileName;
                txtPathSource.Text = fileSourcePath;
            }
        }

        private void rdCode_CheckedChanged(object sender, EventArgs e)
        {
            lblOption.Text = "Codigo";
            txtOption.Text = string.Empty;
        }

        private void rdRandon_CheckedChanged(object sender, EventArgs e)
        {
            lblOption.Text = "Cantidad";
            txtOption.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                run.FileSource = fileSourcePath;
                run.FolderPath = targetPath;
                run.Month = cboMonth.SelectedIndex + 1;
                run.Year = int.Parse(txtYear.Text);
                if (rdCode.Checked)
                {
                    run.Method = GeneratorReport.MethodReport.Code;
                    run.CodeStore = txtOption.Text;
                }
                else
                {
                    run.Method = GeneratorReport.MethodReport.Random;
                    run.RandomNumber = int.Parse(txtOption.Text);
                }

                firstThreadBackground = new Thread(new ThreadStart(ThreadUI));
                firstThreadBackground.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica tus parametros.");
            }
        }
    }
}
