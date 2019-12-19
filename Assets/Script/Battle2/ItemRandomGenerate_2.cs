using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomGenerate_2 : MonoBehaviour
{
    public GameObject[] item;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Item_Random_Generate", 5, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Item_Random_Generate()
    {
        int number = Random.Range(0, item.Length);
        Instantiate(item[number], new Vector3(Random.Range(-15.4f, 7.30676f), Random.Range(7.31f, 27.4f)), Quaternion.identity);
    }

}
