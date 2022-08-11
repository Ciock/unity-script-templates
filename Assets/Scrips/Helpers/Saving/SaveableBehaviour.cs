using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public abstract class
SaveableBehaviour
: MonoBehaviour, ISaveable, ISerializationCallbackReceiver
{
    public abstract JsonData SavedData { get; }

    public abstract void LoadFromData(JsonData data);

    public string SaveID
    {
        get
        {
            return _saveID;
        }
        set
        {
            _saveID = value;
        }
    }

    // We mark it as serialized so that Unity editor saves it with the rest of the scene,
    // and as HideInInspector because there is no need to change it manually.
    [HideInInspector]
    [SerializeField]
    private string _saveID;



    public void OnBeforeSerialize(){
        if(_saveID == null){
            _saveID = System.Guid.NewGuid().ToString();
        }
    }

    public void OnAfterDeserialize(){}

}
