using System;
using UnityEngine;

public class EnemyFactoryWave : MonoBehaviour, IFactoryWave{

    private GameObject enemy;
    // instantiate enemy
    public GameObject[] enemyNormal;
    public GameObject enemyElite;
    public GameObject enemyBoss;
    // spawn points
    public Transform[] spawnPoints;
    public GameObject FactoryMethod(int tag, int spawn, int mode)
    {
        if (mode == 0) {
            this.enemy = Instantiate(enemyNormal[tag], spawnPoints[spawn]);
        } else if (mode == 1) {
            this.enemy = Instantiate(enemyElite, spawnPoints[spawn]);
        } else {
            this.enemy = Instantiate(enemyBoss, spawnPoints[spawn]);
        }

        return this.enemy;
    }
}