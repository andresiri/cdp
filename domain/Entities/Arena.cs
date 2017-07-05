using System.Collections.Generic;

namespace domain.Entities
{
    public class Arena : EntityModel
    {
        public string Description { get; set; }
		public string Name { get; set; }
		public string Latitude { get; set; }
		public string Longitude { get; set; }	

        public List<Pelada> Peladas { get; set; }
        public virtual List<PeladaEvent> PeladaEvents { get; set; }
    }
}
