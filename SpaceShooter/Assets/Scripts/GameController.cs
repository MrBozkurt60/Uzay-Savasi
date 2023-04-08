using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject engel;
    public int AsteroidSayisi;
    public float OlusturmaBekleme;

    public TextMeshProUGUI SkorYazisi;
    public int skor;

    public TextMeshProUGUI gameover;
    public TextMeshProUGUI restart;

    public bool Gameover, Restart;

    private void Update()
    {
        if(restart == true)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    IEnumerator SpawnValues()
    {
        while(true)   //sonsuza kadar oluþum
        {
            yield return new WaitForSeconds(2);

            for (int i = 1; i < AsteroidSayisi; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-3, 3), 0f, 10f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(engel, spawnPosition, spawnRotation);

                //coroutine
                //1.IEnumerator döndürmek zorundadýr
                //2.en az bir tane yield return kullanýlmalýdýr
                //3.çaðýrýlýrken startcoroutine diye çaðýrýlmalýdýr
                yield return new WaitForSeconds(OlusturmaBekleme);

            }
            yield return new WaitForSeconds(2);   //asteroid dalga bir bitince 4 sn bekle

            if(Gameover == true)
            {
                restart.text = "Press 'R' for restart";
                Restart = true;
                break;

            }

        }
    }


    public void UpdateSkor()
    {
        skor += 10;
        SkorYazisi.text = "SKOR : " + skor;
    }

    public void GameOver()
    {
        gameover.text = "GAME OVER !";
        Gameover = true;
    }


    void Start()
    {
        gameover.text = " ";
        restart.text = " ";
        Gameover = false;
        Restart = false;
        StartCoroutine(SpawnValues());
    }

   
}
