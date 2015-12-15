using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPractic
{
    public interface IMainForm
    {
        string filePath { get; }
        string text { get; set; }
        event EventHandler FileOpenClick;
        event EventHandler SaveClick;

    }

    public partial class Form1 : Form, IMainForm
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += butSelectFile_Click;
            button2.Click += butSaveClick;
        }

        private void butSaveClick(object sender, EventArgs e)
        {
            if (SaveClick != null) 
            {
                SaveClick(this,EventArgs.Empty);
            }
        }

        public string filePath { get { return textBox2.Text; } }

        public string text
        {
            get { return textBox1.Text; }
            set { textBox1.Text=value; }}

        public event EventHandler FileOpenClick; 
        public event EventHandler SaveClick;

        private void butSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text files|*.txt|All files|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;
                if (FileOpenClick != null)
                {
                    FileOpenClick(this, EventArgs.Empty);
                }

            }
        }
      
    }
    
}
