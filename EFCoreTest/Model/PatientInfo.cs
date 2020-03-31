using System;
using System.ComponentModel.DataAnnotations;

namespace EFCoreTest.Model
{
    public class PatientInfo
    {
        [Key]
        public string Patient_Id { get; set; }
        public string PATIENT_NAME { get; set; }
        public string PACT_CODE { get; set; }
        public string PACT_NAME { get; set; }
        public string SPELL_CODE { get; set; }
        public string WB_CODE { get; set; }
        public DateTime BIRTHDAY { get; set; }
        public string SEX_CODE { get; set; }
        public string IDENNO { get; set; }
        public string IDCARD_TYPE { get; set; }
        public string PROF_CODE { get; set; }
        public string WORK_NAME { get; set; }
        public string WORK_TEL { get; set; }
        public string WORK_ZIP { get; set; }
        public string HOME_ADDRESS { get; set; }
        public string TELEPHONE { get; set; }
        public string HOME_ZIP { get; set; }
        public string BIRTH_AREA_CODE { get; set; }
        public string DIST { get; set; }
        public string NATION_CODE { get; set; }
        public string COUN_CODE { get; set; }
        public string MARI { get; set; }
        public string EMAIL { get; set; }
        public string LINKMAN_NAME { get; set; }
        public string LINKMAN_TEL { get; set; }
        public string LINKMAN_ADDRESS { get; set; }
        public string LINKMAN_RELA_CODE { get; set; }
        public string ACCOUNT_FLAG { get; set; }
        public int? INHOS_TIMES { get; set; }
        public string ENCRYPT_FLAG { get; set; }
        public string ENCRYPT_DESC { get; set; }
        public string ABO_BLOOD { get; set; }
        public string RH_BLOOD { get; set; }
        public string REMARK { get; set; }
        public string OPER_CODE { get; set; }
        public DateTime OPER_DATE { get; set; }
        public DateTime CREATE_DATE { get; set; }
        public string LOCAL_FLAG { get; set; }
        public string MOBILEPHONE { get; set; }
        public string PACT_NO { get; set; }
        public string ENGLISH_NAME { get; set; }
        public string MOTHER_NAME { get; set; }
        public string FATHER_NAME { get; set; }
        public DateTime LOCAL_BEGIN_DATE { get; set; }
        public string EXTEND_CARDS { get; set; }
        public string VIP_FLAG { get; set; }
    }
}
