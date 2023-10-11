namespace VersionOfProject.Entity
{
    public class Employe
    {
        public int Id { get; set; } // key identity 1,1
        public string Name { get; set; }    // len = 50 
        public decimal Salary { get; set; } // salay ==> 4000

        public string JobDescription { get; set; } // len 50

        public string Address { get; set; } // len = 70

        public string PhoneNumber { get; set; } // len 11 must be 11 number 
    }
}
