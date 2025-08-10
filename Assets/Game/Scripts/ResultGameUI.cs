using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultGameUI : MonoBehaviour
{
    public Transform resultContainer;  // The parent object with VerticalLayoutGroup
    public GameObject playerItemEntryPrefab; // A prefab with a Text component

    private Dictionary<Player, GameObject> entries = new Dictionary<Player, GameObject>();

    public void UpdateResult(List<Player> finishedPlayers)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // Clear old entries
        foreach (Transform child in resultContainer)
        {
            Destroy(child.gameObject);
        }
        entries.Clear();

        // Add players in order
        for (int i = 0; i < finishedPlayers.Count; i++)
        {
            Player p = finishedPlayers[i];
            GameObject entry = Instantiate(playerItemEntryPrefab, resultContainer);
            entry.GetComponent<PlayerItem>().SetPlayerName($"{i + 1}. {p.NickName}");
            entries[p] = entry;
        }
    }
}
