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

public class CargoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly  IMapper mapper;
    
    public CargoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CargoDto>>> Get()
    {
        var datos = await unitOfWork.Cargos.GetAllAsync();
        return mapper.Map<List<CargoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CargoDto>> Get(int id)
    {
        var data = await unitOfWork.Cargos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<CargoDto>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<CargoDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.Cargos.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<CargoDto>>(datos.registros);
        return new Pager<CargoDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<CargoDto>> Post(CargoDto cargoDto)
    {
        var data = this.mapper.Map<Cargo>(cargoDto);
        this.unitOfWork.Cargos.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        cargoDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = cargoDto.Id }, cargoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<CargoDto>> Put(int id, [FromBody] CargoDto cargoDto)
    {
        if (cargoDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Cargo>(cargoDto);
        unitOfWork.Cargos.Update(data);
        await unitOfWork.SaveAsync();
        return cargoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Cargos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Cargos.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}