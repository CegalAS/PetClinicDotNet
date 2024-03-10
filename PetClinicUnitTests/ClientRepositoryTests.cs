using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PetClinic.Model;
using PetClinic.Model.Repository;
using PetClinic.Model.Repository.Implementation;
using PetClinic.Model.Repository.Interfaces;

namespace PetClinicUnitTests
{
    public class ClientRepositoryTests
    {
        private readonly IPetClinicRepository _repository;

        public ClientRepositoryTests()
        {
            //initialize services

            var config = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("testsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Create and configure services
            //using local db for testing purposes
            //https://learn.microsoft.com/en-us/ef/core/testing/choosing-a-testing-strategy#inmemory-as-a-database-fake

            var services = new ServiceCollection();
            services.AddDbContext<PetClinicDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("SQLServerConnection"))
            );
            services.AddScoped<IPetClinicRepository, PetClinicRepository>();

            // Build the service provider
            var serviceProvider = services.BuildServiceProvider();
            _repository = serviceProvider.GetRequiredService<IPetClinicRepository>();
        }

        [Fact]
        public async Task RegisterDeleteAndGetClient_ReturnsNull()
        {
            //Arrange
            var client = GetClientDetails();
            _repository.InsertClient(client);
            await _repository.SaveAsync();
            var clientFromDb = await _repository.GetClientByIdAsync(client.Id);
            Assert.NotNull(clientFromDb);

            //Act
            _repository.DeleteClient(client);
            await _repository.SaveAsync();

            var clientFromDbAfterDelete = await _repository.GetClientByIdAsync(client.Id);
            Assert.Null(clientFromDbAfterDelete);
        }

        [Fact]
        public async Task RegisterAndGetClientById_ReturnsClient()
        {
            //Arrange
            var client = GetClientDetails();
            //Act
            _repository.InsertClient(client);
            await _repository.SaveAsync();

            //Assert
            var clientFromDb = await _repository.GetClientByIdAsync(client.Id);
            Assert.NotNull(clientFromDb);
            Assert.Equal(client.Name, clientFromDb.Name);
            Assert.Equal(client.BirthDate, clientFromDb.BirthDate);
            Assert.Equal(client.StreetAddress, clientFromDb.StreetAddress);
            Assert.Equal(client.ZipCode, clientFromDb.ZipCode);
            Assert.Equal(client.City, clientFromDb.City);
            Assert.Equal(client.Sex, clientFromDb.Sex);
            Assert.Equal(client.PhoneNumber, clientFromDb.PhoneNumber);
            Assert.Equal(client.Email, clientFromDb.Email);
        }

        [Fact]
        public async Task RegisterAndGetClientByIdUpdateClientAndGetById_ReturnsUpdatedClient()
        {
            //Arrange
            var client = GetClientDetails();
            _repository.InsertClient(client);
            await _repository.SaveAsync();
            var clientFromDb = await _repository.GetClientByIdAsync(client.Id);
            Assert.NotNull(clientFromDb);

            //Act
            clientFromDb.Name = "Jane Doe";
            _repository.UpdateClient(clientFromDb);
            await _repository.SaveAsync();

            //Assert
            var updatedClientFromDb = await _repository.GetClientByIdAsync(client.Id);
            Assert.NotNull(updatedClientFromDb);
            Assert.Equal(clientFromDb.Name, updatedClientFromDb.Name);
        }

        private Client GetClientDetails()
        {
            return new Client
            {
                Name = "John Doe",
                BirthDate = new DateTime(1980, 1, 1, 0, 0, 0),
                StreetAddress = "123 Main St",
                ZipCode = "1234",
                City = "Anytown",
                Sex = 'M',
                PhoneNumber = "12345678",
                Email = "john.doe@gmail.com"
            };
        }
    }
}
