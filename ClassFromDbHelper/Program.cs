using System;
using System.Text;

namespace ClassFromDbHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            string fields = "id, patient_id, patient_status, vaccination_flag, vaccination_note, bloodtransfusion_flag, smoking_code, excessivedrinking_code, main_notes, createby, createtime, modifiedby, modifiedtime, description, delete_flag, backaries, backtaurus, backgemini";
            Console.WriteLine(MakeClass(fields));
            Console.ReadLine();
        }

        static string MakeClass(string fields)
        {
            StringBuilder sb = new StringBuilder();
            var fieldCollection = fields.Split(",");
            foreach (var field in fieldCollection)
            {
                //var propertyName = TransWord(field.Trim());
                var propertyName = field.ToUpper();
                sb.Append($"public string {propertyName} {{ get; set; }}{Environment.NewLine}");
            }
            return sb.ToString();
        }

        private static string TransWord(string p)
        {
            string result = "";
            for (int i = 0; i < p.Length; i++)
            {
                if (i == 0)
                    result += p[i].ToString().ToUpper();
                else if (p[i] == '_')
                {
                    result += '_';
                    result += p[i+1].ToString().ToUpper();
                    i++;
                }
                else
                    result += p[i].ToString().ToLower();
            }
            return result;
        }
    }
}
