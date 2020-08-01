using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace AppendManyToMany
{
    [Table("Person_Address")] //Associated entity
    public class PersonAddress
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
    }
}
