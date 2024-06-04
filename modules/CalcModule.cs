using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVZPP_Calc.modules
{
    internal class CalcModule
    {
        public double mGG { get; set; }
        public double pGG { get; set; }
        public double mLVZH { get; set; }
        public double pLVZH { get; set; }

        public double nkprGG { get; set; }
        public double nkprLVZH { get; set; }


        // FOR GG
        public double CalculateRadiusGG()
        {
            return 7.8 * Math.Pow((mGG / (pGG*nkprGG)), 0.33);
        }
        public double CalculateZGG()
        {
            return 0.26 * Math.Pow((mGG / (pGG * nkprGG)), 0.33);
        }


        // FOR LVZH
        public double CalculateRadiusLVZH()
        {
            return 7.8 * Math.Pow((mLVZH / (pLVZH * nkprLVZH)), 0.33);
        }
        public double CalculateZLVZH()
        {
            return 0.26 * Math.Pow((mLVZH / (pLVZH * nkprLVZH)), 0.33);
        }
    }
}
