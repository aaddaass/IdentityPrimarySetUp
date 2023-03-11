using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;


namespace KPI_vol2.Models
{
    public class Uzytkownik
    {
      
        public int                  Id              { get; set; }
        public string?               Imię            { get; set; }
        public string ?              Nazwisko        { get; set; }
        public string  ?             Email           { get; set; }
       // public string             ? Telefon         { get; set; }
        public int   ?               DepartmentID    { get; set; }
        public Departments?          Departments     { get; set; }
        public int    ?              TelefonId       { get; set; }
        public TelephonNo  ?         TelephonNo      { get; set; }
        public ICollection<UzytkownikDevice> uzytkownikDevices         { get; set; }

        //public IList<Device> devices { get; set; }

        public string FullName { get { return Imię + " " + Nazwisko; } }
    }
}
