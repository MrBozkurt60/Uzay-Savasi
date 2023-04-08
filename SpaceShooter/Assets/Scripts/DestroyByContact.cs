using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;

    private GameController gameController;

    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter(Collider other)   //script asteroide ekli
    {
        if(other.gameObject.tag == "boundary")   //baþta direkt boundary ile temas ettiði için asteroid yok oldu
        {
            return;   //eðer tag boundary ise yok etme dedim ve direkt alt satýra geçti 
        }

        Instantiate(explosion, transform.position, transform.rotation);   //patlama efekti asteroidin olduðu yerde çýksýn

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        Destroy(other.gameObject);   //lazer yok edilir
        Destroy(gameObject);   //asteroid yok edilir
        gameController.UpdateSkor();

        
    }
}
