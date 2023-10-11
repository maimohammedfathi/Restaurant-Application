using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionOfProject.Entity;

namespace VersionOfProject
{
    public partial class Charts : Form
    {
        WFContext con;
        public Charts()
        {
            InitializeComponent();
            con = new WFContext();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            AdminDashbordForm admin = new AdminDashbordForm();
            admin.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Charts_Load(object sender, EventArgs e)
        {
            LabelForNumberOfOrderToday.Text = "";
            LabelForNumberOfOrderToday.Text = con.orders.Where(o => o.OrderDate.Day == DateTime.Now.Day).ToList().Count.ToString();
            LabLForNumberOForders.Text = "";
            LabLForNumberOForders.Text = con.orders.Where(o => o.OrderDate.Month == DateTime.Now.Month).ToList().Count.ToString();
            LabelForEmployCount.Text = "";
            LabelForEmployCount.Text = con.Employies.ToList().Count.ToString();
            LabelForFoodCount.Text = "";
            LabelForFoodCount.Text = con.Foods.ToList().Count().ToString();
            labelfordrinks.Text = " ";
            labelfordrinks.Text = con.Drinks.ToList().Count.ToString();
            LabelForFoodCategory.Text = "";
            LabelForFoodCategory.Text = con.FoodCategories.ToList().Count.ToString();
            LabelForDrinkCategory.Text = "";
            LabelForDrinkCategory.Text = con.DrinkCategories.ToList().Count.ToString();

        }
    }
}
