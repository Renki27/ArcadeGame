using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetTime : Target
{
    public float time;
    public Material plus;
    public Material minus;

    public bool repositionate = true;


    private void Start()
    {
        if (time > 0)
        {
            this.GetComponent<Renderer>().material = plus;
        } else
        {
            this.GetComponent<Renderer>().material = minus;
        }
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.IncreaseTimer(time);
        }

        if (repositionate)
        {
            base.OnTriggerEnter(other);
        }

    }
}
