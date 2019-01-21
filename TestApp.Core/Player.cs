using System;

namespace TestApp.Core
{
    public class Player
    {
        public Player(Guid id,string fullName, Position position, int age, Guid clubId)
        {
            Id = id;
            FullName = fullName;
            Position = position;
            Age = age;
            ClubId = clubId;
        }
        public Guid Id { get; }

        public string FullName{ get; }

        public Position Position{ get; }

        public int Age { get; }

        public Guid ClubId { get; }

        public Club Club{ get; set; }


    }
}
