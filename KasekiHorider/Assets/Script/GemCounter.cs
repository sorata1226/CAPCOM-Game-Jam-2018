using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCounter : MonoBehaviour {
    [SerializeField]
    private int flameDelay = 10;
    public int count = 0;
    public Text text;
    private bool willUpdateCount = false;
    private int flames = 0;
	// Use this for initialization
	void Start () {
        text.text = count.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if(willUpdateCount){
            flames--;
            if(flames==0){
                count++;
                text.text = count.ToString();
                willUpdateCount = false;
            }
        }
	}

    public void AddCount()
    {
        willUpdateCount = true;
        flames = flameDelay;
    }
}
