
internal class Program
{
    public static Player player = new Player();
    public static Entrance entrance = new Entrance();
    public static FightScene fightScene = new FightScene();
    static void Main(string[] args)
    {
        Console.SetWindowSize(100, 35);

        new GameManager();
        GameManager.GM.player = player;

        entrance.EntranceUI();
    }


}
