using CRUDUsingAdoNet.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingAdoNet.DAL
{
    public class Student1DAL
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        private readonly IConfiguration configuration;
        public Student1DAL(IConfiguration configuration)
        {
            this.configuration = configuration;
            string constr = configuration["ConnectionStrings:defaultConnection"];
            con = new SqlConnection(constr);
        }
        public List<Student1> GetAllStudent1()
        {
            List<Student1> studentlist = new List<Student1>();
            string qry = "select * from Student1";
            cmd = new SqlCommand(qry, con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Student1 student = new Student1();
                    student.Id = Convert.ToInt32(dr["Id"]); // Id is a col name, should be match
                    student.Name = dr["Name"].ToString();
                    student.Branch = dr["Branch"].ToString();
                    student.Percentage = Convert.ToInt32(dr["Percentage"]);
                    studentlist.Add(student);
                }
            }
            con.Close();
            return studentlist;
        }
        public Student1 GetStudent1ById(int id)
        {
            Student1 student = new Student1();
            string qry = "select * from Student1 where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    student.Id = Convert.ToInt32(dr["Id"]); // Id is a col name, should be match
                    student.Name = dr["Name"].ToString();
                    student.Branch = dr["Branch"].ToString();
                    student.Percentage = Convert.ToInt32(dr["Percentage"]);
                }
            }
            con.Close();
            return student;
        }
        public int AddStudent1(Student1 stud)
        {
            string qry = "insert into Student1 values(@name,@br,@per)";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@br", stud.Branch);
            cmd.Parameters.AddWithValue("@per", stud.Percentage);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
        public int UpdateStudent1(Student1  stud)
        {
            string qry = "update Student1 set Name=@name,Branch=@br,Percentage=@per where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", stud.Id);
            cmd.Parameters.AddWithValue("@name", stud.Name);
            cmd.Parameters.AddWithValue("@br", stud.Branch);
            cmd.Parameters.AddWithValue("@per", stud.Percentage);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
        public int DeleteStudent1(int id)
        {
            string qry = "delete from Student1 where Id=@id";
            cmd = new SqlCommand(qry, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;
        }
    }
}
