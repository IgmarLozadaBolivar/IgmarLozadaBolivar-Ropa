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

public class EstadoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly  IMapper mapper;
    
    public EstadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EstadoDto>>> Get()
    {
        var datos = await unitOfWork.Estados.GetAllAsync();
        return mapper.Map<List<EstadoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EstadoDto>> Get(int id)
    {
        var data = await unitOfWork.Estados.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<EstadoDto>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<EstadoDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.Estados.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<EstadoDto>>(datos.registros);
        return new Pager<EstadoDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EstadoDto>> Post(EstadoDto estadoDto)
    {
        var data = this.mapper.Map<Estado>(estadoDto);
        this.unitOfWork.Estados.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        estadoDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = estadoDto.Id }, estadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EstadoDto>> Put(int id, [FromBody] EstadoDto estadoDto)
    {
        if (estadoDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Estado>(estadoDto);
        unitOfWork.Estados.Update(data);
        await unitOfWork.SaveAsync();
        return estadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Estados.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Estados.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}