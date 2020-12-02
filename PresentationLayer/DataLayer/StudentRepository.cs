using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class StudentRepository
    {
        public List<Student> GetAllStudents()
        {
            List<Student> studenti = new List<Student>();

            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Students";

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while(sqlDataReader.Read())
                {
                    Student s = new Student();
                    s.Id = sqlDataReader.GetInt32(0);
                    s.Name = sqlDataReader.GetString(1);
                    s.IndexNumber = sqlDataReader.GetString(2);
                    s.AverageMark = sqlDataReader.GetDecimal(3);

                    studenti.Add(s);
                }
            }
            return studenti;
        }

        public int InsertStudent(Student s)
        {
            int result;
            using (SqlConnection sqlConnection = new SqlConnection(Constants.connString))
            {
 
                string commandText = "Insert Into Students(Name, IndexNumber, AverageMark) VALUES(@Name, @IndexNumber, @AverageMark)";
                SqlCommand sqlCommand = new SqlCommand(commandText, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@Name", s.Name);
                sqlCommand.Parameters.AddWithValue("@IndexNumber", s.IndexNumber);
                sqlCommand.Parameters.AddWithValue("@AverageMark", s.AverageMark);

                sqlConnection.Open();

                result = sqlCommand.ExecuteNonQuery();
            }

            return result;         
        }

    }
}
