using System;
using UnityEngine;

public class EnemyFactory : MonoBehaviour, IFactory{

    [SerializeField]
    public GameObject[] enemyPrefab;
    [SerializeField]
    public Transform[] spawnPoints;

    public GameObject FactoryMethod(int tag, int spawn)
    {
        GameObject enemy = Instantiate(enemyPrefab[tag], spawnPoints[spawn]);
        return enemy;
    }
}