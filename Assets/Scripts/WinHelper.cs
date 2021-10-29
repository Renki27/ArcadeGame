using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinHelper : MonoBehaviour
{
    public string CoverScene;
    public string score = "1000";
    public Text txt_score;



    public void returnToCover()
    {
        try
        {
            GameManager.gameInstance.ChangeScene("Cover");
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
    }


    private void Start()
    {
        score = GameManager.gameInstance.getScore().ToString();
        this.txt_score.text = score;

    }

}
