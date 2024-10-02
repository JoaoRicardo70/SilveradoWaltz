using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject MenuPrincipal;
    [SerializeField] GameObject MenuOpcoes;

    private void Start()
    {
        MenuOpcoes.SetActive(false);
        MenuPrincipal.SetActive(true);
    }

    public void Jogar()
    {
        PhotonNetwork.JoinOrCreateRoom("SampleScene", new RoomOptions { MaxPlayers = 4}, TypedLobby.Default);
        //entrar no scene online
      
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("SampleScene");
    }

    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}
