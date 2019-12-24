using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRandomGenerate_2 : MonoBehaviour
{
    public GameObject[] item;
    // Start is called before the first frame update
    void Start() { InvokeRepeating("Item_Random_Generate_2", 5, 1); }

    void Item_Random_Generate_2()
    {
        int number = Random.Range(0, item.Length);
        Instantiate(item[number], new Vector3(Random.Range(0, 0), Random.Range(0, 0)), Quaternion.identity);
    }

}
