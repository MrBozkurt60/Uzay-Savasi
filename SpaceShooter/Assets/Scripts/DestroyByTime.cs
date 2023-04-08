using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float LifeTime;   //patlama eklentilerini yok et
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

}
