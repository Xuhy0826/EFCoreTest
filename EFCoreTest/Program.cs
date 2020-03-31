using System;
using System.Threading.Tasks;
using EFCoreTest.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var options = new DbContextOptions<MyContext>();

            #region 查询
            //using (var context = new MyContext(options))
            //{
            //    var res = context.Employee.ToListAsync();
            //    //var res = context.Employee.OrderBy("EMPLOYEENO").Skip(0).Take(5).ToListAsync();//分页
            //    if (res.Status == TaskStatus.Faulted)
            //    {
            //        Console.WriteLine(res.Exception.Message);
            //    }
            //    Console.ReadLine();
            //}
            #endregion

            #region 新增
            var employee = new Employee()
            {
                EmployeeNo = 6,
                Name = "老周",
                Department = "d6",
                BirthDay = DateTime.Now.AddYears(-40),
                IsValid = true
            };
            using (var context = new MyContext(options))
            {
                var res = context.Employee.AddAsync(employee);
                if (res.Status == TaskStatus.Faulted)
                {
                    Console.WriteLine(res.Exception.Message);
                }
                context.SaveChanges();
                Console.WriteLine("添加成功");
                Console.ReadLine();
            }
            #endregion

        }
    }
}
