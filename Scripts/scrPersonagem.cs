using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPersonagem : MonoBehaviour
{
    public int mod_RoF;
    public float mod_Dano;
    public bool atv_mod_Dano;
    public scrPlayer playerScript;
    // public List<tipoSkill> Emmet_Skills;
    // public List<tipoSkill> Mal_Skills;

    void Awake()
    {
        // switch (playerScript.char)
        // {
        //     case 0:
        //     //pegar habilidades emmet;
        //     break;
            
        //     case 1:
        //     //pegar habilidades mal
        //     break;

        //     case 2: 
        //     //pegar habilidades paden
        //     break;

        //     case 3:
        //     //pegar habilidades jake
        //     break;

        //     default:
        //     //pegar habilidades emmet
        // }
    }

    // // Start is called before the first frame update
    // void Start()
    // {
    //     danoFinal = danoArma;
    //     mod_Dano1= danoFinal * .10f;
    //     danoFinal= danoArma + mod_Dano;
    //     mod_Dano2= danofinal * .10f;
    //     danofinal=  danofinal + mod_Dano2;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if (atv_mod_Dano)
    //     {
    //         AumentaDano();
    //     }if (atv_mod_Dano2)
    //     {
    //         AumentaDano();
    //     }
    // }

    // void AumentaDano()
    // {

    //     mod_Dano= (playerScript.pDano * 10)/100; //converter para float
    //     playerScript.pDano = playerScript.pDano + mod_Dano;

    //     mod_Dano=(playerScript.pDano * 10)/100;
    //     playerScript.pDano= playerScript.pDano + mod_Dano;
    // }
}

public enum TipoPersonagens
{
    emmet,
    mal,
    irmao1,
    irmao2
}
