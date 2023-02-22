namespace OrderApi.Model {
    public class KafkaOrderRequest {
        public string Car { get; set; }
        public string Price { get; set; }
        public string Details { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
