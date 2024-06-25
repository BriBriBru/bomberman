using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public List<int> remainingPlayers = new List<int>();

    public void DestroyPlayer(GameObject player)
    {
        Destroy(player);
        PlayerController playerController= player.GetComponent<PlayerController>();
        remainingPlayers.Remove(playerController.id);
        CheckWinner();
    }

    void CheckWinner()
    {
        if (remainingPlayers.Count == 1)
        {
            int winnerId = remainingPlayers[0];
            Debug.Log("Player " + winnerId + " wins");
        }
    }
}
