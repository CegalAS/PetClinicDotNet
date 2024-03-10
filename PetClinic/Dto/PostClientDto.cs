namespace PetClinic.Dto
{
    public class PostClientDto : BaseClientDto
    {
        public DateTimeOffset BirthDate { get; set; }
        public char Sex { get; set; }
    }
}
