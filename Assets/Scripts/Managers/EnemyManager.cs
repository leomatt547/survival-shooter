using UnityEngine;

public class EnemyManager : MonoBehaviour{
    public PlayerHealth playerHealth;
    public float spawnTime = 3f;
    public int spawnPointCount;
    public int enemyCount;

    [SerializeField]
    MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start(){
        //Mengeksekusi fungs Spawn setiap beberapa detik sesuai dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn(){
        //Jika player telah mati maka tidak membuat enemy baru
        if (playerHealth.currentHealth <= 0f){
           return;
        }

        //Mendapatkan nilai random
       int spawnPointIndex = Random.Range(0, spawnPointCount);
       int spawnEnemy = Random.Range(0, enemyCount);
        //Memduplikasi enemy
        Factory.FactoryMethod(spawnEnemy, spawnPointIndex);
    }
}