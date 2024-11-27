using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.DAL.DTOs
{
    public class ContactDto
    {
            public int ContactID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
            public string EmailID { get; set; }
            public string CompanyName { get; set; }
            public int CompanyID { get; set; }
    }
}