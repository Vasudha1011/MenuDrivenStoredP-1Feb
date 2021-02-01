using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MenuWithoutParameters
{
    class WithParameters
    {

        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        public int InsertWithParameters()
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
                cmd = new SqlCommand("insert into EmployeeTab values(@empname,@salary,@deptno)", con);
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

        public int UpdateWithParameters()
        {
            try
            {
                Console.WriteLine("updating name by id-------");
                Console.WriteLine("Enter employee Id");
                var empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Emp Name to update");
                var empname = Console.ReadLine();
                Console.WriteLine("Enter Emp Salary to update");
                var salary = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter Emp dept id to update");
                var deptno = Convert.ToInt32(Console.ReadLine());
                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");

                cmd = new SqlCommand("update Employeetab set EmpName=@empname,Salary=@salary,DeptNo=@deptno where EmpId=@empid", con);
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value = empid;
                cmd.Parameters.Add("@empname", SqlDbType.VarChar, 20).Value = empname;
                cmd.Parameters.Add("@salary", SqlDbType.Float).Value = salary;
                cmd.Parameters.Add("@deptno", SqlDbType.Int).Value = deptno;
                con.Open();

                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row updated in the table");
                ShowData();
                return i;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                con.Close();
            }
        }

        public int DeleteWithParameters()
        {
            try
            {
                Console.WriteLine("enter Employee id to delete");
                var empid = int.Parse(Console.ReadLine());
                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                cmd = new SqlCommand("delete from Employeetab where EmpId=@empid", con);
                cmd.Parameters.Add("@empid", SqlDbType.Int).Value = empid;

                con.Open();
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("one row deleted in the table");
                ShowData();
                return i;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return 1;
            }
            finally
            {
                con.Close();
            }

        }
        public int SearchWithParameters()
        {
            try
            {

                Console.WriteLine("Enter employee Id");
                var empid = Convert.ToInt32(Console.ReadLine());

                con = new SqlConnection("Data Source=vasudha;Initial Catalog=WFASql;Integrated Security=True");
                cmd = new SqlCommand("select * from Employeetab where EmpId=@empid", con);
                cmd.Parameters.Add("@empId", SqlDbType.Int).Value = empid;

                con.Open();

                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["EmpName"]}\t {dr["Salary"]}\t {dr["DeptNo"]}");
                }
               
                return 0;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
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


    class MenuWithParameters
    {
        static void Main()
        {
            string x;
            WithParameters wp = new WithParameters();

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
                        wp.InsertWithParameters();
                        break;
                    case 2:
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Update operation");
                        Console.WriteLine("--------------------");
                        wp.UpdateWithParameters();
                        break;
                    case 3:
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Delete operation");
                        Console.WriteLine("--------------------");
                        wp.DeleteWithParameters();
                        break;
                    case 4:
                        Console.WriteLine("-------------------");
                        Console.WriteLine("Search operation");
                        Console.WriteLine("--------------------");
                        wp.SearchWithParameters();
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

