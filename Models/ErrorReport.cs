namespace MyMvcApp.Models
{
    public class ErrorReport
    {
        public int Id { get; set; } // Unik ID for rapporten
        public string Description { get; set; } // Beskrivelse av feilen
        public string Location { get; set; } // Sted der feilen ble oppdaget
        public DateTime DateReported { get; set; } // Dato da feilen ble rapportert
    }
}