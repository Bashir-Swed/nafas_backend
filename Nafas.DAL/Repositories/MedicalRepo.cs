using Microsoft.Data.SqlClient;
using Nafas.DAL.DTOs;
using Nafas.DAL.DTOs.Medical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
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
                    using (SqlCommand command = new SqlCommand(query, connection))
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public int? AddNewDisease(MedicalKnowledgeDTO Disease)
        {
            string query = @"insert into MedicalKnowledge(DiseaseName,Discription,Prevention,Symptoms,Treatment)
values(@DiseaseName,@Discription,@Prevention,@Symptoms,@Treatment)";
            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DiseaseName", Disease.DiseaseName);
                        command.Parameters.AddWithValue("@Discription", Disease.Discription);
                        command.Parameters.AddWithValue("@Prevention", Disease.Prevention);
                        command.Parameters.AddWithValue("@Symptoms", Disease.Symptoms);
                        command.Parameters.AddWithValue("@Treatment", Disease.Treatment);
                        connection.Open();
                        int id = (int)command.ExecuteScalar();
                        return id;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public int? UpdateDisease(MedicalKnowledgeDTO Disease)
        {
            string query = @"UPDATE Diseases
                     SET DiseaseName = @DiseaseName,
                         Discription =@Discription,
                         Prevention = @Prevention,
                         Symptoms = @Symptoms,
                         Treatment = @Treatment
                     WHERE DiseaseID = @DiseaseID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@DiseaseName", Disease.DiseaseName);
                        command.Parameters.AddWithValue("@Discription", Disease.Discription);
                        command.Parameters.AddWithValue("@Prevention", Disease.Prevention);
                        command.Parameters.AddWithValue("@Symptoms", Disease.Symptoms);
                        command.Parameters.AddWithValue("@Treatment", Disease.Treatment);

                        connection.Open();
                        int rows = command.ExecuteNonQuery();
                        return rows;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public int? DeleteDisease(int diseaseID)
        {
            string query = @"DELETE FROM Diseases
                     WHERE DiseaseID = @DiseaseID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DiseaseID", diseaseID);

                        connection.Open();
                        int rows = command.ExecuteNonQuery();
                        return rows;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }


        public int? UpdateMedicalNotes(MedicalNotesDTO note)
        {
            string query = @" UPDATE MedicalNotes
                     SET Notes=@Notes
					  WHERE UserID=@UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Notes", note.Notes);


                        connection.Open();
                        int rows = command.ExecuteNonQuery();
                        return rows;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        public int? DeleteMedicalNotes(MedicalNotesDTO note)
        {
            string query = @" Delete FROM MedicalNotes WHERE UserID=@UserID";

            try
            {
                using (SqlConnection connection = new SqlConnection(Global.connectionstring))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Notes", note.Notes);


                        connection.Open();
                        int rows = command.ExecuteNonQuery();
                        return rows;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;

        }
    }
}

