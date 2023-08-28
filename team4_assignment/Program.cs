
internal class Program
{
    public static Player player = new Player();
    public static Entrance entrance = new Entrance();
    public static FightScene fightScene = new FightScene();
    static void Main(string[] args)
    {
        new GameManager();
        GameManager.GM.player = player;

        entrance.EntranceUI();
    }


}
