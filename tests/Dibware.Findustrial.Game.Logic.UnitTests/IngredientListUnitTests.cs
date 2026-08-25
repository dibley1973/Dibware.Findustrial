namespace Dibware.Findustrial.Game.Logic.UnitTests;

using Dibware.Findustrial.Game.Logic.BluePrint;
using Dibware.Findustrial.Game.Logic.Entities;
using Dibware.Findustrial.Game.Logic.Exceptions;
using Dibware.Findustrial.Game.Logic.Quantities;

/// <summary>
/// Unit tests for the <see cref="IngredientList"/> class.
/// </summary>
[TestClass]
public sealed class IngredientListUnitTests
{
    [TestMethod]
    public void All_AfterConstruction_ReturnsEmpty()
    {
        // Arrange
        var list = new IngredientList();

        // Act
        var actual = list.All();

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(0, actual.Count);
    }

    [TestMethod]
    public void All_AfterAddingMaterialTypeWithQuantityOfOne_ReturnsThatItem()
    {
        // Arrange
        var list = new IngredientList();
        var material = new Material("Iron");
        var materialQuantity = new MaterialQuantity(material, 1);

        list.Add(materialQuantity);

        // Act
        var actual = list.All();

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(1, actual.Count);
        Assert.AreEqual(actual.Keys.First().Name, material.Name);
        Assert.AreEqual(actual.Values.First(), 1);
    }

    [TestMethod]
    public void All_AfterAddingMaterialTypeWithQuantityOfTwo_ReturnsThatItem()
    {
        // Arrange
        var list = new IngredientList();
        var material = new Material("Iron");
        var materialQuantity = new MaterialQuantity(material, 2);

        list.Add(materialQuantity);

        // Act
        var actual = list.All();

        // Assert
        Assert.IsNotNull(actual);
        Assert.AreEqual(1, actual.Count);
        Assert.AreEqual(actual.Keys.First().Name, material.Name);
        Assert.AreEqual(actual.Values.First(), 2);
    }

    [TestMethod]
    public void Add_AddingTwoIdenticalMaterials_ThrowsException()
    {
        // Arrange
        var list = new IngredientList();
        var material1 = new Material("Iron");
        var material2 = new Material("Iron");
        var materialQuantity1 = new MaterialQuantity(material1, 2);
        var materialQuantity2 = new MaterialQuantity(material2, 2);

        list.Add(materialQuantity1);

        // Act
        Action actual = () => list.Add(materialQuantity2);

        // Assert
        Assert.ThrowsException<SameMaterialAlreadyAddedException>(actual);
    }

    [TestMethod]
    public void HasMaterial_BeforeAddingAnyMAterial_ReturnsFalse()
    {
        // Arrange
        var list = new IngredientList();
        var material = new Material("Iron");

        // Act
        var actual = list.HasMaterial(material);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void HasMaterial_AfterAddinDifferentMaterial_ReturnsTrue()
    {
        // Arrange
        var list = new IngredientList();
        var material1 = new Material("Iron");
        var material2 = new Material("Coal");
        var materialQuantity1 = new MaterialQuantity(material1, 2);
        var materialQuantity2 = new MaterialQuantity(material2, 2);

        list.Add(materialQuantity1);

        // Act
        var actual = list.HasMaterial(material2);

        // Assert
        Assert.IsFalse(actual);
    }

    [TestMethod]
    public void HasMaterial_AfterAddingCheckedMaterial_ReturnsTrue()
    {
        // Arrange
        var list = new IngredientList();
        var material = new Material("Iron");
        var materialQuantity = new MaterialQuantity(material, 1);
        list.Add(materialQuantity);

        // Act
        var actual = list.HasMaterial(material);

        // Assert
        Assert.IsTrue(actual);
    }
}
