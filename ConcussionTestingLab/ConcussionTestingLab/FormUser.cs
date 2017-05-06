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
    public partial class FormUser : Form
    {
        UserClass.User userObj = new UserClass.User();
        //UserClass.TestScores testObj = new UserClass.TestScores();
        double concScore;
        double memScore;
        double reactScore;
        bool valid;
        int index = UserClass.testScoreList.Count;

        public FormUser()
        {
            InitializeComponent();
            //lblUserName.Text = userObj.userName;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            lblUserName.Text = UserClass.userList[0].userName;
            addScoresToList();
            displayScores();
        }

        private void btnMemoryTest_Click(object sender, EventArgs e)
        {
            //THIS event opens another form

            // Hide "this" current form
            this.Hide();

            // Create a new object that will represent the next form.
            FormMemoryTest frm = new FormMemoryTest();

            // Displays the other form using its object instance
            frm.Show();

            frm = null;
        }

        private void btnReactionTest_Click(object sender, EventArgs e)
        {
            //THIS event opens another form

            // Hide "this" current form
            this.Hide();

            // Create a new object that will represent the next form.
            FormReactionTimeTest frm = new FormReactionTimeTest();

            // Displays the other form using its object instance
            frm.Show();

            frm = null;
        }

        private void btnConcentration_Click(object sender, EventArgs e)
        {
            //THIS event opens another form

            // Hide "this" current form
            this.Hide();

            // Create a new object that will represent the next form.
            FormConcentrationTest frm = new FormConcentrationTest();

            // Displays the other form using its object instance
            frm.Show();

            frm = null;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(index < UserClass.testScoreList.Count)
                saveTestScores();
            this.Close();
            Application.Exit();
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            //THIS event opens another form

            // Hide "this" current form
            this.Hide();

            // Create a new object that will represent the next form.
            FormAnalysis frm = new FormAnalysis();

            // Displays the other form using its object instance
            frm.Show();

            frm = null;
        }

        private void addScoresToList()
        {
            if(UserClass.memoryList.Count > 0 && UserClass.concentrationList.Count > 0 && UserClass.timeTestList.Count > 0)
            {
                if(UserClass.memoryList.Count == UserClass.concentrationList.Count && UserClass.memoryList.Count == UserClass.timeTestList.Count)
                {
                    for(int i = 0; i < UserClass.memoryList.Count; i++)
                    {
                        UserClass.TestScores testObj = new UserClass.TestScores();
                        testObj.curDate = DateTime.Today;
                        testObj.memoryScore = UserClass.memoryList[i].score;
                        testObj.concentrationScore = UserClass.concentrationList[i].score;
                        testObj.reactionTimeScore = UserClass.timeTestList[i].score;
                        UserClass.testScoreList.Add(testObj);
                    } // for()
                } // endif
            } // endif
        } // addScoresToList()

        private void displayScores()
        {
            rtbResults.Text += "Recent Scores: \r\n";

            foreach (UserClass.TestScores obj in UserClass.testScoreList)
            {
                rtbResults.Text += "\r\n" + obj.curDate.ToString("MM/dd/yyyy") + "\r\n";
                rtbResults.Text += "\t Concentration: " + obj.concentrationScore.ToString("F2") + "\r\n";
                rtbResults.Text += "\t Memory: " + obj.memoryScore.ToString("F2") + "\r\n";
                rtbResults.Text += "\t Reaction: " + obj.reactionTimeScore.ToString("F2") + "\r\n";
            }
        } // displayScores()

        private void saveTestScores()
        {
            string file = "../../Data/" + UserClass.userList[0].userID + "_" + UserClass.userList[0].userName; // will store the file name as M#_Name.dat

            if (File.Exists(file + ".dat"))
            {
                try
                {

                    for (int i = index; i < UserClass.testScoreList.Count; i++)
                    {
                        File.AppendAllText(file + ".dat", "\r\n" + UserClass.testScoreList[i].curDate.ToString("MM/dd/yyyy") + " " + UserClass.testScoreList[i].concentrationScore.ToString() + " " + UserClass.testScoreList[i].memoryScore.ToString() + " " + UserClass.testScoreList[i].reactionTimeScore.ToString());
                    }
                } // try

                catch (IOException err)
                {
                    MessageBox.Show(err.Message);
                } // catch

                finally
                {
                    MessageBox.Show("File has been appended.");
                    valid = true;
                } // finally
            } // end if

            else
            {
                MessageBox.Show("Something went wrong!");
                valid = false;
            } // else
        } // saveTestScores()
    }
}
