using CarRentalService.Api.Services;
using Microsoft.AspNetCore.Mvc;
using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;

namespace CarRentalService.Api.Controllers;

/// <summary>
/// Запросы
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class RequestController(RequestService requestService) : ControllerBase
{
    /// <summary>
    /// Выводит информацию обо всех транспортных средствах
    /// </summary>
    /// <returns>Список транспортных средств</returns>
    [HttpGet]
    [Route("return-all-vehicle")]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetAllVehicles()
    {
        return Ok(await requestService.GetAllVehicles());
    }

    /// <summary>
    /// Выводит информацию обо всех клиентах, которые брали в аренду автомобили указанной модели
    /// </summary>
    /// <returns>Список клиентов</returns>
    [HttpGet]
    [Route("return-clients-by-car-model")]
    public async Task<ActionResult<IEnumerable<Client>>> GetClientsByVehicleModel([FromQuery] string targetModel)
    {
        return Ok(await requestService.GetClientsByVehicleModel(targetModel));
    }

    /// <summary>
    /// Выводит информацию об автомобилях, находящихся в аренде
    /// </summary>
    /// <returns>Список автомобилей</returns>
    [HttpGet]
    [Route("return-vehicles-under-lease")]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehiclesCurrentlyRented()
    {
        return Ok(await requestService.GetVehiclesCurrentlyRented());
    }

    /// <summary>
    /// Выводит топ 5 наиболее часто арендуемых автомобилей
    /// </summary>
    /// <returns>Список автомобилей</returns>
    [HttpGet]
    [Route("return-top-5-frequently-rented-cars")]
    public async Task<ActionResult<IEnumerable<RecordsInfoDto>>> GetTop5MostRentedVehicles()
    {
        return Ok(await requestService.GetTop5MostRentedVehicles());
    }

    /// <summary>
    /// Выводит для каждого автомобиля количество аренд
    /// </summary>
    /// <return>Количество аренд</return>
    [HttpGet]
    [Route("return-rental-count")]
    public async Task<ActionResult<IEnumerable<RecordsInfoDto>>> GetRentalCount()
    {
        return Ok(await requestService.GetRentalCount());
    }

    /// <summary>
    /// Выводит информацию о пунктах проката, в которых арендовали автомобили максимальное число раз
    /// </summary>
    /// <returns>Список пунктов проката</returns>
    [HttpGet]
    [Route("get-rental-points-with-max-rentals")]
    public async Task<ActionResult<IEnumerable<PointsInfoDto>>> GetRentalPointsWithMaxRentals()
    {
        return Ok(await requestService.GetRentalPointsWithMaxRentals());
    }
}
