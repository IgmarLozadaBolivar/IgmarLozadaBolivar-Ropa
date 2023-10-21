using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class OrdenController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public OrdenController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrdenDto>>> Get()
    {
        var datos = await unitOfWork.Ordenes.GetAllAsync();
        return mapper.Map<List<OrdenDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<OrdenDto>> Get(int id)
    {
        var data = await unitOfWork.Ordenes.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<OrdenDto>(data);
    }

    [HttpGet("OrdenesEnProceso")]
    //[Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<OrdenDto>>> OrdenesEnProceso()
    {
        var enProceso = await unitOfWork.Ordenes.OrdenesEnProceso();
        return mapper.Map<List<OrdenDto>>(enProceso);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<OrdenDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.Ordenes.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<OrdenDto>>(datos.registros);
        return new Pager<OrdenDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<OrdenDto>> Post(OrdenDto ordenDto)
    {
        var data = this.mapper.Map<Orden>(ordenDto);
        this.unitOfWork.Ordenes.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        ordenDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = ordenDto.Id }, ordenDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<OrdenDto>> Put(int id, [FromBody] OrdenDto ordenDto)
    {
        if (ordenDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Orden>(ordenDto);
        unitOfWork.Ordenes.Update(data);
        await unitOfWork.SaveAsync();
        return ordenDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Ordenes.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Ordenes.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}