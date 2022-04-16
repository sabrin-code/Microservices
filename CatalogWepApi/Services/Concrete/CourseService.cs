using AutoMapper;
using CatalogWepApi.Models;
using CatalogWepApi.Settings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Responses;
using CatalogWepApi.Dtos;

namespace CatalogWepApi.Services
{
    public class CourseService
    {
        private readonly IMapper _map;
        private readonly IMongoCollection<Course> _mongoCollection;
        private readonly IMongoCollection<Category> _mongoCategoryCollection;
        public CourseService(IMapper map,IDatabaseSettings databaseSettings)
        {
            var connection = new MongoClient(databaseSettings.ConnectionString);
            var database = connection.GetDatabase(databaseSettings.DatabaseName);
            _mongoCollection=database.GetCollection<Course>(databaseSettings.CourseTable);

            _map=map;
        }

        public async Task<ResponseApi<List<CourseDto>>> GetAllAsync()
        {
            var courses = await _mongoCollection.Find(x => true).ToListAsync();
            if (courses.Any())
            {
                foreach (var item in courses)
                {
                    item.Category=await _mongoCategoryCollection.Find(x => x.Id==item.CategoryId).FirstOrDefaultAsync();
                }
                
            }
            else
            {
                courses= new List<Course>();
            }
            return ResponseApi<List<CourseDto>>.Success(_map.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<ResponseApi<CourseDto>>GetCourseByIdAsync(string id)
        {
            var course = await _mongoCollection.Find(x => x.Id==id).FirstOrDefaultAsync();
           course.Category = await _mongoCategoryCollection.Find(x => x.Id==course.CategoryId).FirstOrDefaultAsync();
            if (course==null)
            {
                return ResponseApi<CourseDto>.Error(404,"Course not found");
            }
            return ResponseApi<CourseDto>.Success(_map.Map<CourseDto>(course), 200);
        }

        public async Task<ResponseApi<List<CourseDto>>>GetCourseByUserIdAsync(string id)
        {
            var courses = await _mongoCollection.Find(x => x.UserId==id).ToListAsync();
            if (courses.Any())
            {
                foreach (var item in courses)
                {
                    item.Category=await _mongoCategoryCollection.Find(x => x.Id==item.Id).FirstOrDefaultAsync();
                }
            }
            else
            {
                courses =new List<Course>();
            }
            return ResponseApi<List<CourseDto>>.Success(_map.Map<List<CourseDto>>(courses), 200);
        }

        public async Task<ResponseApi<CourseDto>>CreateCourseAsync(CourseCreateDto courseCreateDto)
        {
            var newcourse = _map.Map<Course>(courseCreateDto);
            await _mongoCollection.InsertOneAsync(newcourse);
            return ResponseApi<CourseDto>.Success(_map.Map<CourseDto>(newcourse), 200);
        }
        public async Task<ResponseApi<CourseDto>>UpdateCOurseAsync(UpdateCourseDto updateCourseDto)
        {
            var updatedcourse = _map.Map<Course>(updateCourseDto);
            var result = await _mongoCollection.FindOneAndReplaceAsync(x => x.Id==updateCourseDto.Id, updatedcourse);
            if (result==null)
            {
                return ResponseApi<CourseDto>.Error(404, "");
            }
            return ResponseApi<CourseDto>.Success(_map.Map<CourseDto>(updatedcourse), 200);

        }

        public async Task<ResponseApi<CourseDto>>DeleteCourseAsync(string id)
        {
            var result = await _mongoCollection.DeleteOneAsync(x => x.Id==id);
            if (result.DeletedCount>0)
            {
                return ResponseApi<CourseDto>.Success(200);
            }
            return ResponseApi<CourseDto>.Error(404,"");
            
        }
    }
}
