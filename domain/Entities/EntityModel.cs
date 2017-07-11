using System;

namespace domain.Entities
{
    public abstract class EntityModel : Model
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
