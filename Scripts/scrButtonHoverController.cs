// ButtonHoverController.cs

using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class scrButtonHoverController : MonoBehaviour
{
    public TMP_Text text1;
    public TMP_Text text2;

    [System.Serializable]
    public class ButtonText
    {
        public string[] texts = new string[2];
    }

    public ButtonText[] buttonTexts;

    public void OnButtonHover(int index)
    {
        if(index >= 0 && index < buttonTexts.Length)
        {
            text1.text = buttonTexts[index].texts[0];
            text2.text = buttonTexts[index].texts[1];
        }
    }

    public void OnButtonExit()
    {
        text1.text = "";
        text2.text = "";
    }
}
