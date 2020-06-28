using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

  //  [SerializeField]
    private float _speed = 500;
    private int MAX_FUEL_LEVEL = 100;
    private int MAX_SHIELD_DURATION = 100;
    // Start is called before the first frame update
    private float _height;
    public GameObject prefab;

    private int score;
    private int fuelLevel;
    private int shieldEnableDuration;
    private Rigidbody2D rigidBody;
    private UIManager uIManager;
    private SpawnManager spawnManager;
    public GameObject explosion;
    private AudioManager audioManager;
    void Start()
    {
        // transform.position = new Vector3(1, 0, 0);
        // _height = transform.

        audioManager = FindObjectOfType<AudioManager>();
        fuelLevel = MAX_FUEL_LEVEL;
        rigidBody = GetComponent<Rigidbody2D>();
        uIManager =  GameObject.Find("Canvas").GetComponent<UIManager>();
        spawnManager =  GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        StartCoroutine("UpdateShieldAndFuel");
        StartCoroutine("FireLaser");
    }

    // Update is called once per frame
    void Update()
    {
        if (fuelLevel == 0)
        {
            die();
        }
        Move();

    }


    private void Move()
    {
   
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
            transform.position = touchPosition ;
            //Vector3 direction = touchPosition - transform.position;
            /*rigidBody.velocity = new Vector2(direction.x, direction.y) * 1.5f * _speed * Time.deltaTime;

            if(touch.phase == TouchPhase.Ended)
            {
                rigidBody.velocity = Vector2.zero;
            }*/

        }
        else
        {
            // float horizontalInput = CrossPlatformInputManager.GetAxis("Horizontal");
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * _speed * 1.5f * horizontalInput * Time.deltaTime);
        }

     
    }

    /*
     *  1. collide with enemy
     *  2. Collide with fuel
     *  3. collide with shield
     *  4. collide with coins
     * 
     * 
     * */
     void OnTriggerEnter2D(Collider2D col)
     {

     
         if (col.transform.tag=="Enemy Laser" || col.transform.tag == "Enemy Child" || col.transform.tag == "EnemyType2" || col.transform.tag == "EnemyType3")
         {
             if (shieldEnableDuration == 0)
             {
                die();   
             }
            Destroy(col.gameObject);

        }

         if (col.transform.tag == "Fuel")
         {
             fuelLevel = MAX_FUEL_LEVEL;
            //update ui
            Destroy(col.gameObject);
        }
         if (col.transform.tag == "Shield")
         {
             shieldEnableDuration = MAX_SHIELD_DURATION;
            //update ui
            Destroy(col.gameObject);
        }
         if (col.transform.tag == "Coin")
         {
             score += 5;
            uIManager.UpdateScore(score);
            Destroy(col.gameObject);
        }
     }

    public void Disable()
    {
        this.gameObject.SetActive(false);
    }

     void die()
     {
        Disable();
        GameObject explosionObj = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Destroy(explosionObj, 1);
        Destroy(this.gameObject, 1);
        FindObjectOfType<AudioManager>().Play("EnemyExplosion");
        //Animate the player explosion
        spawnManager.EndGame();
    }


    IEnumerator FireLaser()
    {
        for (; ; )
        {
            GameObject newObject = Instantiate(prefab, new Vector3(transform.position.x, transform.position.y + 355, 0), Quaternion.identity);
       
            yield return new WaitForSeconds(0.4f);
        }
    }

    IEnumerator UpdateShieldAndFuel()
    {
        while (fuelLevel > 0)
        {
            fuelLevel -= 2;
            uIManager.UpdateFuelLevel(fuelLevel/100f);
            if (shieldEnableDuration > 0)
            {
                shieldEnableDuration -= 10;
                uIManager.UpdateShieldDuration(shieldEnableDuration);
            }
            yield return new WaitForSeconds(7f);
        }
    }
}
