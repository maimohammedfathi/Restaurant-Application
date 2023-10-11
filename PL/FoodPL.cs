using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOfProject.Entity;
using VersionOfProject.VeiwModel;

namespace VersionOfProject.PL
{
    public class FoodPL
    {
        WFContext Context;
        public FoodPL()
        {
            Context = new WFContext();
        }
        public List<FoodVeiwModel> GetAll()
        {
            var result = Context.Foods.Select(f => new FoodVeiwModel
            {
                Id = f.Id,
                Name = f.Name,
                UniteOnStock = f.UniteOnStock,
                TotalAmount = f.TotalAmount,
                Cost = f.Cost,
                Price = f.Price,
                CategoryID = f.CategoryID
            }).ToList(); 

            return result;
        }
        public bool Add(Food data)
        {
            if (data == null)
                throw new Exception("Data must Be Not Null");

            if (data.Name == null || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");
            if (data.UniteOnStock < 0 )//|| data.UniteOnStock > data.TotalAmount)
                throw new Exception("UniteOnStock must be positive and Lessthan or equal total");
            //if(data.TotalAmount < 0 || data.TotalAmount < data.UniteOnStock)
            //    throw new Exception("TotalAmount must be positive and GreaterThan or equal UniteOnStock");
            if(data.Cost <= 0 || data.Cost > data.Price)
                throw new Exception("Cost must be positive and lessthan Price");
            if (data.Price <= 0 ||   data.Price < data.Cost)
                throw new Exception("Price must be positive and greater than  Cost");
            try
            {
                var falag = Context.Foods.SingleOrDefault(f => f.Name == data.Name);
                if (falag == null)
                {
                    data.TotalAmount = data.UniteOnStock ;
                    Context.Foods.Add(data);
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
        public bool Edit(Food data)
        {
            if (data == null)
                throw new Exception("Data must Be Null");

            if (data.Name == null || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");
            if (data.UniteOnStock < 0 )//|| data.UniteOnStock > data.TotalAmount)
                throw new Exception("UniteOnStock must be positive and Lessthan or equal total");
            //if (data.TotalAmount < 0 || data.TotalAmount < data.UniteOnStock)
            //    throw new Exception("TotalAmount must be positive and GreaterThan or equal UniteOnStock");
            if (data.Cost <= 0 || data.Cost > data.Price)
                throw new Exception("Cost must be positive and lessthan Price");
            if (data.Price <= 0 || data.Price < data.Cost)
                throw new Exception("Price must be positive and greater than  Cost");
            try
            {
                var objFromDB = Context.Foods.SingleOrDefault(f => f.Id == data.Id);
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

        public bool Delete(Food data)
        {
            try
            {
               Context.Foods.Remove(data);
               return  Context.SaveChanges() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception (ex.Message);
            }
        }

    }
}
