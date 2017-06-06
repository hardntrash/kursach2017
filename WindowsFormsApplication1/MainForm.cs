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
        DeleteForm delform;
        SearchForm searchform;
        public List<string> strList;
        public MainForm()
        {
            InitializeComponent();
            strList = new List<string>();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = "Поиск термина";
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
            this.Hide();
            delform = new DeleteForm();
            delform.Show();
        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = null;
        }

        private void toolStripTextBox1_Leave(object sender, EventArgs e)
        {
                toolStripTextBox1.Text = "Поиск термина";
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                search();
            }
            if(e.KeyCode == Keys.Space)
            {
                e.Handled = true;
            }
        }

        void search()
        {
            searchform = new SearchForm();
            string searchTerm = toolStripTextBox1.Text;
            string file = "text.txt";
            StreamReader f = new StreamReader(file);
            string str = null;
            while ((str = f.ReadLine()) != null)
            {
                if (str == searchTerm)
                {
                    strList.Add(str);
                    do
                    {
                        strList.Add(f.ReadLine());
                    }
                    while (str == "-=-");
                    this.Hide();
                    searchform.Show();
                    f.Close();
                    break;
                }
            }
            f.Close();
        }
    }
}
