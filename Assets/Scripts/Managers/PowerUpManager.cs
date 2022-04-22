using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float spawnTime = 20f;
    public int spawnPoints;
    private GameObject powerup;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start(){
        //Mengeksekusi fungs Spawn setiap beberapa detik sesuai dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn(){
        //Jika player telah mati maka tidak membuat powerup baru
        if (playerHealth.currentHealth <= 0f){
           return;
        }

        //Mendapatkan nilai random
       int spawnPointIndex = Random.Range(0, spawnPoints);
       int spawnPowerup = Random.Range(0, 3);

        //Memduplikasi powerup
        powerup = Factory.FactoryMethod(spawnPowerup, spawnPointIndex);
        Destroy(powerup, 20.0f); //timeout 20s
        Debug.Log("Powerup destroyed");
    }
}
