using System.Globalization;
using System.Text.RegularExpressions;
using PetClinic.Dto;

namespace PetClinic.Validation
{
    public class ClientValidator
    {
        public ClientValidator() { }

        public List<string> ValidatePostClient(PostClientDto clientDto)
        {
            var errors = new List<string>();

            if (clientDto.BirthDate > DateTime.Now)
            {
                errors.Add("Birth date cannot be in the future");
            }
            if (clientDto.BirthDate < DateTime.Now.AddYears(-120))
            {
                errors.Add("Birth date cannot be more than 120 years ago");
            }
            if (clientDto.Sex != 'M' && clientDto.Sex != 'F')
            {
                errors.Add("Sex can be either M or F");
            }
            errors.AddRange(ValidatePutClient(clientDto));

            return errors;
        }

        public List<string> ValidatePutClient(BaseClientDto clientDto)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(clientDto.Name))
            {
                errors.Add("Name is required");
            }
            if (!string.IsNullOrEmpty(clientDto.Name) && clientDto.Name.Length > 100)
            {
                errors.Add("Name is too long");
            }

            if (!string.IsNullOrEmpty(clientDto.Name) && clientDto.Name.Split(" ").Length < 2)
            {
                errors.Add("Please specify first name and last name");
            }

            if (string.IsNullOrEmpty(clientDto.StreetAddress))
            {
                errors.Add("Street address is required");
            }

            if (
                !string.IsNullOrEmpty(clientDto.StreetAddress)
                && clientDto.StreetAddress.Length > 200
            )
            {
                errors.Add("Street address is too long");
            }

            if (
                !string.IsNullOrEmpty(clientDto.StreetAddress)
                && clientDto.StreetAddress.Split(" ").Length < 2
            )
            {
                errors.Add("Please Specify Street address and house number");
            }

            if (string.IsNullOrEmpty(clientDto.City))
            {
                errors.Add("City is required");
            }

            if (!string.IsNullOrEmpty(clientDto.City) && clientDto.City.Length > 100)
            {
                errors.Add("City name is too long");
            }

            if (string.IsNullOrEmpty(clientDto.ZipCode))
            {
                errors.Add("Zip code is required");
            }
            if (!string.IsNullOrEmpty(clientDto.ZipCode) && clientDto.ZipCode.Length != 4)
            {
                errors.Add("Zip code must be 4 digits");
            }
            if (string.IsNullOrEmpty(clientDto.PhoneNumber))
            {
                errors.Add("Phone number is required");
            }
            if (!string.IsNullOrEmpty(clientDto.PhoneNumber) && clientDto.PhoneNumber.Length != 8)
            {
                errors.Add("Phone number must be 8 digits");
            }
            if (string.IsNullOrEmpty(clientDto.Email))
            {
                errors.Add("Email is required");
            }
            if (!string.IsNullOrEmpty(clientDto.Email) && !IsValidEmail(clientDto.Email))
            {
                errors.Add("Email is not valid");
            }
            return errors;
        }

        /// <summary>
        /// Copied from Microsoft's guide "How to verify that strings are in valid email format":
        /// https://docs.microsoft.com/en-us/dotnet/standard/base-types/how-to-verify-that-strings-are-in-valid-email-format
        /// NOTE: This is overall a less strict validation than the original implementation. See also:
        /// https://softwareengineering.stackexchange.com/questions/78353/how-far-should-one-take-e-mail-address-validation
        /// Additional validations can be added if required in the future.
        /// </summary>
        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(
                    email,
                    @"(@)(.+)$",
                    DomainMapper,
                    RegexOptions.None,
                    TimeSpan.FromMilliseconds(200)
                );

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    var domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(
                    email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(250)
                );
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
