
internal class Program
{
    public static Player player = new Player();
    static void Main(string[] args)
    {
        new GameManager();
        GameManager.GM.player = player;

        Entrance entrance = new Entrance();
        entrance.EntranceUI();
    }


}
