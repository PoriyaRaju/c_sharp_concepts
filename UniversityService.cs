using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AdoLearn
{

    internal class UniversityService
    {
        private SqlConnection _connection;
        public UniversityService(string connString)
        {
            try
            {
                _connection = new SqlConnection(connString);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void GetAllUniversities()
        {

            try
            {
                _connection.Open();
                Console.WriteLine("Database connected");
                string uni_courses = "SELECT * FROM uni_courses";

                SqlCommand cmd = new SqlCommand(uni_courses, _connection);

                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("id|University|Course|Department|Added_at");


                while (reader.Read())
                {
                    // uc.id,u.uni_name,c.course_name,d.department_name,uc.added_at
                    long uni_id = reader.GetInt64(0);
                    string uni_name = reader.GetString(1);
                    string course_name = reader.GetString(2);
                    string department_name = reader.GetString(3);
                    int added_at = reader.GetInt32(4);


                    //Console.WriteLine("reader.GetValue(1); : " + reader.GetValue(1));

                    Console.WriteLine($"{uni_id}|{uni_name}|{course_name}|{department_name}|{added_at}");
                }
                _connection.Close();

                // Count university

                cmd.CommandText = "SELECT count(*) from universities;";
                cmd.Connection = _connection;
                _connection.Open();
                int totlaUniversity = (int)cmd.ExecuteScalar();
                Console.WriteLine(totlaUniversity);
                _connection.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Sql Conncetion Failed");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Conncetion closed...");
                _connection.Close();
            }

        }

        public void AddUniversities(string universitiy,string city,string state,int added_at)
        { 

            string insert_university = "INSERT INTO universities(uni_name,city,state,established_at) VALUES(@universitiy,@city,@state,@added_at);";

            SqlCommand insertCmd = new SqlCommand(insert_university, _connection);

            insertCmd.Parameters.AddWithValue("@universitiy", universitiy);
            insertCmd.Parameters.AddWithValue("@city", city);
            insertCmd.Parameters.AddWithValue("@state", state);
            insertCmd.Parameters.AddWithValue("@added_at", added_at);

            _connection.Open();

            int affectedRows = (int)insertCmd.ExecuteNonQuery();
            Console.WriteLine("affectedRows : " + affectedRows);
            _connection.Close();
        }

        public void GetStudentdetails()
        {
    
            //_connection.ChangeDatabase("multi_universities");

            SqlCommand spCommand = new SqlCommand("sp_student_records", _connection);

            spCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter parameter = new SqlParameter("@student_id", SqlDbType.BigInt);

            parameter.Value = 1;

            spCommand.Parameters.Add(parameter);

            _connection.Open();

            SqlDataReader reader = spCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.Write($"{reader["student_id"]} | {reader["student_name"]} | {reader["university"]} | {reader["college_name"]} | {reader["course_name"]} | {reader["department_name"]} ");
                Console.WriteLine($"{reader["enrollment_year"]} | {reader["current_semester"]} |");
            }
            _connection.Close();
        }

        public void GetUniversitiesByAdpter(string coonString)
        {
            using (SqlConnection conn = new SqlConnection(coonString))
            {
                SqlDataAdapter adpter = new SqlDataAdapter("SELECT * FROM uni_courses WHERE uni_name;", conn);

                DataTable dt = new DataTable();
                adpter.Fill(dt);
                //int column =   dt.Columns.Count;

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row[0]} | {row[1]} | {row[2]} | {row[3]} | {row[4]} ");
                }
            }
        }

        public void UpdateUniversity(string connString)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter adpter = new SqlDataAdapter("SELECT * FROM uni_courses WHERE uni_name = @uni_name;", conn);

                adpter.GetFillParameters();

                DataTable dt = new DataTable();
                adpter.Fill(dt);
                //int column =   dt.Columns.Count;

                foreach (DataRow row in dt.Rows)
                {
                    Console.WriteLine($"{row[0]} | {row[1]} | {row[2]} | {row[3]} | {row[4]} ");
                }
            }
        }

    }
}
