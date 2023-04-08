using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //bu kodla boundary klas� art�k unity �zerinde eri�ilebilir hale gelir
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    [SerializeField] int hiz , egim; //public olmas�n ama unity �zerinden ula��y�m
    [SerializeField] float nextFire;
    [SerializeField] float fireRate; //ate�leme oran�
    AudioSource ses;

    public Boundary boundary;
    public GameObject shot;
    public GameObject ShotSpawn;


     void Start()
    {
        fizik = GetComponent<Rigidbody>();  //rigidbody atamas�
        ses = GetComponent<AudioSource>();  //ses atamas�
    }

     void Update()
    {   if(Input.GetButton("Fire1") && Time.time > nextFire)   //fare tu�una bas�l�rsa lazer olu�tur
        {
            nextFire = Time.time + fireRate;

            Instantiate(shot, ShotSpawn.transform.position, ShotSpawn.transform.rotation);
            ses.Play();
        }
    }

      

    void FixedUpdate()     //fizik i�in ideal
    {
        float yatayKontrol = Input.GetAxis("Horizontal");
        float dikeyKontrol = Input.GetAxis("Vertical");

        fizik.velocity = new Vector3(yatayKontrol * hiz, 0f, dikeyKontrol * hiz);   //h�z atamas�

        Vector3 position = new Vector3(Mathf.Clamp(fizik.position.x, boundary.xMin, boundary.xMax), 
            0f, 
            Mathf.Clamp(fizik.position.z, boundary.zMin, boundary.zMax));   //ekran d���na ��kmas�n

        fizik.position = position;

        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x * egim);   //sa�a ve sola e�im
    }
}
