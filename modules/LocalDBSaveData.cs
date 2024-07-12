using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MVZPP_Calc.net8.data;
using MVZPP_Calc.net8.model;
using System.Data.SqlClient;

namespace MVZPP_Calc.modules
{
    internal class LocalDBSaveData
    {
        public void SaveDataGG(double mGG, double pGG, double CnkprGG, double R_result_for_GG, double Z_result_for_GG, double Rf_result_for_GG)
        {
            using(var context = new AppData())
            {
                try
                {
                    KNPR_GG_CALC_RES newSrt = new KNPR_GG_CALC_RES
                    {
                        mGG = mGG,
                        pGG = pGG,
                        CnkprGG = CnkprGG,
                        R_result_for_GG = R_result_for_GG,
                        Z_result_for_GG = Z_result_for_GG,
                        Rf_result_for_GG = Rf_result_for_GG,
                    };

                    context.GG_result.Add(newSrt);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                    throw;
                }
            }
        }

        public void SaveDataLVZH(double mPP, double pPP, double CnkprPP, double R_result_for_PP, double Z_result_for_PP, double Rf_result_for_PP)
        {
            using (var context = new AppData())
            {
                try
                {
                    NKPR_LVZH_CALC_RES newSrt = new NKPR_LVZH_CALC_RES
                    {
                        mPP = mPP,
                        pPP = pPP,
                        CnkprPP = CnkprPP,
                        R_result_for_PP = R_result_for_PP,
                        Z_result_for_PP = Z_result_for_PP,
                        Rf_result_for_PP = Rf_result_for_PP
                    };

                    context.PP_result.Add(newSrt);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex}");
                    throw;
                }
            }
        }
    }
}