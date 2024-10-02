using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class scrTiro: MonoBehaviour 
{
    // Start is called before the first frame update
    [Header("Arma")]

    // bool atirando=true;
    // bool recarregando=false;
    public scrPlayer _PlayerScript;
    public LayerMask alvoLayer;
    public RaycastHit rayHit;
    public int atualArma=0;
    // public int dano, municao,CheiaMunicao, cooldownReload;
    // public float alcance, tiroDelay, spread;
    public AudioSource reload;
    public AudioSource noammo;


    public GameObject RealCam;

    public GameObject MainCCam;
    public GameObject MiraCCam;
   public Transform mira; //ta sendo o transform da camera
   public Transform orientacao;
//    public Transform ponta;
    //efeitos
    public GameObject hitEffect;
   public scrShake _ScriptShake; //!possivel shake


    public TipoArmas Arma_Equipada;

     [Header("Equipamento")]

    [SerializeField] internal List <scrArma> armamento= new List<scrArma>(4);

    public int indexEquip=0;

    // CamShake.Shake(durationShake, magnitudeShake);


    [Header("Mirando")]
    [SerializeField] public bool mirando;



    void Start()
    {
        _PlayerScript=GetComponent<scrPlayer>();
        armamento[indexEquip].municao=armamento[indexEquip].CheiaMunicao; //TODO: apenas definir que arma vai usar e cada uma er a cheiamunicao como propriedade
     RealCam=GameObject.FindWithTag( "MainCamera");
        mira= RealCam.transform;
        _ScriptShake= RealCam.GetComponent<scrShake>();
        MainCCam=GameObject.FindWithTag("cinemachine");
        MiraCCam=GameObject.FindWithTag("miracinemachine");
        MiraCCam.SetActive(false);

                // Atualiza a HUD com a arma inicial
        scrArmashud.instance.UpdateWeaponHUD(armamento[indexEquip]);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && armamento[indexEquip].atirando && !armamento[indexEquip].recarregando) //tiro
        {
            Atirar();
        }

//!ATIVAR DEPOIS DO TESTE
        //mira
        if (Input.GetKey(KeyCode.Mouse1) && !mirando && !armamento[indexEquip].recarregando)
        {
            Apontar();
            switch (indexEquip)
            {
                case 0:
                _PlayerScript.anim.SetBool("Revolver_Aim",true);
                _PlayerScript.anim_revolver.SetBool("Mira_Revolver", true);
                break;

                case 1:
                _PlayerScript.anim.SetBool("Shotgun_Aim",true);
                _PlayerScript.anim_shotgun.SetBool("Mira_Shotgun", true);
                break;
                case 2:
                _PlayerScript.anim.SetBool("Rifle_Aim",true);
                _PlayerScript.anim_rifle.SetBool("Mira_Rifle", true);
                break;
                
                default:
                _PlayerScript.anim.SetBool("Revolver_Aim",true);
                break;
            }
        }else if (Input.GetKeyUp(KeyCode.Mouse1) &&  !MainCCam.activeInHierarchy || !mirando)
        {
            AbaixarArma();

             switch (indexEquip)
            {
                case 0:
                _PlayerScript.anim.SetBool("Revolver_Aim",false);
                    _PlayerScript.anim_revolver.SetBool("Mira_Revolver", false);
                break;
                case 1:
                _PlayerScript.anim.SetBool("Shotgun_Aim",false);
                    _PlayerScript.anim_shotgun.SetBool("Mira_Shotgun", false);
                break;
                case 2:
                _PlayerScript.anim.SetBool("Rifle_Aim",false);
                    _PlayerScript.anim_rifle.SetBool("Mira_Rifle", false);
                break;
                
                default:
                _PlayerScript.anim.SetBool("Revolver_Aim",false);
                break;
            }
        }
//!ATIVAR DEPOIS DO TESTE

        Debug.DrawLine(armamento[indexEquip].ponta.position, MainCCam.transform.forward, Color.red); //!ATIVAR DEPOIS DO TESTE

        //*recarregar
        if(Input.GetKey(KeyCode.R) && armamento[indexEquip].municao<armamento[indexEquip].CheiaMunicao && !armamento[indexEquip].recarregando)//recarregar
        {
            armamento[indexEquip].recarregando=true;
            _PlayerScript.anim.SetBool("Reload", true);
            switch (indexEquip)
            {
                case 0 :
                    _PlayerScript.anim_revolver.SetBool("Reload_Revolver", true);
                    break;
                case 1 :
                    _PlayerScript.anim_shotgun.SetBool("Reload_Shotgun", true);
                    break;
                case 2 :
                    _PlayerScript.anim_rifle.SetBool("Reload_Rifle", true);
                    break;

            }

            Recarregar();
            reload.Play();
        }

        //*troca de arma
        if (Input.GetKeyDown(KeyCode.Tab) && !mirando)
        {
            if (indexEquip<=1) //recomeçar se chegar no maixmo da lista
            {
            armamento[indexEquip].modelo.SetActive(false);
            indexEquip++;
            _PlayerScript.anim.SetInteger("Equipamento",indexEquip); //!TESTAR
            armamento[indexEquip].modelo.SetActive(true);

            scrArmashud.instance.UpdateWeaponHUD(armamento[indexEquip]);
            
            Debug.Log("mudou para arma: " + indexEquip);
                armamento[indexEquip].municao = armamento[indexEquip].CheiaMunicao;//TODO: arrumar isso
            }
            else
            {
                armamento[indexEquip].modelo.SetActive(false);
                indexEquip = 0;
                scrArmashud.instance.UpdateWeaponHUD(armamento[indexEquip]);
                _PlayerScript.anim.SetInteger("Equipamento", indexEquip ); //!TESTAR
                armamento[indexEquip].modelo.SetActive(true);
            }
        }

        //*corrida desativa a arma
        if (_PlayerScript.anim.GetBool("Run") == true)
        {
                armamento[indexEquip].modelo.SetActive(false);
        }
        else
        {
                armamento[indexEquip].modelo.SetActive(true);
        }
        
        
    }
    //*tiro
     private void Atirar() 
    {   
        armamento[indexEquip].muzzleFlash.Play();

        //camera shake
        // StartCoroutine(scriptShake.CameraShake(.15f, armamento[indexEquip].intensidadeShake)); //TODO: magnitude relativo a arma
        _ScriptShake.Teste();
        _ScriptShake.sourceImpulse(mira.forward);

        


        armamento[indexEquip].atirando=false;

        //!spread
        //if Arma_Equipada== TipoArma.escopeta
        // float spreadX= Random.Range(-spread, spread);
        // float spreadY= Random.Range(-spread, spread);
        //if(rigidbody.velocity.magnitude > 0) spread = spread * 1.5f;
        // Vector3 trajetoria= mira.forward + new Vector3(spreadX,spreadY,0);


        if (armamento[indexEquip].municao > 0)
        {
            armamento[indexEquip].somTiro.Play();
            armamento[indexEquip].municao--;

            //TODO: colocar na ponta da arma
            if (Physics.Raycast(mira.position, mira.forward, out rayHit, armamento[indexEquip].alcance)) //!mudar mira.foward pra trajetoria pro spread
            {

                Debug.Log(rayHit.collider.name);

                if (rayHit.collider.CompareTag("Inimigo"))
                {
                    Debug.Log("tiro no corpo");
                    rayHit.collider.GetComponentInParent<scrInimigo>().Tomou(armamento[indexEquip].dano); //instanciar bala ao inves de raycast?
                }

                if (rayHit.collider.CompareTag("Head"))
                {
                    Debug.Log("tiro na cabeça");

                    rayHit.collider.GetComponentInParent<scrInimigo>().Headshot(armamento[indexEquip].dano); //instanciar bala ao inves de raycast?
                }

                if(rayHit.collider.CompareTag("Garrafa"))
                {
                    Destroy(rayHit.collider.gameObject);
                }

                GameObject hitObject = Instantiate(hitEffect, rayHit.point, Quaternion.LookRotation(rayHit.normal));//efeito acertou
                Destroy(hitObject, 2f);

            }
            scrArmashud.instance.UpdateAmmoHUD(armamento[indexEquip].municao);

        }
        else
        {
            Debug.Log("Sem munição");
            noammo.Play();
        }

        Invoke("ResetShot", armamento[indexEquip].tiroDelay); //TODO: usar outro metodo
        // StartCoroutine(ResetShot());
    }

    private void Recarregar()
    {
        //adicionar tempo de carregamento
        armamento[indexEquip].recarregando=true;
        mirando=false;
        // StartCoroutine(Carregado());
        Invoke("Carregado", armamento[indexEquip].cooldownReload);
        Debug.Log("reload");
    }

    private void Carregado()
    {
        armamento[indexEquip].municao=armamento[indexEquip].CheiaMunicao;
        armamento[indexEquip].recarregando=false;
        _PlayerScript.anim.SetBool("Reload", false);
        _PlayerScript.anim_revolver.SetBool("Reload_Shotgun", false);
        _PlayerScript.anim_shotgun.SetBool("Reload_Revolver", false);
        _PlayerScript.anim_rifle.SetBool("Reload_Rifle", false);

        scrArmashud.instance.UpdateAmmoHUD(armamento[indexEquip].municao);
    }

    // IEnumerator Carregado()
    // {
    //     yield return new WaitForSeconds(cooldownReload);
    //     municao=CheiaMunicao;
    //     recarregando=false;
    // }
    private void ResetShot()
    {
        armamento[indexEquip].atirando=true;
    }

    private void Apontar()
    {
        mirando=true;
     MainCCam.SetActive(false);
        MiraCCam.SetActive(true);

    }

    private void AbaixarArma()
    {
        Debug.Log("Soltou mouse1");
        mirando=false;
     MainCCam.SetActive(true);
        MiraCCam.SetActive(false);

    }

    

    // IEnumerator ResetShot()
    // {
    //     yield return new WaitForSeconds(tiroDelay);

    //     atirando=true;
    // }
}

// public enum TipoArmas
// {
//     revolver,
//     escopeta,
//     rifle,
//     duplo
// }