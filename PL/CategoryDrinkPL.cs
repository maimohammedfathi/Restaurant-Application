using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VersionOfProject.Entity;

namespace VersionOfProject.PL
{
    public class CategoryDrinkPL
    {
        WFContext Context;
        public CategoryDrinkPL()
        {
            Context = new WFContext();
        }
        public List<DrinkCategory> GetAll()
        {
            var result = Context.DrinkCategories.OrderBy(F=>F.Id).ToList();
            return result;
        }

        public bool Add(DrinkCategory data)
        {
            if (data == null)
                throw new Exception("Data must Be Not Null");

            if (data.Name == "" || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");

            try
            {
                var falag = Context.DrinkCategories.SingleOrDefault(d => d.Name == data.Name);
                if (falag == null)
                {
                    Context.DrinkCategories.Add(data);
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

        public bool Edit(DrinkCategory data)
        {
            if (data == null)
                throw new Exception("Data must Be Not Null");

            if (data.Name == "" || data.Name.Length > 50)
                throw new Exception("Name must be  lessthan   50 char ");

            try
            {
                var objFromDB = Context.DrinkCategories.SingleOrDefault(d => d.Id == data.Id);
                if (objFromDB != null)
                {
                    if (Context.DrinkCategories.SingleOrDefault(d => d.Name == data.Name) == null)
                    {
                        objFromDB.Name = data.Name;
                        Context.Entry(objFromDB).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        if (Context.SaveChanges() > 0)
                        {
                            Context.Entry(objFromDB).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
                            return true;
                        }
                        else
                        {
                            throw new Exception($"{data.Name} oready Exists");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }

        public bool Delete(DrinkCategory data)
        {
            if (data != null)
            {
                var count = Context.Drinks.Where(d => d.CategoryID == data.Id).Count();
                if (count > 0)
                {
                    throw new Exception($" Category  {data.Name} can not deleted becase assign to {count}  Product ");
                }

                try
                {
                    Context.DrinkCategories.Remove(data);
                    return Context.SaveChanges() > 0 ? true : false;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return false;
        }

        public List<Drinks> GetDrinksByCategoryId(int categoryId)
        {
            return Context.Drinks.Where(d => d.CategoryID == categoryId).ToList();
        }
    }
}
