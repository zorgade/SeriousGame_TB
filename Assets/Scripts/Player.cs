public class Player {

    private string pseudo;
    public int score;
    public int position;

    public Player(string pseudo, int score, int position)
    {
        this.Pseudo = pseudo;
        this.score = score;
        this.position = position;
    }
    public string Pseudo    { get { return pseudo; } set { pseudo = value; } }
    public int Score { get { return score; } set { score = value; } }
    public int Position { get { return position; } set { position = value; } }

}
