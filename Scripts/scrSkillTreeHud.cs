using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrSkillTreeHud : MonoBehaviour
{
    //dentro de cada botao
    [SerializeField] private scrPlayer scr_Player;
    [SerializeField] private scrArvoreManager scr_Arvore;

    // Start is called before the first frame update
    void Start()
    {
      scr_Arvore.SetPlayerSkill(scr_Player.PegarHabilidades());   
    }

  
    
}
