using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MenuWithoutParameters
{
    class WithOutSqlParameters
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr=null;
        public int InsertWithOutParameters()
        {
            try
            {

                Console.WriteLine("enter Employee Name");
                var empname = Console.ReadLine();
                Console.WriteLine("enter Employee salary");
                var salary = Convert.ToSingle(Console.ReadLine());

                Console.WriteLine("enter Employee departmentid");
                var deptno = Convert.ToInt32(Console.ReadLine());

                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                cmd = new SqlCommand("insert into EmployeeTab values('" + empname + "'," + salary + "," + deptno + ")", con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row added to the table");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                con.Close();
            }
        }


        public int UpateWithOutParameters()
        {
            try
            {
                Console.WriteLine("updating name by id-------");
                Console.WriteLine("enter Employee Name");
                var empname = Console.ReadLine();
                Console.WriteLine("enter Employee id");
                var empid = int.Parse(Console.ReadLine());

                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                cmd = new SqlCommand("update EmployeeTab set empname=('" + empname + "')" + "where empid=(" + empid + ")", con);
                con.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row added to the table");
                ShowData();
                return i;


            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteWithOutParameters()
        {
            try
            {
                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                Console.WriteLine("enter Employee id to delete");
                var empid = int.Parse(Console.ReadLine());
                cmd = new SqlCommand("Delete from Employeetab where empid=(" + empid + ")", con);
                con.Open();
                int j = cmd.ExecuteNonQuery();
                Console.WriteLine("one row deleted in the the table");
                ShowData();
                return j;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                con.Close();
            }

        }
        public int SearchWithOutParameters()
        {

            try
            {
                Console.WriteLine("enter Employee id to search");
                var empid = int.Parse(Console.ReadLine());
                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                cmd = new SqlCommand("select * from EmployeeTab where empid=(" + empid + ")", con);
                con.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {


                    Console.WriteLine($"{dr["empname"]}\t {dr["salary"]}\t {dr["deptno"]}");

                }
                return 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                return 1;
            }
            finally
            {
                dr.Close();
                con.Close();
            }
        }
        public int ShowData()
        {
            try
            {


                Console.WriteLine("Data from the table after the dML Command");
                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                cmd = new SqlCommand("select * from EmployeeTab", con);
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["empid"]}\t{dr["empname"]}\t {dr["salary"]}\t {dr["deptno"]}");
                }
                return 0;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"{ex.Message}");
                return 0;

            }
            finally
            {
                con.Close();
            }
        }
    }
    class Program
    {


        static void Main(string[] args)
        {
            string x;
            WithOutSqlParameters wo = new WithOutSqlParameters();

            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("Choose an operation to perfom");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1.Insert");
                Console.WriteLine("2.Update");
                Console.WriteLine("3.Delete");
                Console.WriteLine("4.Search");
                int opt;
                opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                     case 1:
                         Console.WriteLine("-------------------");
                         Console.WriteLine("Insert operation");
                         Console.WriteLine("--------------------");
                         wo.InsertWithOutParameters();
                         break;
                     case 2:
                         Console.WriteLine("-------------------");
                         Console.WriteLine("Update operation");
                         Console.WriteLine("--------------------");
                         wo.UpateWithOutParameters();
                         break;
                     case 3:
                         Console.WriteLine("-------------------");
                         Console.WriteLine("Delete operation");
                         Console.WriteLine("--------------------");
                         wo.DeleteWithOutParameters();
                         break;
                    case 4:
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Search operation");
                        Console.WriteLine("--------------------");
                        wo.SearchWithOutParameters();
                        break;
                    default:
                        Console.WriteLine("Invalid Option!! Choose only between 1-4");
                        break;

                }
                Console.WriteLine("Do you want to continue yes/no");
                x = Console.ReadLine();

            } while (x == "yes");

        }
    }
}
