using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public GameObject pressE;
    public GameObject borderUP;
    public GameObject borderDown;
    public Dialog dialog;
    private MazeController mazeController;
    public int lvl = 0;
    public GameObject[] shelf;
    public GameObject plase;
    public bool readyToBattle = false;
    // Start is called before the first frame update
    void Start()
    {
        mazeController = FindObjectOfType<MazeController>();
    }

    private Collider2D[] coll;

    public AudioClip aud;
    public void startBattle()
    {
        FindObjectOfType<EnemySpawner>().Spawn();
        readyToBattle = false;
        globalMD.playerLock = true;
        borderUP.SetActive(false);
        borderDown.SetActive(false);
        coll = FindObjectsOfType<Collider2D>();
        foreach (Collider2D x in coll )
        {
            x.enabled = false;
        }
        //FindObjectOfType<AudioController>().PlaySelectedMusic(aud);
        
        dialog.showDialog(lvl);
        //mazeController.gameObject.transform.SetParent(null);
    }

    public void LoadMaze()
    {
        mazeController.LoadMaze(lvl);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (readyToBattle)
            {  
                startBattle();
            }
        }
    }


    private GameObject currentenemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            currentenemy = other.gameObject;
            pressE.SetActive(true);
            readyToBattle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            pressE.SetActive(false);
            readyToBattle = false;
        }
    }

    void endBattle()
    {
        globalMD.playerLock = false;
        borderUP.SetActive(true);
        borderDown.SetActive(true);
        foreach (Collider2D x in coll)
        {
            x.enabled = true;
        }
        //mazeController.gameObject.transform.SetParent(Camera.main.transform);
    }

    public void loseBattle()
    {
        endBattle();
        lvl -= 1;
        if (lvl < 0)
        {
            //globalMD.playerLock = true;
            globalMD.LoadScene("GameOwer");
        }
        else
        {
            shelf[lvl].GetComponent<SpriteRenderer>().sprite = null;
        }

        globalMD.lvl = lvl;
    }

    public void EndGame()
    {
        animator = GetComponent<Animator>();
        animator.enabled = true;
        globalMD.lvl = lvl;
        FindObjectOfType<AudioController>().PlaySelectedMusic(aud);

    }

    public void goToWinScreen()
    {
        globalMD.LoadScene("FinalWineScene");
    }

    public void winBattle()
    {
        endBattle();
        shelf[lvl].GetComponent<SpriteRenderer>().sprite = 
            currentenemy.GetComponent<ShelfController>().TakeShelf();
        lvl += 1;
        globalMD.lvl = lvl;
        if (lvl > 4)
        {
            EndGame();
        }
    }
}
