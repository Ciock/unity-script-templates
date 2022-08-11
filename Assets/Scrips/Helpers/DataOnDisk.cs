using System.IO;
using UnityEngine;

public static class DataOnDisk
{
    public static string PathForFilename(string filename) =>
        Path.Combine(Application.persistentDataPath, filename);
}
