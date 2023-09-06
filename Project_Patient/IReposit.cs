using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Patient
{
    public interface IReposit
    {
        IEnumerable<Patient> GetAll();
        Patient GetById(int PatientId);
        void Insert(Patient patient);
        void Update(Patient patient);
        void Delete(int patientId);

    }
}
