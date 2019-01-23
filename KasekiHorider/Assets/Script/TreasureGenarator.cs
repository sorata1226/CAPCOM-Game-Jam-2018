using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureGenarator : MonoBehaviour {

    public List<GameObject> TreasureList;

    public float GemToGemMinDistance = 1f;
    public float GemToPlayerMinDistance = 1f;

    public int CreateNum = 3;
    public float CreateRange = 6f;

    System.Random rnd;
    List<Vector3> gemPosList;
 
    // Use this for initialization
    void Start ()
    {
        gemPosList = new List<Vector3>();
        rnd = new System.Random(System.Environment.TickCount);
        Generate(CreateNum, CreateRange);
	}
    // Update is called once per frame
    void Update () {
		
	}

    bool IsInvalidArea(Vector3 pos)
    {
        if (pos.magnitude < GemToPlayerMinDistance) return true;    // 初期位置近くにはおかない.
        foreach(var it in gemPosList)
        {
            if ((pos-it).magnitude < GemToGemMinDistance) return true;    // 他の宝石近くにはおかない.
        }
        return false;
    }

    public void Generate(int num, float range)
    {
        gemPosList.Clear();
        int loopCount = 0;
        int createCount = 0;

        float floor = Mathf.Clamp( FloorManager.instance.floorIndex,0, 5);
        //float floor = FloorManager.instance.floorIndex;
        
        float rareRate = 0.05f + 0.01f * floor;
        float uncommonRate = 0.2f + 0.05f * floor;
        
        while (createCount < num)
        {
            float rand = (float)rnd.NextDouble();
            float distance = range * (float)rnd.NextDouble();
            float rad = 2f * Mathf.PI * (float)rnd.NextDouble();
            Vector3 pos = new Vector3(distance * Mathf.Cos(rad), distance * Mathf.Sin(rad));

            int type = 0;
            if(rand <= rareRate)
            {
                type = 2;
            } else if(rand <= uncommonRate)
            {
                type = 1;
            }

            if (IsInvalidArea(pos) == false)
            {
                Instantiate(TreasureList[type], pos, Quaternion.identity);
                gemPosList.Add(pos);
                createCount++;
            }
            
            if(loopCount++ > 1000000)
            {
                break;
            }
        }

    }
}
