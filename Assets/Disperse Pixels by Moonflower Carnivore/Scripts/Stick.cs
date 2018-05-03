using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour {

    public ParticleSystem fire;
    public GameObject lightObj;

    private int numSticks;
    private bool inHands;
    private bool isBurning;
    private int burnTime = 2500; //500 == 5 secs


    void Start () {
        fire.Stop();
        lightObj.SetActive(false);
        isBurning = false;
	}

    void FixedUpdate()
    {
        if (isBurning)
        {
            if (numSticks > 0)
            {
                lightObj.SetActive(true);
                lightObj.SetActive(true);
                burnTime = burnTime - 1;
                if (burnTime == 0)
                {
                    numSticks = numSticks - 1;
                    burnTime = 2500;
                }
            } else
            {
                lightObj.SetActive(false);
                fire.Stop();
                isBurning = false;
            }
        }
        else
        {
            lightObj.SetActive(false);
            isBurning = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stick")
        {
            numSticks += 1;
            Destroy(other.gameObject);
            fire.Play();
            isBurning = true;
            lightObj.SetActive(true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hands")
            inHands = true;
    }

    public void OnTriggerExit(Collider other)
    {
        //inHands = false;
    }
}
