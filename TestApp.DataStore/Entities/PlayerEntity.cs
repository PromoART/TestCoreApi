using TestApp.Core;

namespace TestApp.DataStore.Entities
{
    public class PlayerEntity
    {
        public virtual int Id { get; set; }

        public virtual string FullName { get; set; }

        public virtual Position Position { get; set; }

        public virtual int Age { get; set; }

        public virtual int ClubId { get; set; }
    }
}
