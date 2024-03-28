using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton _instance;
    public static Singleton Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new Singleton();
                if(GameObject.Find("Manager") == null)
                {
                    GameObject gameObject = new GameObject("Manager");
                    gameObject.AddComponent<Singleton>();
                    Instantiate(gameObject);
                    DontDestroyOnLoad(gameObject);
                }
            }
            return _instance;
        }
    }

    /*
    여기에 서브 Manager를 적재할수 있음
    ex)
    GameManager game = new GameManager();
    DataManager data = new DataManager();
    public static GameManager Game { get { return Instance.game; } }
    public static DataManager Data { get { return Instance.data; } }
    */
}
