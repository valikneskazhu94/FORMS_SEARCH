using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (bookshopsEntities db = new bookshopsEntities())
            {
                var books = db.Books.Select(a => new {
                    a.NameBook,
                    a.Authors.FirstName
                }).ToList();
                dataGridView1.DataSource = books;
            }
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;

            using (bookshopsEntities db = new bookshopsEntities())
            {
                if (radioButton1.Enabled == true)
                {
                    radioButton2.Enabled = false;
                    var books = db.Books.Select(a => new
                    {
                        a.NameBook,
                        a.Authors.FirstName,
                        a.Authors.LastName,
                    }).Where(x => x.FirstName.Contains(textBox1.Text)).ToList();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = books;
                }
                else if (radioButton2.Enabled ==true)
                {
                    radioButton1.Enabled = false;
                    var books = db.Books.Select(a => new
                    {
                        a.NameBook,
                        a.Authors.FirstName,
                        a.Authors.LastName,
                    }).Where(x => x.LastName.Contains(textBox1.Text)).ToList();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = books;
                }
            }
        }
    }
}
