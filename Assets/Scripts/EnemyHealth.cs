using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public AudioClip deathClip;
//---------------------------------------------------------------
    public Slider healthSlider;
    bool damaged;
//---------------------------------------------------------------
    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        currentHealth = startingHealth;

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            Destroy(gameObject, 3f);
        }
	}

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        //Changes the health bar slider when damaged
        //--------------------------------------------------------
        healthSlider.value = currentHealth;
        //--------------------------------------------------------

        if (isDead)
            return;
        //enemyAudio.Play();

        currentHealth -= amount;

        /*hitParticles.transform.position = hitPoint;
         *hitParticles.Play();
         */
        if (currentHealth <= 0)
            Death();
    }

    void Death()
    {
        Debug.Log("Enemy is dead");
        isDead = true;
        capsuleCollider.isTrigger = true;
        //anim.SetTrigger("Dead");

        //replace this later
        isSinking = true;

        /*enemyAudio.clip = deathClip;
        enemyAudio.Play();*/
    }

    public void StartSinking ()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        Destroy(gameObject, 2f);
    }
}
