using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Model
{
    public class AddressBookModel
    {
        public List<Address> AddressList { get; set; }



        public class Address
        {
            public string Name { get; set; }
            public string NameKana { get; set; }
            public string PostalCode { get; set; }
            public string StreetAddress { get; set; }
            public string FaxNo { get; set; }
            public string TellNo { get; set; }
            public string MailAddress { get; set; }
        }
    }
   
}
