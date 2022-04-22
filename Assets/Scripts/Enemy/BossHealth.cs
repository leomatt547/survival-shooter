using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : EnemyHealth
{
    override public void Death() {
        base.Death();
        UpgradeWeapon.GameIsPaused = true;
    }
}
