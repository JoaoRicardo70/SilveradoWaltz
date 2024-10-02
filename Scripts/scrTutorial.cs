using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tutorialCanvas;

    void Start()
    {
        
        tutorialCanvas.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

        if(tutorialCanvas.activeSelf){

            Time.timeScale = 0f;
        }
        
        if(Input.GetKeyDown(KeyCode.Return)){

            tutorialCanvas.SetActive(false);
            Time.timeScale = 1f;

        }

        //if(Input.GetKeyDown(KeyCode.Backspace)){

        //}
        
    }
}
