namespace F1_time_tracking.Models
{
    public class DriverTeam
    {
        public int DriverID { get; set; }
        public int TeamID { get; set; }
        public int SeasonID { get; set; }
        public Driver Driver { get; private set; }
        public Team Team { get; private set; }
        public Season Season { get; private set; }
    }
}