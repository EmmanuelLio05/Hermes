namespace Hermes.Models.Entities {
    public class Momento {
        public decimal Temperature { get; set; }

        public decimal Humidity { get; set; }

        public decimal Shine { get; set; }

        public bool PhotoLightState{ get; set; }

        public bool FanState { get; set; }

        public decimal WaterReserve{ get; set; }
    }
}
