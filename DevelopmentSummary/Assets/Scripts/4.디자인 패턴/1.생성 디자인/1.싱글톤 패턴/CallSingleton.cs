using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSingleton : MonoBehaviour
{
    //Singleton singleton;
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(Singleton.Instance.GetType());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
