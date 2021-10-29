using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Vector3 _initialPos;

    private Rigidbody rigidBody;

    private float velX;
    private float velY;
    private float jump;
    private bool onGround;
    protected float inGameTime;
    protected int playerScore;
   // private float animSpeed = 0.6f;
    public Animator anim;

    public float velocity = 1.5f;
    public float vForce = 2f;
    public float elapsedTime = 0f;
    public float timeLimit = 30;

    public Text txt_elapsedTime;
    public Text txt_score;
    public Text txt_timeLimit;







    // Start is called before the first frame update
    void Start()
    {

        
        //Codigo ineficiente, es mejor hacer la asignación desde la interfaz. Malo para la optimización
        //var var GameObject.Find("item").GetComponent<Text>;
        


        rigidBody = gameObject.GetComponent<Rigidbody>();
        _initialPos = new Vector3(transform.position.x,
                                  transform.position.y,
                                  transform.position.z);

        this.playerScore = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //update UI
        txt_elapsedTime.text = this.elapsedTime.ToString();
        txt_score.text = this.playerScore.ToString();
        txt_timeLimit.text = (this.timeLimit - this.inGameTime).ToString();



        elapsedTime += Time.deltaTime;
        inGameTime += Time.deltaTime;


        if (inGameTime > timeLimit)
        {
            GameEnd();
        }

        velX = Input.GetAxis("Horizontal");  //-1 ... 0 ... 1
        velY = Input.GetAxis("Vertical");
        jump = Input.GetAxis("Jump");
        onGround = Physics.Raycast(this.transform.position, Vector3.down, 1.05f);


        //vector 2D a 3D
        if (velX != 0 || velY != 0)
        {
            rigidBody.velocity = (new Vector3(velX, 0, velY)) * velocity;
            Vector3 movement = rigidBody.velocity;
            transform.rotation = Quaternion.LookRotation(movement);

            anim.SetFloat("MovementY", velY);
            anim.SetFloat("MovementX", velX);
        }

        /*
        if(onGround)
        {
            Debug.Log("In the ground");
        }
        */

        if ((onGround) && (jump >= 0.3f))
        {
            rigidBody.AddForce(Vector3.up * (vForce));
        }


        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enter Pressed");
            transform.position = new Vector3(_initialPos.x, _initialPos.y, _initialPos.z);
            //  this.GetComponent<Rigidbody>().velocity = Vector3.zero;
          

            rigidBody.velocity = Vector3.zero;

        }
    }

    private void GameEnd()
    {
        Debug.Log("Game Completed");
        GameManager.gameInstance.ChangeScene("Lose");
    }

    public void Alert()
    {
        Debug.Log("Tigger  connection established");
    }


    public void IncreaseScore(int value)
    {
        this.playerScore += value;
      //  Debug.Log("Score:  " + this.playerScore);
    }

    public void IncreaseTimer(float value)
    {
       // Debug.Log("Actual timer:  " + this.inGameTime);
        inGameTime -= value;
    }
}
