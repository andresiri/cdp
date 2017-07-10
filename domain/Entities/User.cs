using System;
using System.Collections.Generic;

namespace domain.Entities
{
    public class User : EntityModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime? Birthday { get; set; }
        public byte? Number { get; set; }
        public string Position { get; set; }

        public virtual List<PeladaEventUser> PeladaEventUsers { get; set; }
        public virtual List<PeladaUser> PeladaUsers { get; set; }
        public virtual List<Pelada> Peladas { get; set; }
    }
}
