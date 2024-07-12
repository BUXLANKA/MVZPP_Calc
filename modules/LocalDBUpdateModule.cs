using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVZPP_Calc.net8.data;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace MVZPP_Calc.net8.modules
{
    public class LocalDBUpdateModule : DbContext
    {
        public void UpdateGG(DataGridView LocalDataGridView)
        {
            try
            {
                using (var context = new AppData())
                {
                    context.GG_result.Load();
                    LocalDataGridView.DataSource = context.GG_result.Local.ToBindingList();
                    LocalDataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"fatal error == {ex}");
                throw;
            }
        }
        public void UpdatePP(DataGridView LocalDataGridView)
        {
            try
            {
                using (var context = new AppData())
                {
                    context.PP_result.Load();
                    LocalDataGridView.DataSource = context.PP_result.Local.ToBindingList();
                    LocalDataGridView.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"fatal error == {ex}");
                throw;
            }
        }
    }
}
