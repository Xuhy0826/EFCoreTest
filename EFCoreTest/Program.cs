using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContextOptions<MyContext> options = new DbContextOptions<MyContext>();
            using (var context = new MyContext(options))
            {

                var res = context.Patients.ToListAsync();
                if (res.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine(res.Exception.Message);
                }
                Console.ReadLine();
            }
        }
    }
}
    