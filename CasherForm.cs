using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VersionOfProject.Entity;
using VersionOfProject.PL;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using Syncfusion.Pdf.Tables;
using Microsoft.EntityFrameworkCore;

namespace VersionOfProject
{
    public partial class CasherForm : Form
    {

        List<Button> DrinksBtn;
        WFContext con;
        List<Button> FoodsBtn;
        List<Button> DrinkCategryBTNs;
        List<Button> FoodCategryBTNs;

        int IndexOfRowDataGrideView = 0;

        public void FillDrinksPanal(List<Drinks> drinks)
        {
            DrinkPanel.Controls.Clear();
            List<Button> NewDrinksBtn = new List<Button>();
            var pnlocationX = 0;
            var pnlocationY = 0;
            for (int i = 0; i < drinks.Count; i++)
            {
                // input name=tea value=10 ===> tea 10
                NewDrinksBtn.Add(new Button());
                NewDrinksBtn[i].Text = drinks[i].Name + "\n $" + drinks[i].Price.ToString();
                NewDrinksBtn[i].Size = new Size(100, 100);

                NewDrinksBtn[i].Location = new Point(pnlocationX, pnlocationY);
                NewDrinksBtn[i].Click += AddToMenue;
                DrinkPanel.Controls.Add(NewDrinksBtn[i]);
                pnlocationX += 100;
                if (pnlocationX % 500 == 0)
                {
                    pnlocationY += 100;
                    pnlocationX = 0;
                }
            }
        }
        public void FillFoodsPanal(List<Food> Foods)
        {
            FoodPanal.Controls.Clear();
          List<Button> NewFoodBtn = new List<Button>();
            var pnlocationX = 0;
            var pnlocationY = 0;
            for (int i = 0; i < Foods.Count; i++)
            {
                // input name=tea value=10 ===> tea 10
                NewFoodBtn.Add(new Button());
                NewFoodBtn[i].Text = Foods[i].Name + "\n $" + Foods[i].Price.ToString();
                NewFoodBtn[i].Size = new Size(100, 100);

                NewFoodBtn[i].Location = new Point(pnlocationX, pnlocationY);
                NewFoodBtn[i].Click += AddToMenue;
                FoodPanal.Controls.Add(NewFoodBtn[i]);
                pnlocationX += 100;
                if (pnlocationX % 500 == 0)
                {
                    pnlocationY += 100;
                    pnlocationX = 0;
                }
            }
        }

        public void FillDefaoultdrinks()
        {
            DrinkPanel.Controls.Clear();
            var drinks = con.Drinks.Where(d => d.UniteOnStock > 0).ToList();
            List<Button> DrinksBtn = new List<Button>();
            var pnlocationX = 0;
            var pnlocationY = 0;
            for (int i = 0; i < drinks.Count; i++)
            {
                // input name=tea value=10 ===> tea 10
                DrinksBtn.Add(new Button());
                DrinksBtn[i].Text = drinks[i].Name + "\n $" + drinks[i].Price.ToString();
                DrinksBtn[i].Size = new Size(100, 100);

                DrinksBtn[i].Location = new Point(pnlocationX, pnlocationY);
                DrinksBtn[i].Click += AddToMenue;
                DrinkPanel.Controls.Add(DrinksBtn[i]);
                pnlocationX += 100;
                if (pnlocationX % 500 == 0)
                {
                    pnlocationY += 100;
                    pnlocationX = 0;
                }
            }
        }
        public void FillDefaoultFoods()
        {
            FoodPanal.Controls.Clear();
            int pnlocationX = 0;
            int pnlocationY = 0;
            List<Button> FoodsBtn = new List<Button>();
            var foods = con.Foods.Where(f => f.UniteOnStock > 0).ToList();

            for (int i = 0; i < foods.Count; i++)
            {
                // input name=tea value=10 ===> tea 10
                FoodsBtn.Add(new Button());
                FoodsBtn[i].Text = foods[i].Name + "\n $" + foods[i].Price.ToString();
                FoodsBtn[i].Size = new Size(100, 100);

                FoodsBtn[i].Location = new Point(pnlocationX, pnlocationY);
                FoodsBtn[i].Click += AddToMenue;
                FoodPanal.Controls.Add(FoodsBtn[i]);
                pnlocationX += 100;
                if (pnlocationX % 500 == 0)
                {
                    pnlocationY += 100;
                    pnlocationX = 0;
                }
            }
        }

