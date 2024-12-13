using Microsoft.AspNetCore.Mvc;
using CarRentalService.Api.Services;
using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;

namespace CarRentalService.Api.Controllers;

/// <summary>
/// Контроллер для работы с записями об арендах автомобиля
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalRecordController(IEntityService<RentalRecordCreateDto, RentalRecord> rentalRecordService) : ControllerBase
{
    /// <summary>
    /// Получить все записи об арендах
    /// </summary>
    /// <returns>Записи об арендах автомобилей</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RentalRecord>>> Get()
    {
        return Ok(await rentalRecordService.GetAll());
    }

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи об аренде автомобиля</param>
    /// <returns>Возвращает запись</returns>
    /// <response code="200">Запись</response>
    /// <response code="404">Запись не найдена</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<RentalRecord>> Get(int id)
    {
        var rentalRecord = await rentalRecordService.GetById(id);
        if (rentalRecord == null)
        {
            return NotFound();
        }
        return Ok(rentalRecord);
    }

    /// <summary>
    /// Добавить новую запись об аренде автомобиля
    /// </summary>
    /// <param name="newRentalRecord">Новая запись</param>
    /// <returns>Добавленная запись</returns>
    /// <response code="200">Запись добавлена</response>
    /// <response code="404">Запись не добавлена</response>
    [HttpPost]
    public async Task<ActionResult<RentalRecord>> Post(RentalRecordCreateDto newRentalRecord)
    {
        var result = await rentalRecordService.Create(newRentalRecord);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    /// <summary>
    /// Обновить данные записи об аренде автомобиля
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <param name="rentalRecord">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, RentalRecordCreateDto rentalRecord)
    {
        var result = await rentalRecordService.Update(id, rentalRecord);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить запись об аренде автомобиля
    /// </summary>
    /// <param name="id">Идентификатор записи</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await rentalRecordService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
