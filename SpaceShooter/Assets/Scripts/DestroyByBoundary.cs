using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
     void OnTriggerExit(Collider temas)
    {
        Destroy(temas.gameObject);   //sýnýrdan çýkýnca lazerler yok olsun
    }
}
