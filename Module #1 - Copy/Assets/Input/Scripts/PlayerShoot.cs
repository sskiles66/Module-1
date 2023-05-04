using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody Bullet;
    public Transform bulletSpawn;
    public Transform crosshair;

    public AudioClip gunshotSound;

    public AudioSource audioSource;

    void Start()
    {
        //this was giving me a headache
        //audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
        audioSource.clip = gunshotSound;
        audioSource.PlayOneShot(audioSource.clip);

        

        //Using RayCasting to see what the crosshair is pointing at. 
        //A ray is projected and a hit is stored. 
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(crosshair.position), out hit, 1000))
        {
            Vector3 direction = (hit.point - bulletSpawn.position).normalized;
            Rigidbody bullet = Instantiate(Bullet, bulletSpawn.position, Quaternion.LookRotation(direction));
            bullet.velocity = direction * 50;
            Debug.Log(hit.transform.name);
            
        }
    }
}
