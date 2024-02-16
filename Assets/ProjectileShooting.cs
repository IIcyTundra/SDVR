using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ProjectileShooting : MonoBehaviour
{
    // BASIC CLASS FOR SIMPLE SEMI-AUTO WEAPON
    [SerializeField] GameObject projectile;
    [SerializeField] int shootForce = 35;   // a reasonable speed we can change
    GunMovement cam;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInput();
    }

    void playerInput() {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {     // I have this binded to left click right now. will most likely change.
            Shoot();
        }

        // right now this is for a single shot weapon. getkey will be used for full autos
    }

    void Shoot() {
        // this basically just shoots from where the player is. for right now.
        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity);   // create new bullet
        bullet.transform.rotation = Quaternion.LookRotation(transform.forward);     // change rotation of the new bullet
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * shootForce, ForceMode.Impulse);    // "shoot" the bullet
        
        // add a collision function...

        Destroy(bullet, 3);     // destroy clone after 3 seconds
    }
}
