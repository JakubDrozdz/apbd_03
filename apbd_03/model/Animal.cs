namespace apbd_03;

public class Animal : AnimalModel
{
    public int IdAnimal { get; set; }

    public Animal():base()
    {
        
    }
    public Animal(AnimalModel animalModel, int animalId) : base(animalModel)
    {
        IdAnimal = animalId;
    }
}