using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Win.Models;

namespace Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            if(user =="" || pass == "")
            {
                MessageBox.Show("Nhap thong tin Dang nhap");
            }
            else
            {
                using (var context= new HCDContext())
                {
                    TaiKhoan tk = context.TaiKhoans.Where(x => x.User == user && x.Pass == pass).SingleOrDefault();
                    if(tk == null)
                    {
                        MessageBox.Show("Thong tin dang nhap sai");
                    }
                    else if(tk.Status== false)
                    {
                        MessageBox.Show("Tai khoan da bi khoa");

                    }
                    else
                    {
                        if (tk.Role == 1)
                        {
                            QL form = new QL();
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            CN form = new CN();
                            form.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }
    }
}
