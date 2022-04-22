using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public float speed = 6f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    int floorMask;
    float camRayLength = 100f;
    public PlayerShooting playerShooting;

     //bool variables
    public bool isPowerUpAnimation;
    public bool isPower1Up;
    public bool isPower2Up;

    //float variables
    public float power1Timer;
    public float power2Timer;
    public float currentPowerId;

    public GameObject Power1Box;
    public GameObject Power2Box;
    public Image power1_bar;  
    public Image power2_bar;  
    public Slider powerSlider;  
    public Slider speedSlider;  

    private void Start()
    {
        instance = this;
        Power1Box.SetActive(false);
        Power2Box.SetActive(false);
    }

    private void Awake()
    {
        //mendapatkan nilai mask dari layer yang bernama Floor
        floorMask = LayerMask.GetMask("Floor");

        //Mendapatkan komponen Animator
        anim = GetComponent<Animator>();

        //Mendapatkan komponen Rigidbody
        playerRigidbody = GetComponent<Rigidbody>();

        // get player shooting
        playerShooting = GetComponentInChildren<PlayerShooting>();
    }

    private void FixedUpdate()
    {
        //Mendapatkan nilai input horizontal (-1,0,1)
        float h = Input.GetAxisRaw("Horizontal");
        //Mendapatkan nilai input vertical (-1,0,1)
        float v = Input.GetAxisRaw("Vertical");
        
        Move(h, v);
        Turning();
        Animating(h, v);

        //If PowerUp-1 is On then PowerUP-1's Timer bar will start descreasing
        if (isPower1Up)
        {
            power1_bar.fillAmount -= Time.deltaTime / power1Timer;
        }

        //If PowerUp-2 is On then PowerUP-2's Timer bar will start descreasing
        if (isPower2Up)
        {
            power2_bar.fillAmount -= Time.deltaTime / power1Timer;
        }

        //When Power1up is Over - PowerUp-1's Effect will stop
        if (power1_bar.fillAmount==0)
        {
            Debug.Log("Power Down");
            isPower1Up = false;
            Power1Box.SetActive(false);
            power1_bar.fillAmount = 1;
            //Effect
            //gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            playerShooting.damagePerShot = playerShooting.damagePerShot - 40;
            powerSlider.value = playerShooting.damagePerShot;
        }

        //When Power2up is Over - PowerUp-2's Effect will stop
        if (power2_bar.fillAmount==0)
        {
            Debug.Log("Speed Down");
            isPower2Up = false;
            Power2Box.SetActive(false);
            power2_bar.fillAmount = 1;
            //Effects
            anim.speed = 1;
            speed = 6;
            speedSlider.value = speed;
        }
    }

    //Method player dapat berjalan
    public void Move(float h, float v)
    {
        //Set nilai x dan y
        movement.Set(h, 0f, v);

        //Menormalisasi nilai vector agar total panjang dari vector adalah 1
        movement = movement.normalized * speed * Time.deltaTime;

        //Move to position
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        //Buat Ray dari posisi mouse di layar
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Buat raycast untuk floorHit
        RaycastHit floorHit;

        //Lakukan raycast
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            //Mendapatkan vector daro posisi player dan posisi floorHit
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            //Mendapatkan look rotation baru ke hit position
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);

            //Rotasi player
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    public void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    // When the Player collides with the PowerUp Capsule this method will be called
    public void PowerUpActionCalled(int powerId)
    {
        currentPowerId = powerId;
        StartCoroutine(WaitForPowerUpAnimation());
    }

    //for Power up animation
    IEnumerator WaitForPowerUpAnimation()
    {
        //PowerUp animation start
        isPowerUpAnimation = true;
        anim.Play("PowerUp");
        anim.SetBool("isWalking", false);
        yield return new WaitForSeconds(2);

        //PowerUp animation over
        //anim.SetBool("isWalking", true);
        isPowerUpAnimation = false;

        //if powerUp-1 is active then the players shoot increases
        if (currentPowerId == 1) 
        {
            isPower1Up = true;
            Power1Box.SetActive(true);
            power1_bar.fillAmount = 1;
            Debug.Log("Power up");
            //gameObject.transform.localScale = new Vector3(3, 3, 3);
            playerShooting.damagePerShot = playerShooting.damagePerShot + 40;
            powerSlider.value = playerShooting.damagePerShot;
        }

        //if powerUp-2 is active then the players speed increases
        else if (currentPowerId == 2)
        {
            isPower2Up = true;
            Power2Box.SetActive(true);
            power2_bar.fillAmount = 1;
            Debug.Log("Speed Up");
            speed = 12;
            anim.speed = 2;
            speedSlider.value = speed;
        }

        //if powerUp-3 is active then the players health increases
        else if (currentPowerId == 3)
        {
            Debug.Log("Health Up");
            PlayerHealth.instance.currentHealth += 30;
            PlayerHealth.instance.healthSlider.value = PlayerHealth.instance.currentHealth;
        }
    }
}
