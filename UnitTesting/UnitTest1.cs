using System; 
using System.Linq; 
using Microsoft.VisualStudio.TestTools.UnitTesting; // Import the MSTest framework for unit testing
using KomodoCafe;

namespace UnitTesting 
{
    [TestClass] // Attribute marking this class as a test class
    public class UnitTest1 
    {

        [TestMethod] // Attribute marking this method as a test method
        public void TestAddMenuItem() 
        {
            // Arrange
            MenuRepository repository = new MenuRepository(); //  new instance of MenuRepository to test 
            int initialCount = repository.GetAllMenuItems().Count; // Get the initial count of menu items

            // Act
            repository.AddMenuItem(5, "Test Item", "Test Description", "Test Ingredients", 9.99m); // Adds a new menu item for testing

            // Assert
            Assert.AreEqual(initialCount + 1, repository.GetAllMenuItems().Count); // Checks if the count of menu items has increased by 1 after adding test item
        }

        [TestMethod] 
        public void TestDeleteMenuItem()
        {
            // Arrange
            MenuRepository repository = new MenuRepository(); 
            int initialCount = repository.GetAllMenuItems().Count; 

            // Act
            repository.DeleteMenuItem(1); // Delete a menu item (assumes that meal ID 1 exists in the initial menu items)

            // Assert
            Assert.AreEqual(initialCount - 1, repository.GetAllMenuItems().Count); // Checks if the count of menu items has decreased by 1 after deleting an item
        }
    }
};
