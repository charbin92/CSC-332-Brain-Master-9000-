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
    public partial class FormUser : Form
    {
        UserClass.User userObj = new UserClass.User();
        UserClass.TestScores testObj = new UserClass.TestScores();
        public double concScore;
        public FormUser()
        {
            InitializeComponent();
            //lblUserName.Text = userObj.userName;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            lblUserName.Text = UserClass.userList[0].userName;
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
    }
}
