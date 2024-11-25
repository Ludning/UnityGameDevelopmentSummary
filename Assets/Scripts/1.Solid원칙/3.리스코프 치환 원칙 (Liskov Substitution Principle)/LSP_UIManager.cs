using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSP_UIManager : MonoBehaviour
{
    private static LSP_UIManager _instance;

    public static LSP_UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LSP_UIManager>();
                if (_instance == null)
                    _instance = new GameObject("UIManager").AddComponent<LSP_UIManager>();
            }
            return _instance;
        }
    }
    
    public Canvas Canvas;
}
