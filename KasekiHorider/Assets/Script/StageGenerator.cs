using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour {
    [SerializeField]
    private GameObject pivot;

    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private int rowCount = 10;

    [SerializeField]
    private int columnCount = 10;

    [SerializeField]
    private int startHoleSize = 2;

    public Vector3 startPoint { private set; get; }
    

	// Use this for initialization
	void Awake () {
        var centerRowBegin = (rowCount / 2) - (startHoleSize / 2);
        var centerColumnBegin = (columnCount / 2) - (startHoleSize / 2);
        var centerRowEnd = (rowCount / 2) + (startHoleSize / 2);
        var centerColumnEnd = (columnCount / 2) + (startHoleSize / 2);
        for (int i=0; i<rowCount; i++)
        {
            for(int j=0; j<columnCount; j++)
            {
                var obj = GameObject.Instantiate(blockPrefab);
                var block = obj.GetComponent<Block>();
                var pos = pivot.transform.position;
                var scale = block.transform.localScale;
                pos += new Vector3(
                    (block.spriteRenderer.size.x) * j * scale.y,
                    (block.spriteRenderer.size.y) * i * scale.x,
                    0
                );
                if (i >= centerRowBegin &&
                    i < centerRowEnd &&
                    j >= centerColumnBegin &&
                    j < centerColumnEnd)
                {
                    startPoint = pos;
                    GameObject.Destroy(block);
                    continue;
                }
                obj.transform.position = pos;
                obj.transform.parent = transform;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
