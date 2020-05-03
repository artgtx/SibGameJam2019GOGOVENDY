using UnityEngine;
using UnityEngine.UI;

public class MazeController : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject MazeBorder;
    [SerializeField] GameObject[] MazeList;
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject WinImage;
    [SerializeField] GameObject LooseImage;
    [SerializeField] AudioClip winClip;
    [SerializeField] AudioClip looseClip;
    [SerializeField] AudioClip timerClip;


    private GameObject Maze;
    private Text timerText;
    private float timer = 10;
    // Start is called before the first frame update
    void SetMaze()
    {
        if (Maze != null)
        {
            Vector3 BorderSize = MazeBorder.GetComponent<Collider2D>().bounds.size;
            Vector3 MazeSize = Maze.GetComponent<Collider2D>().bounds.size;
            float MazeX = BorderSize.x / MazeSize.x;
            float MazeY = BorderSize.y / MazeSize.y;
            float scaleK = Mathf.Min(MazeX, MazeY);
            Vector3 scale = Maze.transform.localScale;
            Maze.transform.localScale = new Vector3((scale.x * scaleK), (scale.y * scaleK), 0);
            Maze.transform.SetParent(MazeBorder.transform);
            Maze.transform.position = new Vector3(MazeBorder.transform.position.x, MazeBorder.transform.position.y, -5);
        }
    }

    void SetPlayer()
    {
        Player.SetActive(true);
        GameObject start = GameObject.Find("Start");
        //start.transform.parent = transform;
        Player.transform.position = new Vector3(start.transform.position.x, start.transform.position.y, -7);
    }

    public void LoadMaze(int level)
    {
        if (MazeList.Length - 1 < level)
        {
            Debug.LogError("There is no such maze for this level: " + level);
        }
        Maze = Instantiate(MazeList[level]);
        MazeBorder.SetActive(true);
        SetMaze();
        SetPlayer();
        StartTimer();
        
    }

    void StartTimer()
    {
        FindObjectOfType<AudioController>().PlaySelectedEffect(timerClip);
        Canvas.SetActive(true);
        timerText = Canvas.GetComponentInChildren<Text>();
        timer = 10;
    }

    void StopTimer()
    {
        Canvas.SetActive(false);
        timerText = null;
        timer = 10;
    }

    void CloseMaze()
    {
        Destroy(Maze);
        //Maze.SetActive(false);
        MazeBorder.SetActive(false);
        Player.SetActive(false);
        StopTimer();
    }
    
    public void Win()
    {
        if (globalMD.lvl < 4)
        {
            FindObjectOfType<AudioController>().PlaySelectedEffect(winClip);
            CloseMaze();
            WinImage.SetActive(true);
            //WinImage.GetComponent<Animator>().enabled = false;
            //WinImage.GetComponent<Animator>().enabled = true;
            //globalMD.playerLock = true;
            FindObjectOfType<Player>().winBattle();
        }
        else
        {
            CloseMaze();
            FindObjectOfType<Player>().winBattle();
        }
    }

    void Loose()
    {
        FindObjectOfType<AudioController>().PlaySelectedEffect(looseClip);
        CloseMaze();
        LooseImage.SetActive(true);
        LooseImage.GetComponent<Animator>().enabled = false;
        LooseImage.GetComponent<Animator>().enabled = true;
        FindObjectOfType<Player>().loseBattle();
    }

    float testTimer;
    void Start()
    {
        testTimer = 0;
        //LoadMaze(1);
        //CloseMaze();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timerText != null)
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Round(timer).ToString();
        }
        if (timer < 0)
        {
            Loose();
            timerText = null;
            timer = 10;
        }
    }
}
