using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class scrConnect : MonoBehaviourPunCallbacks
{//using Photon.RealTime
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene("Menu");
    }

    // public override void OnJoinedRoom()
    // {
    //     PhotonNetwork.Instantiate("player",  new Vector2(Random.Range(1f,10f), transform.position.y), Quaternion.Identity);
    // }

    
}
