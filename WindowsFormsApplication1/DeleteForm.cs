using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class DeleteForm : Form
    {
        MainForm mainform;
        public DeleteForm()
        {
            InitializeComponent();
            mainform = new MainForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> strList = new List<string>();
            string deleteTerm = textBox1.Text;
            string file = "text.txt";
            StreamReader rf = new StreamReader(file);
            string str = null;
            while ((str = rf.ReadLine()) != null)
            {
                if (str == deleteTerm)
                {
                    do
                    {
                        rf.ReadLine();
                    }
                    while (str == "-=-");
                    rf.ReadLine();
                    MessageBox.Show("термин удален");
                }
                else
                {
                    strList.Add(str);
                }
            }
            rf.Close();
            StreamWriter wf = new StreamWriter(file);
            foreach (string x in strList)
            {
                wf.WriteLine(x);
            }
            wf.Close();
            mainform.Show();
            this.Close();
        }

        private void DeleteForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainform.Show();
        }
    }
}
