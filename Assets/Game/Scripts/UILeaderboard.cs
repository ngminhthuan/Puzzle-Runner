using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class UILeaderboard : MonoBehaviour
{
    public Transform leaderboardContainer;  // The parent object with VerticalLayoutGroup
    public GameObject leaderboardEntryPrefab; // A prefab with a Text component

    private Dictionary<Player, GameObject> entries = new Dictionary<Player, GameObject>();

    public void UpdateLeaderboard(List<Player> finishedPlayers)
    {
        // Clear old entries
        foreach (Transform child in leaderboardContainer)
        {
            Destroy(child.gameObject);
        }
        entries.Clear();

        // Add players in order
        for (int i = 0; i < finishedPlayers.Count; i++)
        {
            Player p = finishedPlayers[i];
            GameObject entry = Instantiate(leaderboardEntryPrefab, leaderboardContainer);
            entry.GetComponent<PlayerItem>().SetPlayerName ($"{i + 1}. {p.NickName}");
            entries[p] = entry;
        }
    }
}
