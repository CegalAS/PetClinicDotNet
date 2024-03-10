using PetClinic.Dto;
using PetClinic.Validation;

namespace PetClinicUnitTests
{
    public class ClientValidationUnitTests
    {
        private ClientValidator _validator;

        public ClientValidationUnitTests()
        {
            _validator = new ClientValidator();
        }

        [Fact]
        public void PostClientTestHappyPath_ReturnsNull()
        {
            var client = new PostClientDto
            {
                Name = "John Doe",
                BirthDate = new DateTimeOffset(1980, 1, 1, 0, 0, 0, TimeSpan.Zero),
                StreetAddress = "123 Main St",
                ZipCode = "1234",
                City = "Anytown",
                Sex = 'M',
                PhoneNumber = "12345678",
                Email = "john.doe@gmail.com"
            };
            var errors = _validator.ValidatePostClient(client);
            Assert.Empty(errors);
        }

        [Fact]
        public void PostClientTestNullErrors_ReturnsError()
        {
            var client = new PostClientDto
            {
                Name = "",
                BirthDate = new DateTimeOffset(1980, 1, 1, 0, 0, 0, TimeSpan.Zero),
                StreetAddress = "",
                ZipCode = "",
                City = "",
                Sex = ' ',
                PhoneNumber = "",
                Email = ""
            };
            var errors = _validator.ValidatePostClient(client);

            Assert.NotEmpty(errors);
            Assert.Equal(7, errors.Count);
            Assert.Contains("Name is required", errors);
            Assert.Contains("Street address is required", errors);
            Assert.Contains("City is required", errors);
            Assert.Contains("Zip code is required", errors);
            Assert.Contains("Sex can be either M or F", errors);
            Assert.Contains("Phone number is required", errors);
            Assert.Contains("Email is required", errors);
        }

        [Fact]
        public void PostClientTestNonNullErrors_ReturnsError()
        {
            var client = new PostClientDto
            {
                Name = "Jhn",
                BirthDate = new DateTimeOffset(2050, 1, 1, 0, 0, 0, TimeSpan.Zero),
                StreetAddress = "Adress",
                ZipCode = "123",
                City = "City",
                Sex = 'M',
                PhoneNumber = "12345678910",
                Email = "john.doe@emai.au.com"
            };
            var errors = _validator.ValidatePostClient(client);

            Assert.NotEmpty(errors);
            Assert.Equal(5, errors.Count);
            Assert.Contains("Please specify first name and last name", errors);
            Assert.Contains("Please Specify Street address and house number", errors);
            Assert.Contains("Zip code must be 4 digits", errors);
            Assert.Contains("Phone number must be 8 digits", errors);
            Assert.Contains("Birth date cannot be in the future", errors);
        }

        [Fact]
        public void PostClientToLongNameTestAndTooOldInvalidMail_ReturnsErrors()
        {
            //create a string
            var client = new PostClientDto
            {
                Name = new string('a', 101) + " " + new string('a', 101),
                BirthDate = new DateTimeOffset(1000, 1, 1, 0, 0, 0, TimeSpan.Zero),
                StreetAddress = new string('a', 101) + " " + new string('a', 101),
                ZipCode = "1234",
                PhoneNumber = "12345678",
                City = new string('a', 101),
                Email = "john.doe123215432mail.com",
                Sex = 'M'
            };

            var errors = _validator.ValidatePostClient(client);
            Assert.NotEmpty(errors);
            Assert.Equal(5, errors.Count);
            Assert.Contains("Birth date cannot be more than 120 years ago", errors);
            Assert.Contains("Name is too long", errors);
            Assert.Contains("Street address is too long", errors);
            Assert.Contains("City name is too long", errors);
            Assert.Contains("Email is not valid", errors);
        }

        [Theory]
        [InlineData("j_o_h_n_d_o_e@mail.com")]
        [InlineData("johnDoes@mail.nice.y.com")]
        [InlineData("123AI###JD@mail.com")]
        public void ClientValidatorStrangeEmailTests(string email)
        {
            var client = new BaseClientDto
            {
                Name = "John Doe",
                StreetAddress = "123 Main St",
                ZipCode = "1234",
                City = "Anytown",
                PhoneNumber = "12345678",
                Email = email
            };
            var errors = _validator.ValidatePutClient(client);
            Assert.Empty(errors);
        }
    }
}
