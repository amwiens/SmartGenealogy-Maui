using SmartGenealogy.Data.Models;

namespace SmartGenealogy.Data.Repository;

public interface IPlaceRepository
{
    public Task CreatePlaceAsync(Place place);
    public Task<Place> GetPlaceAsync(int id);
    public Task<IEnumerable<Place>> GetAllPlacesAsync();
    public Task UpdatePlaceAsync(int id, Place place);
    public Task DeletePlaceAsync(int id);
}