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
    public partial class MainForm : Form
    {
        Form1 addform;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LinkedList<string> _linkstring = new LinkedList<string>();
            List<string> _list = new List<string>();
            StreamReader f = new StreamReader("text.txt");
            bool tmp = true;
            while ( tmp == true)
                {
                
                while (f.Peek() > -1)
                {
                    string s = f.ReadLine();

                    if (s != "-=-")
                    {
                        _linkstring.AddLast(s);
                    }
                    else
                    {
                        tmp = false;
                        foreach (string x in _linkstring)
                        {
                            richTextBox1.Text += x + Environment.NewLine;
                        }
                        _linkstring.Clear();
                        richTextBox1.Text += Environment.NewLine;
                    }
                }
            }
            f.Close();
        }

        private void добавитьТерминToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            addform = new Form1();            
            addform.Show();         
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void удалитьТерминToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        bool Find_Termin(string findTerm)
        {
            StreamReader f = new StreamReader("text.txt");
            string sr = null;
            while ((sr = f.ReadLine()) != null)
            {
                if (sr == findTerm)
                {
                    MessageBox.Show(String.Format("Данный термин \"{0}\" уже задан", sr));
                    f.Close();
                    return false;
                }
                else
                {
                    while (sr != "-=-")
                    {
                        sr = f.ReadLine();
                    }
                }
            }
            f.Close();
            return true;
        }
    }
}
