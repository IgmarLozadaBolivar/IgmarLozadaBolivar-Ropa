using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class EmpleadoController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public EmpleadoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<EmpleadoDto>>> Get()
    {
        var datos = await unitOfWork.Empleados.GetAllAsync();
        return mapper.Map<List<EmpleadoDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<EmpleadoDto>> Get(int id)
    {
        var data = await unitOfWork.Empleados.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<EmpleadoDto>(data);
    }

    [HttpGet("Cargos")]
    //[Authorize(Roles = "Administrador, Empleado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<object>> Cargos()
    {
        var entidad = await unitOfWork.Empleados.Cargos();
        var dto = mapper.Map<IEnumerable<object>>(entidad);
        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<EmpleadoDto>> Post(EmpleadoDto empleadoDto)
    {
        var data = this.mapper.Map<Empleado>(empleadoDto);
        this.unitOfWork.Empleados.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        empleadoDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = empleadoDto.Id }, empleadoDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<EmpleadoDto>> Put(int id, [FromBody] EmpleadoDto empleadoDto)
    {
        if (empleadoDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Empleado>(empleadoDto);
        unitOfWork.Empleados.Update(data);
        await unitOfWork.SaveAsync();
        return empleadoDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Empleados.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Empleados.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}