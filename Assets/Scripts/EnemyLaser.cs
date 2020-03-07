using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : MonoBehaviour
{

    private float _speed = 2500;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1957)
            Destroy(transform.gameObject);
        transform.Translate(Vector3.down * _speed * 1.5f * Time.deltaTime);
    }
}
