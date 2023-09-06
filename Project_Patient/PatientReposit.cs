using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Patient
{
    public class PatientReposit : IReposit
    {
        public void Delete(int patientId)
        {
            Patient patient = PatientDB.PatientList.FirstOrDefault(x => x.PatientId == patientId);
            PatientDB.PatientList.Remove(patient);
        }

        public IEnumerable<Patient> GetAll()
        {
            return PatientDB.PatientList;
        }

        public Patient GetById(int PatientId)
        {
            Patient patient = PatientDB.PatientList.FirstOrDefault(x => x.PatientId == PatientId);
            return patient;
        }

        public void Insert(Patient patient)
        {
           PatientDB.PatientList.Add(patient);
        }

        public void Update(Patient patient)
        {
            Patient _patient = PatientDB.PatientList.FirstOrDefault(x => x.PatientId == patient.PatientId );
            if (patient.Name != null)
            {
                _patient.Name = patient.Name;
            }
            if (patient.Gender != null)
            { 
                _patient.Gender = patient.Gender;
            }
            if (patient.Age != 0)
            { 
                _patient.Age = patient.Age;
            }
            if (patient.Disease != null)
            { 
                _patient.Disease = patient.Disease;
            }
        }
    }
}
