using System.Collections.Generic;

namespace TestApp.ClientDataContracts
{
    public class ClubContract
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Town { get; set; }
        public IEnumerable<PlayerContract> Players{ get; set; }
    }
}
