using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MVZPP_Calc.modules;
using System.IO;
using System.Drawing.Design;
using System.Diagnostics;

namespace MVZPP_Calc
{
    public partial class Form1 : Form
    {
        
        CloseWindowDisclaimer CloseWindow = new CloseWindowDisclaimer();
        GetTime DateTime = new GetTime();
        CalcModule calculator = new CalcModule();
        LocalDBSaveData History = new LocalDBSaveData();

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.kNPR_LVZH_CALC_RESTableAdapter.Fill(this.history_1eR1DataSet.KNPR_LVZH_CALC_RES);
            this.kNPR_GG_CALC_RESTableAdapter.Fill(this.history_1eR1DataSet.KNPR_GG_CALC_RES);

            mGG_Text.Text = "";
            mLVZH_Text.Text = "";

            pGG_Text.Text = "";
            pLVZH_Text.Text = "";

            nkprGG_Text.Text = "";
            nkprLVZH_Text.Text = "";

            R_result_for_GG.Text = "";
            Z_result_for_GG.Text = "";

            R_result_for_LVZH.Text = "";
            Z_result_for_LVZH.Text = "";
        }

        private void CalculateForGG_Click(object sender, EventArgs e)
        {
            if (mGG_Text.Text == "" || pGG_Text.Text == "" || nkprGG_Text.Text == "") 
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                calculator.mGG = Convert.ToDouble(mGG_Text.Text);
                calculator.pGG = Convert.ToDouble(pGG_Text.Text);
                calculator.nkprGG = Convert.ToDouble(nkprGG_Text.Text);

                R_result_for_GG.Text = Convert.ToString(Math.Round(calculator.CalculateRadiusGG(), 6));
                Z_result_for_GG.Text = Convert.ToString(Math.Round(calculator.CalculateZGG(), 6));

                History.SaveDataGG(calculator.mGG, calculator.pGG, calculator.nkprGG, (calculator.CalculateRadiusGG()), (calculator.CalculateZGG()));
            }
        }

        private void ReloadTables_Click(object sender, EventArgs e)
        {
            this.kNPR_LVZH_CALC_RESTableAdapter.Fill(this.history_1eR1DataSet.KNPR_LVZH_CALC_RES);
            this.kNPR_GG_CALC_RESTableAdapter.Fill(this.history_1eR1DataSet.KNPR_GG_CALC_RES);
        }

        private void CalculateForLVZH_Click(object sender, EventArgs e)
        {
            if(mLVZH_Text.Text == "" || pLVZH_Text.Text == "" || nkprLVZH_Text.Text == "")
            {
                MessageBox.Show("Не все поля заполнены!");
            }
            else
            {
                calculator.mLVZH = Convert.ToDouble(mLVZH_Text.Text);
                calculator.pLVZH = Convert.ToDouble(pLVZH_Text.Text);
                calculator.nkprLVZH = Convert.ToDouble(nkprLVZH_Text.Text);

                R_result_for_LVZH.Text = Convert.ToString(Math.Round(calculator.CalculateRadiusLVZH(), 6));
                Z_result_for_LVZH.Text = Convert.ToString(Math.Round(calculator.CalculateZLVZH(), 6));

                History.SaveDataLVZH(calculator.mLVZH, calculator.pLVZH, calculator.nkprLVZH, calculator.CalculateRadiusLVZH(), calculator.CalculateZLVZH());
            }
        }

        private void CreateResultFileForGG_Click(object sender, EventArgs e)
        {
            if (mGG_Text.Text == "" || pGG_Text.Text == "" || nkprGG_Text.Text == "")
            {
                MessageBox.Show("Не все поля заполнены для создания отчёта!");
            }
            else
            {
                string ResultString = $" ОТЧЕТ ИЗМЕРЕНИЙ ОТ {DateTime.Get()}: \n Измерение нижнего концентрационного предела распространения пламени горючих газов (НКПР ГГ)\n мг = {calculator.mGG} кг\n ρг = {calculator.pGG} кг/м3\n Снкрп = {calculator.nkprGG} %\n Rнкпр = {Convert.ToDouble(Math.Round(calculator.CalculateRadiusGG(), 6))} м\n Zнкпр = {Convert.ToDouble(Math.Round(calculator.CalculateZGG(), 6))} м";

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "calculator_results.txt");
                File.WriteAllText(filePath, ResultString);

                Process.Start("notepad.exe", filePath);
            }
        }

        private void CreateResultFileForLVZH_Click(object sender, EventArgs e)
        {
            if (mGG_Text.Text == "" || pGG_Text.Text == "" || nkprGG_Text.Text == "")
            {
                MessageBox.Show("Не все поля заполнены для создания отчёта!");
            }
            else
            {
                string ResultString = $" ОТЧЕТ ИЗМЕРЕНИЙ ОТ {DateTime.Get()}: \n Измерение нижнего концентрационного предела распространения ЛВЖ (НКПР ЛВЖ)\n мп = {calculator.mLVZH} кг\n ρп = {calculator.pLVZH} кг/м3\n Снкрп = {calculator.nkprLVZH} %\n Rнкпр = {Convert.ToDouble(Math.Round(calculator.CalculateRadiusLVZH(), 6))} м\n Zнкпр = {Convert.ToDouble(Math.Round(calculator.CalculateZLVZH(), 6))} м";

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "calculator_results.txt");
                File.WriteAllText(filePath, ResultString);

                Process.Start("notepad.exe", filePath);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseWindow.ShowDisclaimer(e);
        }

        private void ClearAllGGButton_Click(object sender, EventArgs e)
        {
            mGG_Text.Text = "";
            pGG_Text.Text = "";
            nkprGG_Text.Text = "";
            R_result_for_GG.Text = "";
            Z_result_for_GG.Text = "";
        }

        private void ClearAllLVZHButton_Click(object sender, EventArgs e)
        {
            mLVZH_Text.Text = "";
            pLVZH_Text.Text = "";
            nkprLVZH_Text.Text = "";
            R_result_for_LVZH.Text = "";
            Z_result_for_LVZH.Text = "";
        }
    }
}
