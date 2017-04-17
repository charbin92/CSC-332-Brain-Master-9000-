using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ConcussionTestingLab
{
    public partial class frmConcentrationTest : Form
    {
        string[] word = {"Black","Red","Yellow","Green","Purple" };
        Color[] wordColor = {Color.Black,Color.Red,Color.Yellow,Color.Green,Color.Purple};
        public frmConcentrationTest()
        {
            InitializeComponent();
            label2.Visible = false;
            label9.Visible = false;
            label11.Visible = false;
            lblChoice.Visible = false;
        }
        int correct = 0, wrong = 0;
        DateTime starttime, endtime;
        double duration=0;
         
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
        }
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
                UserClass.ConcentrationTest objCTest = new UserClass.ConcentrationTest();
                objCTest.correctAnswer = correct;
                objCTest.wrongAnswer = wrong;
                objCTest.totalAnswer = correct + wrong;
                objCTest.timeSpent = duration;
            }
        }

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
        }

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
        }

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
        }

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
        }

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
        }
    }
}
