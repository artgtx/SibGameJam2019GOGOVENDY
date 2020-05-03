using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MazeTimer : MonoBehaviour
{
    public GameObject Sand;
    public Text text;
    public ReactiveProperty<float> Timer { get; set; }
    private readonly CompositeDisposable disposables = new CompositeDisposable();
    // Start is called before the first frame update
    void Start()
    {
        Timer
            .ObserveEveryValueChanged(x => x.Value)
             .Subscribe(time =>
             {
                 text.text = Mathf.Round(time).ToString();
                 Sand.transform.position = new Vector3(Sand.transform.position.x, time - 10, Sand.transform.position.z);
             }).AddTo(disposables);
    }
    // Update is called once per frame
    void FixedUpdate()
    {

    }
}
