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
    public partial class FormConcentrationTest : Form
    {
        string[] word = {"Black", "Red", "Yellow", "Green", "Purple"};
        Color[] wordColor = {Color.Black, Color.Red, Color.Yellow, Color.Green, Color.Purple};
        bool valid = false;

        public FormConcentrationTest()
        {
            InitializeComponent();
            label2.Visible = false;
            label9.Visible = false;
            label11.Visible = false;
            lblChoice.Visible = false;
        }

        int correct = 0, wrong = 0;
        DateTime starttime, endtime;
        double duration = 0;
        UserClass.ConcentrationTest objCTest = new UserClass.ConcentrationTest();

        private void WordStart()
        {
            Random rnd = new Random();
            Random wc = new Random();
            int c = wc.Next(0, 4);
            int a = rnd.Next(0, 5),b=rnd.Next(0,5),d=rnd.Next(0,5);
            label2.Visible = true;
            label2.Text = word[a];
            label3.Text = word[b];
            label3.ForeColor = wordColor[d];
            for (int i = 0; i < 5; i++)
            {
                if (word[i] != label3.Text)
                    label5.Text = word[i];
                if (wordColor[i] != label3.ForeColor)
                    label5.ForeColor = wordColor[i];
            }
            for (int i = 0; i < 5; i++)
            {
                if (word[i] != label3.Text && word[i] != label5.Text)
                    label4.Text = word[i];
                if (wordColor[i] != label3.ForeColor&&wordColor[i]!=label5.ForeColor)
                    label4.ForeColor = wordColor[i];
            }
            for (int i = 0; i < 5; i++)
            {
                if (word[i] != label3.Text && word[i] != label5.Text && word[i] !=label4.Text)
                label6.Text = word[i];
                if (wordColor[i] != label3.ForeColor && wordColor[i] != label5.ForeColor&&wordColor[i]!=label4.ForeColor)
                    label6.ForeColor = wordColor[i];
            }
            for (int i = 0; i < 5; i++)
            {
                if (word[i] != label3.Text && word[i] != label5.Text && word[i] != label4.Text && word[i] != label6.Text)
                label7.Text = word[i];
                if (wordColor[i] != label3.ForeColor && wordColor[i] != label5.ForeColor && wordColor[i] != label4.ForeColor&&wordColor[i]!=label6.ForeColor)
                    label7.ForeColor = wordColor[i];
            }
            lblChoice.Visible = true;
            if (c == 0||c==1)
                lblChoice.Text = "Word";
            else
                lblChoice.Text = "Color";
        } // WordStart()
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                button1.Text = "Stop";
                label9.Visible = false;
                label11.Visible = false;
                WordStart();
                starttime = DateTime.Now;
            }
            else
            {
                label2.Visible = false;
                lblChoice.Visible = false;
                button1.Text = "Start";
                label9.Visible = true;
                if ((correct + wrong) == 0)
                    label9.Text = "0";
                else
                    label9.Text = ((double)correct * 100 / (correct + wrong)).ToString("F0");
                endtime = DateTime.Now;
                duration = (endtime-starttime).TotalMinutes * 60 + (endtime-starttime).TotalSeconds;
                label11.Visible = true;
                label11.Text= duration.ToString("F0")+" seconds";
                
                objCTest.correctAnswer = correct;
                objCTest.wrongAnswer = wrong;
                objCTest.totalAnswer = correct + wrong;
                objCTest.timeSpent = duration;
                objCTest.score = Convert.ToDouble(label9.Text);
                
            }
        } // button1_Click()

        private void label5_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Stop")
            {
                if (lblChoice.Text == "Word")
                {
                    if (label2.Text == label5.Text)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                if (lblChoice.Text == "Color")
                {
                    int w = 0, col = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (label2.Text == word[i])
                            w = i;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (label5.ForeColor == wordColor[j])
                            col = j;
                    }
                    if (w == col)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                WordStart();
            }
        } // label5_Click()

        private void label4_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Stop")
            {
                if (lblChoice.Text == "Word")
                {
                    if (label2.Text == label4.Text)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                if (lblChoice.Text == "Color")
                {
                    int w = 0, col = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (label2.Text == word[i])
                            w = i;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (label4.ForeColor == wordColor[j])
                            col = j;
                    }
                    if (w == col)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                WordStart();
            }
        } // label4_Click()

        private void label6_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Stop")
            {
                if (lblChoice.Text == "Word")
                {
                    if (label2.Text == label6.Text)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                if (lblChoice.Text == "Color")
                {
                    int w = 0, col = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (label2.Text == word[i])
                            w = i;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (label6.ForeColor == wordColor[j])
                            col = j;
                    }
                    if (w == col)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                WordStart();
            }
        } //label6_Click()

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(button1.Text != "Stop")
            {
                UserClass.concentrationList.Add(objCTest);
                saveScores();

                if (valid == true)
                {
                    //THIS event opens another form

                    // Hide "this" current form
                    this.Hide();

                    // Create a new object that will represent the next form.
                    FormUser frm = new FormUser();

                    // Displays the other form using its object instance
                    frm.Show();

                    frm = null;
                } // endif
            } // endif
        } // btnSubmit_Click()

        private void saveScores()
        {
            StreamWriter streamData = null;
            valid = false;
            string currDate = DateTime.Now.ToString("MM-dd-yyyy");
            //string currDate = DateTime.Now.ToString("d");
            string name = UserClass.userList[0].userName;

            string file = "../../Data/" + name + "_" + currDate + "_ConcentrationTest"; // will store the file name as Name_Date_ConcentrationTest.dat

            if (!File.Exists(file + ".dat"))
            {
                try
                {

                    streamData = new StreamWriter(file + ".dat");
                    
                    streamData.WriteLine(name);
                    streamData.WriteLine(objCTest.timeSpent.ToString("F2"));
                    streamData.WriteLine(objCTest.correctAnswer.ToString());
                    streamData.WriteLine(objCTest.wrongAnswer.ToString());
                    streamData.WriteLine(objCTest.totalAnswer.ToString());
                    streamData.WriteLine(objCTest.score.ToString());
                } // try

                catch (IOException err)
                {
                    MessageBox.Show(err.Message);
                    valid = false;
                } // catch

                finally
                {
                    // Close the file if it is not already closed
                    if (streamData != null)
                    {
                        streamData.Close();
                        MessageBox.Show("File has been written.");
                        valid = true;
                    }
                } // finally
            } // end if

            else
            {
                MessageBox.Show("This Data already Exists!");
                valid = false;
            } // else
        } // saveScores()

        private void label7_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Stop")
            {
                if (lblChoice.Text == "Word")
                {
                    if (label2.Text == label7.Text)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                if (lblChoice.Text == "Color")
                {
                    int w = 0, col = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (label2.Text == word[i])
                            w = i;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (label7.ForeColor == wordColor[j])
                            col = j;
                    }
                    if (w == col)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                WordStart();
            }
        } //label7_Click()

        private void label3_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Stop")
            {
                if (lblChoice.Text == "Word")
                {
                    if (label2.Text == label3.Text)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                if (lblChoice.Text == "Color")
                {
                    int w = 0, col = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        if (label2.Text == word[i])
                            w = i;
                    }
                    for (int j = 0; j < 5; j++)
                    {
                        if (label3.ForeColor == wordColor[j])
                            col = j;
                    }
                    if (w == col)
                    {
                        correct++;
                    }
                    else
                    {
                        wrong++;
                    }
                }
                WordStart();
            }
        } //label3_Click()
    } // Form
}
