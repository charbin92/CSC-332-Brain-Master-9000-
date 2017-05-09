using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcussionTestingLab
{
    public partial class FormAnalysis : Form
    {
        double totalTime;
        int numCorrect;
        int numWrong;
        int totalQuestions;
        double score;
        double avgTime;
        string fileName;
        bool valid = false;

        public FormAnalysis()
        {
            InitializeComponent();
            
        }

        private void populateChart(bool loadChart1)
        {
            if (loadChart1 == true)
            {
                chart1.Series[0].Points[0].SetValueY(score);
                chart1.Series[0].Points[0].IsValueShownAsLabel = true;
                chart1.Series[0].Points[1].SetValueY(numCorrect);
                chart1.Series[0].Points[1].IsValueShownAsLabel = true;
                chart1.Series[0].Points[2].SetValueY(numWrong);
                chart1.Series[0].Points[2].IsValueShownAsLabel = true;
                chart1.Series[0].Points[3].SetValueY(totalTime);
                chart1.Series[0].Points[3].IsValueShownAsLabel = true;

                chart1.ChartAreas[0].RecalculateAxesScale();
            }

            else
            {
                chart2.Series[0].Points[0].SetValueY(score);
                chart2.Series[0].Points[0].IsValueShownAsLabel = true;
                chart2.Series[0].Points[1].SetValueY(numCorrect);
                chart2.Series[0].Points[1].IsValueShownAsLabel = true;
                chart2.Series[0].Points[2].SetValueY(numWrong);
                chart2.Series[0].Points[2].IsValueShownAsLabel = true;
                chart2.Series[0].Points[3].SetValueY(totalTime);
                chart2.Series[0].Points[3].IsValueShownAsLabel = true;

                chart2.ChartAreas[0].RecalculateAxesScale();
            }
        } // populateChart()

        private void btnLoadData1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "DAT Files (*.dat)|*.dat";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                ReadFile();
            }

            if (valid == true)
            {
                bool loadChart1 = true;
                populateChart(loadChart1);
            }
        } //btnLoadData1_Click()

        private void btnLoadData2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "DAT Files (*.dat)|*.dat";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                fileName = dlg.FileName;
                ReadFile();
            }

            if (valid == true)
            {
                bool loadChart1 = false;
                populateChart(loadChart1);
            }
        } //btnLoadData2_Click()

        private void ReadFile()
        {
            if(fileName.Contains("ReactionTest.dat"))
            {

            }

            else
            {
                string line = "x";
                TextReader streamData = null;

                if (File.Exists(fileName))
                {
                    try
                    {
                        streamData = new StreamReader(fileName);

                        while (streamData.Peek() > -1)
                        {
                            line = streamData.ReadLine();
                            line = streamData.ReadLine();
                            totalTime = Convert.ToDouble(line);
                            line = streamData.ReadLine();
                            numCorrect = Convert.ToInt32(line);
                            line = streamData.ReadLine();
                            numWrong = Convert.ToInt32(line);
                            line = streamData.ReadLine();
                            totalQuestions = Convert.ToInt32(line);
                            line = streamData.ReadLine();
                            score = Convert.ToDouble(line);
                        } // while()

                    } // try

                    catch (IOException err)
                    {
                        MessageBox.Show(err.Message);
                        valid = false;
                    } // catch

                    finally
                    {
                        if (streamData != null)
                            streamData.Close();
                        MessageBox.Show("Data Loaded!");
                        valid = true;
                    } // finally
                } // endif

                else
                {
                    MessageBox.Show("Data does not Exist.");
                    valid = false;
                } // else
            }
        } // ReadFile()

        private void FormAnalysis_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points[0].SetValueY(0);
            chart1.Series[0].Points[1].SetValueY(0);
            chart1.Series[0].Points[2].SetValueY(0);
            chart1.Series[0].Points[3].SetValueY(0);
            chart1.ChartAreas[0].RecalculateAxesScale();

            chart2.Series[0].Points[0].SetValueY(0);
            chart2.Series[0].Points[1].SetValueY(0);
            chart2.Series[0].Points[2].SetValueY(0);
            chart2.Series[0].Points[3].SetValueY(0);
            chart2.ChartAreas[0].RecalculateAxesScale();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            //This event opens another form

            //Hide "this" current form
            this.Hide();

            //Create a new object that will represent the next form.

            FormUser frm = new FormUser();

            //Displays the other form using its object instance

            frm.Show();

            frm = null;
        }
    }
}
