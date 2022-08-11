using System.Collections;
using System.Collections.Generic;
using LitJson;
using UnityEngine;

public class TransformSaver : SaveableBehaviour
{
    private const string LOCAL_POSTION_KEY = "localPosition";

    private const string LOCAL_ROTATION_KEY = "localRotation";

    private const string LOCAL_SCALE_KEY = "localScale";

    private JsonData SerializeValue(object obj) =>
        JsonMapper.ToObject(JsonUtility.ToJson(obj));

    // Only works with built-in types that Unity knows how to serialize
    private T DeserializeValue<T>(JsonData data) =>
        JsonUtility.FromJson<T>(data.ToJson());

    public override JsonData SavedData
    {
        get
        {
            var result = new JsonData();

            result[LOCAL_POSTION_KEY] = SerializeValue(transform.localPosition);
            result[LOCAL_ROTATION_KEY] =
                SerializeValue(transform.localRotation);
            result[LOCAL_SCALE_KEY] = SerializeValue(transform.localScale);

            return result;
        }
    }

    public override void LoadFromData(JsonData data)
    {
        if (data.ContainsKey(LOCAL_POSTION_KEY))
        {
            transform.localPosition =
                DeserializeValue<Vector3>(data[LOCAL_POSTION_KEY]);
        }
        if (data.ContainsKey(LOCAL_ROTATION_KEY))
        {
            transform.localRotation =
                DeserializeValue<Quaternion>(data[LOCAL_ROTATION_KEY]);
        }
        if (data.ContainsKey(LOCAL_SCALE_KEY))
        {
            transform.localScale =
                DeserializeValue<Vector3>(data[LOCAL_SCALE_KEY]);
        }
    }
}
