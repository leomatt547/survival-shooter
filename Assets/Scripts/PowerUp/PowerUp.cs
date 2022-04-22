using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    //this variable with store PowerUp number
    public int powerNumber;

    void OnTriggerEnter(Collider other)
    {
        //if any object with Player tag collide with this object when 
        if (other.CompareTag("Player"))
        {
            PlayerMovement.instance.PowerUpActionCalled(powerNumber);
            Destroy(gameObject);
        }
    }
}