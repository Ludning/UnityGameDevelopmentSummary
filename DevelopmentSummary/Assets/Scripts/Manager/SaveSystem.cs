using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    //���÷������� �����ϴ� ��� ����
    Dictionary<string, ISaveAbleObject> SaveData = new Dictionary<string, ISaveAbleObject>();
    public void SaveToJson(string path)
    {

    }
}
public interface ISaveAbleObject
{
    public void Save();
}