using domain.Entities;

namespace api.ViewModel
{
    public class PeladaUserViewModel
    {       
        public int UserId { get; set; }
        public int PeladaId { get; set; }
        public string PeladaName { get; set; }
        public bool IsMonthly { get; set; }
        public bool IsAdministrator { get; set; }
    }
}
