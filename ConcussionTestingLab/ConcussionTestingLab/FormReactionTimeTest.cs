using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConcussionTestingLab
{
    public partial class FormReactionTimeTest : Form
    {
        Random rnd = new Random();
        Brush brush;
        Graphics g;
        int time = 0;
        int color = 0; // red (and blue is 1)
        int wrongKey = 0;
        int correctKey = 0;
        int totalAnswer = 0;
        double avgTime = 0;
        double timespent = 0;
        double totalTime = 0;
        double score = 0;
        private Stopwatch watch;
        UserClass.TimeTest timeTestObj = new UserClass.TimeTest();
        bool valid = false;

        public FormReactionTimeTest()
        {
            InitializeComponent();
        }

        // Add reaction time test
        public void updateReactionTimeTest()
        {
            UserClass.ReactionTimeTest reaction = new UserClass.ReactionTimeTest();
            totalAnswer = wrongKey + correctKey;
            reaction.totalAnswer = totalAnswer;
            reaction.wrongAnswer = wrongKey;
            reaction.correctAnswer = correctKey;
            reaction.timespent = timespent;
            totalTime = 0;
            foreach (var item in UserClass.reactionTestList)
            {
                totalTime += item.timespent;
            }
            totalTime += timespent;
            avgTime = totalTime / (UserClass.reactionTestList.Count + 1);
            reaction.avgTime = avgTime;
            UserClass.reactionTestList.Add(reaction);
        }

        public void draw()
        {
            pictureBoxRuntime.Refresh();
            g = pictureBoxRuntime.CreateGraphics();
            if (time == 3 || time == 0)
            {
                watch.Start();
                if (time == 3)
                {
                    time = 0;
                }
                if (rnd.Next(0, 2) == 0)
                {
                    color = 0;
                    brush = new SolidBrush(Color.Red);
                    g.FillEllipse(brush, 0, 0, 100, 70);
                }
                else
                {
                    color = 1;
                    brush = new SolidBrush(Color.Blue);
                    g.FillRectangle(brush, 0, 0, 100, 70);
                }
            }
            else
            {
                if (brush != null)
                {
                    brush = new SolidBrush(Color.White);
                    if (color == 0)
                    {
                        g.FillEllipse(brush, 0, 0, 100, 70);
                    }
                    else
                    {
                        g.FillRectangle(brush, 0, 0, 100, 70);
                    }
                     
                }
               
            }
            
               
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel2.Location = new Point(
                 0,
                 0
             );
            watch = new Stopwatch();
            //Start timer
            correctKey = 0;
            wrongKey = 0;
            timerSpeed.Interval = 1000;
            timerSpeed.Enabled = true;
            time = 0;
            draw();
        }

        // first panel
        private void button1_Click(object sender, EventArgs e)
        {
            panelInstruction.Visible = false;
            panel1.Visible = true;
            panel1.Location = new Point(
                 this.Width/4,
                 this.Height/4
             );
        }

        // load form
        private void frmReactionTimeTest_Load(object sender, EventArgs e)
        {
            panelInstruction.Location = new Point(
                 0,
                 0
             );
        }

        private void timerSpeed_Tick(object sender, EventArgs e)
        {
            time++;
            draw();
        }

        private void frmReactionTimeTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Create a seperate method that will save all values into the list after a certain number of attempts.
            timespent = watch.Elapsed.Milliseconds;
            watch.Reset();
            watch.Stop();
            timerSpeed.Enabled = false;

            if (totalAnswer < 15)
            {
                getReaction(e);
            } //endif

            else
            {
                score = ((double)correctKey / (double)totalAnswer) * 100;
                string msg = "Finished!";
                msg = msg + Environment.NewLine + "  -Total Answer: " + totalAnswer.ToString()
                          + "(" + wrongKey.ToString() + " wrong and " + correctKey.ToString() + " correct)"
                          + Environment.NewLine + "  -Time Spent: " + (timespent / (double)1000).ToString("F4") + " second(s)"
                          + Environment.NewLine + "  -Avg Time: " + (avgTime / (double)1000).ToString("F4") + " second(s)"
                          + Environment.NewLine + "  -Total Time: " + (totalTime / 1000).ToString() + " second(s)"
                          + Environment.NewLine + "  -Score: " + score.ToString("F2");
                MessageBox.Show(msg);
                timerSpeed.Stop();
                saveDataToList();
                submitData();
            }
            timerSpeed.Enabled = true;
            pictureBoxP.Visible = true;
            pictureBoxQ.Visible = true;
            //timespent = 0; // reset
            //avgTime = 0; // reset
        } //frmReactionTimeTest_KeyPress()

        private void getReaction(KeyPressEventArgs e)
        {
            bool isCorrect = false;

            if (e.KeyChar == 'p') // Blue
            {
                pictureBoxP.Visible = false;
                if (color != 1)
                {
                    wrongKey++;
                    updateReactionTimeTest();

                    //MessageBox.Show("WRONG (" + wrongKey.ToString() + ")");
                    isCorrect = false;


                }
                else
                {
                    correctKey++;
                    updateReactionTimeTest();
                    // timerSpeed.Enabled = false;
                    // MessageBox.Show("CORRECT (" + correctKey.ToString() + ")");
                    // timerSpeed.Enabled = true;
                    isCorrect = true;

                }

            }
            else if (e.KeyChar == 'q') // Red
            {
                pictureBoxQ.Visible = false;
                if (color != 0)
                {
                    wrongKey++;
                    updateReactionTimeTest();
                    //timerSpeed.Enabled = false;
                    //MessageBox.Show("WRONG (" + wrongKey.ToString() + ")");
                    //timerSpeed.Enabled = true;
                    isCorrect = false;

                }
                else
                {
                    correctKey++;
                    updateReactionTimeTest();
                    //timerSpeed.Enabled = false;
                    //MessageBox.Show("CORRECT (" + correctKey.ToString() + ")");
                    //timerSpeed.Enabled = true;
                    isCorrect = true;

                }

            }
            else
            {
                wrongKey++;
                updateReactionTimeTest();
                //timerSpeed.Enabled = false;
                //MessageBox.Show("WRONG (" + wrongKey.ToString() + ")");
                //timerSpeed.Enabled = true;
                isCorrect = false;
            }

            
        } // getReaction()

        private void saveDataToList()
        {
            timeTestObj.timeSpent = totalTime / 1000;
            timeTestObj.avgTime = avgTime / 1000;
            timeTestObj.correctAnswer = correctKey;
            timeTestObj.wrongAnswer = wrongKey;
            timeTestObj.totalAnswer = totalAnswer;
            timeTestObj.score = score;

            UserClass.timeTestList.Add(timeTestObj);
        }

        private void submitData()
        {
            StreamWriter streamData = null;
            valid = false;
            string currDate = DateTime.Now.ToString("MM-dd-yyyy");
            string name = UserClass.userList[0].userName;

            string file = "../../Data/" + name + "_" + currDate + "_ReactionTest"; //will store the file name as Name_Date_ReactionTest.dat

            if (!File.Exists(file + ".dat"))
            {
                try
                {
                    streamData = new StreamWriter(file + ".dat");

                    streamData.WriteLine(name);
                    streamData.WriteLine(timeTestObj.timeSpent.ToString("F2"));
                    streamData.WriteLine(timeTestObj.avgTime.ToString("F2"));
                    streamData.WriteLine(timeTestObj.correctAnswer.ToString());
                    streamData.WriteLine(timeTestObj.wrongAnswer.ToString());
                    streamData.WriteLine(timeTestObj.totalAnswer.ToString());
                    streamData.WriteLine(timeTestObj.score.ToString("F2"));
                } //try

                catch (IOException err)
                {
                    MessageBox.Show(err.Message);
                    valid = false;
                } //catch

                finally
                {
                    //close the file if it is not already closed
                    if (streamData != null)
                    {
                        streamData.Close();
                        MessageBox.Show("File has been written.");
                        valid = true;
                    }
                }// finally
            } //end if

            else
            {
                MessageBox.Show("This Data already Exists!");
                valid = false;
            } //else

            
            //This event opens another form

            //Hide "this" current form
            this.Hide();

            //Create a new object that will represent the next form.

            FormUser frm = new FormUser();

            //Displays the other form using its object instance

            frm.Show();

            frm = null;
            
        } // submitData()

        
    }
}
