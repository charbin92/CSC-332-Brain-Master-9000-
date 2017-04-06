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
    public partial class frmUser : Form
    {
        UserClass.User userObj = new UserClass.User();
        public frmUser()
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
            frmMemoryTest frm = new frmMemoryTest();

            // Displays the other form using its object instance
            frm.Show();

            frm = null;
        }
    }
}
