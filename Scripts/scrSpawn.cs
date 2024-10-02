using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSpawn : MonoBehaviour
{

    [SerializeField] GameObject[] spawnList;
    int index=0;
    
    void OnTriggerEnter(Collider collider)//Encontra o ultimo cover que o player entrou e que será usado caso ele aperte o botão
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Spawnar();
            gameObject.SetActive(false);
        }
    }

    void Spawnar()
    {
        for (int i = 0; i < spawnList.Length; i++)
        {
            spawnList[i].GetComponent<scrInimigo>().ativo=true;
            
        }
    }
}
