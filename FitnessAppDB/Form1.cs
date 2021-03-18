using FitnessAppDB.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace FitnessAppDb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public PersonDbContext personDbContext = new PersonDbContext();
        Form2 newMembershipForm;
        private void Form1_Load(object sender, EventArgs e)
        {
            newMembershipForm = new Form2();
        }

        /// <summary>
        /// Open the form to create a new membership
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            newMembershipForm.ShowDialog();
        }
        /// <summary>
        /// Search a member by id
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Member member = personDbContext.Members.Find(int.Parse(textBox1.Text));
            if (member != null)
            {
                textBox2.Text = member.ToString();
            }
            else
            {
                textBox2.Text = $"В базата данни не конфигурира карта с ид: {textBox1.Text}";
            }
        }
    }
}
