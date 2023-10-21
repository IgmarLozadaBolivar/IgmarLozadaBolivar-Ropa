using API.Dtos;
using API.Helpers.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class TallaController : BaseApiController
{
   private readonly IUnitOfWork unitOfWork;
   private readonly  IMapper mapper;
   
   public TallaController(IUnitOfWork unitOfWork, IMapper mapper)
   {
       this.unitOfWork = unitOfWork;
       this.mapper = mapper;
   }

   [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TallaDto>>> Get()
    {
        var datos = await unitOfWork.Tallas.GetAllAsync();
        return mapper.Map<List<TallaDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TallaDto>> Get(int id)
    {
        var data = await unitOfWork.Tallas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<TallaDto>(data);
    }

    [HttpGet("Pagination")]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<TallaDto>>> GetPagination([FromQuery] Params dataParams)
    {
        var datos = await unitOfWork.Tallas.GetAllAsync(dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
        var listData = mapper.Map<List<TallaDto>>(datos.registros);
        return new Pager<TallaDto>(listData, datos.totalRegistros, dataParams.PageIndex, dataParams.PageSize, dataParams.Search);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<TallaDto>> Post(TallaDto tallaDto)
    {
        var data = this.mapper.Map<Talla>(tallaDto);
        this.unitOfWork.Tallas.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        tallaDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = tallaDto.Id }, tallaDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TallaDto>> Put(int id, [FromBody] TallaDto tallaDto)
    {
        if (tallaDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Talla>(tallaDto);
        unitOfWork.Tallas.Update(data);
        await unitOfWork.SaveAsync();
        return tallaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Tallas.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Tallas.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}