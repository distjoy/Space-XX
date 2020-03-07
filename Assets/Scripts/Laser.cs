using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    private float _speed = 1000;
    private AudioManager audioManager;
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("LaserShot");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 3000)
            Destroy(transform.gameObject);
        transform.Translate(Vector3.up * _speed * 1.5f * Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
            if(col.transform.tag=="Enemy Child" || col.transform.tag == "EnemyType2" || col.transform.tag == "EnemyType3")
        {
            Enemy enemy = col.gameObject.GetComponent<Enemy>();
            enemy.AnimateAndDestroy();
            Destroy(this.gameObject);
 

        }

    }

}
