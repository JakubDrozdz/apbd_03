namespace apbd_03;

public class AnimalsService : IAnimalsService
{
    private IAnimalsRepository _animalsRepository;

    public AnimalsService(IAnimalsRepository animalsRepository)
    {
        _animalsRepository = animalsRepository;
    }
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        return _animalsRepository.GetAnimals(orderBy);
    }

    public int CreateAnimal(AnimalModel animal)
    {
        return _animalsRepository.CreateAnimal(animal);
    }

    public int UpdateAnimal(int idAnimal, AnimalModel animalModel)
    {
        return _animalsRepository.UpdateAnimal(idAnimal, animalModel);
    }

    public int DeleteAnimal(int idAnimal)
    {
        return _animalsRepository.DeleteAnimal(idAnimal);
    }
}