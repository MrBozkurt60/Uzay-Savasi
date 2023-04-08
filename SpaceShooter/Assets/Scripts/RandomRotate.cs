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

        fizik.angularVelocity = Random.insideUnitSphere * hiz;   //açýsal hýza random deðer veme , asteroid dönmesi
    }

    
}
