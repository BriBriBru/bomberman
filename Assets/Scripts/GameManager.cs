using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public void DestroyPlayer(GameObject player)
    {
        Destroy(player);
    }
}
