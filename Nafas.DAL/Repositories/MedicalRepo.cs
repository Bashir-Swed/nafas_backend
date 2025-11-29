using Microsoft.Data.SqlClient;
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

    }
}
