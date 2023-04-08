using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   //bu kodla boundary klasý artýk unity üzerinde eriþilebilir hale gelir
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerKontrol : MonoBehaviour
{
    Rigidbody fizik;
    [SerializeField] int hiz , egim; //public olmasýn ama unity üzerinden ulaþýyým
    [SerializeField] float nextFire;
    [SerializeField] float fireRate; //ateþleme oraný
    AudioSource ses;

    public Boundary boundary;
    public GameObject shot;
    public GameObject ShotSpawn;


     void Start()
    {
        fizik = GetComponent<Rigidbody>();  //rigidbody atamasý
        ses = GetComponent<AudioSource>();  //ses atamasý
    }

     void Update()
    {   if(Input.GetButton("Fire1") && Time.time > nextFire)   //fare tuþuna basýlýrsa lazer oluþtur
        {
            nextFire = Time.time + fireRate;

            Instantiate(shot, ShotSpawn.transform.position, ShotSpawn.transform.rotation);
            ses.Play();
        }
    }

      

    void FixedUpdate()     //fizik için ideal
    {
        float yatayKontrol = Input.GetAxis("Horizontal");
        float dikeyKontrol = Input.GetAxis("Vertical");

        fizik.velocity = new Vector3(yatayKontrol * hiz, 0f, dikeyKontrol * hiz);   //hýz atamasý

        Vector3 position = new Vector3(Mathf.Clamp(fizik.position.x, boundary.xMin, boundary.xMax), 
            0f, 
            Mathf.Clamp(fizik.position.z, boundary.zMin, boundary.zMax));   //ekran dýþýna çýkmasýn

        fizik.position = position;

        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x * egim);   //saða ve sola eðim
    }
}
