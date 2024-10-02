using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrPause : MonoBehaviour
{
    public GameObject pausePanel; // Referência ao painel de pausa
    private bool isPaused = false;

    void Start()
    {
        // Garantir que o painel de pausa comece desativado
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Garantir que o tempo de jogo esteja normal no início
        //CursorManager.Instance.HideCursor();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    void Update()
    {
        // Verifica se a tecla de pausa (por exemplo, Escape) foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Apertou Esc!");
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Debug.Log("Resumindo o jogo");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //CursorManager.Instance.HideCursor();
        // Desativa o painel de pausa e retoma o tempo de jogo
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void PauseGame()
    {
        Debug.Log("Pausando o jogo");
        //CursorManager.Instance.ShowCursor();
        // Ativa o painel de pausa e pausa o tempo de jogo
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void QuitGame()
    {
        // Sai do jogo ou carrega uma cena de menu principal
        Time.timeScale = 1f; // Certifique-se de que o tempo volte ao normal antes de sair
        SceneManager.LoadScene("Menu 2"); // Substitua "MenuScene" pelo nome da sua cena de menu principal
    }
}
