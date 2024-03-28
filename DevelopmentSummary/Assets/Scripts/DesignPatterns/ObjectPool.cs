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

    //������Ʈ Ǯ�� �ʱ�ȭ�ϴ� �Լ���, Ǯ�� �̸� ������Ʈ���� �����ϰ� �غ��մϴ�.
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
        //�� �θ� ������
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
    //������Ʈ Ǯ���� ��� ������ ������Ʈ�� �������� �Լ��Դϴ�.
    public GameObject GetObject(GameObject prefab)
    {
        if (!CheakPoolable(prefab))
            return null;
        GetParent(prefab);
        return GetPool(prefab).Pop();
    }
    //����� ���� ������Ʈ�� ������Ʈ Ǯ�� ��ȯ�ϴ� �Լ��Դϴ�. ������Ʈ�� ���¸� �ʱ�ȭ�ϰ� Ǯ�� ����� �غ� �մϴ�.
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
    //Ǯ�� ������Ʈ�� �������� �߰��ϴ� �Լ��Դϴ�. Ǯ�� ũ�⸦ �������� �����Ͽ� �ʿ信 ���� ������Ʈ�� ������ �� �ֽ��ϴ�.
    public void ExpandPool(GameObject prefab, int count = CreationCount)
    {

    }
    //������Ʈ Ǯ�� ���� ��� ������Ʈ�� �����ϴ� �Լ��Դϴ�. ������ ����ǰų� Ǯ�� �����ϱ� ���� ȣ��� �� �ֽ��ϴ�.
    public void Clear(string name)
    {

    }
    //������Ʈ�� Ȱ��/��Ȱ�� ���¸� �����ϴ� �Լ��Դϴ�. ������Ʈ�� Ǯ�� ��ȯ�� �� ��Ȱ��ȭ�Ͽ� ���� �� �ֽ��ϴ�.
    public void SetActive(string name)
    {

    }
    //������Ʈ Ǯ�� ������ ����ȭ�ϴ� �Լ���, �ʿ信 ���� ������Ʈ�� ������ ������ �����մϴ�.
    public void Optimize(string name)
    {

    }
    //������Ʈ�� Ǯ���� ������ �� ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�. ������Ʈ�� Ȱ��ȭ�� ���� �߰����� �ʱ�ȭ �۾��� ������ �� �ֽ��ϴ�.
    public void OnObjectSpawn(string name)
    {

    }
    //������Ʈ�� Ǯ�� ��ȯ�� �� ȣ��Ǵ� �̺�Ʈ �Լ��Դϴ�. ������Ʈ�� ��Ȱ��ȭ�� ���� �߰����� ���� �۾��� ������ �� �ֽ��ϴ�.
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
