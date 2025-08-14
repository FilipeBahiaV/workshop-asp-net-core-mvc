using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Services
{
	public class SalesRecordService
	{
		private readonly SalesWebMvcContext _context;

		public SalesRecordService(SalesWebMvcContext context)
		{
			_context = context;
		}

		public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
		{
			var result = from obj in _context.SalesRecord select obj;
			if (minDate.HasValue)
			{
				result = result.Where(x => x.Date >= minDate.Value);
			}
			if (maxDate.HasValue)
			{
				result = result.Where(x => x.Date <= maxDate.Value);
			}
			return await result
				.Include(x => x.Seller)
				.Include(x => x.Seller.Department)
				.OrderByDescending(x => x.Date)
				.ToListAsync();
		}

        public async Task<List<SalesGroupByDepartmentViewModel>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }

            var records = await result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToListAsync();

            var departmentGroups = records
                .GroupBy(x => x.Seller.Department)
                .Select(group => new SalesGroupByDepartmentViewModel
                {
                    Department = group.Key,
                    TotalSales = group.Sum(x => x.Amount),
                    SalesRecords = group.ToList()
                })
                .ToList();

            return departmentGroups;
        }
    }
}
