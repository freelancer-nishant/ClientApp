using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.BAL.Models
{
    public class CompanyModel
    {
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; } = string.Empty;
        public string ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public string FormattedPhoneNumber
        {
            get
            {
                if (!string.IsNullOrEmpty(PhoneNumber) && PhoneNumber.Length == 10)
                {
                    return $"({PhoneNumber.Substring(0, 3)}) {PhoneNumber.Substring(3, 3)}-{PhoneNumber.Substring(6)}";
                }
                return PhoneNumber; // Return as-is if formatting is not possible
            }
        }
    }

}
