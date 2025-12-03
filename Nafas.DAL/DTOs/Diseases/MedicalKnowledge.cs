using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nafas.DAL.DTOs.Diseases
{
    public class MedicalKnowledge
    {
        public int DiseaseID {  get; set; }
        public string DiseaseName {  get; set; }
        public string Discription {  get; set; }
        public string Prevention { get; set; }
        public string Symptoms {  get; set; }
        public string Treatment {  get; set; }
    }
}
