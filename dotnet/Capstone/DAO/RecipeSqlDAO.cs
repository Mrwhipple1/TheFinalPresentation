using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class RecipeSqlDAO : IRecipeDAO
    {

        private readonly string connectionString;

        private string sqlAddRecipe = "INSERT INTO recipe (recipe_name, recipe_description, recipe_instructions, user_id) " +
            " VALUES(@recipe_name, @recipe_description, @recipe_instructions, @user_id);";

        private string sqlGetRecipesByName = "SELECT recipe_name, recipe_description, recipe_instructions " +
            " FROM recipe WHERE recipe_name = @recipe_name;";

        private string sqlGetRecipes = "SELECT * FROM recipe WHERE user_id = @user_id;";

        private string sqlGetRecipe = "SELECT * FROM recipe WHERE recipe_id = @recipe_id";

        private string sqlDeleteRecipe = "DELETE FROM recipe WHERE recipe_id = @recipe_id";

        private string sqlModifyRecipe = "UPDATE recipe SET recipe_name = @recipe_name, recipe_description = @recipe_description, " +
            " recipe_instructions = @recipe_instructions WHERE recipe_id = @recipe_id;";


        public RecipeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }

        public bool AddRecipe(Recipe recipe)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddRecipe, conn);

                    cmd.Parameters.AddWithValue("@recipe_name", recipe.RecipeName.ToLower().Trim());
                    cmd.Parameters.AddWithValue("@recipe_description", recipe.RecipeDescription);
                    cmd.Parameters.AddWithValue("@recipe_instructions", recipe.RecipeInstructions);
                    cmd.Parameters.AddWithValue("@user_id", recipe.UserId);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public List<Recipe> GetRecipes(int userId)
        {

            List<Recipe> recipes = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetRecipes, conn);

                    cmd.Parameters.AddWithValue("@user_id", userId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Recipe recipe = new Recipe();

                        recipe = ReaderToRecipe(reader);

                        recipes.Add(recipe);
                    }
                }
            }
            catch (Exception ex)
            {
                recipes = new List<Recipe>();
            }
            return recipes;
        }

        public Recipe GetRecipe(int recipeId)
        {
            Recipe recipe = new Recipe();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlGetRecipe, conn);

                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        recipe = ReaderToRecipe(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                recipe = new Recipe();
            }
            return recipe;
        }

        public List<Recipe> GetRecipeByName(string name)
        {
            List<Recipe> recipes = new List<Recipe>();

            name = "%" + name + "%";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetRecipesByName, conn);

                    cmd.Parameters.AddWithValue("@recipe_name", name.ToLower().Trim());

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Recipe recipe = new Recipe();

                        recipe = ReaderToRecipe(reader);


                        recipes.Add(recipe);
                    }
                }
            }
            catch (Exception ex)
            {
                recipes = new List<Recipe>();
            }
            return recipes;
        }

        public bool DeleteRecipe(int recipeId)
        {
            bool result = false;

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlDeleteRecipe, conn);

                    cmd.Parameters.AddWithValue("@recipe_id", recipeId);

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool ModifyRecipe(Recipe recipe)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sqlModifyRecipe, conn);

                    cmd.Parameters.AddWithValue("@recipe_id", recipe.RecipeId);
                    cmd.Parameters.AddWithValue("@recipe_name", recipe.RecipeName);
                    cmd.Parameters.AddWithValue("@recipe_description", recipe.RecipeDescription);
                    cmd.Parameters.AddWithValue("@recipe_instructions", recipe.RecipeInstructions);

                    

                    int count = cmd.ExecuteNonQuery();

                    if (count > 0)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
        private Recipe ReaderToRecipe(SqlDataReader reader)
        {
            Recipe recipe = new Recipe();

            recipe.RecipeId = Convert.ToInt32(reader["recipe_id"]);
            recipe.RecipeName = Convert.ToString(reader["recipe_name"]);
            recipe.RecipeDescription = Convert.ToString(reader["recipe_description"]);
            recipe.RecipeInstructions = Convert.ToString(reader["recipe_instructions"]);

            return recipe;
        }

        //public List<Ingredient> GetIngredientsByRecipeId(int recipeId)
        //{
        //    List<Ingredient> ingredients = new List<Ingredient>();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            SqlCommand cmd = new SqlCommand(sqlGetIngredientByRecipeId, conn);

        //            cmd.Parameters.AddWithValue("@recipe_id", recipeId);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ingredients = new List<Ingredient>();
        //    }

        ////}

        //}






    }
}
