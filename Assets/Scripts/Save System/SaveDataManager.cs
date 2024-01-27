using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveDataManager
{
    private static SaveData _data;

    public static SaveData Data
    {
        get
        {
            if (_data == null)
            {
                LoadData();
                if (_data == null)
                {
                    _data = new SaveData();
                }
            }

            return _data;
        }
    }
    
    private const string FileExtension = ".banana";
    private const string FileNameDef = "SaveData";
    private const string SaveFolderName = "Whackamole";

    private static string FileName
    {
        get
        {
            return string.Concat(FileNameDef, FileExtension);
        }
    } 
    
    private static string SavePath => Path.Combine(Application.persistentDataPath, SaveFolderName, FileName);


    public static void LoadData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(SavePath, FileMode.Open);
        /*
         * object data type can't be implicitly converted to an inheriting type
         */
        _data = (SaveData)bf.Deserialize(fs);
    }

    public static void SaveData()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = new FileStream(SavePath, FileMode.OpenOrCreate);
        
        /*
         * object data type inheritors can be implicitly casted to the base type (object) 
         */
        bf.Serialize(fs, _data);
        fs.Flush();
    }
}

public class SaveData
{
    public bool isNewFile = false;
    public int appVersion = 1;
    
    public int highScore;
    public int previousScore;

    public SaveData()
    {
        isNewFile = true;
    }
}