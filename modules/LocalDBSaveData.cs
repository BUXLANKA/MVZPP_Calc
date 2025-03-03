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
        string connectionString = @"Data Source=192.168.0.108,1433;Initial Catalog=mvzpp;Integrated Security=True;TrustServerCertificate=True";

        public void SaveDataGG(double mGG, double pGG, double CnkprGG, double R_result_for_GG, double Z_result_for_GG, double Rf_result_for_GG)
        {
            // SQL-запрос для вставки данных
            string query = "INSERT INTO KNPR_GG_CALC_RES (mGG, pGG, CnkprGG, R_result_for_GG, Z_result_for_GG, Rf_result_for_GG) VALUES (@mGG, @pGG, @CnkprGG, @R_result_for_GG, @Z_result_for_GG, @Rf_result_for_GG)";

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
                command.Parameters.AddWithValue("@Rf_result_for_GG", Rf_result_for_GG);

                try
                {
                    // Открываем подключение
                    connection.Open();

                    // Выполняем команду
                    command.ExecuteNonQuery();

                    //MessageBox.Show("Данные успешно добавлены в таблицу NKPR_GG_CALC_RES");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
                }
            }
        }

        public void SaveDataLVZH(double mPP, double pPP, double CnkprPP, double R_result_for_PP, double Z_result_for_PP, double Rf_result_for_PP)
        {
            // SQL-запрос для вставки данных
            string query = "INSERT INTO KNPR_LVZH_CALC_RES (mPP, pPP, CnkprPP, R_result_for_PP, Z_result_for_PP, Rf_result_for_PP) VALUES (@mPP, @pPP, @CnkprPP, @R_result_for_PP, @Z_result_for_PP, @Rf_result_for_PP)";

            // Создаем подключение к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Создаем команду для выполнения SQL-запроса
                SqlCommand command = new SqlCommand(query, connection);

                // Добавляем параметры к команде
                command.Parameters.AddWithValue("@mPP", mPP);
                command.Parameters.AddWithValue("@pPP", pPP);
                command.Parameters.AddWithValue("@CnkprPP", CnkprPP);
                command.Parameters.AddWithValue("@R_result_for_PP", R_result_for_PP);
                command.Parameters.AddWithValue("@Z_result_for_PP", Z_result_for_PP);
                command.Parameters.AddWithValue("@Rf_result_for_PP", Rf_result_for_PP);

                try
                {
                    // Открываем подключение
                    connection.Open();

                    // Выполняем команду
                    command.ExecuteNonQuery();

                    //MessageBox.Show("Данные успешно добавлены в таблицу NKPR_GG_CALC_RES");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении данных: " + ex.Message);
                }
            }
        }
    }
}