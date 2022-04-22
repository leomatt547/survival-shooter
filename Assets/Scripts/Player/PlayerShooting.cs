using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerShooting : MonoBehaviour
{
    public static PlayerShooting instance;
    public int damagePerShot = 20;                  
    float timeBetweenBullets = 0.15f;        
    public float range = 100f;                      
    public Slider shootSlider;  
    List<float> shootDirectionsAngles = new List<float>();   
    List<LineRenderer> gunLines = new List<LineRenderer>();   

    float timer;                                    
    Ray shootRay = new Ray();                                   
    RaycastHit shootHit;                            
    int shootableMask;                             
    ParticleSystem gunParticles;                    
    LineRenderer gunLineOriginal;                           
    AudioSource gunAudio;                           
    Light gunLight;                                 
    float effectsDisplayTime = 0.2f; 
    int gunSpreadUpgradeCount = 0; 

    void Start(){
        instance = this;
    }
    
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLineOriginal = GetComponent<LineRenderer>();
        gunLines.Add(gunLineOriginal);

        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
        shootDirectionsAngles.Add(0f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        shootSlider.value = damagePerShot;
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        foreach (LineRenderer gunLine in gunLines)
        {
            gunLine.enabled = false;
            gunLight.enabled = false;
        }
    }

    public void Shoot()
    {
        timer = 0f;
        gunAudio.Play();

        foreach (LineRenderer gunLine in gunLines)
        {
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);
        }

        gunParticles.Stop();
        gunParticles.Play();

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        List<Vector3> shootPoints = new List<Vector3>();
        foreach (float angle in shootDirectionsAngles)
        {
            shootPoints.Add(Quaternion.AngleAxis(angle, Vector3.up) * transform.forward);
        }

        var gunLineIdx = 0;
        foreach (Vector3 direction in shootPoints) {
            Ray shootRayTmp = new Ray(transform.position, direction);

            if (Physics.Raycast(shootRayTmp, out shootHit, range, shootableMask))
            {
                EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                }
                gunLines[gunLineIdx].SetPosition(1, shootHit.point);
            }
            else
            {
                gunLines[gunLineIdx].SetPosition(1, shootRayTmp.origin + shootRayTmp.direction * range);
            }   
            gunLineIdx += 1;
        }
    }

    public void upgradeWeaponSpeed(){
        timeBetweenBullets -= 0.01f;
    }

    public void upgradeWeaponDamage() {
        damagePerShot += 5;
    }

    public void addWeaponSpread() {
        AddLineRenderer();AddLineRenderer();
        gunSpreadUpgradeCount += 1;
        shootDirectionsAngles.Add(-1.5f * gunSpreadUpgradeCount);
        shootDirectionsAngles.Add(1.5f * gunSpreadUpgradeCount);
    }

    private LineRenderer AddLineRenderer()
    {
        GameObject tmpLineRenderer = new GameObject("LineRenderer");
        tmpLineRenderer.gameObject.transform.parent = transform;
        LineRenderer tmpCopied = CopyComponent<LineRenderer>(gunLineOriginal, tmpLineRenderer);
        gunLines.Add(tmpCopied);
        return tmpCopied;
    }

    T CopyComponent <T> (T original, GameObject destination) where T : Component
    {
        System.Type type = original.GetType();
        var dst = destination.GetComponent(type) as T;
        if (!dst) dst = destination.AddComponent(type) as T;
        var fields = type.GetFields();
        foreach (var field in fields)
        {
            if (field.IsStatic) continue;
            field.SetValue(dst, field.GetValue(original));
        }
        var props = type.GetProperties();
        foreach (var prop in props)
        {
            if (!prop.CanWrite || !prop.CanWrite || prop.Name == "name") continue;
            prop.SetValue(dst, prop.GetValue(original, null), null);
        }
        return dst as T;
    }
}