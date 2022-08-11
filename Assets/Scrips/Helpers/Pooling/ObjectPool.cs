using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPoolNotifier
{
    void OnEnqueuedToPool();

    void OnCreatedOrDequeuedFromPool(bool created);
}

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    private Queue<GameObject> inactiveObjects = new Queue<GameObject>();

    public GameObject GetObject()
    {
        if (inactiveObjects.Count > 0)
        {
            var dequeuedObject = inactiveObjects.Dequeue();

            dequeuedObject.transform.parent = null;
            dequeuedObject.SetActive(true);

            var notifiers = dequeuedObject.GetComponents<IObjectPoolNotifier>();

            foreach (var notifier in notifiers)
            {
                notifier.OnCreatedOrDequeuedFromPool(false);
            }

            return dequeuedObject;
        }
        else
        {
            var newObject = Instantiate(prefab);

            var poolTag = newObject.AddComponent<PooledObject>();

            poolTag.owner = this;
            poolTag.hideFlags = HideFlags.HideInInspector;

            var notifiers = newObject.GetComponents<IObjectPoolNotifier>();

            foreach (var notifier in notifiers)
            {
                notifier.OnCreatedOrDequeuedFromPool(true);
            }

            return newObject;
        }
    }

    public void ReturnObject(GameObject gameObject)
    {
        var notifiers = gameObject.GetComponents<IObjectPoolNotifier>();

        foreach (var notifier in notifiers)
        {
            notifier.OnEnqueuedToPool();
        }

        gameObject.SetActive(false);
        gameObject.transform.parent = this.transform;

        inactiveObjects.Enqueue(gameObject);
    }
}
