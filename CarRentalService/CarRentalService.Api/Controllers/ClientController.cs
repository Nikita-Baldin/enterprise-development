using Microsoft.AspNetCore.Mvc;
using CarRentalService.Api.Services;
using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;

namespace CarRentalService.Api.Controllers;

/// <summary>
/// Контроллер для работы с клиентами
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class ClientController(IEntityService<ClientCreateDto, Client> clientService) : ControllerBase
{
    /// <summary>
    /// Получить всех клиентов
    /// </summary>
    /// <returns>Список клиентов</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Client>>> Get()
    {
        return Ok(await clientService.GetAll());
    }

    /// <summary>
    /// Получить клиента по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор клиента</param>
    /// <returns>Возвращает клиента</returns>
    /// <response code="200">Клиент</response>
    /// <response code="404">Клиент не найден</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Client>> Get(int id) 
    {
        var client = await clientService.GetById(id);
        if (client == null)
        {
            return NotFound();
        }
        return Ok(client);
    }

    /// <summary>
    /// Добавить нового клиента
    /// </summary>
    /// <param name="newClient">Новый клиент</param>
    /// <returns>Добавленный клиент</returns>
    [HttpPost]
    public async Task<ActionResult<Client>> Post(ClientCreateDto newClient)
    {
        return Ok(await clientService.Create(newClient));
    }

    /// <summary>
    /// Обновить данные клиента
    /// </summary>
    /// <param name="id">Идентификатор клиента</param>
    /// <param name="client">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, ClientCreateDto client)
    {
        var result = await clientService.Update(id, client);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить клиента
    /// </summary>
    /// <param name="id">Идентификатор клиента</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await clientService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
