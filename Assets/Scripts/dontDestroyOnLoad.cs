using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using UnityEngine;

public class dontDestroyOnLoad : MonoBehaviour
{
    public static dontDestroyOnLoad instance;

    public string inputNombreActual;
    public string inputNombre;
    public int maximoPuntaje = 0; 

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        CargarPuntajeMayor();
    }

    [Serializable]
    class SaveData
    {
        public int mayorPuntaje;
        public string nombreAlto;
    }

    public void SavePuntajeMayor()
    {

        SaveData data = new SaveData();
        data.mayorPuntaje = maximoPuntaje;
        data.nombreAlto = inputNombre;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void CargarPuntajeMayor()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            maximoPuntaje = data.mayorPuntaje;
            inputNombre = data.nombreAlto;
        }
    }
}

