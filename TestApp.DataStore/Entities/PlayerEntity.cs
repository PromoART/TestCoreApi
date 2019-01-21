using System;
using TestApp.Core;

namespace TestApp.DataStore.Entities
{
    public class PlayerEntity
    {
        public virtual Guid Id { get; set; }

        public virtual string FullName { get; set; }

        public virtual Position Position { get; set; }

        public virtual int Age { get; set; }

        public virtual Guid ClubId { get; set; }
    }
}
