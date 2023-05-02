namespace WeatherEye.Models
{
    public class EnvironmentalSensor
    {
        public int Id { get; set; }
        public double Dampness { get; set; }
        public double Temperature { get; set; }
        public double Pressure { get; set; }
        public double IAQuality { get; set; }
        public DateTime DateOfReading { get; set; }

        public string TimeOfReading
        {
            get {
                return this.DateOfReading.Hour.ToString() + ":"
                    + this.DateOfReading.Minute.ToString(); 
            }
        }
    }
}
