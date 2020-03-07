using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyT1 : Enemy
{

    public GameObject laser;


    private float _speed = 300;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("FireLaser");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -3000)
            Destroy(transform.gameObject);

       transform.Translate(Vector3.down * _speed * 1.5f * Time.deltaTime);

    }
   
    IEnumerator FireLaser()
    {
        for (; ; )
        {
            GameObject newObject = Instantiate(laser, new Vector3(transform.position.x, transform.position.y - 210, 0), Quaternion.identity);
            yield return new WaitForSeconds(10f);
        }
    }
}
