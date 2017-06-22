namespace domain.Entities
{
    public class PeladaEventUser : EntityModel
    {
        public int PeladaEventId { get; set; }
        public int UserId { get; set; }
        public bool UserConfirmed { get; set; }

        public virtual PeladaEvent PeladaEvent { get; set; }
        public virtual User User { get; set; }
    }
}
