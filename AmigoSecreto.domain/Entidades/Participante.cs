namespace AmigoSecreto.domain.Entidades
{
    public class Participante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int GroupId { get; set; }
        public Group group { get; set; }
    }
}
