using System.Text.Json.Serialization;

namespace OpenSenseMapAssessment.Models.SenseBox
{
    public class SenseBoxResponse
    {
        public string Message { get; set; }
        public SenseBoxData Data { get; set; }
    }

    public class SenseBoxData
    {
        public string CreatedAt { get; set; }
        public string Exposure { get; set; }
        public string Model { get; set; }
        public List<string> Grouptag { get; set; }
        public string Name { get; set; }
        public string UpdatedAt { get; set; }
        public CurrentLocation CurrentLocation { get; set; }
        public List<Sensor> Sensors { get; set; }

        [JsonPropertyName("_id")]
        public string Id { get; set; }
        public List<LocationInfo> Loc { get; set; }
        public Integrations Integrations { get; set; }
        public string Access_Token { get; set; }
        public bool UseAuth { get; set; }
    }

    public class CurrentLocation
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
        public string Timestamp { get; set; }
    }

    public class Sensor
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Unit { get; set; }
        public string SensorType { get; set; }
        public string Icon { get; set; }
    }

    public class LocationInfo
    {
        public string Type { get; set; }
        public Geometry Geometry { get; set; }
    }

    public class Geometry
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
        public string Timestamp { get; set; }
    }

    public class Integrations
    {
        public MqttIntegration Mqtt { get; set; }
    }

    public class MqttIntegration
    {
        public bool Enabled { get; set; }
    }
}
