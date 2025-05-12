using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOver : MonoBehaviour
{
    private MenuInicial m_menuInicial = null;
    public void Jugar()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }


}
