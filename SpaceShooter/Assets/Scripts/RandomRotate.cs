using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour
{
    Rigidbody fizik;
    public int hiz;

    void Start()
    {
        fizik = GetComponent<Rigidbody>();

        fizik.angularVelocity = Random.insideUnitSphere * hiz;   //a��sal h�za random de�er veme , asteroid d�nmesi
    }

    
}
