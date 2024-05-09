using System;
using KomodoCafe;

namespace CafeApp
{
    public class ProgramUI
    {
        private MenuRepository _menuRepository = new();

        public void Run()
        {
            System.Console.WriteLine("Welcome to the Komodo Cafe Menu Management System!");

            //SEED DATA HERE//
            //SEED DATA HERE//
            //SEED DATA HERE//
            //SEED DATA HERE//
            //SEED DATA HERE//

            while (true)
            {
                System.Console.WriteLine("\nPlease choose a system option from the list below:");
                System.Console.WriteLine("1. View all cafe menu items");
                System.Console.WriteLine("2. Create a new menu option");
                System.Console.WriteLine("3. Update existing menu option");
                System.Console.WriteLine("4. Delete an existing menu option");
                System.Console.WriteLine("5. Exit Menu Management System");
                System.Console.WriteLine("");

                System.Console.WriteLine("\nEnter your choice: ");
                string? choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ViewAllMenuItems(_menuRepository);
                        break;
                    case "2":
                        CreateNewMenuItem(_menuRepository);
                        break;
                    case "3":
                        UpdateMenuItem(_menuRepository);
                        break;
                    case "4":
                        DeleteMenuItem(_menuRepository);
                        break;
                    case "5":
                        System.Console.WriteLine("Thank you for using the Komodo Menu Management System! Exiting...");
                        return;
                    default:
                        System.Console.WriteLine("Invalid input, please enter from the options listed: ");
                        break;
                }
            }
        }

        static void CreateNewMenuItem(MenuRepository repository)
        {
            Console.WriteLine("Creating a new menu item:");

            Console.Write("Enter meal ID: ");
            int mealID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter name: ");
            string? name = Console.ReadLine();

            Console.Write("Enter description: ");
            string? description = Console.ReadLine();

            Console.Write("Enter ingredients: ");
            string? ingredients = Console.ReadLine();

            Console.Write("Enter price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            repository.AddMenuItem(mealID, name, description, ingredients, price);
            Console.WriteLine("New menu item added successfully!");
        }


        static void UpdateMenuItem(MenuRepository repository)
        {
            Console.WriteLine("Updating an existing menu item:");

            Console.Write("Enter meal ID of the item you want to update: ");
            int mealID = Convert.ToInt32(Console.ReadLine());

            // Check if the menu item exists
            MenuItem existingMenuItem = repository.GetAllMenuItems().FirstOrDefault(item => item.MealID == mealID);
            if (existingMenuItem == null)
            {
                Console.WriteLine("Menu item not found!");
                return;
            }

            // Prompt for new details
            Console.Write("Enter new name (or press Enter to keep the existing name): ");
            string? newName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newName))
            {
                newName = existingMenuItem.Name; // Keep existing name if input is empty
            }

            Console.Write("Enter new description (or press Enter to keep the existing description): ");
            string? newDescription = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newDescription))
            {
                newDescription = existingMenuItem.Description; // Keep existing description if input is empty
            }

            Console.Write("Enter new ingredients (or press Enter to keep the existing ingredients): ");
            string? newIngredients = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newIngredients))
            {
                newIngredients = existingMenuItem.Ingredients; // Keep existing ingredients if input is empty
            }

            Console.Write("Enter new price (or press Enter to keep the existing price): ");
            string? priceInput = Console.ReadLine();
            decimal newPrice;
            if (string.IsNullOrWhiteSpace(priceInput))
            {
                newPrice = existingMenuItem.Price; // Keep existing price if input is empty
            }
            else if (!decimal.TryParse(priceInput, out newPrice))
            {
                Console.WriteLine("Invalid price format. Please enter a valid decimal value.");
                return;
            }

            // Update the menu item
            repository.UpdateMenuItem(mealID, newName, newDescription, newIngredients, newPrice);
            Console.WriteLine("Menu item updated successfully!");
        }


        static void DeleteMenuItem(MenuRepository repository)
        {
            Console.WriteLine("Deleting an existing menu item:");

            Console.Write("Enter meal ID of the item you want to delete: ");
            int mealID = Convert.ToInt32(Console.ReadLine());

            // Check if the menu item exists
            MenuItem existingMenuItem = repository.GetAllMenuItems().FirstOrDefault(item => item.MealID == mealID);
            if (existingMenuItem == null)
            {
                Console.WriteLine("Menu item not found!");
                return;
            }

            // Confirm deletion with user
            Console.Write($"Are you sure you want to delete {existingMenuItem.Name}? (Y/N): ");
            string? confirmation = Console.ReadLine();
            if (confirmation.Trim().ToUpper() == "Y")
            {
                // Delete the menu item
                repository.DeleteMenuItem(mealID);
                Console.WriteLine("Menu item deleted successfully!");
            }
            else
            {
                Console.WriteLine("Deletion cancelled.");
            }
        }

        static void ViewAllMenuItems(MenuRepository repository)
        {
            Console.WriteLine("All Menu Items:");
            foreach (var item in repository.GetAllMenuItems())
            {
                Console.WriteLine($"ID: {item.MealID}");
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Description: {item.Description}");
                Console.WriteLine($"Ingredients: {item.Ingredients}");
                Console.WriteLine($"Price: {item.Price:C}");
                Console.WriteLine();
            }
        }

    }
};