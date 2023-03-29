using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderCreator
{
    public partial class Form : System.Windows.Forms.Form
    {
        public string Direct { get; private set; }

        public Form()
        {
            InitializeComponent();
        }

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                Direct = folderBrowserDialog.SelectedPath;
                textBox1.Text = Direct;

                textBox2.Enabled = true;
                textBox3.Enabled = true;
                CreatFolder.Enabled = true;
            }
        }

        private void CreatFolder_Click(object sender, EventArgs e)
        {
            if(textBox2.Text != "" && textBox3.Text != "")
            {
                Creat();
                MessageBox.Show("Pastas criadas com sucesso!");
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        public void Creat()
        {
            string nameFolder = textBox3.Text;
            int qntFolder = int.Parse(textBox2.Text);

            try
            {
                for (int i = 1; i <= qntFolder; i++)
                {
                    Directory.CreateDirectory(Direct + $@"\{nameFolder} {i}");
                }
            }
            catch (IOException e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
