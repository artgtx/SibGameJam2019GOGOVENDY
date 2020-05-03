using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    public Image introIm;
    public GameObject player;

    public Sprite[] x;

    private int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        player.SetActive(false);
        introIm.sprite = x[num];
        globalMD.gamePause();
    }

    public void change()
    {
        num++;
        if (num>=3)
        {
            globalMD.gamePause();
            player.SetActive(true);
            Destroy(this.gameObject);
        }
        else
        {
            introIm.sprite = x[num];
        }

        
    }

}
