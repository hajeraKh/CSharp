using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Patient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PatientInfo();
            Console.ReadKey();
        }
        public static void PatientInfo()
        {
            Console.WriteLine("1. Show All Patient");
            Console.WriteLine("2. Insert Patient");
            Console.WriteLine("3. Update Patient");
            Console.WriteLine("4. Delete Patient");

            var index=int.Parse(Console.ReadLine());
            Show(index);
        }
        public static void Show(int index)
        { 
            PatientReposit patientReposit=new PatientReposit();
            if (index == 1)
            {
                var Patientlist = patientReposit.GetAll();
                if (Patientlist.Count() == 0)
                {
                    Console.WriteLine("========================");
                    Console.WriteLine("No data found");
                    Console.WriteLine("========================");
                    PatientInfo();
                }
                else
                {
                    foreach (var item in patientReposit.GetAll())
                    {
                        Console.WriteLine($"PatientId :{item.PatientId},Name :{item.Name},Gender :{item.Gender},Age:{item.Age},Disease :{item.Disease}");
                    }
                    Console.WriteLine("======================");
                    PatientInfo();
                }
            }
            else if (index == 2)
            {
                Console.WriteLine("==========================");
                Console.Write("Name :");
                string name = Console.ReadLine();

                Console.Write("Gender :");
                string gender = Console.ReadLine();

                Console.Write("Age :");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Disease :");
                string disease = Console.ReadLine();

                int maxId = patientReposit.GetAll().Any() ? patientReposit.GetAll().Max(x => x.PatientId) : 0;
                Patient patient = new Patient
                {
                    PatientId = maxId + 1,
                    Name = name,
                    Gender = gender,
                    Age = age,
                    Disease = disease
                };
                patientReposit.Insert(patient);
                Console.WriteLine("Data Inserted Successfully!!");
                Console.WriteLine("========================");
                PatientInfo();
            }
            else if (index == 3)
            {
                Console.WriteLine("=======================");
                Console.Write("Enter Patient Id to Update :");
                int id = int.Parse(Console.ReadLine());
                var _patient = patientReposit.GetById(id);

                if (_patient == null)
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine("Patient Id is Invalid!!!");
                    Console.WriteLine("==========================");
                    PatientInfo();

                }
                else
                {
                    Console.WriteLine($"Update Info For Patient Id : {id}");
                    Console.WriteLine("======================");
                    Console.Write("Name :");
                    string name = Console.ReadLine();

                    Console.Write("Gender :");
                    string gender = Console.ReadLine();

                    Console.Write("Age :");
                    int age = int.Parse(Console.ReadLine());

                    Console.Write("Disease :");
                    string disease = Console.ReadLine();

                    Patient patient = new Patient
                    {
                        PatientId = id,
                        Name = name,
                        Gender = gender,
                        Age = age,
                        Disease = disease
                    };
                    patientReposit.Update(patient);
                    Console.WriteLine("Data Updated Successfully");
                    Console.WriteLine("=========================");
                    PatientInfo();
                }
            }
            else if (index == 4)
            {
                Console.WriteLine("================================");
                Console.Write("Enter Patient Id To Delete : ");
                int id= int.Parse(Console.ReadLine());
                var _patient= patientReposit.GetById(id);

                if (_patient == null)
                {
                    Console.WriteLine("========================");
                    Console.WriteLine("Patient Id is Invalid!!!");
                    Console.WriteLine("========================");
                    PatientInfo();
                }
                else
                {
                    patientReposit.Delete(id);
                    Console.WriteLine("Data Deleted Successfully!!!");
                    Console.WriteLine("===============================");
                    PatientInfo();
                }
            }
        }
    }
}
