namespace apbd_03;

public interface IAnimalsRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
}