        public void DrinkFillCategoryPnalDefaoult()
        {
            DrinkCategory.Controls.Clear();
            var data = con.Drinks.Include(d => d.Category).Where(d => d.UniteOnStock > 0).ToList().GroupBy(d => d.Category.Name).ToList();


            //var categoryDrink = con.DrinkCategories.ToList();
            int indexinDrinksPanal = 16;
            for (int x = 0; x < data.Count; x++)
            {
                // input name=tea value=10 ===> tea 10
                DrinkCategryBTNs.Add(new Button());
                DrinkCategryBTNs[x].Text = data[x].Key;
                DrinkCategryBTNs[x].Size = new Size(145, 54);

                DrinkCategryBTNs[x].Location = new Point(16, indexinDrinksPanal);
                DrinkCategryBTNs[x].Click += SelectCategoryFromDrink;
                DrinkCategory.Controls.Add(DrinkCategryBTNs[x]);
                indexinDrinksPanal += 60;

            }
        }

        public void FoodFillCategoryPnalDefaoult()
        {
            FoodCategory.Controls.Clear();
            var data = con.Foods.Include(f => f.Category).Where(f => f.UniteOnStock > 0).ToList().GroupBy(f => f.Category.Name).ToList();

            //var categoryFood = con.FoodCategories.ToList();
            int indexinFoodPanal = 11;
            for (int x = 0; x < data.Count; x++)
            {
                // input name=tea value=10 ===> tea 10
                FoodCategryBTNs.Add(new Button());
                FoodCategryBTNs[x].Text = data[x].Key;
                FoodCategryBTNs[x].Size = new Size(128, 53);

                FoodCategryBTNs[x].Location = new Point(18, indexinFoodPanal);
                FoodCategryBTNs[x].Click += SelectCategoryFromFood;
                FoodCategory.Controls.Add(FoodCategryBTNs[x]);

                indexinFoodPanal += 61;

            }
        }
        public CasherForm()
        {
            InitializeComponent();

            DrinksBtn = new List<Button>();
            FoodsBtn = new List<Button>();
            FoodCategryBTNs = new List<Button>();
            DrinkCategryBTNs = new List<Button>();
            con = new WFContext();
            FillDefaoultFoods();
            FillDefaoultdrinks();
            #region c 1,2
            //var drinks = con.Drinks.Where(d => d.UniteOnStock > 0).ToList();
            //var pnlocationX = 0;
            //var pnlocationY = 0;
            //for (int i = 0; i < drinks.Count; i++)
            //{
            //    // input name=tea value=10 ===> tea 10
            //    DrinksBtn.Add(new Button());
            //    DrinksBtn[i].Text = drinks[i].Name + "\n $" + drinks[i].Price.ToString();
            //    DrinksBtn[i].Size = new Size(100, 100);

            //    DrinksBtn[i].Location = new Point(pnlocationX, pnlocationY);
            //    DrinksBtn[i].Click += AddToMenue;
            //    DrinkPanel.Controls.Add(DrinksBtn[i]);
            //    pnlocationX += 100;
            //    if (pnlocationX % 500 == 0)
            //    {
            //        pnlocationY += 100;
            //        pnlocationX = 0;
            //    }
            //}
            //pnlocationX = 0;
            //pnlocationY = 0;
            //var foods = con.Foods.Where(f => f.UniteOnStock > 0).ToList();
            //for (int i = 0; i < foods.Count; i++)
            //{
            //    // input name=tea value=10 ===> tea 10
            //    FoodsBtn.Add(new Button());
            //    FoodsBtn[i].Text = foods[i].Name + "\n $" + foods[i].Price.ToString();
            //    FoodsBtn[i].Size = new Size(100, 100);

            //    FoodsBtn[i].Location = new Point(pnlocationX, pnlocationY);
            //    FoodsBtn[i].Click += AddToMenue;
            //    FoodPanal.Controls.Add(FoodsBtn[i]);
            //    pnlocationX += 100;
            //    if (pnlocationX % 500 == 0)
            //    {
            //        pnlocationY += 100;
            //        pnlocationX = 0;
            //    }
            //}

            #endregion
            DrinkFillCategoryPnalDefaoult();
            #region c3

            //var categoryDrink = con.DrinkCategories.ToList();
            //int indexinDrinksPanal = 16;
            //for (int x = 0; x < categoryDrink.Count; x++)
            //{
            //    // input name=tea value=10 ===> tea 10
            //    DrinkCategryBTNs.Add(new Button());
            //    DrinkCategryBTNs[x].Text = categoryDrink[x].Name;
            //    DrinkCategryBTNs[x].Size = new Size(145, 54);

            //    DrinkCategryBTNs[x].Location = new Point(16, indexinDrinksPanal);
            //    DrinkCategryBTNs[x].Click += SelectCategoryFromDrink;
            //    DrinkCategory.Controls.Add(DrinkCategryBTNs[x]);
            //    indexinDrinksPanal += 60;

            //} 
            #endregion
            FoodFillCategoryPnalDefaoult();
            #region c 4
            //var categoryFood = con.FoodCategories.ToList();
            //int indexinFoodPanal = 11;
            //for (int x = 0; x < categoryFood.Count; x++)
            //{
            //    // input name=tea value=10 ===> tea 10
            //    FoodCategryBTNs.Add(new Button());
            //    FoodCategryBTNs[x].Text = categoryFood[x].Name;
            //    FoodCategryBTNs[x].Size = new Size(128, 53);

            //    FoodCategryBTNs[x].Location = new Point(18, indexinFoodPanal);
            //    FoodCategryBTNs[x].Click += SelectCategoryFromFood;
            //    FoodCategory.Controls.Add(FoodCategryBTNs[x]);
            //    indexinFoodPanal += 61;

            //} 
            #endregion
        }

