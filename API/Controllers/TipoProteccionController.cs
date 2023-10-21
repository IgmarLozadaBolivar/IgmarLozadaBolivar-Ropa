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

public class TipoProteccionController : Controller
{
    private readonly IUnitOfWork unitOfWork;
    private readonly  IMapper mapper;
    
    public TipoProteccionController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoProteccionDto>>> Get()
    {
        var datos = await unitOfWork.TipoProtecciones.GetAllAsync();
        return mapper.Map<List<TipoProteccionDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoProteccionDto>> Get(int id)
    {
        var data = await unitOfWork.TipoProtecciones.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TipoProteccionDto>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoProteccionDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.TipoProtecciones.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<TipoProteccionDto>>(datos.registros);
        return new Pager<TipoProteccionDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoProteccionDto>> Post(TipoProteccionDto tipoProteccionDto)
    {
        var data = this.mapper.Map<TipoProteccion>(tipoProteccionDto);
        this.unitOfWork.TipoProtecciones.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        tipoProteccionDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoProteccionDto.Id }, tipoProteccionDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoProteccionDto>> Put(int id, [FromBody] TipoProteccionDto tipoProteccionDto)
    {
        if (tipoProteccionDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<TipoProteccion>(tipoProteccionDto);
        unitOfWork.TipoProtecciones.Update(data);
        await unitOfWork.SaveAsync();
        return tipoProteccionDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.TipoProtecciones.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.TipoProtecciones.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}