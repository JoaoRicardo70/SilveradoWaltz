using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrColisoes_Player : MonoBehaviour
{
    public scrPlayer statusPlayer;
    // Start is called before the first frame update
    void Start()
    {
        statusPlayer = GetComponentInParent<scrPlayer>();
    }

    public void Atingido(int dano)
    {
        if(!statusPlayer.God_mode){

            statusPlayer.vida-=dano;
        }
        
        Debug.Log("vida player=" + statusPlayer.vida);
        if(statusPlayer.vida<=0)
        {
            Debug.Log("Player morto");
        }
    }
}
