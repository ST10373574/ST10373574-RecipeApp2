using RecipeApp;
using System;

class Recipe
{
    // Properties
    public Ingredient[] Ingredients { get; set; }
    public Ingredient[] OriginalIngredients { get; set; } // 
    public Step[] Steps { get; set; }
    private double ScalingFactor { get; set; } = 1.0; // Default scaling factor is 1.0 (no scaling)

    // Method to display the recipe
    public void DisplayRecipe()
    {
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
        }

        Console.WriteLine("\nSteps:");
        for (int i = 0; i < Steps.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Steps[i].Description}");
        }
    }

    // Method to scale the recipe by a factor
    public void ScaleRecipe(double factor)
    {
        if (OriginalIngredients == null)
        {
            // Store original quantities
            OriginalIngredients = new Ingredient[Ingredients.Length];
            Array.Copy(Ingredients, OriginalIngredients, Ingredients.Length);
        }
        
        ScalingFactor = factor; // Update scaling factor
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }

    // Method to reset quantities to original values
    public void ResetQuantities()
    {
        if (OriginalIngredients != null && OriginalIngredients.Length == Ingredients.Length)
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                // Divide the quantity by the factor it was scaled by
                Ingredients[i].Quantity = OriginalIngredients[i].Quantity / ScalingFactor;
            }
        }
        else
        {
            Console.WriteLine("Error: Original quantities are not properly initialized or do not match current ingredients.");
        }
    }


    // Constructor
    public Recipe()
    {
        // Initialize arrays
        Ingredients = new Ingredient[0]; // Start with an empty array
        Steps = new Step[0]; // Start with an empty array
    }
}
