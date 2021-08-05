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

        private string sqlAddRecipe = "";

        private string sqlGetRecipes = "";

        private string sqlGetRecipes = "";




        public RecipeSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


        public bool Addrecipe(Recipe recipe)
        {
            bool result = false;

            try
            {
                using (SqlConnection conn = new SqlConnection)
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(sqlAddRecipe, conn);

                    cmd.Parameters.AddWithValue("@recipe_name", recipe.RecipeName);
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


        public bool GetRecipes(string name)
        {
            return true;
        }

        public bool GetRecipe()
        {
            return true;
        }


    }
}
