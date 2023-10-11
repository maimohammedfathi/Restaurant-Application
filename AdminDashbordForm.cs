using Microsoft.EntityFrameworkCore;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using Syncfusion.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using VersionOfProject.Entity;
using VersionOfProject.PL;
using VersionOfProject.VeiwModel;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VersionOfProject
{

    public partial class AdminDashbordForm : Form
    {

        EmployePL employees;
        FoodPL foods;
        DrinkPl Drinkes;
        CategoryFoodPL categoryFoods;
        CategoryDrinkPL CategoryDrinks;
        WFContext Context;
        decimal costFood;
        decimal costDrink;
        decimal totalcost;
        decimal currentProfite;
        string Percentage;
        decimal Water_Bill;
        decimal electricity_Bill;
        decimal gas_Bill;
        decimal rent;




        public AdminDashbordForm()
        {
            InitializeComponent();
            // DGHome.RowHeadersDefaultCellStyle.Font = new Font("Tahoma", 5);

            employees = new EmployePL();
            foods = new FoodPL();
            Drinkes = new DrinkPl();
            Context = new WFContext();
            categoryFoods = new CategoryFoodPL();
            CategoryDrinks = new CategoryDrinkPL();
            display();
            if (Context.AdminHomes.ToList().Count() == 0)
            {
                newadmin();
            }
            DGHome.DataSource = null;
            DGHome.DataSource = Context.AdminHomes.ToList();

        }
        private void AllTaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AllTaps.SelectedIndex)
            {
                case 0:
                    display();
                    if (Context.AdminHomes.ToList().Count() == 0)
                    {
                        newadmin();
                    }
                    DGHome.DataSource = null;
                    DGHome.DataSource = Context.AdminHomes.ToList();
                    break;
                case 1:
                    DGemployee.DataSource = null;
                    DGemployee.DataSource = employees.GetAll();
                    //DGemployee.ClearSelection();
                    btn_Add.Enabled = false;
                    // DGemployee.DefaultCellStyle.Font = new Font("Tahoma", 16);

                    break;
                case 2:

                    DGFood.DataSource = null;
                    DGFood.DataSource = foods.GetAll();

                    btnAdd_Food.Enabled = false;
                    CFoodDisplay();
                    break;
                case 3:
                    DGDrink.DataSource = null;
                    DGDrink.DataSource = Drinkes.GetAll();
                    btn_Add_Drink.Enabled = false;
                    CDrinkDisplay();
                    break;
                case 4:
                    DGCacher.DataSource = null;
                    DGCacher.DataSource = Context.Users.ToList();
                    break;
                case 5:
                    DG_CFood.DataSource = null;
                    DG_CFood.DataSource = categoryFoods.GetAll();
                    btnCFood_Add.Enabled = false;

                    break;
                case 6:
                    DG_CDrink.DataSource = null;
                    DG_CDrink.DataSource = CategoryDrinks.GetAll();
                    btn_CDrink_Add.Enabled = false;


                    break;
            }

        }
        #region Employee


        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                decimal salary = decimal.Parse(txt_Salary.Text);
                Employe emp = new Employe()
                {
                    Name = txt_Name.Text,
                    Address = txt_Address.Text,
                    JobDescription = txt_JobDescraption.Text,
                    PhoneNumber = txt_Phone.Text,
                    Salary = salary
                };
                employees.Add(emp);

                txt_Name.Text = "";
                txt_Address.Text = "";
                txt_JobDescraption.Text = "";
                txt_Phone.Text = "";
                txt_Salary.Text = "";
                DGemployee.DataSource = null;
                DGemployee.DataSource = employees.GetAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            int item = DGemployee.SelectedRows.Count;
            if (item == 1)
            {
                Employe selected = DGemployee.SelectedRows[0].DataBoundItem as Employe;


                try
                {
                    decimal salary = decimal.Parse(txt_Salary.Text);
                    Employe emp = new Employe()
                    {
                        Id = selected.Id,
                        Name = txt_Name.Text,
                        Address = txt_Address.Text,
                        JobDescription = txt_JobDescraption.Text,
                        PhoneNumber = txt_Phone.Text,
                        Salary = salary
                    };
                    employees.Edit(emp);
                    txt_Name.Text = "";
                    txt_Address.Text = "";
                    txt_JobDescraption.Text = "";
                    txt_Phone.Text = "";
                    txt_Salary.Text = "";
                    DGemployee.DataSource = null;
                    DGemployee.DataSource = employees.GetAll();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one Employee");

            }

        }
        private void btn_Remove_Click(object sender, EventArgs e)
        {
            int item = DGemployee.SelectedRows.Count;
            if (item == 1)
            {
                Employe selected = DGemployee.SelectedRows[0].DataBoundItem as Employe;
                try
                {
                    decimal salary = decimal.Parse(txt_Salary.Text);
                    Employe emp = new Employe()
                    {
                        Id = selected.Id,
                        Name = txt_Name.Text,
                        Address = txt_Address.Text,
                        JobDescription = txt_JobDescraption.Text,
                        PhoneNumber = txt_Phone.Text,
                        Salary = salary
                    };
                    selected = null;
                    employees.Delete(emp);
                    txt_Name.Text = "";
                    txt_Address.Text = "";
                    txt_JobDescraption.Text = "";
                    txt_Phone.Text = "";
                    txt_Salary.Text = "";
                    DGemployee.DataSource = null;
                    DGemployee.DataSource = employees.GetAll();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one Employee");
            }
        }
        private void DGemployee_SelectionChanged(object sender, EventArgs e)
        {
            int item = DGemployee.SelectedRows.Count;
            if (item == 1)
            {
                btn_Add.Enabled = false;

                Employe selected = DGemployee.SelectedRows[0].DataBoundItem as Employe;
                txt_Name.Text = selected.Name;
                txt_Address.Text = selected.Address;
                txt_JobDescraption.Text = selected.JobDescription;
                txt_Phone.Text = selected.PhoneNumber;
                txt_Salary.Text = selected.Salary.ToString();
                btn_Edit.Enabled = true;
                btn_Remove.Enabled = true;

            }

        }

        private void BtnCleare_Click(object sender, EventArgs e)
        {
            // employ 

            txt_Name.Text = "";
            txt_Address.Text = "";
            txt_JobDescraption.Text = "";
            txt_Phone.Text = "";
            txt_Salary.Text = "";
            btn_Add.Enabled = true;
            DGemployee.ClearSelection();
            btn_Remove.Enabled = false;
            btn_Edit.Enabled = false;
        }
        #endregion

        #region Food
        public void CFoodDisplay()
        {
            CFoodList.DataSource = null;
            CFoodList.DataSource = categoryFoods.GetAll();
            CFoodList.DisplayMember = "Name";
            CFoodList.ValueMember = "Id";
            // CFoodList.SelectedIndex = 0;
        }

        private void btnAdd_Food_Click(object sender, EventArgs e)
        {
            try
            {
                int uniteOnStock = int.Parse(txt_unit_on_stock.Text);
                decimal cost = decimal.Parse(txt_Cost.Text);
                decimal price = decimal.Parse(txt_Price.Text);
                int categoryID = int.Parse(CFoodList.SelectedValue.ToString());

                Food food = new Food()
                {
                    Name = txt_Name_Food.Text,
                    Cost = cost,
                    Price = price,
                    TotalAmount = uniteOnStock,
                    UniteOnStock = uniteOnStock,
                    CategoryID = categoryID
                };
                foods.Add(food);
                txt_unit_on_stock.Text = "";
                txt_Price.Text = "";
                txt_Total_Amount.Text = "";
                txt_Name_Food.Text = "";
                txt_Cost.Text = "";
                DGFood.DataSource = null;
                DGFood.DataSource = foods.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEdit_Food_Click(object sender, EventArgs e)
        {
            int item = DGFood.SelectedRows.Count;
            if (item == 1)
            {
                FoodVeiwModel selected = DGFood.SelectedRows[0].DataBoundItem as FoodVeiwModel;


                try
                {
                    int uniteOnStock = int.Parse(txt_unit_on_stock.Text);
                    decimal cost = decimal.Parse(txt_Cost.Text);
                    decimal price = decimal.Parse(txt_Price.Text);
                    int categoryID = int.Parse(CFoodList.SelectedValue.ToString());
                    Food food = new Food()
                    {
                        Id = selected.Id,
                        Name = txt_Name_Food.Text,
                        Cost = cost,
                        Price = price,
                        UniteOnStock = uniteOnStock,
                        CategoryID = categoryID

                    };
                    foods.Edit(food);
                    txt_unit_on_stock.Text = "";
                    txt_Price.Text = "";
                    txt_Total_Amount.Text = "";
                    txt_Name_Food.Text = "";
                    txt_Cost.Text = "";
                    DGFood.DataSource = null;
                    DGFood.DataSource = foods.GetAll();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one Food");
            }
        }

        private void btnRemove_Food_Click(object sender, EventArgs e)
        {
            int item = DGFood.SelectedRows.Count;
            if (item == 1)
            {
                FoodVeiwModel selected = DGFood.SelectedRows[0].DataBoundItem as FoodVeiwModel;

                try
                {
                    int uniteOnStock = int.Parse(txt_unit_on_stock.Text);
                    decimal cost = decimal.Parse(txt_Cost.Text);
                    int totalamount = int.Parse(txt_Total_Amount.Text);
                    decimal price = decimal.Parse(txt_Price.Text);
                    int categoryID = int.Parse(CFoodList.SelectedValue.ToString());
                    Food food = new Food()
                    {
                        Id = selected.Id,
                        Name = txt_Name_Food.Text,
                        Cost = cost,
                        Price = price,
                        TotalAmount = totalamount,
                        UniteOnStock = uniteOnStock,
                        CategoryID = categoryID,

                    };
                    foods.Delete(food);
                    txt_unit_on_stock.Text = "";
                    txt_Price.Text = "";
                    txt_Total_Amount.Text = "";
                    txt_Name_Food.Text = "";
                    txt_Cost.Text = "";
                    DGFood.DataSource = null;
                    DGFood.DataSource = foods.GetAll();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one Food");

            }
        }

        private void DGFood_SelectionChanged(object sender, EventArgs e)
        {
            int item = DGFood.SelectedRows.Count;
            if (item == 1)
            {
                btnAdd_Food.Enabled = false;
                FoodVeiwModel selected = DGFood.SelectedRows[0].DataBoundItem as FoodVeiwModel;
                txt_Name_Food.Text = selected.Name;
                txt_Price.Text = selected.Price.ToString();
                txt_Cost.Text = selected.Cost.ToString();
                txt_unit_on_stock.Text = selected.UniteOnStock.ToString();
                txt_Total_Amount.Text = selected.TotalAmount.ToString();
                CFoodList.SelectedValue = selected.CategoryID;
                btnEdit_Food.Enabled = true;
                btnRemove_Food.Enabled = true;
            }

        }

        private void btnClearFood_Click(object sender, EventArgs e)
        {

            txt_unit_on_stock.Text = "";
            txt_Price.Text = "";
            txt_Total_Amount.Text = "";
            txt_Name_Food.Text = "";
            txt_Cost.Text = "";
            btnAdd_Food.Enabled = true;
            DGFood.ClearSelection();
            CFoodDisplay();
            btnEdit_Food.Enabled = false;
            btnRemove_Food.Enabled = false;
        }
        #endregion

        #region Drink

        public void CDrinkDisplay()
        {
            CDrinkList.DataSource = null;
            CDrinkList.DataSource = CategoryDrinks.GetAll();
            CDrinkList.DisplayMember = "Name";
            CDrinkList.ValueMember = "Id";
            //CDrinkList.SelectedIndex = 0;
        }
        private void btn_Add_Drink_Click(object sender, EventArgs e)
        {

            try
            {
                int uniteOnStock = int.Parse(txt_Drink_unit_on_stock.Text);
                decimal cost = decimal.Parse(txt_Drink_Cost.Text);
                //int totalamount = int.Parse(txt_Drink_total_mount.Text);
                decimal price = decimal.Parse(txt_Drink_Price.Text);
                Drinks drink = new Drinks()
                {
                    Name = txt_NameDrink.Text,
                    Cost = cost,
                    Price = price,
                    TotalAmount = uniteOnStock,
                    UniteOnStock = uniteOnStock,
                    CategoryID = int.Parse(CDrinkList.SelectedValue.ToString())

                };
                Drinkes.Add(drink);

                txt_Drink_unit_on_stock.Text = "";
                txt_Drink_Cost.Text = "";
                txt_Drink_total_mount.Text = "";
                txt_Drink_Price.Text = "";
                txt_NameDrink.Text = "";
                DGDrink.DataSource = null;
                DGDrink.DataSource = Drinkes.GetAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Edit_Drink_Click(object sender, EventArgs e)
        {
            int item = DGDrink.SelectedRows.Count;
            if (item == 1)
            {
                DrinkViewModel selected = DGDrink.SelectedRows[0].DataBoundItem as DrinkViewModel;


                try
                {
                    int uniteOnStock = int.Parse(txt_Drink_unit_on_stock.Text);
                    decimal cost = decimal.Parse(txt_Drink_Cost.Text);
                    int totalamount = int.Parse(txt_Drink_total_mount.Text);
                    decimal price = decimal.Parse(txt_Drink_Price.Text);
                    Drinks Drink = new Drinks()
                    {
                        Id = selected.Id,
                        Name = txt_NameDrink.Text,
                        Cost = cost,
                        Price = price,
                        TotalAmount = totalamount,
                        UniteOnStock = uniteOnStock,
                        CategoryID = int.Parse(CDrinkList.SelectedValue.ToString())

                    };
                    Drinkes.Edit(Drink);

                    txt_Drink_unit_on_stock.Text = "";
                    txt_Drink_Cost.Text = "";
                    txt_Drink_total_mount.Text = "";
                    txt_Drink_Price.Text = "";
                    txt_NameDrink.Text = "";
                    DGDrink.DataSource = null;
                    DGDrink.DataSource = Drinkes.GetAll();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one Drink");

            }
        }

        private void btn_Remove_Drink_Click(object sender, EventArgs e)
        {
            int item = DGDrink.SelectedRows.Count;
            if (item == 1)
            {
                DrinkViewModel selected = DGDrink.SelectedRows[0].DataBoundItem as DrinkViewModel;
                try
                {
                    int uniteOnStock = int.Parse(txt_Drink_unit_on_stock.Text);
                    decimal cost = decimal.Parse(txt_Drink_Cost.Text);
                    int totalamount = int.Parse(txt_Drink_total_mount.Text);
                    decimal price = decimal.Parse(txt_Drink_Price.Text);
                    Drinks Drink = new Drinks()
                    {
                        Id = selected.Id,
                        Name = txt_NameDrink.Text,
                        Cost = cost,
                        Price = price,
                        TotalAmount = totalamount,
                        UniteOnStock = uniteOnStock,
                    };
                    Drinkes.Delete(Drink);

                    txt_Drink_unit_on_stock.Text = "";
                    txt_Drink_Cost.Text = "";
                    txt_Drink_total_mount.Text = "";
                    txt_Drink_Price.Text = "";
                    txt_NameDrink.Text = "";
                    DGDrink.DataSource = null;
                    DGDrink.DataSource = Drinkes.GetAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one Drink");

            }
        }

        private void DGDrink_SelectionChanged(object sender, EventArgs e)
        {
            int item = DGDrink.SelectedRows.Count;
            if (item == 1)
            {
                btn_Add_Drink.Enabled = false;
                DrinkViewModel selected = DGDrink.SelectedRows[0].DataBoundItem as DrinkViewModel;
                txt_NameDrink.Text = selected.Name;
                txt_Drink_Price.Text = selected.Price.ToString();
                txt_Drink_Cost.Text = selected.Cost.ToString();
                txt_Drink_unit_on_stock.Text = selected.UniteOnStock.ToString();
                txt_Drink_total_mount.Text = selected.TotalAmount.ToString();
                CDrinkList.SelectedValue = selected.CategoryID;
                btn_Edit_Drink.Enabled = true;
                btn_Remove_Drink.Enabled = true;
            }

        }
        private void btnClearDrink_Click(object sender, EventArgs e)
        {
            txt_Drink_unit_on_stock.Text = "";
            txt_Drink_Cost.Text = "";
            txt_Drink_total_mount.Text = "";
            txt_Drink_Price.Text = "";
            txt_NameDrink.Text = "";
            btn_Add_Drink.Enabled = true;
            DGDrink.ClearSelection();
            CDrinkDisplay();
            btn_Edit_Drink.Enabled = false;
            btn_Remove_Drink.Enabled = false;

        }

        #endregion

        #region Cacher


        private void button1_Click(object sender, EventArgs e)
        {
            int item = DGCacher.SelectedRows.Count;
            if (item == 1)
            {
                User selected = DGCacher.SelectedRows[0].DataBoundItem as User;
                User u = Context.Users.Where(u => u.Id == selected.Id).FirstOrDefault();

                string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                bool isValidEmail = Regex.IsMatch(txt_Email.Text, emailPattern);
                string passwordPattern = @"^(?=.*[0-9]+.*)(?=.*[a-zA-Z]+.*)[0-9a-zA-Z]{6,}$";
                bool isValidPassword = Regex.IsMatch(txt_Password.Text, passwordPattern);
                if (isValidEmail == false)
                {
                    MessageBox.Show("invalid Email");
                }
                else if (isValidPassword == false)
                {
                    MessageBox.Show("invalid Password");
                }
                else
                {
                    u.Email = txt_Email.Text;
                    u.Password = txt_Password.Text;
                    Context.SaveChanges();
                    DGCacher.DataSource = null;
                    DGCacher.DataSource = Context.Users.ToList();
                }
            }
            else
            {
                MessageBox.Show("select on user ");
            }

        }
        private void DGCacher_SelectionChanged(object sender, EventArgs e)
        {
            int item = DGCacher.SelectedRows.Count;
            if (item == 1)
            {
                User selected = DGCacher.SelectedRows[0].DataBoundItem as User;
                txt_Email.Text = selected.Email;
                txt_Password.Text = selected.Password;
            }
            //else
            //{
            //    MessageBox.Show("select on user ");
            //}
        }
        #endregion

        #region Home

        public void newadmin()
        {
            AdminHome adminHome = new AdminHome();
            adminHome.water_bill = Water_Bill;
            adminHome.Electricity_Bill = electricity_Bill;
            adminHome.Gas_Bill = gas_Bill;
            adminHome.Rent = rent;
            totalcost = decimal.Parse(labTES.Text) + Water_Bill + electricity_Bill + electricity_Bill + rent + costFood + costDrink;

            currentProfite = decimal.Parse(labCP.Text) - totalcost;
            if (totalcost == 0)
            {
                Percentage = "0%";
            }
            else
            {
                Percentage = ((currentProfite / totalcost) * 100) + "%";
            }
            adminHome.DateS = DateTime.Now;
            adminHome.TotalCost = totalcost;
            adminHome.CurrentProfite = currentProfite;
            adminHome.percentage = Percentage;
            Context.AdminHomes.Add(adminHome);
            Context.SaveChanges();
            Context.Entry(adminHome).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
        private void btn_set_Click(object sender, EventArgs e)
        {
            try
            {
                var adminHome = Context.AdminHomes.OrderByDescending(s => s.ID).Take(2).Skip(1).FirstOrDefault();
                if (adminHome != null)
                {
                    totalcost = decimal.Parse(labTES.Text) + Water_Bill + electricity_Bill + gas_Bill + rent + costFood + costDrink;
                    currentProfite = decimal.Parse(labCP.Text);
                    decimal total = (adminHome.TotalCost - totalcost) + decimal.Parse(labTES.Text) + Water_Bill + gas_Bill + electricity_Bill + rent;
                    currentProfite = (adminHome.CurrentProfite - currentProfite) - total;
                }
                else
                {
                    currentProfite = decimal.Parse(labCP.Text);
                    totalcost = decimal.Parse(labTES.Text) + Water_Bill + electricity_Bill + gas_Bill + rent + costFood + costDrink;
                    currentProfite = currentProfite - totalcost;
                }
                var admin = Context.AdminHomes.OrderBy(a => a.ID).LastOrDefault();
                Percentage = (currentProfite / totalcost) * 100 + "%";
                admin.TotalCost = totalcost;
                admin.CurrentProfite = currentProfite;
                admin.percentage = Percentage;

                Context.Entry(admin).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                Context.SaveChanges();
                Context.Entry(admin).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

                var date = DateTime.Now.Date.Month;
                if (admin.DateS.Month != date)
                {
                    newadmin();
                }
                DGHome.DataSource = null;
                DGHome.DataSource = Context.AdminHomes.ToList();
                display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("intervalid data");
            }
        }

        private void btnSetWater_Click(object sender, EventArgs e)
        {
            var DBdate = Context.AdminHomes.OrderBy(a => a.ID).LastOrDefault();
            if (txt_waterbill.Text == "")
            {
                MessageBox.Show("Reqiured");
                return;
            }
            else if (!decimal.TryParse(txt_waterbill.Text, out Water_Bill))
            {
                MessageBox.Show("please enter valid number ");
                return;

            }
            else if (Water_Bill < 0)
            {
                MessageBox.Show("please enter valid positive number ");
                return;
            }
            DBdate.water_bill = Water_Bill;
            Context.Entry(DBdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            Context.Entry(DBdate).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            DGHome.DataSource = null;
            DGHome.DataSource = Context.AdminHomes.ToList();

        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            int item = DGHome.SelectedRows.Count;
            if (item == 1)
            {
                AdminHome admin = DGHome.SelectedRows[0].DataBoundItem as AdminHome;

                PrintToPDF(admin.DateS.Month);

            }
        }
        private void btnSetGas_Click(object sender, EventArgs e)
        {

            var DBdate = Context.AdminHomes.OrderBy(a => a.ID).LastOrDefault();

            if (txt_Gas_Bill.Text == "")
            {
                MessageBox.Show("Reqiured");
                return;
            }
            else if (!decimal.TryParse(txt_Gas_Bill.Text, out gas_Bill))
            {
                MessageBox.Show("please enter valid number ");
                return;
            }
            else if (gas_Bill < 0)
            {
                MessageBox.Show("please enter valid positive number ");
                return;
            }

            DBdate.Gas_Bill = gas_Bill;
            Context.Entry(DBdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            Context.Entry(DBdate).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            DGHome.DataSource = null;
            DGHome.DataSource = Context.AdminHomes.ToList();

        }
        private void btnSetElectricity_Click(object sender, EventArgs e)
        {
            var DBdate = Context.AdminHomes.OrderBy(a => a.ID).LastOrDefault();
            if (txt_Electricity_Bill.Text == "")
            {
                MessageBox.Show("Reqiured");
                return;
            }
            else if (!decimal.TryParse(txt_Electricity_Bill.Text, out electricity_Bill))
            {
                MessageBox.Show("please enter valid number ");
                return;
            }
            else if (electricity_Bill < 0)
            {
                MessageBox.Show("please enter valid positive number ");
                return;
            }
            DBdate.Electricity_Bill = electricity_Bill;
            Context.Entry(DBdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            Context.Entry(DBdate).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            DGHome.DataSource = null;
            DGHome.DataSource = Context.AdminHomes.ToList();
        }
        private void btnSetRent_Click(object sender, EventArgs e)
        {
            var DBdate = Context.AdminHomes.OrderBy(a => a.ID).LastOrDefault();
            if (txt_Rent.Text == "")
            {
                MessageBox.Show("Reqiured");
                return;
            }
            else if (!decimal.TryParse(txt_Rent.Text, out rent))
            {
                MessageBox.Show("please enter valid number ");
                return;
            }
            else if (rent < 0)
            {
                MessageBox.Show("please enter valid positive number ");
                return;
            }
            DBdate.Rent = rent;
            Context.Entry(DBdate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
            Context.Entry(DBdate).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            DGHome.DataSource = null;
            DGHome.DataSource = Context.AdminHomes.ToList();
        }
        private void display()
        {
            decimal totalDrink = 0;
            decimal CurrentDrink = 0;
            costDrink = 0;

            var qDrink = Context.Drinks.Select(D => new { D.Price, D.TotalAmount, D.UniteOnStock, D.Cost }).ToList();
            foreach (var d in qDrink)
            {
                totalDrink = totalDrink + (d.Price * d.TotalAmount);

                CurrentDrink = CurrentDrink + (d.Price * (d.TotalAmount - d.UniteOnStock));

                costDrink = costDrink + (d.Cost * d.TotalAmount);
            }
            labCDP.Text = CurrentDrink.ToString();
            labTDP.Text = totalDrink.ToString();
            decimal totalFood = 0;
            decimal CurrentFood = 0;
            costFood = 0;

            var qFood = Context.Foods.Select(D => new { D.Price, D.TotalAmount, D.UniteOnStock, D.Cost });
            foreach (var d in qFood)
            {
                totalFood += d.Price * d.TotalAmount;
                CurrentFood += d.Price * (d.TotalAmount - d.UniteOnStock);
                costFood += d.Cost * d.TotalAmount;
            }
            labCFP.Text = CurrentFood.ToString();

            labTFP.Text = totalFood.ToString();

            labCP.Text = (CurrentDrink + CurrentFood).ToString();

            labTP.Text = (totalFood + totalDrink).ToString();
            decimal TotalSalary = 0;

            var qEmpSalary = Context.Employies.Select(D => new { D.Salary });
            foreach (var d in qEmpSalary)
            {
                TotalSalary += d.Salary;
            }
            labTES.Text = (TotalSalary).ToString();

        }
        public void PrintToPDF(int month)
        {
            var DBdate = Context.AdminHomes.Where(a => a.DateS.Month == month).FirstOrDefault();

            using (PdfDocument document = new PdfDocument())
            {
                // Add a page to the document.
                PdfPage page = document.Pages.Add();

                // Create PDF graphics for a page.
                PdfGraphics graphics = page.Graphics;

                // Set the standard font.
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

                // Create a data table with your static data.
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Water bill");
                dataTable.Columns.Add("Electricity Bill");
                dataTable.Columns.Add("Gas Bill");
                dataTable.Columns.Add("Rent");
                dataTable.Columns.Add("Employee Salary");


                // Add data rows to the table. 

                dataTable.Rows.Add(DBdate.water_bill, DBdate.Electricity_Bill, DBdate.Gas_Bill, DBdate.Rent,
                decimal.Parse(labTES.Text));


                // Draw a string before the table.
                string introText = "business report :...............";
                graphics.DrawString(introText, font, PdfBrushes.Black, new PointF(50, 50));

                string introText_2 = $" total cost {DBdate.TotalCost} ".ToUpper();
                graphics.DrawString(introText_2, font, PdfBrushes.Black, new PointF(50, 100));
                string introText_3 = $" Current Profite {DBdate.CurrentProfite} ".ToUpper();
                graphics.DrawString(introText_3, font, PdfBrushes.Black, new PointF(50, 150));
                string introText_4 = $" Month is {DBdate.DateS.Month}".ToUpper();
                graphics.DrawString(introText_4, font, PdfBrushes.Black, new PointF(50, 200));
                // Create a PDF table to display the data.
                PdfLightTable pdfTable = new PdfLightTable();
                pdfTable.DataSource = dataTable;
                pdfTable.Style.ShowHeader = true;

                // Set the font for the table cells.
                pdfTable.Style.DefaultStyle.Font = font;

                // Set the position of the table below the string.
                PointF tableLocation = new PointF(50, 250);

                // Draw the table on the page.
                pdfTable.Draw(page, tableLocation);


                // Save the document.
                document.Save($"{DBdate.ID}.pdf");
                MessageBox.Show("PDF created successfully");
                string fullPath = Path.GetFullPath($"{DBdate.ID}.pdf");
                MessageBox.Show("PDF file saved to: " + fullPath);
            }

        }
        #endregion
        private void BtnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }



        #region CatgoryFood
        private void DG_CFood_SelectionChanged(object sender, EventArgs e)
        {
            int item = DG_CFood.SelectedRows.Count;
            if (item == 1)
            {
                btnCFood_Add.Enabled = false;
                FoodCategory selected = DG_CFood.SelectedRows[0].DataBoundItem as FoodCategory;
                txtCfood_name.Text = selected.Name;
                btnCFood_Edit.Enabled = true;
                btnCFood_Remove.Enabled = true;
            }
        }
        private void btnCFood_Add_Click(object sender, EventArgs e)
        {
            try
            {
                FoodCategory Food = new FoodCategory()
                {
                    Name = txtCfood_name.Text,
                };
                categoryFoods.Add(Food);
                txtCfood_name.Text = "";
                DG_CFood.DataSource = null;
                DG_CFood.DataSource = categoryFoods.GetAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCFood_Edit_Click(object sender, EventArgs e)
        {
            int item = DG_CFood.SelectedRows.Count;
            if (item == 1)
            {
                FoodCategory selected = DG_CFood.SelectedRows[0].DataBoundItem as FoodCategory;


                try
                {

                    FoodCategory food = new FoodCategory()
                    {
                        Id = selected.Id,
                        Name = txtCfood_name.Text

                    };
                    categoryFoods.Edit(food);
                    txtCfood_name.Text = "";
                    DG_CFood.DataSource = null;
                    DG_CFood.DataSource = categoryFoods.GetAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one catagory");

            }
        }

        private void btnCFood_Remove_Click(object sender, EventArgs e)
        {
            int item = DG_CFood.SelectedRows.Count;
            if (item == 1)
            {
                FoodCategory selected = DG_CFood.SelectedRows[0].DataBoundItem as FoodCategory;


                try
                {

                    FoodCategory food = new FoodCategory()
                    {
                        Id = selected.Id,
                        Name = txtCfood_name.Text

                    };
                    categoryFoods.Delete(food);
                    txtCfood_name.Text = "";
                    DG_CFood.DataSource = null;
                    DG_CFood.DataSource = categoryFoods.GetAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one catagory");

            }
        }

        private void btnCFood_Cleare_Click(object sender, EventArgs e)
        {
            txtCfood_name.Text = "";
            btnCFood_Add.Enabled = true;
            DG_CFood.ClearSelection();
            btnCFood_Edit.Enabled = false;
            btnCFood_Remove.Enabled = false;
        }
        #endregion

        #region CatgoryDrink

        private void btn_CDrink_Add_Click(object sender, EventArgs e)
        {
            try
            {
                DrinkCategory drink = new DrinkCategory()
                {
                    Name = txt_CDrink_Name.Text,
                };
                CategoryDrinks.Add(drink);
                txt_CDrink_Name.Text = "";
                DG_CDrink.DataSource = null;
                DG_CDrink.DataSource = CategoryDrinks.GetAll();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_CDrink_Edit_Click(object sender, EventArgs e)
        {
            int item = DG_CDrink.SelectedRows.Count;
            if (item == 1)
            {
                DrinkCategory selected = DG_CDrink.SelectedRows[0].DataBoundItem as DrinkCategory;
                try
                {

                    DrinkCategory drink = new DrinkCategory()
                    {
                        Id = selected.Id,
                        Name = txt_CDrink_Name.Text

                    };
                    CategoryDrinks.Edit(drink);
                    txt_CDrink_Name.Text = "";
                    DG_CDrink.DataSource = null;
                    DG_CDrink.DataSource = CategoryDrinks.GetAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one catagory");

            }
        }

        private void btn_CDrink_Remove_Click(object sender, EventArgs e)
        {
            int item = DG_CDrink.SelectedRows.Count;
            if (item == 1)
            {
                DrinkCategory selected = DG_CDrink.SelectedRows[0].DataBoundItem as DrinkCategory;
                try
                {

                    DrinkCategory drink = new DrinkCategory()
                    {
                        Id = selected.Id,
                        Name = txt_CDrink_Name.Text

                    };
                    CategoryDrinks.Delete(drink);
                    txt_CDrink_Name.Text = "";
                    DG_CDrink.DataSource = null;
                    DG_CDrink.DataSource = CategoryDrinks.GetAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Select one catagory");

            }
        }

        private void btn_CDrink_Cleare_Click(object sender, EventArgs e)
        {
            txt_CDrink_Name.Text = "";
            btn_CDrink_Add.Enabled = true;
            DG_CDrink.ClearSelection();
            btn_CDrink_Edit.Enabled = false;
            btn_CDrink_Remove.Enabled = false;
        }

        private void DG_CDrink_SelectionChanged(object sender, EventArgs e)
        {
            int item = DG_CDrink.SelectedRows.Count;
            if (item == 1)
            {
                btn_CDrink_Add.Enabled = false;
                DrinkCategory selected = DG_CDrink.SelectedRows[0].DataBoundItem as DrinkCategory;
                txt_CDrink_Name.Text = selected.Name;
                btn_CDrink_Edit.Enabled = true;
                btn_CDrink_Remove.Enabled = true;
            }
        }

        #endregion


        private void TabEmploy_Click(object sender, EventArgs e)
        {

        }

        private void AdminDashbordForm_Load(object sender, EventArgs e)
        {

            WelecomLabel.Text = "Welcom Mr :" + Context.Users.Where(u => u.Id == 1).SingleOrDefault().Email.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labTotal_Profit_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lab_Drink_Cost_Click(object sender, EventArgs e)
        {

        }

        private void DGHome_SelectionChanged(object sender, EventArgs e)
        {
            int item = DGHome.SelectedRows.Count;
            if (item == 1)
            {

                AdminHome selected = DGHome.SelectedRows[0].DataBoundItem as AdminHome;
                if (selected.ID == Context.AdminHomes.OrderBy(a => a.ID).LastOrDefault().ID)
                {
                    txt_Gas_Bill.Text = selected.Gas_Bill.ToString();
                    txt_Electricity_Bill.Text = selected.Electricity_Bill.ToString();
                    txt_waterbill.Text = selected.water_bill.ToString();
                    txt_Rent.Text = selected.Rent.ToString();

                    Water_Bill = selected.water_bill ?? 0;
                    gas_Bill = selected.Gas_Bill ?? 0;
                    electricity_Bill = selected.Electricity_Bill ?? 0;
                    rent = selected.Rent ?? 0;
                }
                else
                {
                   // MessageBox.Show("You Can Only Eidt The Last Month  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_Rent_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
