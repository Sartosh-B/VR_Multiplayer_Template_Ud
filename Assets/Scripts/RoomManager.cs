using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI Callback Methods

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    #endregion

    #region Photon Callback Methods
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
        CreateAndJoinRoom();
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("A room is created with the name: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("The Local player: " + PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name + " Player count " + PhotonNetwork.CurrentRoom.PlayerCount);

        object mapType;

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("map"))
        {
            if (PhotonNetwork.CurrentRoom.CustomProperties.TryGetValue("map",out mapType))
            {
                Debug.Log("Joined room with the map: " + (string)mapType);
            }
        }


    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName+ " joined to: " + "player count: " + PhotonNetwork.CurrentRoom.PlayerCount);
    }

    #endregion

    #region Private Methods

    private void CreateAndJoinRoom()
    {

        string randomRoomName = "Room_" + Random.Range(0, 1000);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;

        string[] roomPropsInLobby = { "map" };

        //We have 2 different maps
        //1. Outdoor = "outdoor"
        //2. School = "school"

        ExitGames.Client.Photon.Hashtable customRoomProperties = new ExitGames.Client.Photon.Hashtable() { {"map", "school" } };


        roomOptions.CustomRoomPropertiesForLobby = roomPropsInLobby; //properties that will be showed in lobby
        roomOptions.CustomRoomProperties = customRoomProperties;


        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);
    }

    #endregion


}


