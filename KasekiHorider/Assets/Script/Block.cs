using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// フィールドに配置されるブロック.
/// </summary>
public class Block : MonoBehaviour {

    private SpriteRenderer mSpriteRenderer;
    public SpriteRenderer spriteRenderer {
        get {
            if(mSpriteRenderer == null)
            {
                mSpriteRenderer = GetComponent<SpriteRenderer>();
            }
            return mSpriteRenderer;
        }
    }

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
#if UNITY_EDITOR
        TestDig();
#endif
    }

    private void TestDig()
    {
    }

    /// <summary>
    /// このブロックを掘ります。
    /// </summary>
    public void Dig()
    {
        //DigEffectManager.callEffect(gameObject.transform);
        GameObject.Destroy(gameObject);
    }
}
