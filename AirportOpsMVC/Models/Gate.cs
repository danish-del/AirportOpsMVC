namespace AirportOpsMVC.Models
{
    public class Gate
    {
            public int Id { get; set; }

            public int TerminalId { get; set; }

            public string? GateNumber { get; set; }

            public bool IsAvailable { get; set; }

            public Terminal? Terminal { get; set; }
        }

    }
