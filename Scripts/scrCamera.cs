using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrCamera : MonoBehaviour
{
    public scrPlayer scriptPlayer;
    
    public Rigidbody rb;
    public float speed;
    public GameObject playerT;
    public Transform playerO;

    public Transform orientacao;

    public Transform mira;


    public float rodar;
    

    public float smoothTurnTime= 0.1f;
    float smoothTurnVelo;
    
    void Start()
    {
        playerT=GameObject.FindWithTag("Player");
        playerO=playerT.transform.Find("PBody");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 direcao= mira.position - new Vector3(transform.position.x, mira.position.y, transform.position.z);
        orientacao.forward = direcao.normalized;

        // float h= Input.GetAxis("Horizontal");
        // float v= Input.GetAxis("Vertical");
        // Vector3 inputDir= orientacao.forward + v + orientacao.right + h;

        // if (inputDir != Vector3.zero)
        // {
                //todo: analisar se pode apagar
            if (!scriptPlayer.noCover)//todo: LIMITAR CAMERA NO COVER
            {
            playerO.forward = direcao.normalized; 
            }
       
            
            // Vector3.Slerp(playerO.forward, inputDir.normalized, Time.deltaTime * rodar); //!testar
        // }

        // if (direcao != Vector3.zero)
        // {

        //     float angle= Mathf.SmoothDampAngle(transform.eulerAngles.y, transform.eulerAngles.x,ref smoothTurnVelo, smoothTurnTime );
        //     playerO.rotation = Quaternion.Euler(0f, angle, 0f); 



        //     playerO.forward = direcao.normalized;
            
        // }


    }

    
}