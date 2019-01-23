using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUI : MonoBehaviour {
    [SerializeField]
    private Image image;

    public static FadeUI instance { private set; get; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    void Start () {
		if(image == null)
        {
            this.image = GetComponentInChildren<Image>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public IEnumerator StartAnimation(float seconds, System.Func<float,float> func)
    {
        var offset = 0f;
        var separate = 100;
        var baseColor = image.color;
        while(offset < seconds)
        {
            yield return new WaitForSeconds(seconds / separate);
            offset += (seconds / separate);
            var parcent = Mathf.Clamp01(offset / seconds);
            baseColor.a = func(parcent);
            image.color = baseColor;
        }
        baseColor.a = func(1f);
        image.color = baseColor;
    }
}
