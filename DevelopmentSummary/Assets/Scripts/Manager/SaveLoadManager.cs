using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveLoadManager : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="data">저장할 Json파일의 데이터</param>
    /// <param name="path">저장할 Json파일의 위치</param>
    /// <returns>저장 성공시 true, 실패시 false</returns>
    public bool SaveJson(string data, string path)
    {
        return true;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public string LoadJson(string path)
    {
        return " ";
    }

    public void LoadResource(string addressablePath)
    {

    }
}
