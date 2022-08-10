using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public float num1;

    void Update()
    {
        num1 = Random.Range(0, 2);
        num1 = Mathf.Round(num1);
    }
        
}
