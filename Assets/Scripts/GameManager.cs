using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Singleton
    private static GameManager _gameInstance;
    public static GameManager gameInstance
    {
        get
        {
            return _gameInstance;
        }
    }

    //miebmros de clase priv

    private int _score;




    
    private void Awake()
    {
        if(_gameInstance == null)
        {
            _gameInstance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            Destroy(this.gameObject);
        }
    }


    //no deben haber start ni update en este objeto


    public void ChangeScene (string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    public void Exit()
    {
        Application.Quit();
    }

    private void OnApplicationQuit()
    {
        //opciones ante el evt de cerrar
        //cerrar conexion a DB
        //cerrar lectura archivos
        //pausar contador tiempo juego
        //etc...


    }

    public int  getScore()
    {
        return this._score;
    }

    public void resetScore()
    {
        this._score = 0;
    }

    public void scoreCalculation (int score)
    {
        this._score += score;
    }


    public bool SaveScore(int pos, int value)
    {
        try
        {
            PlayerPrefs.SetInt("Pos"+pos.ToString(), value);
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.Log(ex);
        }
        return false;
    }

    public int GetScore(int pos)
    {
       return  PlayerPrefs.GetInt("Pos" + pos.ToString(), 0);
    }
}
