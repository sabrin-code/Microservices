using AutoMapper;
using CatalogWepApi.Dtos;
using CatalogWepApi.Models;
using CatalogWepApi.Settings;
using MongoDB.Driver;
using Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogWepApi.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IMongoCollection<Category> _mongoCollection;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _mapper=mapper;
            _mongoCollection=database.GetCollection<Category>(databaseSettings.CategoryTable);
        }
        public async Task<ResponseApi<List<CategoryDto>>> GetAllAsync()
        {
            var categories = await _mongoCollection.Find(x => true).ToListAsync();
            return ResponseApi<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categories), 200);
        }
        public async Task<ResponseApi<CategoryDto>>GetCategoryById(string id)
        {
            var category = await _mongoCollection.Find(x => x.Id==id).FirstOrDefaultAsync();
            if (category!=null)
            {
                return ResponseApi<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
            }
            return ResponseApi<CategoryDto>.Error(404, "");
           
        }
        public async Task<ResponseApi<CategoryDto>>CreateCategoryAsync(Category category)
        {

            await _mongoCollection.InsertOneAsync(category);
            return ResponseApi<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }

      
    }
}
