namespace AmigoSecreto.domain.Entidades
{
    public class Group
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Participante> Participantes { get; set; } = new List<Participante>();
    }
}
