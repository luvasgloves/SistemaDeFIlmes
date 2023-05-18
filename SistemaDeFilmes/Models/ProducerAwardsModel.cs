namespace SistemaDeFilmes.Models
{
    public class ProducerAwardsModel
    {        
            public ProducerAwardsModel()
            {
                Min = new List<ProducerMinMax>();
                Max = new List<ProducerMinMax>();
            }
            public List<ProducerMinMax> Min { get; set; }
            public List<ProducerMinMax> Max { get; set; }
       
        
    }
}
