using System;
using System.Collections.Generic;

namespace domain.Entities
{
    public class PeladaEvent : EntityModel
    {
        public int PeladaId { get; set; }
        public DateTime Date { get; set; }
        public int QuantityOfUsers { get; set; }
        public int ArenaId { get; set; }

        public virtual Pelada Pelada { get; set; }
        public virtual Arena Arena { get; set; }
        public List<PeladaEventUser> PeladaEventUsers { get; set; }
    }
}
