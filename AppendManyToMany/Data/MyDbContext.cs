using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;


namespace AppendManyToMany
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public MyDbContext():base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<PersonAddress> PersonAddresses { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Address> Addresses { get; set; }




        /// <summary>
        /// Links an Associated entity with its related entities.
        /// </summary>
        /// <remarks>
        /// Recommand to put it in the repository level.
        /// </remarks>
        /// <example>
        /// <code>
        /// AppendAssociativeEntity(PersonAddress, Person, Address,..);
        /// </code>
        /// </example>
        public void AppendAssociativeEntity(object associatedEntity, params object[] relatedEntities)
        {
            Type associatedEntityType = associatedEntity.GetType();
            PropertyInfo[] associatedEntityPropreties = associatedEntityType.GetProperties();

            foreach (var relatedEntity in relatedEntities)
            {
                var relatedEntityType = relatedEntity.GetType();

                foreach (var associatedProperty in associatedEntityPropreties)
                {
                    if (associatedProperty.PropertyType == relatedEntityType)
                    {
                        associatedProperty.SetValue(associatedEntity, relatedEntity);

                        var relatedProperty = relatedEntityType.GetProperty(associatedEntityType.Name);
                        relatedProperty.PropertyType.GetMethod("Add").Invoke(relatedProperty.GetValue(relatedEntity, null), new object[] { associatedEntity });
                    }

                }

            }

        }


    }
}
