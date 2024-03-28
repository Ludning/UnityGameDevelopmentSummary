using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPoolable
{
    public void InitForPool();
}
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
            DontDestroyOnLoad(poolOrigin);
        }
        return poolOrigin;
    }
    public GameObject GetParent(GameObject prefab)
    {
        string name = prefab.name;
        //폴 부모가 없으면
        if (_poolParent.ContainsKey(name))
        {
            GameObject parent = new GameObject($"{name}_Pool");
            parent.transform.SetParent(GetOrigin().transform);
            _poolParent.Add(name, parent);
        }
        return _poolParent[name];
    }
    public Stack<GameObject> GetPool(GameObject prefab)
    {
        if (_pool.ContainsKey(name) || _pool[name].Count == 0)
            ExpandPool(prefab);
        return _pool[name];
    }
    //오브젝트 풀에서 사용 가능한 오브젝트를 가져오는 함수입니다.
    public GameObject GetObject(GameObject prefab)
    {
        if (!CheakPoolable(prefab))
            return null;
        GetParent(prefab);
        return GetPool(prefab).Pop();
    }
    //사용이 끝난 오브젝트를 오브젝트 풀에 반환하는 함수입니다. 오브젝트의 상태를 초기화하고 풀에 재사용될 준비를 합니다.
    public void ReturnObject(GameObject gameObject)
    {
        if (!CheakPoolable(gameObject))
        {
            Destroy(gameObject);
            return;
        }
        IPoolable poolAble = gameObject.GetComponent<IPoolable>();
        poolAble.InitForPool();
        GetPool(gameObject);
    }
    //풀에 오브젝트를 동적으로 추가하는 함수입니다. 풀의 크기를 동적으로 조절하여 필요에 따라 오브젝트를 생성할 수 있습니다.
    public void ExpandPool(GameObject prefab, int count = CreationCount)
    {

    }
    //오브젝트 풀을 비우고 모든 오브젝트를 제거하는 함수입니다. 게임이 종료되거나 풀을 재사용하기 전에 호출될 수 있습니다.
    public void Clear(string name)
    {

    }
    //오브젝트의 활성/비활성 상태를 설정하는 함수입니다. 오브젝트를 풀에 반환할 때 비활성화하여 숨길 수 있습니다.
    public void SetActive(string name)
    {

    }
    //오브젝트 풀의 성능을 최적화하는 함수로, 필요에 따라 오브젝트의 생성과 삭제를 관리합니다.
    public void Optimize(string name)
    {

    }
    //오브젝트가 풀에서 꺼내질 때 호출되는 이벤트 함수입니다. 오브젝트가 활성화될 때의 추가적인 초기화 작업을 수행할 수 있습니다.
    public void OnObjectSpawn(string name)
    {

    }
    //오브젝트가 풀에 반환될 때 호출되는 이벤트 함수입니다. 오브젝트가 비활성화될 때의 추가적인 정리 작업을 수행할 수 있습니다.
    public void OnObjectDespawn(string name)
    {

    }
    public bool CheakPoolable(GameObject prefab)
    {
        IPoolable poolAble = prefab.GetComponent<IPoolable>();
        if (poolAble != null)
            return true;
        else
            return false;
    }


}
