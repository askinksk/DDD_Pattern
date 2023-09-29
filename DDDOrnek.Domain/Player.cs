using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DDDOrnek.Domain
{
    public class Player
    {
        public Player(PlayerId id, Name name, Sport sport, Address address, int rating, List<Player> playerMatches)
        {
            PlayerId = id;
            Name = name;
            Sport = sport;
            Address = address;
            Rating = rating;
            PlayerMatches = playerMatches;
          }
        public static Player Create(PlayerId id, Name name, Sport sport, Address address, int rating, List<Player> playerMatches)
        {
            return new Player(id, name, sport, address, rating, new List<Player>());
        }

        public void ComparePlayer(Player newPlayer)
        {
            if (SportIsAMatch(newPlayer) && RatingIsAMatch(newPlayer)) PlayerMatches.Add(newPlayer);
        }

        public void UpdateRating(int rating)
        {
            Rating = rating;
        }

        public PlayerId PlayerId { get; private set; }
        public Name Name { get; private set; }
        public Sport Sport { get; private set; }
        public Address Address { get; private set; }
        public int Rating { get; private set;}
        public List<Player> PlayerMatches { get; private set; }

        private bool SportIsAMatch(Player newPlayer)
        {
            return Sport == newPlayer.Sport;
        }
        private bool RatingIsAMatch(Player newPlayer)
        {
            return Math.Abs(Rating - newPlayer.Rating) <= 3;
        }

        internal static object Create(PlayerId id, Name name, Sport sport, Address address, int rating)
        {
            throw new NotImplementedException();
        }
    }
}
