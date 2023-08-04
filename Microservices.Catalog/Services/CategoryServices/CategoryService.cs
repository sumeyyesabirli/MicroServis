﻿using AutoMapper;
using Microservices.Catalog.Dtos.CategoryDtos;
using Microservices.Catalog.Models;
using Microservices.Catalog.Settings.Abstract;
using MicroServices.Shared.Dtos;
using MongoDB.Driver;
using static MongoDB.Driver.WriteConcern;

namespace Microservices.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDataBaseSettings _dataBaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_dataBaseSettings.ConnectionString);
            var database = client.GetDatabase(_dataBaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_dataBaseSettings.CategoryCollectionName);
        }

        public async Task<Response<CreateCategoryDto>> CreateCategoryAsync(CreateCategoryDto createCategory)
        {
           var value = _mapper.Map<Category>(createCategory);
            await _categoryCollection.InsertOneAsync(value);
            return Response<CreateCategoryDto>.Success(_mapper.Map<CreateCategoryDto>(value),200);

        }

        public async Task<Response<NoContent>> DeleteCategoryAsync(string id)
        {
            var value = await _categoryCollection.DeleteOneAsync(x => x.CategoryID == id);
            if (value.DeletedCount>0) 
            {
                return Response<NoContent>.Success(204);
            }
            else
            {
                return Response<NoContent>.Fail("silinicek data yok ",400);
            }
        }

        public async Task<Response<ResultCategoryDto>> GetCategoryByIdAsync(string id)
        {
            var value = await _categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync();
            if(value== null)
            {
                return  Response<ResultCategoryDto>.Fail("böyle ıd bulunmadı", 404);
            }
            else
            {
                return Response<ResultCategoryDto>.Success(_mapper.Map<ResultCategoryDto>(value), 200);
            }
        }

        public async Task<Response<List<ResultCategoryDto>>> GetCategoryListAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return  Response<List<ResultCategoryDto>>.Success(_mapper.Map<List<ResultCategoryDto>>(values) ,200);
        }


        public async Task<Response<UpdateCategoryDto>> UpdateCategoryAsync(UpdateCategoryDto updateCategory)
        {
            var values = _mapper.Map<Category>(updateCategory);
            var result = await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategory.CategoryID, values);
            if (result == null)
            {
                return Response<UpdateCategoryDto>.Fail("Güncellenecek veri bulunumadı", 400);
            }
            else
            {
                return Response<UpdateCategoryDto>.Success(204);
            }
        }
    }
}
