using System;
using System.Windows.Forms;

namespace Notpad
{
    public partial class Form1 : Form
    {
        private string OurFileName;

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
    }
}