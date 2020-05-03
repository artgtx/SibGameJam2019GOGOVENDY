using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class Stats : MonoBehaviour
{
    public ReactiveProperty<int> curHP { get; set; }
    public int maxHP;

    void Awake()
    {
        curHP = new ReactiveProperty<int>();
        curHP.Value = maxHP;
    }

    


}
