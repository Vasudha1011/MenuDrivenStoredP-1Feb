
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace MenuWithoutParameters
{
    class StoredProc
    {

        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public int InsertWithStoredProc()
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
                cmd = new SqlCommand("sp_InsertEmp1", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@salary", SqlDbType.Float).Value = salary;
                cmd.Parameters.Add("@deptno", SqlDbType.Int).Value = deptno;

                con.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row is insertedto the table");
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

        public int UpdateWithStoredProc()
        {
            try
            {
                Console.WriteLine("updating name by id-------");


                Console.WriteLine("enter an existing Employee id to update records");
                var empid = int.Parse(Console.ReadLine());

                Console.WriteLine("enter Employee Name");
                var empname = Console.ReadLine();


                Console.WriteLine("enter salary");
                var salary = int.Parse(Console.ReadLine());

                Console.WriteLine("enter department id");
                var deptno = int.Parse(Console.ReadLine());

                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                cmd = new SqlCommand("sp_UpdateEmp", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;

                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@salary", SqlDbType.Float).Value = salary;
                cmd.Parameters.Add("@deptno", SqlDbType.Int).Value = deptno;
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


        public int DeleteWithStoredProc()
        {
            try
            {
                Console.WriteLine("Enter employee Id to delete");
                var empid = Convert.ToInt32(Console.ReadLine());

                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                cmd = new SqlCommand("sp_DeleteEmp2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                con.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row deleted to the table");
                ShowData();
                return i;


            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return 1;
            }
            finally
            {
                con.Close();

            }
        }

        public int SelectWithStoredP()
        {
            try
            {
                Console.WriteLine("updating name by id-------");


                Console.WriteLine("enter  Employee id ");
                var empid = int.Parse(Console.ReadLine());


                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                con.Open();
                cmd = new SqlCommand("sp_EmployeeSelect1", con);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;
                dr = cmd.ExecuteReader();
                if (dr != null && dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Console.WriteLine($"{dr["empid"]}\t{dr["empname"]}\t {dr["salary"]}\t {dr["deptname"]}");
                    }
                }
                else
                {
                    Console.WriteLine("not found------");
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


    class WithStoredProc
    {
        static void Main()
        {
            string x;
            StoredProc sp = new StoredProc();

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
                        sp.InsertWithStoredProc();
                        break;
                    case 2:
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Update operation");
                        Console.WriteLine("--------------------");
                        sp.UpdateWithStoredProc();
                        break;
                    case 3:
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Delete operation");
                        Console.WriteLine("--------------------");
                        sp.DeleteWithStoredProc();
                        break;
                    case 4:
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Search operation");
                        Console.WriteLine("--------------------");
                        sp.SelectWithStoredP();
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
