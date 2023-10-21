using API.Dtos;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;

public class ClienteController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ClienteDto>>> Get()
    {
        var datos = await unitOfWork.Clientes.GetAllAsync();
        return mapper.Map<List<ClienteDto>>(datos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ClienteDto>> Get(int id)
    {
        var data = await unitOfWork.Clientes.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        return this.mapper.Map<ClienteDto>(data);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<ClienteDto>> Post(ClienteDto clienteDto)
    {
        var data = this.mapper.Map<Cliente>(clienteDto);
        this.unitOfWork.Clientes.Add(data);
        await unitOfWork.SaveAsync();
        if (data == null)
        {
            return BadRequest();
        }
        clienteDto.Id = data.Id;
        return CreatedAtAction(nameof(Post), new { id = clienteDto.Id }, clienteDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<ActionResult<ClienteDto>> Put(int id, [FromBody] ClienteDto clienteDto)
    {
        if (clienteDto == null)
        {
            return NotFound();
        }
        var data = this.mapper.Map<Cliente>(clienteDto);
        unitOfWork.Clientes.Update(data);
        await unitOfWork.SaveAsync();
        return clienteDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await unitOfWork.Clientes.GetByIdAsync(id);
        if (data == null)
        {
            return NotFound();
        }
        unitOfWork.Clientes.Remove(data);
        await unitOfWork.SaveAsync();
        return NoContent();
    }
}