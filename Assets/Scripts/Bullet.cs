using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody bulletRb;
    public float bulletSpeed;
    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        bulletRb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        bulletRb.velocity = transform.forward * bulletSpeed;

        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }
        
        else if(coll.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
