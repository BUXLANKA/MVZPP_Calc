using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVZPP_Calc.net8.model
{
    public class KNPR_GG_CALC_RES
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int N { get; set; }
        public double mGG { get; set; }
        public double pGG { get; set; }
        public double CnkprGG { get; set; }
        public double R_result_for_GG { get; set; }
        public double Z_result_for_GG { get; set; }
        public double Rf_result_for_GG { get; set; }
    }
}
