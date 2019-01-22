namespace TestApp.ClientDataContracts
{
    public class PlayerContract
    {
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Position { get; set; }

        public string Age { get; set; }

        public string ClubId { get; set; }

        public ClubContract Club { get; set; }
    }
}
