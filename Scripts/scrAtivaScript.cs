using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class scrAtivaScript : MonoBehaviour
{
    private PhotonView view;
    
    [SerializeField] public MonoBehaviour[] scriptIgnorar;
    // Start is called before the first frame update
    void Start()
    {
    view= GetComponent<PhotonView>();


        if (!view.IsMine)
        {
            foreach (var script in scriptIgnorar)
            {
                script.enabled=false;
            }
        }

    }


}
