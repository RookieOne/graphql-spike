namespace GraphqlSpike.Function.Models
{
    public class Interest
    {
        public int ID { get; set; }
        public float Percent { get; set; }
        public string InterestType { get; set; }

        public int ContactId { get; set; }
    }
}