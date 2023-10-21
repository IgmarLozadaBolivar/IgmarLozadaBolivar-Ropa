using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;

public class TipoEstadoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly  IMapper mapper;
    
    public TipoEstadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoEstadoDto>>> Get()
    {
        var datos = await unitOfWork.TipoEstados.GetAllAsync();
        return mapper.Map<List<TipoEstadoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoEstadoDto>> Get(int id)
    {
        var data = await unitOfWork.TipoEstados.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TipoEstadoDto>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoEstadoDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.TipoEstados.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<TipoEstadoDto>>(datos.registros);
        return new Pager<TipoEstadoDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoEstadoDto>> Post(TipoEstadoDto tipoEstadoDto)
    {
        var data = this.mapper.Map<TipoEstado>(tipoEstadoDto);
        this.unitOfWork.TipoEstados.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        tipoEstadoDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoEstadoDto.Id }, tipoEstadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoEstadoDto>> Put(int id, [FromBody] TipoEstadoDto tipoEstadoDto)
    {
        if (tipoEstadoDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<TipoEstado>(tipoEstadoDto);
        unitOfWork.TipoEstados.Update(data);
        await unitOfWork.SaveAsync();
        return tipoEstadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.TipoEstados.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.TipoEstados.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}