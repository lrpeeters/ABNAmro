using System;
using System.ComponentModel.DataAnnotations.Schema;
using ABNAmro.Domain.Interfaces;

namespace ABNAmro.Domain
{
    public abstract class EntityBase : IEntity
    {
        protected EntityBase()
        { }

        [NotMapped]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
