namespace WeatherEye.Models
{
    public class SensorsData
    {
        public DateTime dateTime { get; set; }
        
        public double? s1 { get; set; } //TEMPERATURE
        public double? s2 { get; set; } //HUMIDITY 
        public double? s3 { get; set; } //PRESSURE 
        public double? s4 { get; set; } //AIR_QUALITY_IAQ
        public double? s5 {  get; set; } //LIGHT_ALS
        public double? s6 { get; set; } //lIGHT_UV
        public double? s7 { get; set; } //AIR_PM_10
        public double? s8 { get; set; } //AIR_PM_2_5
        public double? s9  { get; set; } //AIR_PM_1
        public double? s10 { get; set; } //RAIN_DISCRETE
        public double? s11 { get; set; } //RAIN_VALUE
    }
}
