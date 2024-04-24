using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.Progress;

public class ObjectPool : MonoBehaviour
{
    //
    const int CreationCount = 30;

    Dictionary<string, Stack<GameObject>> _pool;
    Dictionary<string, GameObject> _poolParent;

    Dictionary<string, Stack<GameObject>> Pool
    {
        get 
        { 
            if (_pool == null)
                _pool = new Dictionary<string, Stack<GameObject>>();
            return _pool; 
        }
    }
    Dictionary<string, GameObject> PoolParent
    {
        get
        {
            if(_poolParent == null)
                _poolParent = new Dictionary<string, GameObject>();
            return _poolParent;
        }
    }

    GameObject poolOrigin;

    //������Ʈ Ǯ�� �ʱ�ȭ�ϴ� �Լ���, Ǯ�� �̸� ������Ʈ���� �����ϰ� �غ��մϴ�.
    public GameObject GetOrigin()
    {
        if(poolOrigin == null)
        {
            poolOrigin = new GameObject("Pool");
            poolOrigin.AddComponent<ObjectPool>();
            //DontDestroyOnLoad(poolOrigin);
        }
        return poolOrigin;
    }
    public GameObject GetParent(GameObject prefab)
    {
        string prefabName = prefab.name;
        //�� �θ� ������
        if (!PoolParent.ContainsKey(prefabName))
        {
            GameObject parent = new GameObject($"{prefabName}_Pool");
            parent.transform.SetParent(GetOrigin().transform);
            PoolParent.Add(prefabName, parent);
        }
        return PoolParent[prefabName];
    }
    public Stack<GameObject> GetPool(GameObject prefab)
    {
        if (!Pool.ContainsKey(prefab.name) || Pool[prefab.name].Count == 0)
            ExpandPool(prefab);
        return Pool[prefab.name];
    }
    //������Ʈ Ǯ���� ��� ������ ������Ʈ�� �������� �Լ��Դϴ�.
    public GameObject GetObject(GameObject prefab)
    {
        GetParent(prefab);
        GameObject gameObject = GetPool(prefab).Pop();
        gameObject.transform.SetParent(null);
        gameObject.SetActive(true);
        return gameObject;
    }
    //����� ���� ������Ʈ�� ������Ʈ Ǯ�� ��ȯ�ϴ� �Լ��Դϴ�. ������Ʈ�� ���¸� �ʱ�ȭ�ϰ� Ǯ�� ����� �غ� �մϴ�.
    public void ReturnObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(GetParent(gameObject).transform);
        GetPool(gameObject).Push(gameObject);
    }
    //Ǯ�� ������Ʈ�� �������� �߰��ϴ� �Լ��Դϴ�. Ǯ�� ũ�⸦ �������� �����Ͽ� �ʿ信 ���� ������Ʈ�� ������ �� �ֽ��ϴ�.
    public void ExpandPool(GameObject prefab, int count = CreationCount)
    {
        if (!Pool.ContainsKey(prefab.name))
            _pool.Add(prefab.name, new Stack<GameObject>());
        for (int i = 0; i < count; i++)
        {
            GameObject go = GameObject.Instantiate(prefab, GetParent(prefab).transform);
            go.name = prefab.name;
            go.SetActive(false);
            _pool[prefab.name].Push(go);
        }
    }
    //������Ʈ Ǯ�� ���� ��� ������Ʈ�� �����ϴ� �Լ��Դϴ�. ������ ����ǰų� Ǯ�� �����ϱ� ���� ȣ��� �� �ֽ��ϴ�.
    public void Clear(string name)
    {
        foreach (var stack in Pool)
        {
            foreach(var item in stack.Value)
            {
                Destroy(item);
            }
        }
        _pool = null;

        foreach (var go in PoolParent)
        {
            Destroy(go.Value);
        }
        _poolParent = null;
    }
    //�� �θ� ����� �������� �Լ�
    public int GetPoolParentCount()
    {
        return PoolParent.Count;
    }
    //���� ���� ��ü�� ����� �������� �Լ�
    public int GetPoolCount(GameObject prefab)
    {
        if(Pool.ContainsKey(prefab.name))
            return Pool[prefab.name].Count;
        else 
            return 0;
    }
}
