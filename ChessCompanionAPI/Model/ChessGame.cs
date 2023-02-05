namespace ChessCompanionAPI.Model
{
    public class ChessGame
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<string>? Moves { get; set; }
    }
}
