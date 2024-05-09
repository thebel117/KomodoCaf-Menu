using System;
using System.Collections.Generic;
using System.Linq;
using KomodoCafe;

namespace KomodoCafe
{
    public class MenuRepository
    {
        private List<MenuItem> menuItems;

        public MenuRepository()
        {
            menuItems = new List<MenuItem>();
            // Add initial menu items
            InitializeMenu();
        }

        private void InitializeMenu() //Same as the seed data
        {
            // Add initial menu items here
            AddMenuItem(1, "The Thin Lizzy", "A smaller meal for the calorie conscious critter!", "6pc. Iguana Bites, Small Fry, and a Small Drink", 7.99m);
            AddMenuItem(2, "The Go-Gator", "A hearty meal to get you through another day in the swamp!", "12pc. Gator Strips, Medium Fry, and a Medium Drink", 12.99m);
            AddMenuItem(3, "The Komodo Kombo", "A big serving of meat, with an extra treat! Perfect for splitting.", "2lb of Fried Komodo Belly, Large Fry, a Large Drink, and a Candied Gecko", 17.99m);
            AddMenuItem(4, "The Gut-Zilla", "The largest serving of reptile meat we can legally sell! Ideal for parties.", "One whole fried alligator, XL Fry, and a Mop-Bucket of Cola", 49.99m);
        }

        public void AddMenuItem(int mealID, string name, string description, string ingredients, decimal price)
        {
            var menuItem = new MenuItem(mealID, name, description, ingredients, price);
            menuItems.Add(menuItem);
        }

        public void UpdateMenuItem(int mealID, string newName, string newDescription, string newIngredients, decimal newPrice)
        {
            var menuItem = menuItems.Find(item => item.MealID == mealID);
            if (menuItem != null)
            {
                menuItem.Name = newName;
                menuItem.Description = newDescription;
                menuItem.Ingredients = newIngredients;
                menuItem.Price = newPrice;
            }
            else
            {
                Console.WriteLine("Menu item not found!");
            }
        }

        public void DeleteMenuItem(int mealID)
        {
            var menuItem = menuItems.Find(item => item.MealID == mealID);
            if (menuItem != null)
            {
                menuItems.Remove(menuItem);
            }
            else
            {
                Console.WriteLine("Menu item not found!");
            }
        }

        public List<MenuItem> GetAllMenuItems()
        {
            return menuItems;
        }
    }
};