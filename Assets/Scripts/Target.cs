using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float minZ;
    public float maxZ;
    public float minX;
    public float maxX;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //virtual: para reconstruir o recargar sin afectarlo
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
         //   Debug.Log("Hit detected");
            Repositionate();
        }
    }


    public void Repositionate()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), transform.position.y, Random.Range(minZ, maxZ));
    }
}
