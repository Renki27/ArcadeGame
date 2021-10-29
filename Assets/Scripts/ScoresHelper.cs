using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresHelper : MonoBehaviour
{
    public string CoverScene;
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


    private IEnumerator SceneChangeAwait ()
    {
        yield return new WaitForSeconds(timer);

        ReturnToCover();
    }

    public void ReturnToCover()
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
