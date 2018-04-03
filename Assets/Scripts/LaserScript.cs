using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour
{
    public bool trigger;
    LineRenderer line;
    public float m_MaxDamage = 1f;
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }
    void FixedUpdate()
    {
        if (trigger)
        {

        }
    }
    public void ToggleSwitch()
    {
        trigger = !trigger;
        if (trigger)
            FixedUpdate();
        else
            FixedUpdate();
    }
}