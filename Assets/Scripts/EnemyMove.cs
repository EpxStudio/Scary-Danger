using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    public GameObject player;
    public EnemyHealth enemyHealth;
    public int speed = 5;

    float currHP;
    float maxHP;

    // Update is called once per frame
    void FixedUpdate () {
        transform.RotateAround(player.transform.position, new Vector3(0, 1, 0), 20 * Time.deltaTime * speed);
        currHP = enemyHealth.currentHealth;
        maxHP = enemyHealth.startingHealth;
        //SpeedUp();
	}

    void SpeedUp()
    {
        if ((currHP / maxHP) < 0.75f)
        {
            speed = 7;
        }
        if ((currHP / maxHP) < 0.5f)
        {
            speed = 9;
        }
    }
}
