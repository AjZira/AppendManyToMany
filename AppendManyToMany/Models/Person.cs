using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppendManyToMany
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName { get => FirstName + ' ' + LastName; }

        //Proprety Name must follow ICollection<TypeName> by convention "PersonAddress".
        public virtual ICollection<PersonAddress> PersonAddress { get; set; } = new Collection<PersonAddress>();
    }
}
