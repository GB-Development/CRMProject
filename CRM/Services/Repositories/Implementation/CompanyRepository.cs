﻿using CRM.Data;
using CRM.Model.Entities;

namespace CRM.Services.Repositories.Implementation
{
    /// <summary>
    /// Представляет реализацию репозитория для работы с объектами типа  <see cref="Company"/>
    /// </summary>
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="CompanyRepository"/>
        /// </summary>
        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Представляет реализацию метода создания и сохранения одиночного объекта типа <see cref="Company"/> в БД
        /// </summary>
        /// <param name="item"></param>
        public void Create(Company item) { }

        /// <summary>
        /// Представляет реализацию метода создания и сохранения коллекции объектов типа <see cref="Company"/> в БД
        /// </summary>
        /// <param name="items"></param>
        public void CreateCollection(List<Company> items)
        {
            _dbContext.AddRange(items);
            _dbContext.SaveChanges();
        }
    }
}