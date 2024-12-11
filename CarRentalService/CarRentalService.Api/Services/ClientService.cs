using CarRentalService.Api.Dto;
using CarRentalService.Domain.Context;
using CarRentalService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
namespace CarRentalService.Api.Services;

public class ClientService(CarRentalServiceDbContext context) : IEntityService<ClientCreateDto, Client>
{
    public async Task<IEnumerable<Client>> GetAll() => await context.Clients.ToListAsync();

    public async Task<Client?> GetById(int id) => await context.Clients.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<Client?> Create(ClientCreateDto dto)
    {
        var newClient = new Client
        {
            Id = 0,
            PassportNumber = dto.PassportNumber,
            FullName = dto.FullName,
            BirthDate = dto.BirthDate
        };
        context.Clients.Add(newClient);
        await context.SaveChangesAsync();
        return newClient;
    }

    public async Task<bool> Delete(int id)
    {
        var client = await GetById(id);
        if (client == null)
        {
            return false;
        }
        context.Clients.Remove(client);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(int id, ClientCreateDto updateClient)
    {
        var client = await GetById(id);
        if (client == null)
        {
            return false;
        }
        client.FullName = updateClient.FullName;
        client.PassportNumber = updateClient.PassportNumber;
        client.BirthDate = updateClient.BirthDate;
        await context.SaveChangesAsync();
        return true;
    }
}
