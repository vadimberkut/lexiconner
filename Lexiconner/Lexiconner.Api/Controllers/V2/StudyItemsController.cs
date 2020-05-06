﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Lexiconner.Api.DTOs;
using Lexiconner.Api.DTOs.StudyItems;
using Lexiconner.Api.Mappers;
using Lexiconner.Api.Models;
using Lexiconner.Api.Services;
using Lexiconner.Api.Services.Interfaces;
using Lexiconner.Application.Exceptions;
using Lexiconner.Application.Services;
using Lexiconner.Domain.Entitites;
using Lexiconner.Persistence.Repositories;
using Lexiconner.Persistence.Repositories.MongoDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lexiconner.Api.Controllers.V2
{
    [ApiController]
    [Authorize]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class StudyItemsController : ApiControllerBase
    {
        private readonly IDataRepository _dataRepository;
        private readonly IStudyItemsService _studyItemsService;
        private readonly IImageService _imageService;

        public StudyItemsController(
            IDataRepository dataRepository,
            IStudyItemsService studyItemsService,
            IImageService imageService
        )
        {
            _dataRepository = dataRepository;
            _studyItemsService = studyItemsService;
            _imageService = imageService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseApiResponseDto<PaginationResponseDto<StudyItemEntity>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] StudyItemsRequestDto dto)
        {
            var searchFilter = new StudyItemsSearchFilter(dto.Search, dto.IsFavourite);
            var result = await _studyItemsService.GetAllStudyItemsAsync(GetUserId(), dto.Offset, dto.Limit, searchFilter, dto.CollectionId);
            return BaseResponse(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseApiResponseDto<StudyItemEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromRoute]string id)
        {
            var entity = await _dataRepository.GetOneAsync<StudyItemEntity>(x => x.Id == id && x.UserId == GetUserId());
            var dto = CustomMapper.MapToDto(entity);
            return BaseResponse(dto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseApiResponseDto<StudyItemEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] StudyItemCreateDto data)
        {
            var entity = CustomMapper.MapToEntity(GetUserId(), data);

            // set image
            var imagesResult = await _imageService.FindImagesAsync(sourceLanguageCode: entity.LanguageCode, entity.Title);

            if (imagesResult.Any())
            {
                // try to find suitable image
                var image = _imageService.GetSuitableImages(imagesResult);
                if (image != null)
                {
                    entity.Image = new StudyItemImageEntity
                    {
                        Url = image.Url,
                        Height = image.Height,
                        Width = image.Width,
                        Thumbnail = image.Thumbnail,
                        ThumbnailHeight = image.ThumbnailHeight,
                        ThumbnailWidth = image.ThumbnailWidth,
                        Base64Encoding = image.Base64Encoding,
                    };
                }
            }

            await _dataRepository.AddAsync(entity);
            var dto = CustomMapper.MapToDto(entity);
            return BaseResponse(dto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BaseApiResponseDto<StudyItemEntity>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromRoute]string id, [FromBody] StudyItemUpdateDto data)
        {
            var entity = await _dataRepository.GetOneAsync<StudyItemEntity>(x => x.Id == id);
            if(entity.UserId != GetUserId())
            {
                throw new AccessDeniedException("Can't edit the item that you don't own!");
            }

            // update
            if (entity.Title != data.Title)
            {
                entity.Image = null;
            }
            entity.Title = data.Title;
            entity.Description = data.Description;
            entity.ExampleText = data.ExampleText;
            entity.IsFavourite = data.IsFavourite;
            entity.LanguageCode = data.LanguageCode;
            entity.Tags = data.Tags;

            // set image
            if (entity.Image == null)
            {
                var imagesResult = await _imageService.FindImagesAsync(sourceLanguageCode: entity.LanguageCode, entity.Title);

                if (imagesResult.Any())
                {
                    // try to find suitable image
                    var image = _imageService.GetSuitableImages(imagesResult);
                    if(image != null)
                    {
                        entity.Image = new StudyItemImageEntity
                        {
                            Url = image.Url,
                            Height = image.Height,
                            Width = image.Width,
                            Thumbnail = image.Thumbnail,
                            ThumbnailHeight = image.ThumbnailHeight,
                            ThumbnailWidth = image.ThumbnailWidth,
                            Base64Encoding = image.Base64Encoding,
                        };
                    }
                }
            }

            await _dataRepository.UpdateAsync(entity);
            var dto = CustomMapper.MapToDto(entity);
            return BaseResponse(dto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute]string id)
        {
            var existing = await _dataRepository.GetOneAsync<StudyItemEntity>(x => x.Id == id && x.UserId == GetUserId());
            if(existing == null)
            {
                throw new NotFoundException();
            }
            await _dataRepository.DeleteAsync<StudyItemEntity>(x => x.Id == existing.Id);
            return StatusCodeBaseResponse();
        }
    }
}