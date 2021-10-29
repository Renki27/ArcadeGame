using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public Material HighlightMat;
    public Material OriginalMat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        //Se activa cuando entra una colision
        Debug.Log("Object collide the trigger");
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player Tag Object");

            try {
                var player = other.GetComponent<Player>();
                player.Alert();


                var rigidBD = other.GetComponent<Rigidbody>();
                rigidBD.angularVelocity = new Vector3(Random.Range(-1000f, 1000f),
                                                      Random.Range(1f, 1000f), 
                                                      Random.Range(-1000f, 1000f));

                rigidBD.AddTorque(new Vector3(Random.Range(-1000f, 100f),
                                                      Random.Range(1f, 1000f),
                                                      Random.Range(-1000f, 1000f)));

                rigidBD.AddForce(new Vector3(Random.Range(-1000f, 100f),
                                                      Random.Range(1f, 1000f),
                                                      Random.Range(-1000f, 1000f)));



            }
            catch(System.Exception ex)
            {
                Debug.Log("Player component not assigned:  " + ex);
            }
           
        }

    }

    private void OnTriggerStay(Collider other)
    {
        //Se ejecuta por frame (como un update), mientras exista una colision
        Debug.Log("Object inside the trigger");

        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<MeshRenderer>().material = HighlightMat;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Se ejecuta cuando sale del volumen de un trigger
        Debug.Log("Object left the trigger");
        gameObject.GetComponent<MeshRenderer>().material = OriginalMat;
    }



}
