﻿namespace WebStore.Domain.Entities.Base.Interfaces
{
    public interface IOrderEntity : IEntity
    {
        int Order { get; set; }
    }
}