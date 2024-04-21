namespace apbd_03;

public interface IAnimalsService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    
}