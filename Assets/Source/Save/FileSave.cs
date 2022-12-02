using System.IO;
using UnityEngine;

public class FileSave<TAbstract> : ISave<TAbstract>
{
    private readonly string FileName;

    public FileSave()
    {
        FileName = Application.persistentDataPath + "/Save" + typeof(TAbstract).Name + ".save";
    }

    public TConcrete Load<TConcrete>()
    {
        if (File.Exists(FileName) == false)
            return default(TConcrete);

        string jsonString = File.ReadAllText(FileName);
        return JsonUtility.FromJson<TConcrete>(jsonString);
    }

    public void Save(TAbstract data)
    {
        string jsonString = JsonUtility.ToJson(data, true);
        File.WriteAllText(FileName, jsonString);
    }
}