using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int positionX = 3;
    private int positionY = 0;
    public int deltaX = 3;
    [SerializeField] GameObject enemyObject;
    [SerializeField] GameObject[] Enemies;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        int num = Random.Range(0, 5);
        GameObject enemy = Instantiate(Enemies[num]);
        float x = Random.Range(positionX + deltaX, positionX + deltaX);
        float y = Random.Range(-1.5f, 2);
        enemy.transform.position = new Vector3(x, y, -1);
        positionX += deltaX;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
    }
}
