using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenSenseMapAssessment.Models.SenseBox
{
    public class SenseBoxRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Exposure is required")]
        [JsonPropertyName("exposure")]
        public string Exposure { get; set; }

        [Required(ErrorMessage = "Model is required")]
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [JsonPropertyName("location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("lat")]
        public double Lat { get; set; }

        [JsonPropertyName("lng")]
        public double Lng { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }
    }
}
