using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    Random random = new Random();
    public GameObject player;
    public EnemyHealth enemyHealth;
    public float speed = 0;

    float currHP;
    float maxHP;

    // Update is called once per frame
    void FixedUpdate () {
        transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), 20 * Time.deltaTime * speed);
        currHP = enemyHealth.currentHealth;
        maxHP = enemyHealth.startingHealth;
        speed = Random.Range(.1f, 5f);
	}
}
