namespace domain.Entities
{
    public class PeladaTeam : EntityModel
    {
        public string Name { get; set; }
        public int PeladaId { get; set; }    
        
        public virtual Pelada Pelada { get; set; }
    }
}