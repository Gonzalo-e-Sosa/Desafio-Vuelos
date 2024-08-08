using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Vuelos.Models
{
    [PrimaryKey(nameof(FlightNumber))]
    public class Flight
    {
        [Required]
        [MinLength(6)][MaxLength(8)]
        [RegularExpression("^[0-9]{1}[A-Z]{1}[0-9]{4,6}$|^[A-Z]{2}[0-9]{4,6}$", ErrorMessage = "FlightNumber must be in the format '4M1234', 'AU3441', or 'AO123456'")]
        public required string FlightNumber { get; set; }
        
        [Required]
        public DateTime ArrivalTime { get; set; }
        
        [Required][MinLength(3)][MaxLength(300)]
        public required string Airline { get; set; }
        
        [Required]
        public bool Delayed { get; set; }
    }
}
