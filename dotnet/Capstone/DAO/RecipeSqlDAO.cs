﻿using Capstone.DAO.Interfaces;
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

        private string sqlAddRecipe = "INSERT INTO recipe (recipe_name, recipe_description, user_id) " +
            " VALUES(@recipe_name, @recipe_description, @user_id);";

        private string sqlGetRecipesByName = "SELECT recipe_name, recipe_description " +
            " FROM recipe WHERE recipe_name = @recipe_name;";

        private string sqlGetRecipes = "SELECT recipe_name, recipe_description FROM recipe;";

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

                    cmd.Parameters.AddWithValue("@recipe_name", recipe.RecipeName.ToLower());
                    cmd.Parameters.AddWithValue("@recipe_description", recipe.RecipeDescription);
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

        public List<Recipe> GetRecipes()
        {

            List<Recipe> recipes = new List<Recipe>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlGetRecipes, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Recipe recipe = new Recipe();

                        recipe.RecipeName = Convert.ToString(reader["recipe_name"]);
                        recipe.RecipeDescription = Convert.ToString(reader["recipe_description"]);

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

                    cmd.Parameters.AddWithValue("@recipe_name", name.ToLower());

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read() == true)
                    {
                        Recipe recipe = new Recipe();

                        recipe.RecipeName = Convert.ToString(reader["recipe_name"]);
                        recipe.RecipeDescription = Convert.ToString(reader["recipe_description"]);

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
    }
}