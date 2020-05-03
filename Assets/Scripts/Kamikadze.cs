using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikadze : MonoBehaviour
{
    [SerializeField] float timer = 4;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = timer;
    }

    public void StopSound()
    {
       // FindObjectOfType<AudioController>().effectSource.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            time = timer;
            globalMD.playerLock = false;
            gameObject.SetActive(false);
        }
    }
}
