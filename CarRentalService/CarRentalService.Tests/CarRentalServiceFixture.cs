using CarRentalService.Domain.Entity;
namespace CarRentalService.Tests;

public class CarRentalServiceFixture
{
    public List<Client> Clients =
    [
        new(){Id = 0, BirthDate =  new DateTime(2024, 11, 1, 10, 0, 0), FullName = "Данил Шуст", PassportNumber = "7050 845653"},
        new(){Id = 1, PassportNumber = "1153 553450", FullName = "Иван Иванов", BirthDate = new DateTime(2024, 11, 1, 10, 0, 0) },
        new(){Id = 2, PassportNumber = "9940 003490", FullName = "Мария Смирнова", BirthDate = new DateTime(2024, 11, 1, 10, 0, 0) },
        new(){Id = 3, PassportNumber = "4260 652390", FullName = "Алексей Кузнецов", BirthDate = new DateTime(2024, 11, 1, 10, 0, 0) },
        new(){Id = 4, PassportNumber = "8369 704904", FullName = "Елена Соколова", BirthDate = new DateTime(2024, 11, 1, 10, 0, 0) },
        new(){Id = 5, PassportNumber = "2640 888338", FullName = "Дмитрий Попов", BirthDate = new DateTime(2024, 11, 1, 10, 0, 0) }
    ];

    public List<RentalPoint> RentalPoints =
    [
        new RentalPoint { Id = 0, Name = "Прокат в центре", Address = "ул. Ленина, д. 123" },
        new RentalPoint { Id = 1, Name = "Прокат в аэропорту", Address = "ул. Воздушная, д. 456" },
        new RentalPoint { Id = 2, Name = "Прокат в пригороде", Address = "ул. Зеленая, д. 789" }
    ];

    public List<Vehicle> Vehicles =
    [
        new Vehicle { Id = 0, Model = "Тойота Королла", Color = "Белый" },
        new Vehicle { Id = 1, Model = "Хонда Цивик", Color = "Черный" },
        new Vehicle { Id = 2, Model = "Форд Фокус", Color = "Синий" },
        new Vehicle { Id = 3, Model = "Тойота Королла", Color = "Красный" },
        new Vehicle { Id = 4, Model = "Ниссан Альтима", Color = "Серый" }
    ];

    public List<RentalRecord> RentalRecords =
    [
        new RentalRecord
        {
            Id = 0, VehicleId = 0, ClientId = 0, RentalPointId = 0,
            RentalStart = new DateTime(2024, 11, 1, 10, 0, 0),
            RentalDurationDays = 5,
            RentalEnd = new DateTime(2024, 11, 6, 9, 0, 0),
            ReturnPointId = 2
        },
        new RentalRecord
        {
            Id = 1, VehicleId = 1, ClientId = 1, RentalPointId = 1,
            RentalStart = new DateTime(2024, 11, 3, 12, 0, 0),
            RentalDurationDays = 3,
            RentalEnd = new DateTime(2024, 11, 6, 15, 0, 0),
            ReturnPointId = 1
        },
        new RentalRecord
        {
            Id = 2, VehicleId = 2, ClientId = 2, RentalPointId = 2,
            RentalStart = new DateTime(2024, 11, 5, 14, 0, 0),
            RentalDurationDays = 7,
            RentalEnd = null,
            ReturnPointId = null
        },
        new RentalRecord
        {
            Id = 3, VehicleId = 3, ClientId = 3, RentalPointId = 1,
            RentalStart = new DateTime(2024, 10, 20, 9, 0, 0),
            RentalDurationDays = 2,
            RentalEnd = new DateTime(2024, 10, 22, 11, 0, 0),
            ReturnPointId = 1
        },
        new RentalRecord
        {
            Id = 4, VehicleId = 4, ClientId = 4, RentalPointId = 2,
            RentalStart = new DateTime(2024, 11, 10, 8, 0, 0),
            RentalDurationDays = 4,
            RentalEnd = null,
            ReturnPointId = null
        }
    ];
}
