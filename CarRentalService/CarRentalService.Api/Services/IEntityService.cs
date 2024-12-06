namespace CarRentalService.Api.Services;

public interface IEntityService<TCreateDto, TReadDto>
{
    public List<TReadDto> GetAll();
    public TReadDto? GetById(int id);
    public TReadDto? Create(TCreateDto dto);
    public bool Update(int id, TCreateDto dto);
    public bool Delete(int id);
}
