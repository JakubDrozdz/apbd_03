namespace apbd_03;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderBy);

    int CreateAnimal(AnimalModel animal);

    int UpdateAnimal(int idAnimal, AnimalModel animalModel);

    int DeleteAnimal(int idAnimal);
}