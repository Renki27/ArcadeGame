using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCleaner : Target
{

    public GameObject prefabTimeMinus;
   // public GameObject cleanerSpawn;



    private void Start()
    {
        CleanerCaller();

    }


    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {


            if (gameObject.activeInHierarchy)
            {
                Debug.Log("Deactivate");
                gameObject.SetActive(false);
            }

            var clones = GameObject.FindGameObjectsWithTag("NegativeTimer");
   

            foreach (var clone in clones)
            {
                Destroy(clone);
            }

         

        }
      
        //   base.OnTriggerEnter(other);

    }

    private void CleanerCaller()
    {
        var time = Random.Range(2, 10);
        var delay = Random.Range(5, 10);
        InvokeRepeating("CleanerActivator", time, delay);

    }


    public void CleanerActivator()
    {
        if (gameObject.activeInHierarchy)
        {
            Debug.Log("Deactivate");
            gameObject.SetActive(false);
        } else
        {
            transform.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
            gameObject.SetActive(true);
        }
         
    }






}
