using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCopy : MonoBehaviour
{
    public GameObject gameObject;
    public float time = 25;

    void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            time = 25;
            Vector2 CreatePoint = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            Instantiate(gameObject, CreatePoint, Quaternion.identity);
        }
    }
}
