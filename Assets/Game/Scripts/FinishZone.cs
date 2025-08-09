using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System;

public class FinishZone : MonoBehaviourPun
{
    public static FinishZone Instance;

    private List<Player> finishedPlayers = new List<Player>();
    public int totalPlayers;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        totalPlayers = PhotonNetwork.CurrentRoom.PlayerCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PhotonView playerPV = other.GetComponent<PhotonView>();
        if (playerPV != null && playerPV.IsMine) // Only local player triggers
        {
            if (photonView)
            {
                photonView.RPC(nameof(PlayerFinished), RpcTarget.AllBuffered, playerPV.Owner);
            }
            else
            {
                Debug.Log("WTF");
            }
        }
    }

    [PunRPC]
    void PlayerFinished(Player player)
    {
        if (finishedPlayers.Contains(player)) return;

        finishedPlayers.Add(player);
        int position = finishedPlayers.Count;

        Debug.Log($"{player.NickName} finished in position {position}");

        // TODO: Show finish UI for that player
        if (player == PhotonNetwork.LocalPlayer)
        {
            // You can open a finish UI for the local player here
            Debug.Log($"You finished at position {position}");
        }

        // Check if all players have finished
        if (finishedPlayers.Count >= totalPlayers)
        {
            EndRace();
        }
    }

    private void EndRace()
    {
        Debug.Log("Race Finished! Display results.");

        // TODO: Show final results screen here
        // You could pass finishedPlayers list to a UI Manager
    }
}
