using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    public string input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Empezar()
    {
        SceneManager.LoadScene(1);
    }

    public void LeerInput(string s)
    {
        input = s;
        Debug.Log(input);
        dontDestroyOnLoad.instance.inputNombreActual = input;
    }
}
