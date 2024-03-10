namespace PetClinic.Model.Repository.Interfaces
{
    public interface IPetClinicRepository : IDisposable
    {
        void InsertClient(Client client);
        Task<int> SaveAsync();
        Task<Client> GetClientByIdAsync(int id);
        void UpdateClient(Client client);
        void DeleteClient(Client client);
    }
}
