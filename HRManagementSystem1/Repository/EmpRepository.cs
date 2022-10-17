using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using HRManagementSystem1.Models;
namespace HRManagementSystem1.Repository
{
    public class EmpRepository
    {
        private SqlConnection con;
        //To Handle connection related activities    
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
            con = new SqlConnection(constr);
        }
        //To Add Employee details    
        public bool AddEmployee(Employee obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewEmployee", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FirstName", obj.FirstName);
            com.Parameters.AddWithValue("@LastName", obj.LastName);
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Password", obj.Password);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }

        }

        //To sign in
        public string SignIn(Employee obj)
        {

            connection();
            SqlCommand com = new SqlCommand("SignIn", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Email", obj.Email);
            com.Parameters.AddWithValue("@Password", obj.Password);
            string temp = null;
            con.Open();
            SqlDataReader datareader = com.ExecuteReader();
            if (datareader.Read())
            {
                temp = (string)datareader["FirstName"] + " " + (string)datareader["LastName"];
            }
            con.Close();
            return temp;

        }
    }
}