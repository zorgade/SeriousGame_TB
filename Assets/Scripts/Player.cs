public class Player {

    private string pseudo;
    public int score;
    public int position;
    public bool played;

    public Player(string pseudo, int score, int position, bool played)
    {
        this.Pseudo = pseudo;
        this.score = score;
        this.position = position;
        this.played = played;
    }
    public string Pseudo    { get { return pseudo; } set { pseudo = value; } }
    public int Score { get { return score; } set { score = value; } }
    public int Position { get { return position; } set { position = value; } }
    public bool Played { get { return played; } set { played = value; } }

}
