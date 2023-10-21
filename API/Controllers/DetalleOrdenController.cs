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

public class DetalleOrdenController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly  IMapper mapper;
    
    public DetalleOrdenController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleOrdenDto>>> Get()
    {
        var datos = await unitOfWork.DetalleOrdenes.GetAllAsync();
        return mapper.Map<List<DetalleOrdenDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleOrdenDto>> Get(int id)
    {
        var data = await unitOfWork.DetalleOrdenes.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<DetalleOrdenDto>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleOrdenDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.DetalleOrdenes.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<DetalleOrdenDto>>(datos.registros);
        return new Pager<DetalleOrdenDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DetalleOrdenDto>> Post(DetalleOrdenDto detalleOrdenDto)
    {
        var data = this.mapper.Map<DetalleOrden>(detalleOrdenDto);
        this.unitOfWork.DetalleOrdenes.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        detalleOrdenDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = detalleOrdenDto.Id }, detalleOrdenDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DetalleOrdenDto>> Put(int id, [FromBody] DetalleOrdenDto detalleOrdenDto)
    {
        if (detalleOrdenDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<DetalleOrden>(detalleOrdenDto);
        unitOfWork.DetalleOrdenes.Update(data);
        await unitOfWork.SaveAsync();
        return detalleOrdenDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.DetalleOrdenes.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.DetalleOrdenes.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}