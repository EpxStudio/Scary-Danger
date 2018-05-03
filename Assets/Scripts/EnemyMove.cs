using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    Random random = new Random();
    public GameObject player;
    public EnemyHealth enemyHealth;
    public float speed = 0;
    float ypos;

    float currHP;
    float maxHP;

    // Update is called once per frame
    void FixedUpdate () {
        if (transform.position.x % 2 < 2f)
        {
            ypos = transform.position.y - .01f;
        }
        else
        {
            ypos = transform.position.y + .01f;
        }
        transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), 20 * Time.deltaTime * speed);
        currHP = enemyHealth.currentHealth;
        maxHP = enemyHealth.startingHealth;
        speed = Random.Range(1f, 12f);
	}
}
