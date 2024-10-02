using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrTrocaCena : MonoBehaviour
{
    public string sceneName; // Nome da cena para carregar

    public void LoadScene()
    {
        // Carrega a cena com o nome especificado
        SceneManager.LoadScene(sceneName);
    }

        void OnTriggerEnter(Collider other)
    {
        // Verifica se o jogador entrou no collider
        if (other.CompareTag("Player"))
        {
            // Carrega a nova cena
            SceneManager.LoadScene(sceneName);
        }
    }

}
