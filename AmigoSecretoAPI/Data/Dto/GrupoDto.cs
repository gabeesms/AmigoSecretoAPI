namespace AmigoSecretoAPI.Data.Dto
{
    public class GrupoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<ParticipanteDto> Participantes { get; set; } = new();
        public Dictionary<int, int> Matches { get; set; } = new(); // Id do participante -> Id do presenteado
    }
}
