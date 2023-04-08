using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody fizik;
    [SerializeField] int hiz;
    void Start()
    {
        fizik = GetComponent<Rigidbody>();

        fizik.velocity = transform.forward * hiz;   //z ekseninde hareket
    }

}
