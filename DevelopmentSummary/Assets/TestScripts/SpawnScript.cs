using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnScript : MonoBehaviour
{
    public ObjectPool pool;

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;

    float delay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Update()
    {
        Debug.Log($"폴부모 크기 : {pool.GetPoolParentCount()}");
        Debug.Log($"{prefab1.name} : {pool.GetPoolCount(prefab1)}, {pool.GetParent(prefab1).transform.childCount}");
        Debug.Log($"{prefab2.name} : {pool.GetPoolCount(prefab2)}, {pool.GetParent(prefab2).transform.childCount}");
        Debug.Log($"{prefab3.name} : {pool.GetPoolCount(prefab4)}, {pool.GetParent(prefab3).transform.childCount}");
        Debug.Log($"{prefab4.name} : {pool.GetPoolCount(prefab3)}, {pool.GetParent(prefab4).transform.childCount}");
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        int index = Random.Range(1, 5);
        GameObject go;
        switch (index)
        {
            case 1:
                go = pool.GetObject(prefab1);
                go.transform.position = gameObject.transform.position;
                StartCoroutine(ReturnToPoll(go, delay));
                break;
            case 2:
                go = pool.GetObject(prefab2);
                go.transform.position = gameObject.transform.position;
                StartCoroutine(ReturnToPoll(go, delay));
                break;
            case 3:
                go = pool.GetObject(prefab3);
                go.transform.position = gameObject.transform.position;
                StartCoroutine(ReturnToPoll(go, delay));
                break;
            case 4:
                go = pool.GetObject(prefab4);
                go.transform.position = gameObject.transform.position;
                StartCoroutine(ReturnToPoll(go, delay));
                break;
            default:break;
        }
    }
    /*public void ReturnToPoll(GameObject gameObject)
    {
        pool.ReturnObject(gameObject);
    }*/
    IEnumerator ReturnToPoll(GameObject gameObject, float delay)
    {
        yield return new WaitForSeconds(delay);
        pool.ReturnObject(gameObject);
    }
}
