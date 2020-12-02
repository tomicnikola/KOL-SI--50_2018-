using BusinessLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentationLayer
{
    public partial class Form1 : Form
    {
        private readonly StudentBusiness studentBusiness;
        public Form1()
        {
            this.studentBusiness = new StudentBusiness();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            List<Student> studenti = this.studentBusiness.GetAllStudents();
            listBoxStudents.Items.Clear();

            foreach (Student s in studenti)
                listBoxStudents.Items.Add(s.Id + ". " + s.Name + "(" + s.IndexNumber + ") - " + s.AverageMark);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.Name = textBox1.Text;
            s.IndexNumber = textBox2.Text;
            s.AverageMark = Convert.ToDecimal(textBox3.Text);

            if(this.studentBusiness.InsertStudent(s))
            {
                RefreshData();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
            else
            {
                MessageBox.Show("Greska");
            }
        }
    }

}
