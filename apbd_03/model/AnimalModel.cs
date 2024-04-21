namespace apbd_03;

public class AnimalModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Area { get; set; }

    public AnimalModel()
    {
        
    }
    public AnimalModel(AnimalModel animalModel)
    {
        Name = animalModel.Name;
        Description = animalModel.Description;
        Category = animalModel.Category;
        Area = animalModel.Area;
    }
}