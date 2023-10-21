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

public class DetalleVentaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public DetalleVentaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DetalleVentaDto>>> Get()
    {
        var datos = await unitOfWork.DetalleVentas.GetAllAsync();
        return mapper.Map<List<DetalleVentaDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DetalleVentaDto>> Get(int id)
    {
        var data = await unitOfWork.DetalleVentas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<DetalleVentaDto>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<DetalleVentaDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.DetalleVentas.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<DetalleVentaDto>>(datos.registros);
        return new Pager<DetalleVentaDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DetalleVentaDto>> Post(DetalleVentaDto detalleVentaDto)
    {
        var data = this.mapper.Map<DetalleVenta>(detalleVentaDto);
        this.unitOfWork.DetalleVentas.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        detalleVentaDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = detalleVentaDto.Id }, detalleVentaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DetalleVentaDto>> Put(int id, [FromBody] DetalleVentaDto detalleVentaDto)
    {
        if (detalleVentaDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<DetalleVenta>(detalleVentaDto);
        unitOfWork.DetalleVentas.Update(data);
        await unitOfWork.SaveAsync();
        return detalleVentaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.DetalleVentas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.DetalleVentas.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}