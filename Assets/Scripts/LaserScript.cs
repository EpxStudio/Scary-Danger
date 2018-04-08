using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
    public int damagePerShot = 10;
    public float range = 100f;
    public Flashlight flash;

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
        //Will only shoot if the flashlight is on
        if (flash.IsOn())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //Disables the Line renderer so light is all you see
        line.enabled = false;
        //Sets the line renderer in the light origin
        line.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        //If (Origin of the ray, what it has hit, how far it can go)
        //If this has hit something
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //Get the enemy health script of that object the ray has hit
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            //If the object you hit has a health script subtract it by damage per shot
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
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