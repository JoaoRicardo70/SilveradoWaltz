using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class scrArma 
{

    [HideInInspector]
    public bool atirando=true;
    [HideInInspector]
    public bool recarregando=false;
    [HideInInspector]
    public bool equipado=false;
    [Header("Arma")]
    

    public GameObject modelo;
    public Transform ponta;
    public int dano, municao,CheiaMunicao, cooldownReload;
    public float alcance, tiroDelay, spread, intensidadeShake;
    public AudioSource somTiro;

     public Sprite weaponSprite;


    public ParticleSystem muzzleFlash;
    //INTENSIDADE camera shake
    //muzzle flash
    //recoil
    //marca de tiro
    //nome, som

    public TipoArmas Arma_Equipada;


    


}

public enum TipoArmas
{
    revolver,
    escopeta,
    rifle,
    duplo
}
