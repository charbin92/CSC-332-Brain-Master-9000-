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
    public partial class FormMemoryTest : Form
    {
        int correct = 0;
        int incorrect = 0;
        double score = 0;
        int totalQuestions = 0;
        string[] wordArr = { "Knife", "Toy", "Chocolate", "Blue", "Left", "House"};
        string[] choicesArr = { "Boy", "Right", "Knife", "Computer", "House", "Chocolate"};
        DateTime startTime = DateTime.Now;
        double end = 0;
        UserClass.MemoryTest memoryTestObj = new UserClass.MemoryTest();
        bool valid = false;

        public FormMemoryTest()
        {
            InitializeComponent();
        }

        public void showWord(int i)
        {
            lblwordList.Text = wordArr[i];          
        }

        private void btnBegin_Click(object sender, EventArgs e)
        {
            pnlInstructions.Visible = false;
            pnlWords.Visible = true;
            lblwordList.Text = "";

            for (int i = 0; i < wordArr.Length; i++)
            {
                DateTime start = DateTime.Now;
                while (DateTime.Now.Subtract(start).Seconds <1)
                {
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                }
                showWord(i);
            }
            pnlWords.Visible = false;
            pnlInstructions2.Visible = true;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            pnlInstructions2.Visible = false;
            pnlYesNo.Visible = true;

            lblWord.Text = choicesArr[totalQuestions];
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            //bool ans = true;
            if (itsInThere(choicesArr[totalQuestions], wordArr))
            {
                correct += 1;
            }
            else
                incorrect += 1;

            totalQuestions++;

            if(totalQuestions  < choicesArr.Length)
            {
                lblWord.Text = choicesArr[totalQuestions];
            }

            else
            {
                end = DateTime.Now.Subtract(startTime).Seconds;
                score = (double)correct / (double)totalQuestions;
                score *= 100;
                string msg = "Total Correct: ";
                msg += correct.ToString() + "\r\n";
                msg += "Total Incorrect: ";
                msg += incorrect.ToString() + "\r\n";
                msg += "Total Questions Asked: ";
                msg += totalQuestions.ToString() + "\r\n";
                msg += "Time Spent: ";
                msg += end.ToString() + " seconds" + "\r\n";
                msg += "Score: ";
                msg += score.ToString("F2");
                MessageBox.Show(msg);
                collectData();
                submitData();
            }
        }

        private void btnNo_Click_1(object sender, EventArgs e)
        {
            //bool ans = false;
            if (!itsInThere(choicesArr[totalQuestions], wordArr))
            {
                correct += 1;
            }
            else
                incorrect += 1;

            totalQuestions++;

            if (totalQuestions < choicesArr.Length)
            {
                lblWord.Text = choicesArr[totalQuestions];
            }

            else
            {
                end = DateTime.Now.Subtract(startTime).Seconds;
                score = (double)correct / (double)totalQuestions;
                score *= 100;
                string msg = "Total Correct: ";
                msg += correct.ToString() + "\r\n";
                msg += "Total Incorrect: ";
                msg += incorrect.ToString() + "\r\n";
                msg += "Total Questions Asked: ";
                msg += totalQuestions.ToString() + "\r\n";
                msg += "Time Spent: ";
                msg += end.ToString() + " seconds" + "\r\n";
                msg += "Score: ";
                msg += score.ToString("F2");
                MessageBox.Show(msg);
                collectData();
                submitData();
            }
        }

        private void collectData()
        {
            memoryTestObj.timeSpent = end;
            memoryTestObj.correctAnswers = correct;
            memoryTestObj.wrongAnswers = incorrect;
            memoryTestObj.totalAnswers = totalQuestions;
            memoryTestObj.score = score;
        } 

        private Boolean itsInThere(string choice, string[] words)
        {
            bool tempBool = false;

            for (int i = 0; i < words.Length; i++)
            {
                if (words.Contains(choice))
                    tempBool = true;
            }

            return tempBool;
        }

        private void btnNextWord_Click(object sender, EventArgs e)
        {
            lblWord.Text = choicesArr[totalQuestions];
        }

        

        private void saveScores()
        {
            StreamWriter streamData = null;
            valid = false;
            string currDate = DateTime.Now.ToString("MM-dd-yyyy");
            string name = UserClass.userList[0].userName;

            string file = "../../Data/" + name + "_" + currDate + "_MemoryTest"; //will store the file name as Name_Date_MemoryTest.dat

            if (!File.Exists(file + ".dat"))
            {
                try
                {
                    streamData = new StreamWriter(file + ".dat");

                    streamData.WriteLine(name);
                    streamData.WriteLine(memoryTestObj.timeSpent.ToString("F2"));
                    streamData.WriteLine(memoryTestObj.correctAnswers.ToString());
                    streamData.WriteLine(memoryTestObj.wrongAnswers.ToString());
                    streamData.WriteLine(memoryTestObj.totalAnswers.ToString());
                    streamData.WriteLine(memoryTestObj.score.ToString("F2"));
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
        } //saveScore()

        private void submitData()
        {
            UserClass.memoryList.Add(memoryTestObj);
            saveScores();
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
