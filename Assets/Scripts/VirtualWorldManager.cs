using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class VirtualWorldManager : MonoBehaviourPunCallbacks
{
    #region Photon Callbaack Methods
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to: " + "player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion
}
