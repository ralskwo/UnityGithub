public class PlayerModel
{
    public int Health { get; set; }
    public int Score { get; set; }

    public PlayerModel(int health, int score)
    {
        Health = health;
        Score = score;
    }
}