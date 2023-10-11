using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOfProject.Entity;
using VersionOfProject.VeiwModel;

namespace VersionOfProject.PL
{
    public class DrinkPl
    {
        WFContext Context;
        public DrinkPl()
        {
            Context = new WFContext();
        }
        public List<DrinkViewModel> GetAll()
        {
            var result = Context.Drinks.Select(f => new DrinkViewModel
            {
                Id = f.Id,
                Name = f.Name,
                UniteOnStock = f.UniteOnStock,
                TotalAmount = f.TotalAmount,
                Cost = f.Cost,
                Price = f.Price,
                CategoryID = f.CategoryID
            }).ToList(); ;
            return result;
        }
        public bool Add(Drinks data)
        {
            if (data == null)
                throw new Exception("Data must Be Not Null");

            if (data.Name == null || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");
            if (data.UniteOnStock < 0 )//|| data.UniteOnStock > data.TotalAmount)
                throw new Exception("UniteOnStock must be positive and Lessthan or equal total");
            //if (data.TotalAmount < 0|| data.TotalAmount < data.UniteOnStock)
            //    throw new Exception("TotalAmount must be positive and GreaterThan or equal UniteOnStock");
            if (data.Cost <= 0 || data.Cost > data.Price)
                throw new Exception("Cost must be positive and lessthan Price");
            if (data.Price <= 0 || data.Price < data.Cost)
                throw new Exception("Price must be positive and greater than  Cost");
            try
            {
                var falag = Context.Drinks.SingleOrDefault(d => d.Name == data.Name);
                if (falag == null)
                {
                    Context.Drinks.Add(data);
                    if (Context.SaveChanges() > 0)
                    {
                        Context.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        return true;
                    }
                }
                else
                {
                    throw new Exception($"{data.Name} oready Exists");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return false;
        }
        public bool Edit(Drinks data)
        {
            if (data == null)
                throw new Exception("Data must Be Null");

            if (data.Name == null || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");
            if (data.UniteOnStock < 0 )//|| data.UniteOnStock > data.TotalAmount)
                throw new Exception("UniteOnStock must be positive and Lessthan or equal total");
            //if (data.TotalAmount < 0 && data.TotalAmount < data.UniteOnStock)
            //    throw new Exception("TotalAmount must be positive and GreaterThan or equal UniteOnStock");
            if (data.Cost <= 0 || data.Cost > data.Price)
                throw new Exception("Cost must be positive and lessthan Price");
            if (data.Price <= 0 || data.Price < data.Cost)
                throw new Exception("Price must be positive and greater than  Cost");
            try
            {
                var objFromDB = Context.Drinks.SingleOrDefault(d => d.Id == data.Id);
                if (objFromDB != null)
                {
                    // dbuinstock = actual + form
                    objFromDB.UniteOnStock += data.UniteOnStock;
                    //dbtotal = dbtotal + from
                    objFromDB.TotalAmount += data.UniteOnStock;
                    //tea totalAmount = 5 uintOnStock = 5 cost = 15 p = 20
                    objFromDB.Name = data.Name;
                    objFromDB.Cost = data.Cost;
                    objFromDB.Price = data.Price;
                    objFromDB.CategoryID = data.CategoryID;
                    Context.Entry(objFromDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                    if (Context.SaveChanges() > 0)
                    {
                        Context.Entry(objFromDB).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                        return true;
                    }
                }
                else
                {
                    throw new Exception($"{data.Name} oready Exists");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        public bool Delete(Drinks data)
        {
            try
            {
                Context.Drinks.Remove(data);
                return Context.SaveChanges() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
