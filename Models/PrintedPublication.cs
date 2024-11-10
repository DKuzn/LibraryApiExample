namespace LibraryApiExample.Models
{
    public class PrintedPublication
    {
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Pages { get; set; }
        public int Year { get; set; }
        public int Type { get; set; }
        public int Publishing { get; set; }
    }
}
