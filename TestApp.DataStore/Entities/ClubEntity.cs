using System;

namespace TestApp.DataStore.Entities
{
    public class ClubEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Town { get; set; }
    }
}
