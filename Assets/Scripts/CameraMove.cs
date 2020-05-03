using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform CamTransform;
    public Transform Player;
    private float minusxpos;
    public Transform top;
    public Transform botom;
    //public float horizontalFoV = 90.0f;//test

    // ...


    void Start()
    {
        minusxpos = Player.position.x;
        CamTransform = Camera.main.transform;
    }

    void Update()
    {
        CamTransform.position = new Vector3(Player.position.x - minusxpos, CamTransform.position.y, CamTransform.position.z);
        top.position = new Vector3(Player.position.x - minusxpos, top.position.y, top.position.z);
        botom.position = new Vector3(Player.position.x - minusxpos, botom.position.y, botom.position.z);
    }
}


/*
    public Transform player;
    public float smoothSpeed = .3f;

    private Vector3 currentVelocity;
    Vector3 startPosition;

    void Start()
    {
        startPosition = transform.localPosition;
    }


    void LateUpdate()
    {
        if (player.position.x != transform.position.x )
        {            
            if ((player.position.y - player.position.y % 1) != transform.position.y)
            {
                Vector3 newPos = new Vector3(player.position.x , transform.position.y, transform.position.z);
                transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed);
            }
            else
            {
                Vector3 newPos = new Vector3(player.position.x , transform.position.y, transform.position.z);
                transform.position = Vector3.SmoothDamp(newPos, transform.position, ref currentVelocity, smoothSpeed);
            }
        }
    }

}
*/