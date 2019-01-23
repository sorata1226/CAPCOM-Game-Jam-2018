using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private StageGenerator stageGenerator;

    [SerializeField]
    private GemCounter common;
    [SerializeField]
    private GemCounter uncommon;
    [SerializeField]
    private GemCounter rare;

    [SerializeField]
    private float downSpeed = 0.02f;

    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private AudioClip soundBlockDestroy;

    [SerializeField]
    private AudioClip soundNormalGem;

    [SerializeField]
    private AudioClip soundRareGem;

    private PlayerAnimation playerAnimation;

    DigEffectManager DigEffectManager { get; set; }
    Vector3 oldPos;

    // Use this for initialization
    void Start ()
    {
        DigEffectManager = GameObject.Find("DigEffectManager").GetComponent<DigEffectManager>();
        transform.position = stageGenerator.startPoint;
        this.playerAnimation = GetComponent<PlayerAnimation>();
        this.speed = speed - (FloorManager.instance.floorIndex * downSpeed);
        if(speed <= 0)
        {
            speed = 0.1f;
        }
        oldPos = gameObject.transform.position;
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Block"){
            col.gameObject.GetComponent<Block>().Dig();
            var dir = gameObject.transform.position - oldPos;
            dir.Normalize();
            if(DigEffectManager.callEffect(gameObject.transform.position + dir * 0.5f))
            {
                AudioManager.instance.PlaySE(soundBlockDestroy);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Treasure"){
            Debug.Log("Effect");
            Debug.Log(col.gameObject.name);
            ScoreManager.IncrementScore(col.gameObject.GetComponent<Treasure>().score);
            col.gameObject.GetComponent<Treasure>().DestroyTreasure();
            if(col.gameObject.name.Contains("Rare"))
            {
                var effect = GameObject.Instantiate(effectPrefab, transform.parent);
                effect.GetComponent<GetGemEffect>().player = gameObject;
                AudioManager.instance.PlaySE(soundRareGem);
                rare.AddCount();
            } else
            {
                AudioManager.instance.PlaySE(soundNormalGem);
                if (col.gameObject.name.Contains("Uncommon"))
                {
                    uncommon.AddCount();
                }
                else
                {
                    common.AddCount();

                }
            }
        }
    }
    
    // Update is called once per frame
    void Update () {
        oldPos = gameObject.transform.position;
        if (Input.GetKey(KeyCode.W))
        {
            playerAnimation.StartWalkBack();
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerAnimation.StartWalkFront();
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if  (Input.GetKey(KeyCode.D))
        {
            playerAnimation.StartWalkRight();
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if  (Input.GetKey(KeyCode.A))
        {
            playerAnimation.StartWalkLeft();
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter) ||
           Input.GetKeyDown(KeyCode.Return))
        {
            FloorManager.instance.NextFloor();
        }
    }
}
