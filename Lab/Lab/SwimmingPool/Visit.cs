namespace Lab.SwimmingPool;

public class Visit(int clientId, int trainerId, DateTime visitDate, int durationMinutes)
{
        public int ClientId { get; set; } = clientId;
        public int TrainerId { get; set; } = trainerId;
        public DateTime VisitDate { get; set; } = visitDate;
        public int DurationMinutes { get; set; } = durationMinutes;
}