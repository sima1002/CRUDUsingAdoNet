using CRUDUsingAdoNet.Models;
using CRUDUsingAdoNet.DAL;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoNet.DAL
{
    public class EmployeDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;

        public EmployeDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }

        public List<Models.Employe> GetAllEmploye()
        {
            List<Models.Employe> EmployeList = new List<Models.Employe>();
            string qry = "select * from Employe";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Models.Employe employe = new Models.Employe();
                    employe.emp_code = dr["emp_code"].ToString();
                    employe.emp_Name = dr["emp_Name"].ToString();
                    employe.emp_dept = dr["emp_Dept"].ToString();
                    
                }
            }
            con.Close();
            return EmployeList;
        }

        public int AddEmploye(Models.Employe emp)
        {
            string qry = "insert into Employe values(@emp_code,@emp_Name,@emp_dept)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", emp.emp_code);
            cmd.Parameters.AddWithValue("@dept", emp.emp_Name);
            cmd.Parameters.AddWithValue("@sal", emp.emp_dept);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }

        public Models.Employe GetEmployeById(int id)
        {
            Models.Employe employee = new Models.Employe();
            string qry = "select * from Employe where emp_code=@emp_code";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@emp_code", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    employee.emp_code = dr["emp_code"].ToString();
                    employee.emp_Name = dr["emp_Name"].ToString();
                    employee.emp_dept = dr["emp_dept"].ToString();
               
                }
            }
            con.Close();
            return employee;
        }

      

        
        public int UpdateEmploye(Employe emp)
        {
            string qry = "update Employe set emp_Name=@emp_Name,emp_dept=@emp_dept where emp_code=@emp_code";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@emp_code", emp.emp_code);
            cmd.Parameters.AddWithValue("@emp_Name", emp.emp_Name);
            cmd.Parameters.AddWithValue("@emp_dept", emp.emp_dept);
          
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteEmploye(int id)
        {
            string qry = "delete from Employe where emp_code=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@emp_code", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}