using System;
using EFCoreTest.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreTest
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseOracle(
                "DATA SOURCE=LOCALHOST:1521/ORACLE1;USER ID=C##kwitd ;PASSWORD=123456;"
                , b => b.UseOracleSQLCompatibility("12"));
            //加入Sql打印的
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //判断当前数据库是Oracle
            if (this.Database.IsOracle())
            {   //如果需要，手动添加Schema名称，如果是默认或者表前不需要Schema名就可以不用配置
                //modelBuilder.HasDefaultSchema("xuhy");
            }
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Id).ForOracleUseSequenceHiLo("SEQ_EMPLOYEE_ID");
                //列映射
                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.BirthDay).HasColumnName("BIRTHDAY");
                entity.Property(e => e.Department).HasColumnName("DEPARTMENT");
                entity.Property(e => e.EmployeeNo).HasColumnName("EMPLOYEENO");
                entity.Property(e => e.IsValid).HasColumnName("ISVALID");
                entity.Property(e => e.Name).HasColumnName("NAME");
            });
            base.OnModelCreating(modelBuilder);
        }
    }

    public class EFLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new EFLogger(categoryName);
        public void Dispose() { }
    }
    public class EFLogger : ILogger
    {
        private readonly string categoryName;
        public EFLogger(string categoryName) => this.categoryName = categoryName;
        public IDisposable BeginScope<TState>(TState state) => null;
        public bool IsEnabled(LogLevel logLevel) => true;
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //ef core执行数据库查询时的categoryName为Microsoft.EntityFrameworkCore.Database.Command,日志级别为Information
            if (categoryName == "Microsoft.EntityFrameworkCore.Database.Command")
            {
                var logContent = formatter(state, exception);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(logContent);
                Console.ResetColor();
            }
        }
    }
}
