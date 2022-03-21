using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public TMP_InputField saveName;
    public GameObject loadButtonPrefab;

    public void OnSave() {

        SerializationManager.Save(saveName.text, SaveData.current);

     }

    public string[] saveFiles;
    public void GetLoadFiles()
    {
        // Check and create directory if doesn't exist
        if (!Directory.Exists(Application.persistentDataPath + "/saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/saves");
        }

        saveFiles = Directory.GetFiles(Application.persistentDataPath + "/saves/");

    }

    public void showLoadScreen()
    {
        GetLoadFiles(); 

        /*foreach(Transform button in )
        {

        }*/

        for(int i = 0; i < saveFiles.Length; i++)
        {
            GameObject buttonObject = Instantiate(loadButtonPrefab);
            buttonObject.transform.SetParent(transform, false);

            buttonObject.GetComponent<Button>().onClick.AddListener(() =>
            {
                //PlayerMovement.OnLoad(saveFiles[i]);
            });
            buttonObject.GetComponentInChildren<TextMeshProUGUI>().text = saveFiles[i].Replace(Application.persistentDataPath + "/saves/", "");
        }
    }

}
