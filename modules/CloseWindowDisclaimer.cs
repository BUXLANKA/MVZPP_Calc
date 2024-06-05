using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVZPP_Calc.modules
{
    internal class CloseWindowDisclaimer
    {
        public void ShowDisclaimer(FormClosingEventArgs e)
        {
            // Проверяем, была ли нажата кнопка закрытия окна программы
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Отображаем диалоговое окно с подтверждением выхода
                DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из программы?\nНесохраненные данные будут утеряны!", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Если пользователь подтвердил выход, закрываем приложение
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                // Если пользователь отменил выход, отменяем закрытие окна программы
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
