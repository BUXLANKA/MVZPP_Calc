using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVZPP_Calc.net8.model
{
    public class NKPR_LVZH_CALC_RES
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int N { get; set; }
        public double mPP { get; set; }
        public double pPP { get; set; }
        public double CnkprPP { get; set; }
        public double R_result_for_PP { get; set; }
        public double Z_result_for_PP { get; set; }
        public double Rf_result_for_PP { get; set; }
    }
}
