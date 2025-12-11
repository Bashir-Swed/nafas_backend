using Nafas.DAL.DTOs.Medical;
using Nafas.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafas.BLL.Services
{
    public class MedicalService
    {
        private readonly MedicalRepo _medicalRepo=new MedicalRepo();
        public bool AddMedicalNotes(MedicalNotesDTO note)
        {
            return _medicalRepo.AddMedicalNotes(note);
        }
        public int? AddNewDisease(MedicalKnowledgeDTO Disease)
        {
            return _medicalRepo.AddNewDisease(Disease);
        }
    }
}
