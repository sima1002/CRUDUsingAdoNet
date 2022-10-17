using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CRUDUsingAdoNet.Models;


namespace CRUDUsingAdoNet.DAL
{
    public class DepartmentDAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public DepartmentDAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Department> GetAllDepartment()
        {
            List<Department> departmentlist = new List<Department>();
            string qry = "select * from Department";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Department department = new Department();
                    department.dept_code = dr["dept_code"].ToString();
                    department.dept_name = dr["dept_name"].ToString();
                   
                }
            }
            con.Close();
            return departmentlist;
        }
        public Department GetDepartmentById(int id)
        {
            Department department = new Department();
            string qry = "select * from Department where dept_code=@dept_code";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dept_code", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    department.dept_code= dr["dept_code"].ToString(); // Id is a col name, should be match
                    department.dept_name= dr["dept_name"].ToString();
                  
                }
            }
            con.Close();
            return department;
        }
        public int AddDepartment(Department dept)
        {
            string qry = "insert into  Department values(@dept_name)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dept_name", dept.dept_name);
            
            
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int UpdateDepartment(Department dept)
        {
            string qry = "update Department set Name=@dept_name where dept_code=@dept_code";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dept_code", dept.dept_code);
            cmd.Parameters.AddWithValue("@dept_name", dept.dept_name);
          
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteDepartment(int id)
        {
            string qry = "delete from Department where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@dept_code", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
