
using team4_assignment;

internal class Program


{
    public static Player player = new Player();

    static void Main(string[] args)
    {
        new GameManager();
        GameManager.GM.player = player;


        Character character = new Character();

        character.InputName();// 캐릭터 생성기능
        string userName = character.UserName;


    }


}
