﻿using CRM.Model.Entities;

namespace CRM.Services.Repositories
{
    public interface IDealRepository : IRepository<Deal>
    {
        /// <summary>
        /// Представляет метод чтения коллекции объектов
        /// </summary>
        /// <param name="items"></param>
        List<Deal> ReadCollection();
    }
}
