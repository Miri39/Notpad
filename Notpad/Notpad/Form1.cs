using System;
using System.Windows.Forms;

namespace Notpad
{
    public partial class Form1 : Form
    {
        private string OurFileName;
        private string LastFindWord;
        private bool LastFindDown;
        private bool LastFindMatchCase;

        void Save(string filename)
        {
            OurFileName = filename;
            textBox.SaveFile(filename);
        }

        void SaveAs()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Save(saveFileDialog1.FileName);
            }
        }
        
        public Form1()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        bool CheckChanges()
        {
            return true;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckChanges())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox.LoadFile(openFileDialog1.FileName);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OurFileName))
            {
                SaveAs();
            }
            else
            {
                Save(OurFileName);
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            Form2 find = new Form2();
            find.Show(this);
            
        }

        public void DoFind(string search, bool down, bool match_case)
        {
            LastFindWord = search;
            LastFindDown = down;
            LastFindMatchCase = match_case;

            if (down)
            {
                if (match_case)
                {
                    textBox.Find(search, textBox.SelectionStart + 1, RichTextBoxFinds.MatchCase);
                }
                else
                {
                    textBox.Find(search, textBox.SelectionStart + 1, RichTextBoxFinds.None);
                }
            }
        }
 
        public void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 parent_form = (Form1)Owner;
            Form2 form2 = new Form2();
            parent_form.DoFind(form2.textFindWhat.Text, form2.radioButtonDown.Checked,form2.checkMatchCase.Checked);
        }
    }
}