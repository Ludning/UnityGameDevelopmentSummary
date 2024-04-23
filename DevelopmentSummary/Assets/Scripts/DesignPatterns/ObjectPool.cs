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

    //오브젝트 풀을 초기화하는 함수로, 풀에 미리 오브젝트들을 생성하고 준비합니다.
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
        //폴 부모가 없으면
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
    //오브젝트 풀에서 사용 가능한 오브젝트를 가져오는 함수입니다.
    public GameObject GetObject(GameObject prefab)
    {
        GetParent(prefab);
        GameObject gameObject = GetPool(prefab).Pop();
        gameObject.transform.SetParent(null);
        gameObject.SetActive(true);
        return gameObject;
    }
    //사용이 끝난 오브젝트를 오브젝트 풀에 반환하는 함수입니다. 오브젝트의 상태를 초기화하고 풀에 재사용될 준비를 합니다.
    public void ReturnObject(GameObject gameObject)
    {
        gameObject.SetActive(false);
        gameObject.transform.SetParent(GetParent(gameObject).transform);
        GetPool(gameObject).Push(gameObject);
    }
    //풀에 오브젝트를 동적으로 추가하는 함수입니다. 풀의 크기를 동적으로 조절하여 필요에 따라 오브젝트를 생성할 수 있습니다.
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
    //오브젝트 풀을 비우고 모든 오브젝트를 제거하는 함수입니다. 게임이 종료되거나 풀을 재사용하기 전에 호출될 수 있습니다.
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
    //폴 부모가 몇개인지 가져오는 함수
    public int GetPoolParentCount()
    {
        return PoolParent.Count;
    }
    //폴에 넣은 객체가 몇개인지 가져오는 함수
    public int GetPoolCount(GameObject prefab)
    {
        if(Pool.ContainsKey(prefab.name))
            return Pool[prefab.name].Count;
        else 
            return 0;
    }
}
