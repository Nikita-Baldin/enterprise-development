﻿using Microsoft.AspNetCore.Mvc;
using CarRentalService.Api.Services;
using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;

namespace CarRentalService.Api.Controllers;

/// <summary>
/// Контроллер для работы с записями об арендах автомобиля
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalRecordController(RentalRecordService rentalRecordService) : ControllerBase
{
    /// <summary>
    /// Получить все записи об арендах
    /// </summary>
    /// <returns>Записи об арендах автомобилей</returns>
    [HttpGet]
    public ActionResult<IEnumerable<RentalRecord>> Get()
    {
        return Ok(rentalRecordService.GetAll());
    }

    /// <summary>
    /// Получить запись по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор записи об аренде автомобиля</param>
    /// <returns>Возвращает запись</returns>
    /// <response code="200">Запись</response>
    /// <response code="404">Запись не найдена</response>
    [HttpGet("{id}")]
    public ActionResult<RentalRecord> Get(int id)
    {
        var rentalRecord = rentalRecordService.GetById(id);
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
    [HttpPost]
    public ActionResult<RentalRecord> Post(RentalRecordCreateDto newRentalRecord)
    {
        return Ok(rentalRecordService.Create(newRentalRecord));
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
    public IActionResult Put(int id, RentalRecordCreateDto rentalRecord)
    {
        var result = rentalRecordService.Update(id, rentalRecord);
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
    public IActionResult Delete(int id)
    {
        var result = rentalRecordService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}