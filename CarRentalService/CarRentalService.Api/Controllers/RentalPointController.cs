using Microsoft.AspNetCore.Mvc;
using CarRentalService.Api.Services;
using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;

namespace CarRentalService.Api.Controllers;

/// <summary>
/// Контроллер для работы с пунктом проката
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RentalPointController(RentalPointService rentalPointService) : ControllerBase
{
    /// <summary>
    /// Получить все пункты проката
    /// </summary>
    /// <returns>Список пунктов проката</returns>
    [HttpGet]
    public ActionResult<IEnumerable<RentalPoint>> Get()
    {
        return Ok(rentalPointService.GetAll());
    }

    /// <summary>
    /// Получить пункт проката по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пункта проката</param>
    /// <returns>Возвращает пункт проката</returns>
    /// <response code="200">Пункт проката</response>
    /// <response code="404">Пункт проката не найден</response>
    [HttpGet("{id}")]
    public ActionResult<RentalPoint> Get(int id)
    {
        var rentalPoint = rentalPointService.GetById(id);
        if (rentalPoint == null)
        {
            return NotFound();
        }
        return Ok(rentalPoint);
    }

    /// <summary>
    /// Добавить новый пункт проката
    /// </summary>
    /// <param name="newRentalPoint">Новый пункт проката</param>
    /// <returns>Добавленный пункт проката</returns>
    [HttpPost]
    public ActionResult<RentalPoint> Post(RentalPointCreateDto newRentalPoint)
    {
        return Ok(rentalPointService.Create(newRentalPoint));
    }

    /// <summary>
    /// Обновить данные пункта проката
    /// </summary>
    /// <param name="id">Идентификатор пункта проката</param>
    /// <param name="rentalPoint">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpPut("{id}")]
    public IActionResult Put(int id, RentalPointCreateDto rentalPoint)
    {
        var result = rentalPointService.Update(id, rentalPoint);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить пункт проката
    /// </summary>
    /// <param name="id">Идентификатор пункта проката</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var result = rentalPointService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
