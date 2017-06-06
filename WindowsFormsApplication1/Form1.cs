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
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        LinkedList<string> _linkString;
        MainForm mainform;
        public Form1()
        {
            InitializeComponent();
            mainform = new MainForm();
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            _linkString = new LinkedList<string>(richTextBox1.Lines);
            if (textBox1.Text != "")
            {
                _linkString.AddFirst(textBox1.Text.Substring(0, 1).ToUpper() + textBox1.Text.Substring(1, textBox1.Text.Length - 1));
            }
            _linkString.AddLast("-=-");
            bool chg = Find_Termin(Convert.ToString(_linkString.First.Value));
            if(chg == true)
            {
                Save_List(_linkString);
            }
        }       
        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            if ((richTextBox1.Text.Length % 100) == 0)
            {
                SendKeys.Send("~");
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainform = new MainForm();
            mainform.Show();
        }

        private void Save_List(LinkedList<string> lnkList)
        {
            if(textBox1.Text != "")
            {
                if (richTextBox1.Text != "")
                {
                    StreamWriter f = File.AppendText("text.txt");
                    foreach (string x in lnkList)
                    {
                        f.WriteLine(x);
                    }
                    f.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Поле \"Описание\" пусто", "Некоректный ввод", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Поле \"Термин\" пусто", "Некоректный ввод", MessageBoxButtons.OK);
            }            
        }
        bool Find_Termin(string findTerm)
        {
            StreamReader f = new StreamReader("text.txt");
            string sr = null;
            while((sr=f.ReadLine()) != null)
            {
                if(sr == findTerm)
                {
                    MessageBox.Show(String.Format( "Данный термин \"{0}\" уже задан", sr));
                    f.Close();
                    return false;
                }
                else
                {
                    while(sr != "-=-")
                    {
                        sr = f.ReadLine();
                    }
                }
            }
            f.Close();
            return true;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar  == (int)Keys.Space)
            {
                e.Handled = true;
            }
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
