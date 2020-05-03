using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LocalizedText : MonoBehaviour{
	public string key;
    public string num;

	void Start () {

	    if (!key.Equals("") && num.Equals(""))
	    {
	        GetComponent<Text>().text = Localizator.GetTextValue(key);
        }
        else if (!key.Equals("") && !num.Equals(""))
	    {
	        GetComponent<Text>().text = Localizator.GetTextValue(key)+" "+num;
        }



	}

	public void setKey(string key) {
		GetComponent<Text>().text = Localizator.GetTextValue (key);
	}
}
