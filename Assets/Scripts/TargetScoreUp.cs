using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScoreUp : Target
{
    private int score10 = 10;
    public GameObject prefabTimeMinus;


    protected override void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            player.IncreaseScore(score10);

            GameObject.Instantiate(prefabTimeMinus);
            var timeTarget = prefabTimeMinus.GetComponent<TargetTime>();
            timeTarget.gameObject.tag = "NegativeTimer";
            timeTarget.Repositionate();
          

        }
    

        base.OnTriggerEnter(other);


    }
}
