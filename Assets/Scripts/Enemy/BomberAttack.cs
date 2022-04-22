using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAttack : EnemyAttack
{
    override protected void Attack() 
    {
        base.Attack();
        enemyHealth.currentHealth = 0;
        enemyHealth.Death();
        enemyHealth.StartSinking();
    }
}
