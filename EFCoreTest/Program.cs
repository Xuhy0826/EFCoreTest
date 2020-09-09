using System;
using System.Threading.Tasks;
using EFCoreTest.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTest
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var options = new DbContextOptions<MyContext>();

            #region 查询
            await using var context = new MyContext(options);
            var employeeCollection = await context.Employee.AsNoTracking().ToListAsync();
            //var employeeCollection = await context.Employee.OrderBy(e => e.EmployeeNo).AsNoTracking().Skip(0).Take(5).ToListAsync();//分页
            foreach (var employee in employeeCollection)
            {
                Console.WriteLine($"{employee.Name} | {employee.EmployeeNo} | {employee.Department}");
            }

            Console.ReadLine();

            #endregion

            #region 新增
            //var employee = new Employee()
            //{
            //    EmployeeNo = 6,
            //    Name = "老周",
            //    Department = "d6",
            //    BirthDay = DateTime.Now.AddYears(-40),
            //    IsValid = true
            //};
            //await using var context = new MyContext(options);
            //var res = await context.Employee.AddAsync(employee);
            //await context.SaveChangesAsync();
            //Console.WriteLine("添加成功");
            //Console.ReadLine();

            #endregion

        }
    }
}
