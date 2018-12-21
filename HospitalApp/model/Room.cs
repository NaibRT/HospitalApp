namespace HospitalApp.model
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public bool IsFull { get; set; }

        public int WardId { get; set; }
        public virtual Ward Ward { get; set; }
    }
}