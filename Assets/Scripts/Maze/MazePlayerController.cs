using UnityEngine;

public class MazePlayerController : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rb2D;
    [SerializeField] GameObject Master;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float posX = Input.GetAxis("Horizontal");
        float posY = Input.GetAxis("Vertical");

        rb2D.velocity = new Vector2(posX, posY) * speed * Time.fixedDeltaTime;
        
    }

    void Win()
    {
        Master.GetComponent<MazeController>().Win();
        Debug.Log("Win");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CameraShake.ShakeOnce(1, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Finish")
        {
            Win();
        }
    }
}
