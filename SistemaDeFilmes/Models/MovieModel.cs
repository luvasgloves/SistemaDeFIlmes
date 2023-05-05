namespace SistemaDeFilmes.Models
{
    public class MovieModel
    {
        public int Year { get; set; }
        public string Title { get; set; }
        public string Studios { get; set; }
        public List<ProducerModel> Producers { get; set; }
        public bool? Winner { get; set; }


    }
}
