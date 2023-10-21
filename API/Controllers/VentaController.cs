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

public class VentaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly  IMapper mapper;
    
    public VentaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<VentaDto>>> Get()
    {
        var datos = await unitOfWork.Ventas.GetAllAsync();
        return mapper.Map<List<VentaDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<VentaDto>> Get(int id)
    {
        var data = await unitOfWork.Ventas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<VentaDto>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<VentaDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.Ventas.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<VentaDto>>(datos.registros);
        return new Pager<VentaDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<VentaDto>> Post(VentaDto ventaDto)
    {
        var data = this.mapper.Map<Venta>(ventaDto);
        this.unitOfWork.Ventas.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        ventaDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = ventaDto.Id }, ventaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<VentaDto>> Put(int id, [FromBody] VentaDto ventaDto)
    {
        if (ventaDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Venta>(ventaDto);
        unitOfWork.Ventas.Update(data);
        await unitOfWork.SaveAsync();
        return ventaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Ventas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Ventas.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}