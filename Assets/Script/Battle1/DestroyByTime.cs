using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    // 引数の宣言
    // Destroyする時間を指定する
    public float time;

    // DestoryしたいGameObject(基本はアタッチされたもの)
    public GameObject gameObject;

    // Use this for initialization
    void Start()
    {
        // Destory
        Destroy(gameObject, time);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
