using System.ComponentModel.DataAnnotations.Schema;

namespace VersionOfProject.Entity
{
    public class User
    {
        public int Id { get; set; } // key identity 1,1
        public string Email { get; set; } // not null  uniqe  regx
        public string Password { get; set; } // regx

        //[ForeignKey("Employe")]
        //public int? Emp_Id { get; set; }        // fk nullable 
        //public virtual Employe Employe { get; set; }
    }
}
