using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    private bool flashlightEnabled;
    public GameObject flashlight;
    public GameObject lightObj;
    public float maxEnergy;
    private float currentEnergy;

    private int batteries;
    private GameObject batteryPickedUp;
    private float usedEnergy;

	// Use this for initialization
	void Start () {
        maxEnergy = 50 * batteries;
        currentEnergy = maxEnergy;
	}
	
	// Update is called once per second
	void FixedUpdate () {
        maxEnergy = 50 * batteries;
        currentEnergy = maxEnergy;
        //equip flashlight with "F" key
        if (Input.GetKeyDown(KeyCode.F)) {
            flashlightEnabled = !flashlightEnabled;
        }

        //flashlight on if there is energy in it
        if (flashlightEnabled)
        {
            flashlight.SetActive(true);

            if (currentEnergy <= 0)
            {
                lightObj.SetActive(false);
                batteries = 0;
            }

            if (currentEnergy > 0)
            {
                lightObj.SetActive(true);
                currentEnergy -= 0.5f * Time.deltaTime;
                usedEnergy += .5f * Time.deltaTime;
            }

            if (usedEnergy >= 50)
            {
                batteries -= 1;
                usedEnergy = 0;
            }
        }
        //Flashlight off
        else
        {
            flashlight.SetActive(false);
        }
	}

    //Picks up and and adds batteries when stepped over
    public void OnTriggerEnter(Collider batt){
        if (batt.tag == "Battery")
        {
            batteryPickedUp = batt.gameObject;
            batteries += 1;
            Destroy(batteryPickedUp);
        }
    }
}
