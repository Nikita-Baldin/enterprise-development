namespace CarRentalService.Api.Services;

public interface IEntityService<TCreateDto, TReadDto>
{
    public Task<IEnumerable<TReadDto>> GetAll();
    public Task<TReadDto?> GetById(int id);
    public Task<TReadDto?> Create(TCreateDto dto);
    public Task<bool> Update(int id, TCreateDto dto);
    public Task<bool> Delete(int id);
}
