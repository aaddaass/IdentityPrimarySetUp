namespace KPI_vol2.Models
{
    public class WorkingAreas
    {
        /*
         * Biura
         * Hala produkcyjna
         * CTX
         * DATRON
         * DMF
         * Fastems L1
         * Fastems L2
         * Fastems L3
         * Fastems L4
         * Magazyn/Logistyka
         * Montaż
         * Narzędziownia
         * Quality
         * Ślusarnia
         * UR
         * Waterjet/Piła
         * Wiertarka
         */
        public int Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Tasks>? Tasks { get; set; }
    }
}
