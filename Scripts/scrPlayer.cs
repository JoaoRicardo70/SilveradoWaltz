using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class scrPlayer : MonoBehaviour
{
//TODO: rawinput do mouse

    [Header("Movement")]
    public Transform orientacao;
    public Rigidbody rb;//!deletar rigidbody
    public CharacterController controller;
    float velo;
    public float correrVelo;
    public float baseVelo;
    public AudioSource andar;


    public float drag;
    public float smoothTurnTime= 7f;
    float smoothTurnVelo;

    [Header("Cover")]
    public bool podeCover;
    public bool noCover;
    public bool podeMover;
    Transform areaCover;

    
    [Header("Gravidade")]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundDistance;
    [SerializeField] bool isGround;
    [SerializeField] float gforce= -9.81f;
    internal Vector3 aceleramento;

    [Header("Animações")]
    public Animator anim;
    public Animator anim_revolver;
    public Animator anim_shotgun;
    public Animator anim_rifle;

    public bool run=false;

    [Header("Scripts")]
    public scrTiro _TiroScript;
    private scrHabilidade habilidades;

    float h;
    float v;
    float movimento;
    public float FB;
    public float RL;
    [Header("Level")]

    public int kills=0;
    public int levelAtual=0;
    public int pontos;
    // public int char; //0 emmet 1 mal 2 paden 3 jake
    [SerializeField] GameObject skilltree;
    [SerializeField] private bool abriuST;


    [Header("Status")]
    public int pDano;
    public int pRoF;
    public float vida;
    [SerializeField] GameObject gameOver_canvas;

    [Header("God Mode")]
    public bool God_mode;


    // [Header("Online")] //TODO: fazer versao offline
    // PhotonView view;

//!apagar
    // [Header("Arma")]
    // bool atirando=true;
    // bool recarregando=false;
    // public LayerMask alvoLayer;
    // public RaycastHit rayHit;
    // public int dano, municao,CheiaMunicao, cooldownReload, indexEquipada;
    // public float alcance, tiroDelay, spread;



    // public Transform mira;

   


    
    // Start is called before the first frame update
    void Start()
    {
        kills=0;
        levelAtual=0;
        pontos=0;
        abriuST=false;
        habilidades= new scrHabilidade();

        //gameOver_canvas = GameObject.FindWithTag("GameOver");
        //gameOver_canvas.SetActive(false);


        pDano=0;
        // rb= GetComponent<Rigidbody>();
        controller= GetComponent<CharacterController>();
        _TiroScript= GetComponent<scrTiro>();
        // view=GetComponent<PhotonView>(); //!deletar, usar so o do script ignorar
        vida=400;
      
    }

    // Update is called once per frame
    void Update()
    {
        //inputs
        h= Input.GetAxisRaw("Horizontal");
        v= Input.GetAxisRaw("Vertical");
        Debug.Log(h);

        //faz o player caircair
        Gravidade(); 
        
        if(vida<=0)
        {
            Derrotado();
            Debug.Log("Player morto");
        }
        
        //Todo: movimento animação
        // if (h>0)
        // {
        //     Debug.Log("esquerda");
        // }else if (h<0)
        // {
        //     Debug.Log("direita");
        // }

        if (Input.GetButton("Fire3") && !noCover && !_TiroScript.mirando && FB > 0 )//correr
        {
            velo=correrVelo;


            anim.SetBool("Run", true);
                // Avoid any reload.
            
            Debug.Log("Correndo");
        }else 
        {
            velo=baseVelo;
            anim.SetBool("Run",false);

        }

        if (Input.GetButtonDown("Fire1") && noCover)
        {
            noCover=false;
            Debug.Log("Fora do cover");
        }

        if (Input.GetButtonDown("Fire1") && podeCover)//cover
        {
            noCover=true;
            podeCover=false;
            Debug.Log("No cover");
        }//TODO: apertar de novo pra sair do cover
        
       

    if (!noCover)
    {
    Move();//andar
    }else Cover();


//TODO: melhor movimento
//    Vector3 finalMove= inputDir.normalized * velo + aceleramento;
//     CharMove();


    //*usar habilidade 1


    if (Input.GetKeyDown(KeyCode.Q))//usa ricochete
    {
        //scriptPersonagem.Habilidade1.Ativar();
    } 

    //*usar habilidade2
    if (Input.GetKeyDown(KeyCode.E))//usa horadoduelo
    {
        //usa habilidade 2
    }

    //*abrir skilltree
    // if (Input.GetKeyDown(KeyCode.K))
    // {
    //     abriuST;
    // }

    // skilltree.SetActive(abriuST);

    //*subir nivel
    GanharXP();

    }

    void FixedUpdate()
    {
        isGround=Physics.CheckSphere(groundCheck.position,groundDistance,groundLayer);
        // Move();
    }

    private void Gravidade()
    {
        //reseta celeramento quando no chão
        if (isGround && aceleramento.y>0)
        {
            aceleramento.y=-2f;
        }

        if (!isGround)
        {
            aceleramento.y += gforce * Time.deltaTime;
            controller.Move(aceleramento * Time.deltaTime);
        }
    }

    private void Move()
    {
       Vector3 inputDir = orientacao.forward * v + orientacao.right * h;
       if(inputDir != Vector3.zero){

        if(!andar.isPlaying){

            Debug.Log("Andar Barulho");
            andar.Play();
        }

       }else andar.Stop();

        FB = Input.GetAxis("Vertical");
        RL = Input.GetAxis("Horizontal");
        anim.SetFloat("FT", FB);
        anim.SetFloat("RL", RL);
       

       controller.Move(inputDir.normalized * velo * Time.deltaTime); //TODO: trocar .normalized por Vector3.ClampMagnitude(inputDir,1.0f) se ficar escorregadio
        //Vector3 move= new Vector3(h,0,v);
        //controller.Move(move.normalized * velo * Time.deltaTime);

        //if(move != Vector3.zero)
        //{ 
            //personagem.forward=move;
        //}


    // if (inputDir != Vector3.zero)
    // {
    //   float targetAngle= Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
    //   float angle= Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,ref smoothTurnVelo, smoothTurnTime );
    //   transform.rotation = Quaternion.Euler(0f, angle, 0f); 

    //   Vector3 mov= Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;    

    // }
        //*rigidbody
    //    rb.AddForce(inputDir.normalized * velo * 10f * Time.deltaTime, ForceMode.Force); //!time.deltaime

    //     rb.drag= drag; //so se estiver no chao
        //*rigidbody
    }

    //*melhor movimento
    // private void CharMove()
    // {
    //    controller.Move(finalMove * Time.deltaTime);

    // }


    // private void Atirar() //tiro
    // {   
    //     atirando=false;
//!apagar
    public void Atingido(int dano)
    {

        if(!God_mode)vida-=dano;
        //if(vida<=0)
        //{
            //Derrotado();
           // Debug.Log("Player morto");
       // }
    }

    private void Derrotado()
    {
        //TODO: quando player morrer ele ficar um tempo pra ser resgatado
        Debug.Log("GAME OVER!");
        gameOver_canvas.SetActive(true);
    }
//!apagar

    private void Cover()
    {
        //TODO: Deixar costas do player perto do cover, não parado onde ele apertou, snap?
        //deixa so horizontal e limita nas extremidades do cover
        // rb.constraints= RigidbodyConstraints.FreezeRotationY;
        // rb.constraints= RigidbodyConstraints.FreezeRotationZ;

       Debug.Log("EM COVER");
        Vector3 atualPosicao= transform.position;
        transform.forward= areaCover.forward; //vira o player de costar para o cover
        //verifica se passou do limite
        if (atualPosicao.x > areaCover.GetChild(0).transform.position.x) // child(0) limte da esquerda
        {
            if (h==1)
            {
               podeMover=false;
             
            }else
            {
                podeMover=true;

            }
        }

        if (atualPosicao.x < areaCover.GetChild(1).transform.position.x) // verifica se passou do limitie
        {
            if (h==-1)
            {
                podeMover=false;
            }else
            {
                podeMover=true;
            }
        }

        
            Vector3 inputDir= orientacao.right * h;
            //*mover no cover
            if (podeMover)
            {
            // rb.AddForce(inputDir.normalized * velo * 10f * Time.deltaTime, ForceMode.Force); //!modo rigidbody
              controller.Move(inputDir.normalized * velo * Time.deltaTime);

            }
        
            
        

    }

    private void GanharXP()
    {
        if (kills>=7)
        {
            levelAtual++;
            pontos++;
        }
    }

    public scrHabilidade PegarHabilidades()
    {
        return habilidades;
    }

    public bool podeHabilidade1()
    {
        return habilidades.CheckSkill(scrHabilidade.tipoSkill.Erichochete);

    }

    public bool podeHabilidade2()
    {
        return habilidades.CheckSkill(scrHabilidade.tipoSkill.Ehoradoduelo);

    }

    void OnTriggerEnter(Collider col)//Encontra o ultimo cover que o player entrou e que será usado caso ele aperte o botão
    {
        if (col.gameObject.CompareTag("Cover"))
        {
            areaCover=col.gameObject.transform;
            
            Debug.Log("novo cover selecionado: " + col.name);
        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("Cover") && !noCover)
        {
            podeCover=true;
            Debug.Log("pode cover no: " + col.name);
        }
    }

    void OnTriggerExit(Collider col)//tira a possibilidade de ficar em cover, talvez deixar o area cover nulo
    {
        if (col.gameObject.CompareTag("Cover"))
        {
            areaCover=col.gameObject.transform; //TODO:tirar esse transform

            podeCover=false;

            Debug.Log("saiu da area do cover" + col.name);
        }
    }
    //     //spread
    //     // float spreadX= Random.Range(-spread, spread);
    //     // float spreadY= Random.Range(-spread, spread);
    //     // Vector3 trajetoria= mira.forward + new Vector3(spreadX,spreadY,0);



}
