using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DDDOrnek.Domain
{
    public class AddPlayerInteractor
    {
        private readonly IRepository _repository;
        public AddPlayerInteractor(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public void Handle(PlayerId id, Name name, Sport sport, Address address, int rating)
        {
            if (id == null || name == null || sport == null || address == null)
            {
                throw new ArgumentNullException();
            }

            var player = Player.Create(id, name, sport, address, rating);

            _repository.AddPlayer(player);
        }
    }

    public interface IRepository
    {
        void AddPlayer(Player player);
        void AddPlayer(object player);
        void UpdatePlayer(Player player1);
    }
}
