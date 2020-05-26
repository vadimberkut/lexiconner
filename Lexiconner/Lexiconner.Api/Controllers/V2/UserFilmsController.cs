﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Lexiconner.Api.DTOs;
using Lexiconner.Api.Mappers;
using Lexiconner.Api.Models;
using Lexiconner.Api.Services;
using Lexiconner.Api.Services.Interfaces;
using Lexiconner.Application.Exceptions;
using Lexiconner.Application.Services;
using Lexiconner.Domain.Dtos;
using Lexiconner.Domain.Dtos.StudyItems;
using Lexiconner.Domain.Dtos.UserFilms;
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
    public class UserFilmsController : ApiControllerBase
    {
        private readonly IDataRepository _dataRepository;
        private readonly IFilmsService _filmsService;

        public UserFilmsController(
            IDataRepository dataRepository,
            IFilmsService filmsService
        )
        {
            _dataRepository = dataRepository;
            _filmsService = filmsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BaseApiResponseDto<PaginationResponseDto<UserFilmDto>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetAll([FromQuery] UserFilmsRequestDto dto)
        {
            var searchFilter = new UserFilmsSearchFilterModel(dto.Search);
            var result = await _filmsService.GetAllUserFilmsAsync(GetUserId(), dto.Offset, dto.Limit, searchFilter);
            return BaseResponse(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseApiResponseDto<UserFilmDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            var result = await _filmsService.GetUserFilmAsync(GetUserId(), id);
            return BaseResponse(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BaseApiResponseDto<UserFilmDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Create([FromBody] UserFilmCreateDto data)
        {
            var result = await _filmsService.CreateUserFilmAsync(GetUserId(), data);
            return BaseResponse(result);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BaseApiResponseDto<UserFilmDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] UserFilmUpdateDto data)
        {
            var result = await _filmsService.UpdateUserFilmAsync(GetUserId(), id, data);
            return BaseResponse(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.Forbidden)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _filmsService.DeleteUserFilm(GetUserId(), id);
            return StatusCodeBaseResponse();
        }
    }
}