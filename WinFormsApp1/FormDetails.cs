using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class FormDetails : Form
    {
        public FormDetails(string name, string description)
        {
            InitializeComponent();
            this.textBox1.Text = name;
            this.textBox2.Text = description;
        }
    }
}
