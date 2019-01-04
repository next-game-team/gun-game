using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{

    private readonly List<GameObject> _objects = new List<GameObject>();
    
    [SerializeField] private int _objectsCount;
    [SerializeField] private GameObject _objectPrefab;

    public void Init()
    {
        for(var i = 0; i < _objectsCount; i++)
        {
            _objects.Add(InstantiateNewObject());
        }
    }
    
    public GameObject GetObject()
    {
        GameObject objectFromPool;
        if (_objects.Count == 0)
        {
             objectFromPool = InstantiateNewObject();
        }
        else
        {
            objectFromPool = _objects[_objects.Count - 1];
            _objects.Remove(objectFromPool);
        }
        
        return objectFromPool;
    }

    public GameObject GetObject(Vector2 position)
    {
        var objectFromPool = GetObject();
        objectFromPool.transform.position = position;
        return objectFromPool;
    }

    public void ReturnObject(GameObject returnedObject)
    {
        returnedObject.SetActive(false);
        returnedObject.transform.parent = transform;
        _objects.Add(returnedObject);
    }

    private GameObject InstantiateNewObject()
    {
        var newObject = Instantiate(_objectPrefab, gameObject.transform);
        newObject.SetActive(false);
        newObject.transform.parent = gameObject.transform;
        return newObject;
    }
}
