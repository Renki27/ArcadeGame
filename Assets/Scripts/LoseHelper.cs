using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHelper : MonoBehaviour
{
    public string CoverScene;


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


}
