using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonExample : Singleton<SingletonExample>
{
    public object globalVariable;

    public void somethingUsefulGlobally(){
        Debug.Log("Doing something useful globally");
    }
}

// SingletonExample.instance.somethingUsefulGlobally();