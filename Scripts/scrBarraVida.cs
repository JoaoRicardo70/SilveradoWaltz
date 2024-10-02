using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrBarraVida : MonoBehaviour
{

    public Slider sliderVida;
    public float vidaMax = 400f;
    public float vidap;
    public int vidai;

    [SerializeField] GameObject objetoHud;

    public scrPlayer vidaPlayer;
    public scrInimigo vidaInimigo;
    // Start is called before the first frame update
    void Start()
    {
        if (objetoHud.tag == "Player"){

            vidap = vidaPlayer.vida;

        }

        if (objetoHud.tag == "Inimigo"){

            vidaInimigo = objetoHud.GetComponent<scrInimigo>();
            vidai = vidaInimigo.vida;
            
        }
        //vida = vidaMax;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objetoHud.tag == "Player"){

            vidap = vidaPlayer.vida;
            if(sliderVida.value != vidap){

                sliderVida.value = vidap;
            }
        }
        if (objetoHud.tag == "Inimigo"){

            vidai = vidaInimigo.vida;
            if(sliderVida.value != vidai){

                sliderVida.value = vidai;
            }
        }

        //vidaPlayer.Atingido();
        //vidaInimigo.Tomou();

        //teste
        //if(Input.GetKeyDown(KeyCode.H)){

            //testetomaDano(10);

        //}
        
    }

    //void testetomaDano(float dano){

        //vida -= dano;
        
    //}

    void tomaDano(){



    }
}
