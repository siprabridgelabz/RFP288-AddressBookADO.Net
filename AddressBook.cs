using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADOProblem
{
    public class AddressBook
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
         Initial Catalog=AddressBook_Service;";
        

        public void AddNewContactInDatabase(Contact contact)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("SPAddingNewData", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", contact.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", contact.LastName);
                    cmd.Parameters.AddWithValue("@Address", contact.Address);
                    cmd.Parameters.AddWithValue("@City", contact.City);
                    cmd.Parameters.AddWithValue("@State", contact.State);
                    cmd.Parameters.AddWithValue("@Zip", contact.Zip);
                    cmd.Parameters.AddWithValue("@PhoneNumber", contact.PhoneNumber);
                    cmd.Parameters.AddWithValue("@EmailID", contact.EmailID);
                    int result = cmd.ExecuteNonQuery();
                    if (result >= 1)
                    {
                        Console.WriteLine("Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

       
        public void GetAllDataFrom_DataBase()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                List<Contact>list=new List<Contact>();
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("SPGetAllData", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Contact contact = new Contact();
                            contact.FirstName = reader.GetString(1);
                            contact.LastName = reader.GetString(2);
                            contact.Address = reader.GetString(3);
                            contact.City = reader.GetString(4);
                            contact.State = reader.GetString(5);
                            contact.Zip = reader.GetInt32(6);
                            contact.PhoneNumber = reader.GetInt64(7);
                            contact.EmailID = reader.GetString(8);
                            list.Add(contact);
                        }
                        foreach(Contact item in list)
                        {
                            Console.WriteLine(item.FirstName+" "+ item.LastName + " "+item.Address +
                                " "+item.City + " "+item.State+ " "+item.Zip + " "+item.PhoneNumber + " "+item.EmailID + " ");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No rows is exist");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateDataInDB(Contact contacts)
        {

            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    //Select * from tablename
                    SqlCommand cmd = new SqlCommand("SPUpdateDataInDataBase", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("FirstName", contacts.FirstName);

                    cmd.Parameters.AddWithValue("LastName", contacts.LastName);
                    cmd.Parameters.AddWithValue("City", contacts.City);
                    int result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Contact updated successfully");
                    }
                    else
                    {
                        Console.WriteLine("Not Updated");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DeleteDataFromDB(string firstName)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            try
            {
                using (sqlConnection)
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("SPDeleteDataFromDB", sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("FirstName", firstName);

                    int result = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Contact Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Not Updated");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
