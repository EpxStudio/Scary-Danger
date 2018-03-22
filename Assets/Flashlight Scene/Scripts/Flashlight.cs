using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    //Flashlight Management variables
    private bool flashlightEnabled;
    public GameObject lightObj;
    public float maxEnergy;
    private float currentEnergy;

    //Battery interaction variables
    private int batteries;
    private float usedEnergy;

    //Vive controller interaction variables
    bool switchedOn = false;
    
    // Use this for initialization
    void Start () {
        maxEnergy = 50 * batteries;
        currentEnergy = maxEnergy;
	}

	
	// Update is called once per second
	void FixedUpdate () {
        maxEnergy = 50 * batteries;
        currentEnergy = maxEnergy;
      /*  //equip flashlight with "F" key
        if (Input.GetKeyDown(KeyCode.F)) {
            flashlightEnabled = !flashlightEnabled;
        }*/

        //flashlight on if there is energy in it
        if (flashlightEnabled)
        {
            lightObj.SetActive(true);
            if (currentEnergy <= 0)
            {
                lightObj.SetActive(false);
                batteries = 0;
            }

            if (currentEnergy > 0)
            {
                lightObj.SetActive(true);
                currentEnergy -= .5f * Time.deltaTime;
                usedEnergy += .5f * Time.deltaTime;
            }

            if (usedEnergy >= 50)
            {
                batteries -= 1;
                usedEnergy = 0;
            }
            print("Batteries: " + batteries);
            print("usedEnergy: " + usedEnergy);
        }
        else
            lightObj.SetActive(false);
    }

    //Charges Flashlight when battery collides with it
    public void OnTriggerEnter(Collider other){
        if (other.tag == "Battery")
        {
            batteries += 1;
            Destroy(other.gameObject);
        }
    }

    public void ToggleSwitch()
    {
        flashlightEnabled = !flashlightEnabled;
        if (flashlightEnabled)
            FixedUpdate();
        else
            FixedUpdate();
    }
}
