using System.Collections.ObjectModel;

using SmartGenealogy.Data.Models;
using SmartGenealogy.Data.Repository;

namespace SmartGenealogy.ViewModels;

public class MainViewModel
{
    IPlaceRepository _placeRepository;

    public ObservableCollection<Place> Places { get; set; }

    public MainViewModel(IPlaceRepository placeRepository)
    {
        _placeRepository = placeRepository;
        Places = new ObservableCollection<Place>();
    }

    public async Task GetPlacesAsync()
    {
        Places.Clear();
        //MauiProgram.SwitchDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "blog.db"));
        var places = await _placeRepository.GetAllPlacesAsync();
        if (places != null)
        {
            foreach (var place in places)
            {
                Places.Add(place);
            }
        }
    }
}