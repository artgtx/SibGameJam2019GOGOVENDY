using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TutorialDialog : MonoBehaviour
{
    


   public string[] currentDialog;
   private int numMsg = 0;
   public Text msg;
   private bool shown = false;


    public void showDialog()
    {
        if (!shown)
        {
            globalMD.gamePause();
      
            this.gameObject.SetActive(true);
            showNextMsg();
            shown = true;
        }

        
    }

    public void showNextMsg()
    {
        
        if (numMsg == currentDialog.Length)
        {
            endDialog();
            return;
        }

        msg.text = currentDialog[numMsg];
      

        numMsg++;

    }

    void endDialog()
    {
        numMsg = 0;
        
        this.gameObject.SetActive(false);
        globalMD.gamePause();
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            showNextMsg();
        }
    }
    
}
