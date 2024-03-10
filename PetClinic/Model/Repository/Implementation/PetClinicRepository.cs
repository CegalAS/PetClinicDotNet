using PetClinic.Model.Repository.Interfaces;

namespace PetClinic.Model.Repository.Implementation
{
    public class PetClinicRepository : IPetClinicRepository
    {
        private PetClinicDbContext _context;

        public PetClinicRepository(PetClinicDbContext context)
        {
            _context = context;
        }

        public void DeleteClient(Client client)
        {
            _context.Client.Remove(client);
        }

        public void UpdateClient(Client client)
        {
            _context.Client.Update(client);
        }

        public void InsertClient(Client client)
        {
            _context.Client.Add(client);
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _context.Client.FindAsync(id);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
