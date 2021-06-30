using SQLite;

namespace BMIApp.Models
{
    public class BmiItem
    {
        [PrimaryKey, AutoIncrement]
      
        public int ID { get; set; }
        public double Bmi { get; set; }


}
}
