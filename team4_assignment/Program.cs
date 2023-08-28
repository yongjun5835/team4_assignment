
internal class Program
{
    static void Main(string[] args)
    {
        new GameManager();
        Player player = new Player();
        GameManager.GM.player = player;

        Entrance entrance = new Entrance();
        entrance.EntranceUI();
    }


}
