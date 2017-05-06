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
    public partial class FormAnalysis : Form
    {
        public FormAnalysis()
        {
            InitializeComponent();
            chart1.Series[0].Points[0].SetValueY(25);
        }
    }
}
