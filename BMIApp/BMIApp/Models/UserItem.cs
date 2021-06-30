using SQLite;

namespace BMIApp.Models
{
    public class UserItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
     }
}
