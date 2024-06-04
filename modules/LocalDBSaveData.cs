using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVZPP_Calc.modules;

namespace MVZPP_Calc.modules
{
    internal class LocalDBSaveData
    {
        string connectionString = @"";

        public void SaveData(double mGG, double pGG, double CnkprGG, double R_result_for_GG, double Z_result_for_GG)
        {
            // SQL-запрос для вставки данных
            string query = "INSERT INTO KNPR_GG_CALC_RES (mGG, pGG, CnkprGG, R_result_for_GG, Z_result_for_GG) VALUES (@mGG, @pGG, @CnkprGG, @R_result_for_GG, @Z_result_for_GG)";

            // Создаем подключение к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Создаем команду для выполнения SQL-запроса
                SqlCommand command = new SqlCommand(query, connection);

                // Добавляем параметры к команде
                command.Parameters.AddWithValue("@mGG", mGG);
                command.Parameters.AddWithValue("@pGG", pGG);
                command.Parameters.AddWithValue("@CnkprGG", CnkprGG);
                command.Parameters.AddWithValue("@R_result_for_GG", R_result_for_GG);
                command.Parameters.AddWithValue("@Z_result_for_GG", Z_result_for_GG);

                try
                {
                    // Открываем подключение
                    connection.Open();

                    // Выполняем команду
                    command.ExecuteNonQuery();

                    MessageBox.Show("Данные успешно добавлены в таблицу NKPR_GG_CALC_RES");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
                }
            }
        }
    }
}