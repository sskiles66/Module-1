using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        
        //If a bullet hits this specific plane with the manually made tag, "Plane", then the bullet is destroyed on impact
        if (other.gameObject.CompareTag("Plane"))
        {
            Destroy(gameObject);
        }

        //If a bullet hits this specific object with the manually made tag, "Breakable", then the bullet and the object
        //are destroyed on impact
        if (other.gameObject.CompareTag("Breakable"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Debug.Log("Enemy Hit");
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Player Hit!");
        }
    }
}
