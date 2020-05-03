using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rb2D;
    public Rigidbody2D rbBackground;
    public Rigidbody2D market;
    public Transform player;
    public GameObject dark;

    private float speedBg = 0.5f;
    float speedofShop= 1f;
    // Start is called before the first frame update
    void Start()
    {
        //speed = new Vector2(2f, 2f);
        rb2D = GetComponent<Rigidbody2D>();
        tmpPlayer= this.gameObject.transform.position;
    }

    private Vector3 tmpPlayer;
    private Vector3 positionPlayer;
    public Transform SkyTransform;
    public Transform SityTransform;
    
    void Update()
    {
        if (!globalMD.playerLock)
        {
            float posX = Input.GetAxis("Horizontal");
            float posY = Input.GetAxis("Vertical");
            if (posX < 0)
            {
                player.rotation = Quaternion.Euler(0, 180, 0);
                var pl = GetComponent<Player>().plase.transform;
                pl.position = new Vector3(pl.position.x, pl.position.y, -4);

            }
            else if  (posX > 0)
            {
                player.rotation = Quaternion.Euler(0, 0, 0);
                var pl = GetComponent<Player>().plase.transform;
                pl.position = new Vector3(pl.position.x, pl.position.y, -3);
            }

            positionPlayer = this.gameObject.transform.position - tmpPlayer;
            SkyTransform.position += new Vector3(positionPlayer.x*0.5f,0,0);
            SityTransform.position += new Vector3(positionPlayer.x*0.5f,0,0);
            tmpPlayer = this.gameObject.transform.position;
             rb2D.velocity = new Vector2(posX, posY) * speed;
            // rbBackground.velocity = new Vector2(posX, 0) * speed*speedBg;
            //market.velocity = new Vector2(posX, 0) * speed*speedofShop;

        }
        else
        {
            rb2D.velocity = new Vector2(0, 0);
            rbBackground.velocity = new Vector2(0, 0);
            //market.velocity = new Vector2(0, 0);
        }


    }
}
