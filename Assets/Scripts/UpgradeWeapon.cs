using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;

    public GameObject upgradeMenuUI;
    public PlayerShooting playerShooting;

    // Update is called once per frame
    void Update()
    {
        if (GameIsPaused) {
            Pause();
        } 
        // if (Input.GetKeyDown(KeyCode.Escape)) {
            
        // }
    }

    public void Resume () {
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void upgradeWeaponSpeed() {
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        GameObject gunBarrelEnd = GameObject.FindWithTag("GunBarrelEnd");
        playerShooting = (PlayerShooting) gunBarrelEnd.GetComponent(typeof(PlayerShooting));

        playerShooting.upgradeWeaponSpeed();
    }

    public void upgradeWeaponDamage() {
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        GameObject gunBarrelEnd = GameObject.FindWithTag("GunBarrelEnd");
        playerShooting = (PlayerShooting) gunBarrelEnd.GetComponent(typeof(PlayerShooting));

        playerShooting.upgradeWeaponDamage();
    }

    public void addWeaponSpread() {
        upgradeMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        GameObject gunBarrelEnd = GameObject.FindWithTag("GunBarrelEnd");
        playerShooting = (PlayerShooting) gunBarrelEnd.GetComponent(typeof(PlayerShooting));

        playerShooting.addWeaponSpread();
    }

    public void Pause () {
        upgradeMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
