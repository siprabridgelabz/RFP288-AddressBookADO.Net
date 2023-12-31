﻿using System;
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
                Console.WriteLine("3-UpdateData from DB");
                Console.WriteLine("4- Delete Data from DB");

                Console.WriteLine("select above option");
                int option=Convert.ToInt32(Console.ReadLine());
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
                            FirstName = "Lipsa",
                            LastName = "Kumari",
                            City = "MPS"
                        };
                        addressBook.UpdateDataInDB(contacts);
                        break;
                    case 4:
                        addressBook.DeleteDataFromDB("Lipsa");
                        break;
                }


            }
        }
    }
}
