using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class GameplayUI : MonoBehaviourPun
{
    public ResultGameUI rankingPanel;

    private void Start()
    {
        // Hide rankings at start
        rankingPanel.gameObject.SetActive(false);
    }

    public void ShowRankings(List<Player> players)
    {
        rankingPanel.gameObject.SetActive(true);
        rankingPanel.UpdateResult(players);
    }

    public void OnExitClicked()
    {
        PhotonNetwork.LeaveRoom();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu"); // Change to your lobby scene name
    }
}
