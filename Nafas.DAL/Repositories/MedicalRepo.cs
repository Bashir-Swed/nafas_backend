using Microsoft.Data.SqlClient;
using Nafas.DAL.DTOs.Diseases;
using Nafas.DAL.DTOs.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafas.DAL.Repositories
{
    public class MedicalRepo
    {
        public bool AddMedicalNotes(MedicalNotesDTO note)
        {
            string query = @"insert into MedicalNotes(UserID,Notes)values (@UserID,@Notes)";
            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    using(SqlCommand command=new SqlCommand(query,connection))
                    {
                        command.Parameters.AddWithValue("@UserID", note.UserId);
                        command.Parameters.AddWithValue("@Notes", note.Notes);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool AddNewDisease(MedicalKnowledge Disease)
        {
            string query = @"insert into Diseases(DiseaseName,Discription,Prevention,Symptoms,Treatment)
values(@DiseaseName,@Discription,@Prevention,@Symptoms,@Treatment)";
            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DiseaseName",Disease.DiseaseName);
                        command.Parameters.AddWithValue("@Discription", Disease.Discription);
                        command.Parameters.AddWithValue("@Prevention", Disease.Prevention);
                        command.Parameters.AddWithValue("@Symptoms", Disease.Symptoms);
                        command.Parameters.AddWithValue("@Treatment", Disease.Treatment);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            return true;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
