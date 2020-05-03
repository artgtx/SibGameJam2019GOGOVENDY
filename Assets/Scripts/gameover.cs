using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(load());

    }
    
    IEnumerator  load()
    {
        yield return new WaitForSeconds(2);
        globalMD.LoadScene("GameTest");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
