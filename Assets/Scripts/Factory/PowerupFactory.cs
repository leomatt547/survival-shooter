using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupFactory : MonoBehaviour, IFactory{

    [SerializeField]
    public GameObject[] powerupPrefab;
	public Transform[] spawnPoints;

    public GameObject FactoryMethod(int tag, int spawn)
    {
        GameObject powerup = Instantiate(powerupPrefab[tag], spawnPoints[spawn]);
        return powerup;
    }
}
