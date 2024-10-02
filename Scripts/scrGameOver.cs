using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scrGameOver : MonoBehaviour
{
    void Start()
    {
         Time.timeScale = 0f;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void VoltarMenu()
    {
        // Sai do jogo ou carrega uma cena de menu principal
        Time.timeScale=1f;
        SceneManager.LoadScene("Menu 2"); // Substitua "MenuScene" pelo nome da sua cena de menu principal
    }
}
