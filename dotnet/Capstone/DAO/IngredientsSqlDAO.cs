using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public class IngredientsSqlDAO : IIngredientsDAO
    {
        private readonly string connectionString;

        private string sqlAddIngredient = "INSERT INTO ingredients (ingredient_name, measurment_unit, user_id) " +
            " VALUES (@ingredient_name, @measurment_unit, @user_id); ";

        public IngredientsSqlDAO(string dbConnectionString)
        {
            connectionString = dbConnectionString;
        }


    public bool AddIngredient(Ingredients ingredient)
    {
        bool result = false;

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sqlAddIngredient, conn);


                cmd.Parameters.AddWithValue("@ingredient_name", ingredient.Name);
                cmd.Parameters.AddWithValue("@measurment_unit", ingredient.Measurement);
                cmd.Parameters.AddWithValue("@user_id", ingredient.UserId);

                  


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
}
}
