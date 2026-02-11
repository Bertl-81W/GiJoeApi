using GiJoeApi.Models;

namespace GiJoeApi.Services
{
    public class GiJoeService
    {
        private readonly List<Joe> _joes = new();

        public List<Joe> GetAll()
        {
            return _joes;
        }

        public Joe? GetByName(string name)
        {
            return _joes.FirstOrDefault(j =>
                j.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void Add(Joe newJoe)
        {
            _joes.Add(newJoe);
        }

        public bool Update(string name, Joe updatedJoe)
        {
            var existingJoe = GetByName(name);

            if (existingJoe == null)
            {
                return false;
            }

            existingJoe.Name = updatedJoe.Name;
            existingJoe.PlaceOfBirth = updatedJoe.PlaceOfBirth;
            existingJoe.Specialty = updatedJoe.Specialty;

            return true;
        }

        public bool Delete(string name)
        {
            var joe = GetByName(name);

            if (joe == null)
            {
                return false;
            }

            _joes.Remove(joe);
            return true;
        }

        public async Task<List<Joe>> GetExternalJoesAsync()
        {
            // placeholder for external API call
            await Task.Delay(500);
            return new List<Joe>();
        }
    }
}
