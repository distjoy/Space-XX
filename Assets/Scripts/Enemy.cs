using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explosion;
    public GameObject coin;
    public void AnimateAndDestroy()
    {
        this.gameObject.SetActive(false);
        GameObject explosionObj = Instantiate(explosion, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
       // explosionObj.GetComponent<ParticleSystem>().Play();
        GameObject coinObj = Instantiate(coin, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        Destroy(explosionObj,1);
        Destroy(this.gameObject,1);
        FindObjectOfType<AudioManager>().Play("EnemyExplosion");
    }

 
}
