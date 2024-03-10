using System.Net;
using System.Numerics;

namespace PetClinic.Dto
{
    public class GetClientDto
    {
        public string Name { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string Address { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<GetClientPetsDto> Pets { get; set; } = new List<GetClientPetsDto>();
    }

    public class GetClientPetsDto
    {
        public string PetName { get; set; }
        public string PetType { get; set; }
        public string PetBreed { get; set; }
        public string MedicalHistory { get; set; }
        public List<GetClientPetsAppointmentsDto> Appointments { get; set; }
    }

    public class GetClientPetsAppointmentsDto
    {
        public string AppointmentStartTime { get; set; }
        public string AppointmentEndTime { get; set; }
        public string AppointmentClinicName { get; set; }
        public string AppointmentVetName { get; set; }
    }
}
