using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerNetworkSetup : MonoBehaviourPunCallbacks
{
    public GameObject localXRRigGameobject;

    public GameObject avatarHeadGameobject;
    public GameObject avatarBodyGameobject;
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            //the player is local
            localXRRigGameobject.SetActive(true);
            SetLayerRecursively(avatarHeadGameobject, 6);
            SetLayerRecursively(avatarHeadGameobject, 7);
        }
        else
        {
            //the player is the remote player
            localXRRigGameobject.SetActive(false);
            SetLayerRecursively(avatarHeadGameobject, 0);
            SetLayerRecursively(avatarHeadGameobject, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetLayerRecursively(GameObject go, int layerNumber)
    {
        if (go == null) return;
        foreach (Transform trans in go.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
