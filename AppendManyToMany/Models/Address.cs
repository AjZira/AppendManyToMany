using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AppendManyToMany
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }

        //Proprety Name must follow ICollection<TypeName> by convention "PersonAddress".
        public virtual ICollection<PersonAddress> PersonAddress { get; set; } = new Collection<PersonAddress>();
    }
}
