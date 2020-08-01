using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AppendManyToMany
{
    public class Status
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public StatusType StatusType { get; set; }

        //Proprety Name must follow ICollection<TypeName> by convention "PersonAddress".
        public virtual ICollection<PersonAddress> PersonAddress { get; set; } = new Collection<PersonAddress>();

    }
}
