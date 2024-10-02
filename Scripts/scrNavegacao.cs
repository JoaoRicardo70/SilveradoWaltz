using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class scrNavegacao : MonoBehaviour
{
    //ataca e persegue

    public Transform jogador; //TODO:transformar em array
    public NavMeshAgent navMesh;
    public bool iniciado;
    // public float walkSpeed;
    // public float distJogador;
    public scrInimigo inimigo;


    public RaycastHit rayAttack;  //melhorar tiro do enimigo


    [Header("Ataque")]
    // public float attackTime, attackChance, attackDamage;
    public float attackChance;
    bool atacou;
    public Transform arma;
    public ParticleSystem muzzleF;
    

    //TODO: munição, recarregar, tempo pra começar a atirar

//talvez eu so uso o dist jogador memso
    public float attackRange, sightRange; 
    public bool vistoPlayer, rangePlayer;


    void Awake() //carregar tudo junto e depois só ativar
    {
        navMesh = GetComponent<NavMeshAgent>();
        
   
    }

    // Start is called before the first frame update
    void Start()
    {
        jogador = GameObject.FindWithTag("Player").transform;
        navMesh.isStopped = false;
        navMesh.speed = inimigo.walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(inimigo.ativo)CalcularDistancia();
    }

    void CalcularDistancia()
    {   
        float limite= Vector3.Distance(transform.position, jogador.position);


        if (limite < inimigo.distJogador)
        {
            Stop();
            Atacar();
            Debug.Log("jogador proximo");
        }else
        {
            Move(inimigo.walkSpeed);
            navMesh.SetDestination(jogador.position);  
            Debug.Log("caçando jogador");
        }
    }

    void Move(float speed)
    {
        navMesh.ResetPath();
        navMesh.isStopped = false;
        navMesh.speed = speed;
        Debug.Log("Inimigo andando");
    }

    void Stop()
    {
        //navMesh.SetDestination(transform.position)

        navMesh.isStopped = true;
        navMesh.speed = 0;
        navMesh.velocity = Vector3.zero;
        transform.LookAt(jogador.position);
        arma.LookAt(jogador.position);
        Debug.Log("Inimigo parado");
    }

    void Atacar()
    {
        if (!atacou)
        {
            float spreadX= Random.Range(-attackChance, attackChance);
            float spreadY= Random.Range(-attackChance, attackChance);
            
            Vector3 trajetoria= arma.forward + new Vector3(spreadX,spreadY,0);



        //! Testar instanciando projetil, raycast por chance ou raycast por spread
        if (Physics.Raycast(arma.position, trajetoria, out rayAttack, inimigo.attackRange)) 
        {
           Debug.DrawLine(arma.position, trajetoria, Color.green,inimigo.attackRange);
       
            if (rayAttack.collider.CompareTag("Player"))
            {
                Debug.Log("Acertou player");
                rayAttack.collider.GetComponent<scrColisoes_Player>().Atingido(inimigo.attackDamage); //instanciar bala ao inves de raycast?

            }else Debug.Log("Errou player");
        }
        

           
            muzzleF.Play();
            inimigo.tiro.Play();
            atacou=true;
            Invoke("ResetAtacar", inimigo.attackTime);
        }
    }

    private void ResetAtacar()
    {
        atacou=false;
    }
}
