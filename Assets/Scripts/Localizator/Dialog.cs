using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Player Player;
    public string[] namesOfEnemy;
    
    public string[] firstDialog;
    public bool[] names1;
    public string[] secondDialog;
    public bool[] names2;
    public string[] thirdDialog;
    public bool[] names3;
    public string[] fourthDialog;
    public bool[] names4;
    public string[] fifthDialog;
    public bool[] names5;
    
    private int numMsg = 0;
    public Text msg;
    public Text name;
    private string playerName = "Венди";
    private string enemyName;
    private int level;


    private string[] currentDialog;
    bool[] currentBool;
    


    public void showDialog(int lvl)
    {
        globalMD.gamePause();
        level = lvl;
        enemyName = namesOfEnemy[lvl];
        switch (lvl)
        {
        case 0:
            currentBool = names1;
            currentDialog = firstDialog;
            break;
        case 1:
            currentBool = names2;
            currentDialog = secondDialog;
            break;
        case 2:
            currentBool = names3;
            currentDialog = thirdDialog;
            break;
        case 3:
            currentBool = names4;
            currentDialog = fourthDialog;
            break;
        case 4:
            currentBool = names5;
            currentDialog = fifthDialog;
            break;
            

        }
        
        this.gameObject.SetActive(true);
        showNextMsg();
    }

    [SerializeField] AudioClip blabla;
    public void showNextMsg()
    {
        FindObjectOfType<AudioController>().PlaySelectedMusic(blabla);
        if (numMsg == currentDialog.Length)
        {
            endDialog();
            return;
        }

        msg.text = currentDialog[numMsg];
        if (currentBool[numMsg])
        {
            name.text = playerName;
        }
        else
        {
            name.text = namesOfEnemy[level];
        }

        numMsg++;

    }

    public TutorialDialog tutorial;
    public AudioClip aud;
    void endDialog()
    {
        numMsg = 0;
        
        this.gameObject.SetActive(false);
        globalMD.gamePause();
        FindObjectOfType<AudioController>().PlaySelectedMusic(aud);
        Player.LoadMaze();
        tutorial.showDialog();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            showNextMsg();
        }
    }
}
