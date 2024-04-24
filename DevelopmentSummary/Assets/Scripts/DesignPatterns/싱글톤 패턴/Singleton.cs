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
                GameObject gameObject = GameObject.Find("Manager");
                if (gameObject == null)
                {
                    gameObject = new GameObject("Manager");
                }
                _instance = gameObject.AddComponent<Singleton>();
                DontDestroyOnLoad(gameObject);
            }
            return _instance;
        }
    }

    /*
    ���⿡ ���� Manager�� �����Ҽ� ����
    ex)
    GameManager game = new GameManager();
    DataManager data = new DataManager();
    public static GameManager Game { get { return Instance.game; } }
    public static DataManager Data { get { return Instance.data; } }
    */
}
