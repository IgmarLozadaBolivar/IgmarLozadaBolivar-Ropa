using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class MunicipioController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public MunicipioController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<MunicipioDto>>> Get()
    {
        var datos = await unitOfWork.Municipios.GetAllAsync();
        return mapper.Map<List<MunicipioDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<MunicipioDto>> Get(int id)
    {
        var data = await unitOfWork.Municipios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<MunicipioDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<MunicipioDto>> Post(MunicipioDto municipioDto)
    {
        var data = this.mapper.Map<Municipio>(municipioDto);
        this.unitOfWork.Municipios.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        municipioDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = municipioDto.Id }, municipioDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<MunicipioDto>> Put(int id, [FromBody] MunicipioDto municipioDto)
    {
        if (municipioDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Municipio>(municipioDto);
        unitOfWork.Municipios.Update(data);
        await unitOfWork.SaveAsync();
        return municipioDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Municipios.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Municipios.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}