using UnityEngine;
using UnityEngine.EventSystems;

public class scrSelecionaIcon : MonoBehaviour
{
    public Sprite defaultSprite; // Sprite padrão
    public Sprite highlightedSprite; // Sprite quando o mouse estiver sobre a imagem
    
    private SpriteRenderer spriteRenderer; // Referência ao componente SpriteRenderer

    private void Awake()
    {
        // Obtém a componente SpriteRenderer do GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Verifique se spriteRenderer foi encontrado
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer não encontrado!");
            return;
        }

        // Define o sprite inicial como o defaultSprite
        spriteRenderer.sprite = defaultSprite;
    }

    // Método chamado quando o mouse entra na área do GameObject
    private void OnMouseEnter()
    {
        Debug.Log("Mouse entrou no GameObject");
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = highlightedSprite;
        }
    }

    private void OnMouseExit()
    {
        Debug.Log("Mouse saiu do GameObject");
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = defaultSprite;
        }
    }
}
