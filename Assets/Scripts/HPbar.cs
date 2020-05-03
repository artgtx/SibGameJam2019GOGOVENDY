using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;

public class HPbar : MonoBehaviour
{

    public Stats stats;
    public Image hpBar;

    private CompositeDisposable disposables = new CompositeDisposable();

    void Start()
    {
        stats.curHP
            .ObserveEveryValueChanged(x => x.Value)
             .Subscribe(xs =>
             {
                 hpBar.fillAmount = Mathf.Round(stats.curHP.Value) / Mathf.Round(stats.maxHP);

             }).AddTo(disposables);
    }

    
   

    void OnDestroy()
    {
        if (disposables != null)
        {
            disposables.Dispose();
        }

    }
}
