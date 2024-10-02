using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrInimigo : MonoBehaviour
{
    public int vida;
    public bool ativo;
    public TipoEnimigo tipo;
    public scrPlayer scrplayer;
    [Header("Status")]
    public float attackRange,attackTime,distJogador,walkSpeed;
    public int attackDamage;
    public AudioSource tiro;

    public scrNavegacao navegacao;

    [Header("Animações")]
    public Animator anim;

    void Start(){

        anim.SetBool("Run", false);
        anim.SetInteger("Equipamento", 0);
        anim.SetFloat("FT", 0);
        
    }

    void Update(){

        if(navegacao.navMesh.speed != 0){

            anim.SetFloat("FT", 1);

        }else{

            anim.SetFloat("FT", 0);
        }

    }

    public void Tomou(int dano)
    {   
        if(ativo)vida-=dano;
        Debug.Log("inimigo vida=" + vida);
        if (vida<=0)
        {
            Morreu();
        }
    }

    public void Headshot(int dano)
    {   
        if(ativo)vida-=dano*2;
        Debug.Log("hEADSHOT");
        if (vida<=0)
        {
            Morreu();
        }
    }

    public void Morreu()
    {
        scrplayer.kills++;
        Destroy(gameObject);
    }

    public void Ativar()
    {
        ativo=true;
    }
   
}

public enum TipoEnimigo
{
   p,
   r,
   e
}
