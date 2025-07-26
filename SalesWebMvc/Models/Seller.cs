using System.Linq;
namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        public ICollection<SalesRecord> Sales = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addSale(SalesRecord sale)
        {
            Sales.Add(sale);
        }

        public void removeSale(SalesRecord sale)
        {
            Sales.Remove(sale);
        }

        public double totalSales(DateTime initial, DateTime finale)
        {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= finale).Sum(sr => sr.Amount);
        }
    }
}
