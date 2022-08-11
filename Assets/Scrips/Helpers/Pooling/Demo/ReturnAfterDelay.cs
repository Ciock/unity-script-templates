using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAfterDelay : MonoBehaviour, IObjectPoolNotifier
{
    void IObjectPoolNotifier.OnCreatedOrDequeuedFromPool(bool created)
    {
        StartCoroutine(DoReturnAfterDelay());
    }

    void IObjectPoolNotifier.OnEnqueuedToPool()
    {
    }

    IEnumerator DoReturnAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);

        gameObject.ReturnToPool();
    }
}
