using CarRentalService.Api.Dto;
using CarRentalService.Domain.Entity;
namespace CarRentalService.Api.Services;

public class ClientService() : IEntityService<ClientCreateDto, Client>
{
    private readonly List<Client> _clients = [];
    private int _clientId = 1;

    public List<Client> GetAll() => _clients;

    public Client? GetById(int id) => _clients.FirstOrDefault(c => c.Id == id);

    public Client Create(ClientCreateDto dto)
    {
        var newClient = new Client
        {
            Id = _clientId++,
            PassportNumber = dto.PassportNumber,
            FullName = dto.FullName,
            BirthDate = dto.BirthDate
        };
        _clients.Add(newClient);
        return newClient;
    }

    public bool Delete(int id)
    {
        var client = GetById(id);
        if (client == null)
        {
            return false;
        }
        return _clients.Remove(client);
    }

    public bool Update(int id, ClientCreateDto updateClient)
    {
        var client = GetById(id);
        if (client == null)
        {
            return false;
        }
        client.FullName = updateClient.FullName;
        client.PassportNumber = updateClient.PassportNumber;
        client.BirthDate = updateClient.BirthDate;
        return true;
    }
}
