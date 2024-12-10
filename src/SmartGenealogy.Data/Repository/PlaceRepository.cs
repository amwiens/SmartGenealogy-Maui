using Microsoft.EntityFrameworkCore;

using SmartGenealogy.Data.Models;

namespace SmartGenealogy.Data.Repository;

public class PlaceRepository : IPlaceRepository
{
    private readonly SmartGenealogyDbContext _context;

    public PlaceRepository(SmartGenealogyDbContext context)
    {
        _context = context;
    }

    public async Task CreatePlaceAsync(Place place)
    {
        try
        {
            await _context.Places.AddAsync(place);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task DeletePlaceAsync(int id)
    {
        var place = await _context.Places.Where(p => p.Id == id).FirstOrDefaultAsync();
        if (place != null)
        {
            _context.Places.Remove(place);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Place>> GetAllPlacesAsync()
    {
        var places = await _context.Places.ToListAsync();
        if (places == null)
            return null;
        return places;
    }

    public async Task<Place> GetPlaceAsync(int id)
    {
        var place = await _context.Places.Where(p => p.Id == id).FirstOrDefaultAsync();
        if (place == null)
            return null;
        return place;
    }

    public async Task UpdatePlaceAsync(int id, Place newPlace)
    {
        var place = await _context.Places.Where(p => p.Id == id).FirstOrDefaultAsync();
        if (place != null)
        {
            place.Name = newPlace.Name;

            _context.Places.Update(place);
            await _context.SaveChangesAsync();
        }
    }
}