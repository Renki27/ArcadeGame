using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverHelper : MonoBehaviour
{

    public string gameScene;
    public string scoresScene;


    public float timer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SceneChangeAwait());
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator SceneChangeAwait()
    {
        yield return new WaitForSeconds(timer);

        CheckScores();
    }

    public void GameStart()
    {
        try {
            GameManager.gameInstance.ChangeScene("Game");
        } catch(System.Exception ex)
        {
            Debug.Log(ex);
        }
       
    }

    public void CheckScores()
    {
        try
        {
            GameManager.gameInstance.ChangeScene("Scores");
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
    }

 

    public void Exit()
    {
        try
        {
            GameManager.gameInstance.Exit();
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
    }
}
