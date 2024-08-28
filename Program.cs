using Npgsql;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdoCommand3project
{
    internal class Program
    {
        // cs variable is doing Database initialize
        public string cs = "Server=localhost;Port=5432;Database=ado_dbms;UserId=postgres;Password=1234";


        //This method is define the database connection
        public void connection()
        {  
            NpgsqlConnection con = new NpgsqlConnection(cs);

            try
            {
                con.Open();
                using (con)
                {
                    if (con.State == ConnectionState.Open)
                    {
                        Console.WriteLine("Connect Done...!");
                        Console.WriteLine("\n\n\n");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        //This method is show all records in database 
        public void showAllData()
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            con.Open();

            string query = "Select * from Student";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("Id: " + dr["id"] + ", " + "Name: " + dr["name"] + ", " + "Gender: " + dr["gender"] + ", " + "Age: " + dr["age"] + ", "
                    + "City: " + dr["city"] + "\n");       
            }

            Console.WriteLine("\n\n\n");
            con.Close();
        }


        //This method is insert the data in database
        public void insertData() 
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            con.Open();

            Console.Write("Enter the Id : ");
            int id = (int)Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter the Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter the Gender : ");
            string gender = Console.ReadLine();

            Console.Write("Enter the Age : ");
            int age = (int)Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter the City : ");
            string city = Console.ReadLine();

            string query = "insert into Student values(@id, @name, @gender, @age, @city)";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.Parameters.AddWithValue("@name",name);
            cmd.Parameters.AddWithValue("@gender",gender);
            cmd.Parameters.AddWithValue("@age",age);
            cmd.Parameters.AddWithValue("@city",city);
            Console.WriteLine("\n");
            int a =cmd.ExecuteNonQuery();

            if(a > 0) 
            {
                Console.WriteLine("Data inserted Done..!");
                Console.WriteLine("\n\n\n");
            }
            else
            {
                Console.WriteLine("Data insertion failed..!");
                Console.WriteLine("\n\n\n");
            }
            con.Close();
        }


        //This method is update record in database
        public void updatetData()
        {
            NpgsqlConnection con = new NpgsqlConnection(cs);
            con.Open();

            Console.Write("Enter the Id : ");
            int id = (int)Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter the Name : ");
            string name = Console.ReadLine();

            Console.Write("Enter the Gender : ");
            string gender = Console.ReadLine();

            Console.Write("Enter the Age : ");
            int age = (int)Convert.ToInt64(Console.ReadLine());

            Console.Write("Enter the City : ");
            string city = Console.ReadLine();

            string query = "update Student set name = @name, gender = @gender, age = @age, city = @city where id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@gender", gender);
            cmd.Parameters.AddWithValue("@age", age);
            cmd.Parameters.AddWithValue("@city", city);
            Console.WriteLine("\n");
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                Console.WriteLine("Data Update Done..!");
                Console.WriteLine("\n\n\n");
            }
            else
            {
                Console.WriteLine("Data Update failed..!");
                Console.WriteLine("\n\n\n");
            }
            con.Close();
        }



        //This method id delete the record through id
        public void deleteById() 
        {

            NpgsqlConnection con = new NpgsqlConnection(cs);
            con.Open();

            Console.Write(" Do delete data enter the Id : ");
            int id = (int)Convert.ToInt64(Console.ReadLine());

            string query = "delete from Student where id = @id";
            NpgsqlCommand cmd = new NpgsqlCommand( query, con);
            cmd.Parameters.AddWithValue("@id",id);
            int a = cmd.ExecuteNonQuery();

            if (a > 0)
            {
                Console.WriteLine("Data Deleted..!");
                Console.WriteLine("\n\n\n");
            }
            else
            {
                Console.WriteLine("Data deletion failed..!");
                Console.WriteLine("\n\n\n");
            }
            con.Close();
        }


        //Main method
        static void Main(string[] args)
        {
            Program p1 = new Program();
            
            p1.connection();
            p1.showAllData();
            //p1.insertData();
            //p1.updatetData();
            p1.deleteById();
            p1.showAllData();

            Console.ReadLine();
        }
    
    }
}
