using System;

namespace Models.ViewModels
{
    public class OrderSummary
    {
      public string movieTitle { get; set; }
      public string theaterName { get; set; }
      public TimeSpan showStartTime { get; set; }
      public TimeSpan showEndTime { get; set; }
      public int ticketPrice { get; set; }
    }
}
