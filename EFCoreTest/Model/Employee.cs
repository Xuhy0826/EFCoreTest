using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTest.Model
{
    [Table("EMPLOYEE")]  //指定数据库对应表名
    public class Employee
    {
        [Key]  //主键
        [Column("ID")] //指定数据库对应表栏位名称
        public long Id { get; set; }
        [Column("EMPLOYEENO")]
        public int EmployeeNo { get; set; }
        [Column("NAME")]
        public string Name { get; set; }
        [Column("BIRTHDAY")]
        public DateTime BirthDay { get; set; }
        [Column("DEPARTMENT")]
        public string Department { get; set; }
        [Column("ISVALID")]
        public bool IsValid { get; set; }
    }
}
