using System;

namespace ABNAmro.Domain.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
