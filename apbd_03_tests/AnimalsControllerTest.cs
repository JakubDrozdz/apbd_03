using System.Net;
using apbd_03;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace apbd_03_tests;

public class AnimalsControllerTest
{
    Mock<IAnimalsRepository> _animalRepository = new Mock<IAnimalsRepository>();
    [Fact]
    public void ShouldReturnOKStatusCodeWhenDeletedRow()
    {
        _animalRepository.Setup(animalRepository => animalRepository.DeleteAnimal(1)).Returns(1);
        AnimalsController animalsController = new AnimalsController(new AnimalsService(_animalRepository.Object));
        var result = animalsController.DeleteAnimal(1);
        Assert.Equal(200, GetResponseStatusCode(result));
    }
    
    [Fact]
    public void ShouldReturnNoContentStatusCodeWhenRowNotDeleted()
    {
        _animalRepository.Setup(animalRepository => animalRepository.DeleteAnimal(2)).Returns(0);
        AnimalsController animalsController = new AnimalsController(new AnimalsService(_animalRepository.Object));
        var result = animalsController.DeleteAnimal(1);
        Assert.Equal(204, GetResponseStatusCode(result));
    }
    
    [Fact]
    public void ShouldReturnOKStatusCodeWhenUpdatedRow()
    {
        AnimalModel animalModelMock = new Mock<AnimalModel>().Object;
        _animalRepository.Setup(animalRepository => animalRepository.UpdateAnimal(1, animalModelMock)).Returns(1);
        AnimalsController animalsController = new AnimalsController(new AnimalsService(_animalRepository.Object));
        var result = animalsController.UpdateAnimal(1, animalModelMock);
        Assert.Equal(200, GetResponseStatusCode(result));
    }
    
    [Fact]
    public void ShouldReturnNoContentStatusCodeWhenRowNotUpdated()
    {
        AnimalModel animalModelMock = new Mock<AnimalModel>().Object;
        _animalRepository.Setup(animalRepository => animalRepository.UpdateAnimal(2, animalModelMock)).Returns(0);
        AnimalsController animalsController = new AnimalsController(new AnimalsService(_animalRepository.Object));
        var result = animalsController.UpdateAnimal(2, animalModelMock);
        Assert.Equal(204, GetResponseStatusCode(result));
    }

    private int GetResponseStatusCode(IActionResult result)
    {
        return (int) result
            .GetType()
            .GetProperty("StatusCode")
            .GetValue(result, null);
    }
}