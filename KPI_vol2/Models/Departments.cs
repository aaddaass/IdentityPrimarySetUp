namespace KPI_vol2.Models
{
    public class Departments
    {   
        /*
         * BHP
         * HR
         * Inżyniering
         * IT
         * Kontrola Jakości
         * Koordynator Biur
         * Lean
         * Logistyka
         * Montaż
         * Planowanie
         * Produkcja
         * Programiści
         * Projekty strategiczne
         * UR
         * Zakupy
         */
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Tasks>? Tasks { get; set; }

    }
}
