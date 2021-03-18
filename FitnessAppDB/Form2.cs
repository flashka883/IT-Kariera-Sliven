using FitnessAppDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessAppDb
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        Form1 mainForm;
        private void Form2_Load(object sender, EventArgs e)
        {
            mainForm = new Form1();
        }

        /// <summary>
        /// Finalize the membership & add the new member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("You haven't entered first name!");
            }
            else if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("You haven't entered second name!");
            }
            else if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("You haven't entered third name!");
            }
            else if (textBox4.Text == string.Empty)
            {
                MessageBox.Show("You haven't entered age!");
            }
            else if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("You haven't entered subscription period!");
            }
            else
            {
                string firstName = textBox1.Text;
                string secondName = textBox2.Text;
                string thirdName = textBox3.Text;
                int age = int.Parse(this.textBox4.Text);

                DateTime period = DateTime.Now;
                switch (listBox1.SelectedIndex)
                {
                    case 0: period = period.AddMonths(1); break;
                    case 1: period = period.AddMonths(3); break;
                    case 2: period = period.AddMonths(6); break;
                    case 3: period = period.AddYears(1); break;
                    case 4: period = period.AddYears(2); break;
                }

                MemberInfo memberInfo = new MemberInfo();
                memberInfo.FirstName = firstName;
                memberInfo.SecondName = secondName;
                memberInfo.ThirdName = thirdName;
                memberInfo.Age = age;



                mainForm.personDbContext.MemberInfos.Add(memberInfo);

                mainForm.personDbContext.Members.Add(
                        new Member()
                        {
                            //Id = 0,
                            MemberInfoId = memberInfo,
                            DateRegistrated = DateTime.Now,
                            DateExpiration = period
                        }
                    ); 

                mainForm.personDbContext.SaveChanges();

                ClearForm();
                Visible = false;
            } 
        }

        /// <summary>
        /// Close the adding new member form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ClearForm();
            Visible = false;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearForm();
        }

        /// <summary>
        /// Clear all textBoxes & disselect the listBox item
        /// </summary>
        private void ClearForm()
        {
            foreach (var tb in this.Controls)
            {
                if (tb is TextBox)
                {
                    ((TextBox)tb).Text = String.Empty;
                }
            }

            listBox1.SelectedItem = null;
        }
    }
}
