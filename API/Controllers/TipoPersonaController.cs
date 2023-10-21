using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class TipoPersonaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly  IMapper mapper;
    
    public TipoPersonaController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TipoPersonaDto>>> Get()
    {
        var datos = await unitOfWork.TipoPersonas.GetAllAsync();
        return mapper.Map<List<TipoPersonaDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TipoPersonaDto>> Get(int id)
    {
        var data = await unitOfWork.TipoPersonas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TipoPersonaDto>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TipoPersonaDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.TipoPersonas.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<TipoPersonaDto>>(datos.registros);
        return new Pager<TipoPersonaDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TipoPersonaDto>> Post(TipoPersonaDto tipoPersonaDto)
    {
        var data = this.mapper.Map<TipoPersona>(tipoPersonaDto);
        this.unitOfWork.TipoPersonas.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        tipoPersonaDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = tipoPersonaDto.Id }, tipoPersonaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<TipoPersonaDto>> Put(int id, [FromBody] TipoPersonaDto tipoPersonaDto)
    {
        if (tipoPersonaDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<TipoPersona>(tipoPersonaDto);
        unitOfWork.TipoPersonas.Update(data);
        await unitOfWork.SaveAsync();
        return tipoPersonaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.TipoPersonas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.TipoPersonas.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}