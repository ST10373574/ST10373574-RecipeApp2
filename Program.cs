using System;

namespace RecipeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            bool recipeCleared = false;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Recipe App Menu:");
                Console.WriteLine("1. Add Ingredients");
                Console.WriteLine("2. Add Steps");
                Console.WriteLine("3. Display Recipe");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Quantities");
                Console.WriteLine("6. Clear All Data");
                Console.WriteLine("7. Exit");
                Console.WriteLine();
                Console.ResetColor();

                Console.Write("Enter your choice (1-7): ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                    Console.ResetColor();
                    continue;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        AddIngredients(recipe);
                        break;
                    case 2:
                        AddSteps(recipe);
                        break;
                    case 3:
                        if (recipeCleared)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("You have no recipe information.");
                            Console.ResetColor();
                        }
                        else
                        {
                            DisplayRecipe(recipe);
                        }
                        Console.WriteLine();
                        break;
                    case 4:
                        ScaleRecipe(recipe);
                        break;
                    case 5:
                        ResetQuantities(recipe);
                        break;
                    case 6:
                        ClearAllData(recipe);
                        recipeCleared = true;
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 7.");
                        Console.ResetColor();
                        break;
                }
            }
        }

        static void AddIngredients(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Add Ingredients:");
            Console.ResetColor();

            Console.Write("Enter the number of ingredients: ");
            int ingredientCount = int.Parse(Console.ReadLine());
            recipe.Ingredients = new Ingredient[ingredientCount];

            Console.WriteLine();

            for (int i = 0; i < ingredientCount; i++)
            {
                Console.WriteLine($"Enter details for ingredient {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit: ");
                string unit = Console.ReadLine();

                recipe.Ingredients[i] = new Ingredient { Name = name, Quantity = quantity, Unit = unit };
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ingredients added successfully.");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void AddSteps(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Add Steps:");
            Console.ResetColor();

            Console.Write("Enter the number of steps: ");
            int stepCount = int.Parse(Console.ReadLine());
            recipe.Steps = new Step[stepCount];

            Console.WriteLine();

            for (int i = 0; i < stepCount; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string description = Console.ReadLine();

                recipe.Steps[i] = new Step { Description = description };
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Steps added successfully.");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void ScaleRecipe(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Scale Recipe:");
            Console.ResetColor();

            Console.Write("Enter scale factor (0.5, 2, or 3): ");
            double scaleFactor = double.Parse(Console.ReadLine());
            recipe.ScaleRecipe(scaleFactor);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Recipe scaled successfully.");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void ResetQuantities(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Reset Quantities:");
            Console.ResetColor();

            recipe.ResetQuantities();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Quantities reset successfully.");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void ClearAllData(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Clear All Data:");
            Console.ResetColor();

            recipe.Ingredients = new Ingredient[0];
            recipe.Steps = new Step[0];
            recipe.OriginalIngredients = null;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("All data cleared successfully.");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void DisplayRecipe(Recipe recipe)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Recipe:");
            Console.ResetColor();

            if (recipe.Ingredients.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No ingredients added.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Ingredients:");
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name}");
                }
            }

            if (recipe.Steps.Length == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No steps added.");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("Steps:");
                for (int i = 0; i < recipe.Steps.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipe.Steps[i].Description}");
                }
            }
        }
    }
}



