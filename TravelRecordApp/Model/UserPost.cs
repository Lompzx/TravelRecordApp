using System;
using SQLite;

namespace TravelRecordApp.Model
{
    public class UserPost
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Experience { get; set; }
        [MaxLength(250)]
        public string VenueName { get; set; }
        [MaxLength(100)]
        public string CategoryId { get; set; }
        [MaxLength(250)]
        public string CategoryName { get; set; }
        [MaxLength(500)]
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Distance { get; set; }
    }
}
