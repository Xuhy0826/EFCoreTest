using System;
using System.Text;

namespace ClassFromDbHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            string fields = "patient_id, patient_name, pact_code, pact_name, spell_code, wb_code, birthday, sex_code, idenno, idcard_type, prof_code, work_name, work_tel, work_zip, home_address, telephone, home_zip, birth_area_code, dist, nation_code, coun_code, mari, email, linkman_name, linkman_tel, linkman_address, linkman_rela_code, account_flag, inhos_times, encrypt_flag, encrypt_desc, abo_blood, rh_blood, remark, oper_code, oper_date, create_date, local_flag, mobilephone, pact_no, english_name, mother_name, father_name, local_begin_date, extend_cards, vip_flag";
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
