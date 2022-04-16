using CatalogWepApi.Dtos;
using CatalogWepApi.Models;
using Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogWepApi.Services
{
    public interface ICategoryService
    {
        Task<ResponseApi<List<CategoryDto>>> GetAllAsync();
        Task<ResponseApi<CategoryDto>> GetCategoryById(string id);
        Task<ResponseApi<CategoryDto>> CreateCategoryAsync(Category category);
    }
}
