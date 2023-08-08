using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADOProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Contact contact = new Contact() { FirstName = "Sipra", LastName = "Mishra", Address = "MPL",
                City = "Jajpur", State = "OD", Zip = 123456, PhoneNumber = 96687835,
                    EmailID = "sipra123@" };
                AddressBook addressBook = new AddressBook();
                Console.WriteLine("1-Insert Data");
                Console.WriteLine("2-Crate All Data from DataBase");
                Console.WriteLine("3-Update Data In DataBase");
                Console.WriteLine("select above option");

                int option =Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        addressBook.AddNewContactInDatabase(contact);
                        break;
                    case 2:
                        addressBook.GetAllDataFrom_DataBase();
                        break;
                    case 3:
                        Contact contacts = new Contact()
                        {
                            FirstName = "Priya",
                            LastName = "Mishra",
                            City = "UK"
                        };
                        addressBook.UpdateDataInDB(contacts);
                        break;
                }


            }
        }
    }
}
