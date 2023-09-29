using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDOrnek.Domain
{
    public class ComparePlayerInteractor
    {
        private readonly IRepository _repository;
        public ComparePlayerInteractor(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void Handle(Player player1, Player player2)
        {
            if (player1 == null || player2 == null)
            {
                throw new ArgumentNullException();
            }

            player1.ComparePlayer(player2);
            _repository.UpdatePlayer(player1);
        }
    }
}
