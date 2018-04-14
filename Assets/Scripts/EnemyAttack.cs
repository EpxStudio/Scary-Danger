using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    public float damage = .5f;      //Does 25 damge per second to player
    public float range = 10f;
    public Health playerHealth;

    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer line;
    

    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        shootableMask = 1 << 8;
        //Disables the Line renderer so you can't see it
        line.enabled = false;
        //Sets the line renderer in the Damage Check Object
        line.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        //If (Origin of the ray, what it has hit, how far it can go, layer it ray can collide with)
        //If this has hit something
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {

            //Get the player health script if the ray collides with the enemy (player looks at enemy)
            if(shootHit.collider.CompareTag("Enemy"))
            {
                playerHealth.TakeDamage(damage);
            }
            
            //sets the end of the Line renderer at the thing it has hit
            line.SetPosition(1, shootHit.point);
        }
        //else make the line go far out 100 units (range)
        else
        {
            line.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }

}

    