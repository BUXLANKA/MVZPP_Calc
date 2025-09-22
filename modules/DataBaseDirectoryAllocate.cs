using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVZPP_Calc.net8.modules
{
    internal class DataBaseDirectoryAllocate
    {
        protected string _MainDbSetDirectoryPath = "./data";
        protected string _DbSetPath = "./data/local";

        public void AllocateDirectoryForAppDbSet()
        {
            try
            {
                if (!Directory.Exists(_DbSetPath))
                {
                    Directory.CreateDirectory(_DbSetPath);
                    File.SetAttributes(_MainDbSetDirectoryPath, File.GetAttributes(_MainDbSetDirectoryPath) | FileAttributes.Hidden);
                    File.SetAttributes(_DbSetPath, File.GetAttributes(_DbSetPath) | FileAttributes.Hidden);
                }
                else
                {
                    // nothing
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fatal Error == {ex}");
                Environment.Exit(0);
                throw;
            }
        }
    }
}
