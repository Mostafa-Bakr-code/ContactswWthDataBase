
using System;
using System.Data;
using ContactsBusinessLayer;

namespace ContactsConsolApp
{
    internal class Program
    {
        static void testFindContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Console.WriteLine(Contact1.FirstName+ " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else 
            {
                Console.WriteLine("Contact [" + ID + "] Not found!");   
            }
        }

        static void testFindCountry(int ID)

        {
            
            clsCountry Country = clsCountry.Find(ID);
            if (Country != null)
            {
                
                Console.WriteLine(Country.ID);
                Console.WriteLine(Country.Name);

            }
            else
            {
                Console.WriteLine("Conuntry [" + ID + "] Not found!");
            }
        }

        static void testAddNewContact()


        {
            clsContact Contact1 = new clsContact();

            Contact1.FirstName = "Fadi";
            Contact1.LastName = "Maher";
            Contact1.Email = "A@a.com";
            Contact1.Phone = "010010";
            Contact1.Address = "address1";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";
          
           if (Contact1.Save())
            {

                Console.WriteLine("Contact Added Successfully with id=" + Contact1.ID);
            }

        }

        static void testAddNewCountry()


        {
            clsCountry Country = new clsCountry();

            Country.Name = "Mexico";


            if (Country.Save())
            {

                Console.WriteLine("Country Added Successfully with id=" + Country.ID);
            }

            else
            {
                Console.WriteLine("Error");
            }

        }

        static void testUpdateContact(int ID)

        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                //update whatever info you want
                Contact1.FirstName = "Lina";
                Contact1.LastName = "Maher";
                Contact1.Email = "A2@a.com";
                Contact1.Phone = "2222";
                Contact1.Address = "222";
                Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
                Contact1.CountryID = 1;
                Contact1.ImagePath = "";

                if (Contact1.Save())
                {

                    Console.WriteLine("Contact updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testUpdateCountry(int ID)

        {
            clsCountry Country = clsCountry.Find(ID);

            if (Country != null)
            {
                //update whatever info you want
                Country.Name = "Morocco";


                if (Country.Save())
                {

                    Console.WriteLine("Country updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void testDeleteContact(int ID)

        {

            if (clsContact.isContactExist(ID))

                if (clsContact.DeleteContact(ID))

                    Console.WriteLine("Contact Deleted Successfully.");
                else
                    Console.WriteLine("Faild to delete contact.");

            else
                Console.WriteLine("The contact with id = " + ID + " is not found");

        }

        static void testDeleteCountry(int ID)

        {

            if (clsCountry.isCountryExist(ID))

                if (clsCountry.DeleteCountry(ID))

                    Console.WriteLine("Country Deleted Successfully.");
                else
                    Console.WriteLine("Faild to delete country.");

            else
                Console.WriteLine("The Country with id = " + ID + " is not found");

        }

        static void ListContacts()
        {

            DataTable dataTable = clsContact.GetAllContacts();
           
            Console.WriteLine("Contacts Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]},  {row["FirstName"]} {row["LastName"]} ");
            }

        }

        static void ListCountries()
        {

            DataTable dataTable = clsCountry.GetAllCountries();

            Console.WriteLine("Countries Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]},  {row["CountryName"]} ");
            }

        }

        static void testIsContactExist(int ID)

        {

            if (clsContact.isContactExist(ID))

                Console.WriteLine("Yes, Contact is there.");

            else
                Console.WriteLine("No, Contact Is not there.");

        }

        static void testIsCountryExist(int ID)

        {

            if (clsCountry.isCountryExist(ID))

                Console.WriteLine("Yes, Country is there.");

            else
                Console.WriteLine("No, Country Is not there.");

        }

        static void Main(string[] args)
        {

            testDeleteCountry(6);


            Console.ReadKey();

        }
    }
}
