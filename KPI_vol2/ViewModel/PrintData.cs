using Microsoft.VisualBasic;

namespace KPI_vol2.ViewModel
{
    public class PrintData
    {
        public int      Id { get;set; }
        public DateTime DataUtworzenia { get;set; }
        public DateTime DataZakonczenia { get;set; }
        public string   Opis { get;set; }
        public string   Wykonanie { get;set;} 
        public bool     IsSelected { get;set; }
        public string   OsobaPilotujaca { get;set; }

        public DayOfWeek DayOfWeek { get;set; }
    }
}
