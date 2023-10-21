using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class DepartamentoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public DepartamentoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartamentoDto>>> Get()
    {
        var datos = await unitOfWork.Departamentos.GetAllAsync();
        return mapper.Map<List<DepartamentoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartamentoDto>> Get(int id)
    {
        var data = await unitOfWork.Departamentos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<DepartamentoDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<DepartamentoDto>> Post(DepartamentoDto departamentoDto)
    {
        var data = this.mapper.Map<Departamento>(departamentoDto);
        this.unitOfWork.Departamentos.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        departamentoDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = departamentoDto.Id }, departamentoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<DepartamentoDto>> Put(int id, [FromBody] DepartamentoDto departamentoDto)
    {
        if (departamentoDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Departamento>(departamentoDto);
        unitOfWork.Departamentos.Update(data);
        await unitOfWork.SaveAsync();
        return departamentoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Departamentos.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Departamentos.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}