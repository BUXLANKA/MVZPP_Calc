using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVZPP_Calc.net8.data
{
    // !!! only for DEBUG !!! //
    internal class ForceDataDelete
    {
        public void Start()
        {
            using (var context = new AppData())
            {
                context.Database.EnsureDeleted();
                context.SaveChanges();
                MessageBox.Show("Done!");
                Environment.Exit(0);
            }
        }
    }
}
