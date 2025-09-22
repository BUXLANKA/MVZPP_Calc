namespace MVZPP_Calc.modules
{
    internal class GetTime
    {
        public string Get()
        {
            string? date;

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            return date = $"{day}.{month}.{year}";
        }
    }
}
