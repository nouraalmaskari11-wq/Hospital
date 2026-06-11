using Hospital_Management_System.Models;
using System.Numerics;

namespace Hospital_Management_System
{
    internal class Program
    {
        public static void PatientRegistration(HospitalContext context)
        {
            int patientId = (context.Patients.Count) + 1;

            Console.WriteLine(" Enter patient Name: ");
            string patientName = Console.ReadLine();

            Console.WriteLine(" Enter Patient Age: ");
            int patientAge = int.Parse(Console.ReadLine());

            Console.WriteLine(" Enter Patient Gender: ");
            string patientGender = Console.ReadLine();

            Console.WriteLine(" Enter Patient Phone:");
            string patientPhone = Console.ReadLine();

            Console.WriteLine(" Enter Patient Email:");
            string patientEmail = Console.ReadLine();

            Console.WriteLine(" Enter Patient Blood Type: ");
            string patientBloodType = Console.ReadLine();

            context.Patients.Add(
                new Patient
                {
                    patientId = patientId,
                    patientName = patientName,
                    patientAge = patientAge,
                    patientGender = patientGender,
                    patientPhone= patientPhone,
                    patientEmail= patientEmail,
                    patientBloodType= patientBloodType
                }
                );
            Console.WriteLine($"Patient: {patientName} Added successufully! , Patient ID :{patientId}");
        }
        public static void AddNewDoctor(HospitalContext context)
        {
            int doctorId = (context.Doctors.Count) + 1;

            Console.WriteLine(" Enter Doctor Name: ");
            string doctorName = Console.ReadLine();

            Console.WriteLine(" Enter Doctor Specialization: ");
            string doctorSpecialization = Console.ReadLine();

            Console.WriteLine(" Enter Doctor Phone: ");
            string doctorPhone = Console.ReadLine();

            Console.WriteLine(" Enter Doctor Email:");
            string doctorEmail = Console.ReadLine();

            Console.WriteLine(" Enter Consultation Fee: ");
            decimal consultationFee = Decimal.Parse( Console.ReadLine());

            context.Doctors.Add(
                new Doctor
                {
                    doctorId = doctorId,
                    doctorName = doctorName,
                    doctorSpecialization = doctorSpecialization,
                    doctorPhone = doctorPhone,
                    doctorEmail = doctorEmail,
                    consultationFee = consultationFee
                }
                );
            Console.WriteLine($"Doctor: {doctorName} Added successufully! , Doctor ID :{doctorId}");

        }
        public static void ViewAllPatients(HospitalContext context)
        {
            if (context.Patients.Count == 0)
            {
                Console.WriteLine("Their is no Patient currently registered!");
                return;
            }

            foreach(Patient patient in context.Patients)
            {
                Console.WriteLine($"Patient ID:{patient.patientId}, Patient Name:{patient.patientName}, Patient Age:{patient.patientAge}, Patient Gender:{patient.patientGender}, Patient Phone:{patient.patientPhone}, Patient Email:{patient.patientEmail}, Patient Blood Type:{patient.patientBloodType} ");
            }
        }
        public static void ViewAllDoctorsBySpecialization(HospitalContext context)
        { 
            foreach (Doctor doctor in context.Doctors)
            {
                Console.WriteLine($"Doctor ID: {doctor.doctorId}, Doctor Name:{doctor.doctorName}");
            }
            
            Console.WriteLine("Enter the Specialization of the Doctor ");
            string doctorSpecialization = Console.ReadLine(); // "cardiologists "

            bool found =false;  

            foreach (Doctor doctor in context.Doctors)
            {
                if (doctor.doctorSpecialization == doctorSpecialization)
                {
                    Console.WriteLine($"Doctor ID: {doctor.doctorId}, Doctor Name:{doctor.doctorName}, Doctor Specialization: {doctor.doctorSpecialization}, Consultation Fee: {doctor.consultationFee}");
                    found = true;
                }  
            }

            if (found = false)
            {
                Console.WriteLine($"The doctor with {doctorSpecialization} Specialization dosen't found.");
            }
        }
       

   

        static void Main(string[] args)
        {
            HospitalContext context = new HospitalContext();
            context.Patients = new List<Patient>();
            context.Doctors = new List<Doctor>();
            context.Appointments = new List<Appointment>();
            context.AvailableSlots = new List<AvailableSlot>();
            context.MedicalRecords = new List<MedicalRecord>();

            
            bool exit = false;

            while (exit == false)
            {
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        PatientRegistration(context);
                        break;
                    case 2:
                        AddNewDoctor(context);
                        break;
                    case 3:
                        ViewAllPatients(context);
                        break;
                    case 4:
                        ViewAllDoctorsBySpecialization(context);
                        break;
                    case 5:
                      
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Enter A valid option");
                        break;
                }

                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
                Console.Clear();
            }
                
        }
    }
}
