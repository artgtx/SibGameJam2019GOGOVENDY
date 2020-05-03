using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfController : MonoBehaviour
{
    public GameObject[] shelfs = new GameObject[5];
    public Sprite[] goods = new Sprite[5];
    public Sprite[] vendsBody = new Sprite[5];
    public Sprite[] vendsLegs = new Sprite[5];
    public GameObject Body;
    public GameObject Legs;
    public bool random;
    bool destroy = false;
    public Sprite TakeShelf()
    {
        //int x = Random.Range(0, 5);
        int index = -1;
        if (FindFilled(out index))
        {
            var good = shelfs[index].GetComponent<SpriteRenderer>().sprite;
            destroy = true;
            return good;
        }
        Debug.LogError("No shelf in enemy");
        return null;
    }

    public bool FindFilled(out int number)
    {
        number = -1;
        for (int i = 0; i < shelfs.Length; i++)
        {
            Sprite sprite = shelfs[i].GetComponent<SpriteRenderer>().sprite;
            if (sprite != null && sprite != goods[5])
            {
                number = i;
                return true;
            }
        }
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
        int x = Random.Range(0, 5);
        int y = Random.Range(0, 5);
        shelfs[y].GetComponent<SpriteRenderer>().sprite = goods[x];
        if (random)
        {
            x = Random.Range(0, 4);
            Body.GetComponent<SpriteRenderer>().sprite = vendsBody[x];
            Legs.GetComponent<SpriteRenderer>().sprite = vendsLegs[x];
        }
        Body.GetComponent<Animator>().SetTrigger("IdleEnemy2");
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy)
        {
            Destroy(gameObject);
        }
    }
}
