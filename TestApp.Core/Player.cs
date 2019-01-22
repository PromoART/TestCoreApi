namespace TestApp.Core
{
    public class Player
    {
        public Player(string fullName, Position position, int age)
        {
            FullName = fullName;
            Position = position;
            Age = age;
        }
        public int Id { get; set; }

        public string FullName{ get; }

        public Position Position{ get; }

        public int Age { get; }

        public int ClubId { get; set; }

        public Club Club{ get; set; }


    }
}
