using Microsoft.AspNetCore.Mvc;
using CarRentalService.Api.Services;
using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;

namespace CarRentalService.Api.Controllers;

/// <summary>
/// Контроллер для работы с автомобилем
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class VehicleController(IEntityService<VehicleCreateDto, Vehicle> vehicleService) : ControllerBase
{
    /// <summary>
    /// Получить все автомобили
    /// </summary>
    /// <returns>Список автомобилей</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vehicle>>> Get()
    {
        return Ok(await vehicleService.GetAll());
    }

    /// <summary>
    /// Получить автомобиль по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор автомобиля</param>
    /// <returns>Возвращает автомобиль</returns>
    /// <response code="200">Автомобиль</response>
    /// <response code="404">Автомобиль не найден</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> Get(int id)
    {
        var vehicle = await vehicleService.GetById(id);
        if (vehicle == null)
        {
            return NotFound();
        }
        return Ok(vehicle);
    }

    /// <summary>
    /// Добавить новый автомобиль
    /// </summary>
    /// <param name="newVehicle">Новый автомобиль</param>
    /// <returns>Добавленный автомобиль</returns>
    [HttpPost]
    public async Task<ActionResult<Vehicle>> Post(VehicleCreateDto newVehicle)
    {
        return Ok(await vehicleService.Create(newVehicle));
    }

    /// <summary>
    /// Обновить данные автомобиля
    /// </summary>
    /// <param name="id">Идентификатор автомобиля</param>
    /// <param name="vehicle">Данные для изменения</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, VehicleCreateDto vehicle)
    {
        var result = await vehicleService.Update(id, vehicle);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }

    /// <summary>
    /// Удалить автомобиль
    /// </summary>
    /// <param name="id">Идентификатор автомобиля</param>
    /// <returns>Результат операции</returns>
    /// <response code="200">Данные успешно обновлены</response>
    /// <response code="404">Данные с указанным идентификатором не найдены</response>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await vehicleService.Delete(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok();
    }
}
