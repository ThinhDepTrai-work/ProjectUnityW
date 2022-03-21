using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SerializationManager
{
    public static bool Save(string saveName = Constant.SaveName.Playing, object saveData = null)
    {
        // Get Formatter
        BinaryFormatter binaryFormatter = GetBinaryFormatter();

        // Check and create directory if doesn't exist
        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        // Save path
        string path = Application.persistentDataPath + "/saves/" + saveName + ".dat";

        // Create New File
        FileStream file = File.Create(path);

        binaryFormatter.Serialize(file, saveData);

        file.Close();

        return true;
    }

    public static object Load(string saveName = Constant.SaveName.Playing)
    {
        // Save path
        string path = Application.persistentDataPath + "/saves/" + saveName + ".dat";

        if (!File.Exists(path))
        {
            Debug.Log("Save file not found at " + path);
            return null;
        }

        BinaryFormatter formatter = GetBinaryFormatter();

        FileStream file = File.Open(path, FileMode.Open);

        try
        {
            object saveData = formatter.Deserialize(file);
            return saveData;
        }
        catch
        {
            return null;
        }
        finally
        {
            file.Close();
        }

    }

    /// <summary>
    /// <para>Config binary formater with custom Surrogates included</para>
    /// </summary>
    /// <returns></returns>
    private static BinaryFormatter GetBinaryFormatter()
    {
        // Get formatter
        BinaryFormatter formatter = new BinaryFormatter();

        SurrogateSelector selector = new SurrogateSelector();

        // How to read/write Vector 3
        ISerializationSurrogate vector3Surrogate = new Vector3SerializationSurrogate();

        // How to read/write CharacterStat
        ISerializationSurrogate characterStatSurrogate = new CharacterStatSerializationSurrogate();

        // Add to selector of formatter
        selector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3Surrogate);
        //selector.AddSurrogate(typeof(CharacterStat), new StreamingContext(StreamingContextStates.All), characterStatSurrogate);

        // How to read data
        formatter.SurrogateSelector = selector;

        return formatter;
    }
}
