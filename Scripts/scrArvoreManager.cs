using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrArvoreManager : MonoBehaviour
{
    //objeto de fora que vira a função onClick

    public GameObject telaArvore; // O GameObject que representa a tela
    public scrHabilidade playerHabilidade;



    void Start()
    {
        // Inicialmente, bloqueia o cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ToggleScreen();
        }
    }

    void ToggleScreen()
    {
        bool isActive = !telaArvore.activeSelf;
        telaArvore.SetActive(isActive);

        if (isActive)
        {
            // Pause o jogo e mostre o cursor
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Continue o jogo e esconda o cursor
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ClickSkill()
    {
        playerHabilidade.DesbloquearSkill(scrHabilidade.tipoSkill.Ehoradoduelo);
    }

    public void SetPlayerSkill(scrHabilidade playerHabilidade)
    {
        this.playerHabilidade= playerHabilidade;
    }
}