        private void SelectCategoryFromDrink(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var cat = con.DrinkCategories.SingleOrDefault(d => d.Name == btn.Text);
            var drinks = con.Drinks.Where(d => d.CategoryID == cat.Id && d.UniteOnStock > 0).ToList();
            DrinkPanel.Controls.Clear();
            FillDrinksPanal(drinks);

        }
        private void SelectCategoryFromFood(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var cat = con.FoodCategories.SingleOrDefault(d => d.Name == btn.Text);
            var foods = con.Foods.Where(d => d.CategoryID == cat.Id && d.UniteOnStock > 0).ToList();
            FoodPanal.Controls.Clear();
            FillFoodsPanal(foods);
        }

        private void CasherForm_Load(object sender, EventArgs e)
        {
            WelecomLabel.Text = "Welecom Mr : " + con.Users.Where(u => u.Id == 2).SingleOrDefault().Email.ToString();
        }
        private void AddToMenue(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var name = btn.Text.Split("$")[0].Trim();
            var price = btn.Text.Split("$")[1].Trim();
            // check amount in db 
         
           

            // check exists 

            for (int r = 0; r < BillGV.RowCount - 1; r++)
            {

                if (name == BillGV.Rows[r].Cells[0].Value.ToString())
                {
                    var AmountInGride = Convert.ToDecimal(BillGV.Rows[r].Cells[2].Value);
                    var flag1 = con.Drinks.Where(d => d.Name.Trim() == name && d.UniteOnStock - AmountInGride == 0).SingleOrDefault();
                    var flag2 = con.Foods.Where(f => f.Name.Trim() == name && f.UniteOnStock - AmountInGride == 0).SingleOrDefault();

                    if (flag1 != null)
                    {
                        MessageBox.Show($" no Pice of {name} ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // FillDefaoultdrinks();
                        return;
                    }
                    if (flag2 != null)
                    {
                        MessageBox.Show($" no Pice of {name} ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // FillDefaoultFoods();
                        return;

                    }
                    BillGV.Rows[r].Cells[2].Value = Convert.ToDecimal(BillGV.Rows[r].Cells[2].Value) + 1;
                    BillGV.Rows[r].Cells[3].Value = Convert.ToDecimal(BillGV.Rows[r].Cells[2].Value) * Convert.ToDecimal(BillGV.Rows[r].Cells[1].Value);
                    DisplayLableTotal.Text = (Convert.ToDecimal(DisplayLableTotal.Text) + Convert.ToDecimal(BillGV.Rows[r].Cells[1].Value)).ToString();

                
                    return;
                }
            }


            DataGridViewRow row = (DataGridViewRow)BillGV.Rows[IndexOfRowDataGrideView].Clone();

            row.Cells[0].Value = name;
            row.Cells[1].Value = price;
            row.Cells[2].Value = 1;
            row.Cells[3].Value = Convert.ToDecimal(row.Cells[2].Value) * Convert.ToDecimal(row.Cells[1].Value);

            BillGV.Rows.Add(row);
            IndexOfRowDataGrideView += 1;

            // calculate total bill
            DisplayLableTotal.Text = (Convert.ToDecimal(DisplayLableTotal.Text) + Convert.ToDecimal(row.Cells[3].Value)).ToString();
        }





        private void Btn_Rmove_Click(object sender, EventArgs e)
        {
            int count = BillGV.SelectedRows.Count;
            if (count == 1)
            {
                DisplayLableTotal.Text = (Convert.ToDecimal(DisplayLableTotal.Text) - Convert.ToDecimal(BillGV.SelectedRows[0].Cells[3].Value)).ToString();

                BillGV.Rows.Remove(BillGV.SelectedRows[0]);


                IndexOfRowDataGrideView -= 1;
                return;
            }
            MessageBox.Show("Please select one item from bill");
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            BillGV.Rows.Clear();
            IndexOfRowDataGrideView = 0;
            DisplayLableTotal.Text = "0";
        }

        private void Btn_Save_Click(object sender, EventArgs e)
        {
            List<OrderItem> ordresItem = new List<OrderItem>();
            Order order = new Order();
            for (int r = 0; r < BillGV.RowCount - 1; r++)
            {
                var name = BillGV.Rows[r].Cells[0].Value.ToString();
                var amount = Convert.ToInt32(BillGV.Rows[r].Cells[2].Value.ToString());
                var price = Convert.ToDecimal(BillGV.Rows[r].Cells[3].Value);
                var flag = con.Drinks.Where(d => d.Name == name).FirstOrDefault();
                ordresItem.Add(new OrderItem() { Name = name, Amount = amount, Cost = price });
                if (flag != null)
                {
                    flag.UniteOnStock -= amount;
                    con.Entry(flag).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    var bb = con.SaveChanges();
                    con.Entry(flag).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

                }
                var flag2 = con.Foods.Where(f => f.Name == name).FirstOrDefault();
                if (flag2 != null)
                {
                    flag2.UniteOnStock -= amount;
                    con.Entry(flag2).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    con.SaveChanges();
                    con.Entry(flag2).State = Microsoft.EntityFrameworkCore.EntityState.Detached;

                }

            }

            order.TotalCost = Convert.ToDecimal(DisplayLableTotal.Text);
            order.OrderDate = DateTime.Now;

            OrderPL orderPL = new OrderPL();
            orderPL.Submitorder(order, ordresItem);

            PrintToPDF();
            BillGV.Rows.Clear();
            IndexOfRowDataGrideView = 0;
            DisplayLableTotal.Text = "0";
         
  
            FillDefaoultFoods();
            FillDefaoultdrinks();
            DrinkFillCategoryPnalDefaoult();
            FoodFillCategoryPnalDefaoult();
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        public void PrintToPDF()
        {
            var order = con.orders.OrderBy(s => s.Id).LastOrDefault();
            var oderitems = con.OrdersItems.Where(oi => oi.OrderId == order.Id).ToList();

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
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Amount");
                dataTable.Columns.Add("Price");


                // Add data rows to the table. 
                foreach (var item in oderitems)
                {
                    dataTable.Rows.Add(item.Name, item.Amount, item.Cost);

                }



                // Draw a string before the table.
                string introText = "Ordred To :...............";
                graphics.DrawString(introText, font, PdfBrushes.Black, new PointF(50, 50));

                string introText_2 = $"total Cost = {order.TotalCost} and date is {order.OrderDate.Date}".ToUpper();
                graphics.DrawString(introText_2, font, PdfBrushes.Black, new PointF(50, 100));
                // Create a PDF table to display the data.
                PdfLightTable pdfTable = new PdfLightTable();
                pdfTable.DataSource = dataTable;
                pdfTable.Style.ShowHeader = true;

                // Set the font for the table cells.
                pdfTable.Style.DefaultStyle.Font = font;

                // Set the position of the table below the string.
                PointF tableLocation = new PointF(50, 150);

                // Draw the table on the page.
                pdfTable.Draw(page, tableLocation);


                // Save the document.
                document.Save($"{order.Id}.pdf");
                MessageBox.Show("PDF created successfully");
                string fullPath = Path.GetFullPath($"{order.Id}.pdf");
                MessageBox.Show("PDF file saved to: " + fullPath);
            }

        }

        private void AllDrinks_Click(object sender, EventArgs e)
        {
            FillDefaoultdrinks();
        }

        private void AllCategoryDrink_Click(object sender, EventArgs e)
        {
            FillDefaoultFoods();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
