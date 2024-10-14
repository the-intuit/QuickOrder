using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Menu.Data
{
    public class DataBaseMenuOrderContext : IdentityDbContext
    {
        public DataBaseMenuOrderContext()
        { }
        public DataBaseMenuOrderContext(DbContextOptions<DataBaseMenuOrderContext> options) : base(options) {
        }

        public DbSet<MyNewModel> MyNewModels { get; set; } 
        public DbSet<EmployeeData> EmployeeData { get; set; }
    }
    public class MyNewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    
    [Table("EmployeeData")]
    public class EmployeeData
    {
        [Key]
        public int ID { get; set; }
        public int EmployeeID { get; set; }

        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }

        [Display(Name = "Contact Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Your Skill")]
        public int SkillID { get; set; }

        [Display(Name = "Years of Experience")]
        public int YearsExperience { get; set; }
    }
    //public class YourDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    //{
    //    public DataContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
    //        optionsBuilder.UseSqlServer("Data Source=rc;Initial Catalog=MenuOrder;Integrated Security=True;Trusted_Connection=true;TrustServerCertificate=true;");

    //        return new DataContext(optionsBuilder.Options);
    //    }
    //}
}
