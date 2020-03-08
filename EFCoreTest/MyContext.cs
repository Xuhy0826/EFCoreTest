using System;
using System.Runtime.InteropServices.ComTypes;
using EFCoreTest.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace EFCoreTest
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }

        public DbSet<PatientInfo> Patients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseOracle(
                "data source=localhost:1521/oracle1;user id=C##kwitd;password=123456;Incr Pool Size=5;Decr Pool Size=2;", b => b.UseOracleSQLCompatibility("12"));
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //判断当前数据库是Oracle 需要手动添加Schema(DBA提供的数据库账号名称)
            if (this.Database.IsOracle())
            {
                //modelBuilder.HasDefaultSchema("C##kwitd");
            }
            modelBuilder.Entity<PatientInfo>(entity =>
            {
                entity.ToTable("PTM_PATIENTINFO");
                entity.Property(o => o.PATIENT_ID).IsRequired();
                //entity.Property(o => o.Id).ForOracleUseSequenceHiLo("secq______");
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

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //ef core执行数据库查询时的categoryName为Microsoft.EntityFrameworkCore.Database.Command,日志级别为Information
            if (categoryName == "Microsoft.EntityFrameworkCore.Database.Command"
                && logLevel == LogLevel.Debug)
            {
                var logContent = formatter(state, exception);
                //TODO: 拿到日志内容想怎么玩就怎么玩吧
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(logContent);
                Console.ResetColor();
            }
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }
}
