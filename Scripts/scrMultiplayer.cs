using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class scrMultiplayer : MonoBehaviour
{
    [SerializeField] public GameObject prefabPlayer;
 

//fazer um array pra ignorar todo script que nao seja ismine

    // Start is called before the first frame update
    void Awake()
    {

        Vector3 randomPosition= new Vector3(Random.Range(1f,10f), 0.5f,Random.Range(1f,10f));
        PhotonNetwork.Instantiate(prefabPlayer.name, randomPosition, Quaternion.identity);

        
    }

}
