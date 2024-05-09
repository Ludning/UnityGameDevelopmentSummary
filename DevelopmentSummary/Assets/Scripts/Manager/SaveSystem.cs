using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    //리플렉션으로 저장하는 기능 구현
    Dictionary<string, ISaveAbleObject> SaveData = new Dictionary<string, ISaveAbleObject>();
    public void SaveToJson(string path)
    {

    }
}
public interface ISaveAbleObject
{
    public void Save();
}