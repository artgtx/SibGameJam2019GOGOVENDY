using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{



    public void exitBtn()
    {
        Application.Quit();
        
    }

    public AudioClip game1;

   
    public void loadGame()
    {
        FindObjectOfType<AudioController>().PlaySelectedMusic(game1);
        globalMD.LoadScene("GameTest");
    }
    
    public Animator animaa;

    public void btnPressed()
    {
        animaa.enabled = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
