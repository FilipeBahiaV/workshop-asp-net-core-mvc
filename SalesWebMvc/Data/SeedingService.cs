using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(!_context.Department.Any() ||
                !_context.SalesRecord.Any()||
                !_context.Seller.Any())
            {
                Department d1 = new Department(1, "Computers");
                Department d2 = new Department(2, "Electronics");
                Department d3 = new Department(3, "Fashion");
                Department d4 = new Department(4, "Books");

                Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 21), 1000, d1);
                Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1999, 7, 05), 1000, d2);
                Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(1978, 2, 28), 1000, d1);
                Seller s4 = new Seller(4, "Martha Brown", "martha@gmail.com", new DateTime(1980, 7, 6), 1000, d4);
                Seller s5 = new Seller(5, "Donald Brown", "donald@gmail.com", new DateTime(1998, 7, 21), 1000, d2);
                Seller s6 = new Seller(6, "Alex Brown", "alex@gmail.com", new DateTime(2001, 8, 11), 1000, d1);

                SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SalesStatus.Billed, s1);
                SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 4), 7000.0, SalesStatus.Billed, s5);
                SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 13), 4000.0, SalesStatus.Canceled, s4);
                SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 1), 8000.0, SalesStatus.Billed, s1);
                SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 09, 21), 3000.0, SalesStatus.Billed, s3);
                SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 09, 15), 2000.0, SalesStatus.Billed, s1);
                SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 09, 28), 13000.0, SalesStatus.Billed, s2);
                SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 09, 11), 4000.0, SalesStatus.Billed, s4);
                SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 09, 14), 11000.0, SalesStatus.Pending, s6);
                SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 09, 7), 9000.0, SalesStatus.Billed, s6);
                SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 09, 13), 6000.0, SalesStatus.Billed, s2);
                SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 09, 25), 7000.0, SalesStatus.Pending, s3);
                SalesRecord r13 = new SalesRecord(13, new DateTime(2018, 09, 29), 10000.0, SalesStatus.Billed, s4);
                SalesRecord r14 = new SalesRecord(14, new DateTime(2018, 09, 4), 3000.0, SalesStatus.Billed, s5);


                _context.Department.AddRange(d1, d2, d3, d4);
                _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);
                _context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r8, r9, r10, r11, r12, r13, r14);

                _context.SaveChanges();

            }
        }
    }
}
