using Microsoft.EntityFrameworkCore;
using MVZPP_Calc.modules;
using MVZPP_Calc.net8.data;
using MVZPP_Calc.net8.model;
using MVZPP_Calc.net8.modules;
using System.Diagnostics;
using System.Runtime.Versioning;

namespace MVZPP_Calc
{
    [SupportedOSPlatform("windows")]
    public partial class Form1 : Form
    {
        CloseWindowDisclaimer CloseWindow = new CloseWindowDisclaimer();
        GetTime DateTime = new GetTime();
        CalcModule calculator = new CalcModule();
        LocalDBSaveData History = new LocalDBSaveData();
        LocalDBUpdateModule TableUpdater = new LocalDBUpdateModule();
        ForceDataDelete _FDDAgent = new ForceDataDelete();

        private AppData? dbContext;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.dbContext = new AppData();
            this.dbContext.Database.EnsureCreated();
            this.dbContext.GG_result.Load();
            this.dbContext.PP_result.Load();
            this.dataGridView1.DataSource = dbContext.GG_result.Local.ToBindingList();
            this.dataGridView2.DataSource = dbContext.PP_result.Local.ToBindingList();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.dbContext?.Dispose();
            this.dbContext=null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            mGG_Text.Text = "";
            mLVZH_Text.Text = "";

            pGG_Text.Text = "";
            pLVZH_Text.Text = "";

            nkprGG_Text.Text = "";
            nkprLVZH_Text.Text = "";

            R_result_for_GG.Text = "";
            Z_result_for_GG.Text = "";
            Rf_result_for_GG.Text = "";

            R_result_for_LVZH.Text = "";
            Z_result_for_LVZH.Text = "";
            Rf_result_for_LVZH.Text = "";
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
                Rf_result_for_GG.Text = Convert.ToString(Math.Round(calculator.CalculateRfGG(), 6));

                History.SaveDataGG(calculator.mGG, calculator.pGG, calculator.nkprGG, calculator.CalculateRadiusGG(), calculator.CalculateZGG(), calculator.CalculateRfGG());
                TableUpdater.UpdateGG(dataGridView1);
            }
        }

        private void ReloadTables_Click(object sender, EventArgs e)
        {
            TableUpdater.UpdateGG(dataGridView1);
            TableUpdater.UpdatePP(dataGridView2);
        }

        private void CalculateForLVZH_Click(object sender, EventArgs e)
        {
            if (mLVZH_Text.Text == "" || pLVZH_Text.Text == "" || nkprLVZH_Text.Text == "")
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
                Rf_result_for_LVZH.Text = Convert.ToString(Math.Round(calculator.CalculateRfLVZH(), 6));

                History.SaveDataLVZH(calculator.mLVZH, calculator.pLVZH, calculator.nkprLVZH, calculator.CalculateRadiusLVZH(), calculator.CalculateZLVZH(), calculator.CalculateRfLVZH());
                TableUpdater.UpdatePP(dataGridView2);
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
                string ResultString = $" ОТЧЕТ ИЗМЕРЕНИЙ ОТ {DateTime.Get()}: \n Измерение нижнего концентрационного предела распространения пламени горючих газов (НКПР ГГ)\n мг = {calculator.mGG} кг\n ρг = {calculator.pGG} кг/м3\n Снкрп = {calculator.nkprGG} %\n Rнкпр = {Math.Round(calculator.CalculateRadiusGG(), 6)} м\n Zнкпр = {Math.Round(calculator.CalculateZGG(), 6)} м\n Rf = {Math.Round(calculator.CalculateRfGG(), 6)} м";

                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "calculator_results.txt");
                File.WriteAllText(filePath, ResultString);

                Process.Start("notepad.exe", filePath);
            }
        }

        private void CreateResultFileForLVZH_Click(object sender, EventArgs e)
        {
            if (mLVZH_Text.Text == "" || mLVZH_Text.Text == "" || nkprLVZH_Text.Text == "")
            {
                MessageBox.Show("Не все поля заполнены для создания отчёта!");
            }
            else
            {
                string ResultString = $" ОТЧЕТ ИЗМЕРЕНИЙ ОТ {DateTime.Get()}: \n Измерение нижнего концентрационного предела распространения ЛВЖ (НКПР ЛВЖ)\n мп = {calculator.mLVZH} кг\n ρп = {calculator.pLVZH} кг/м3\n Снкрп = {calculator.nkprLVZH} %\n Rнкпр = {Math.Round(calculator.CalculateRadiusLVZH(), 6)} м\n Zнкпр = {Math.Round(calculator.CalculateZLVZH(), 6)} м\n Rf = {Math.Round(calculator.CalculateRfLVZH(), 6)}";

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
            Rf_result_for_GG.Text = "";
        }

        private void ClearAllLVZHButton_Click(object sender, EventArgs e)
        {
            mLVZH_Text.Text = "";
            pLVZH_Text.Text = "";
            nkprLVZH_Text.Text = "";
            R_result_for_LVZH.Text = "";
            Z_result_for_LVZH.Text = "";
        }

        private void ClearOnlyVariableForGGButton_Click(object sender, EventArgs e)
        {
            mGG_Text.Text = "";
            pGG_Text.Text = "";
            nkprGG_Text.Text = "";
        }
    }
}
