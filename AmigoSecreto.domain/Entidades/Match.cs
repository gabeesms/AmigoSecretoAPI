namespace AmigoSecreto.domain.Entidades
{
    public class Match
    {
        public int Id { get; set; }
        public int GiverId { get; set; }
        public int ReceiverId { get; set; }
        public Participante Giver { get; set; }
        public Participante Receiver { get; set; }
    }
}
