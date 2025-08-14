namespace SalesWebMvc.Models.ViewModels
{
    public class SalesGroupByDepartmentViewModel
    {
        public Department Department { get; set; }
        public double TotalSales { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; }
    }
}