using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private GameObject m_home = null;
    [SerializeField] private GameObject m_score = null;
    [SerializeField] private InputField m_userInput = null;
    [SerializeField] private Text m_texto = null;
    private BDconexion m_BDconexion = null;
    private GameObject objetoConexion = null;

    public VideoPlayer videoPlayer; // Asigna el VideoPlayer desde el Inspector

    // Permite el inicio del juego
    public void Jugar()
    {
        // Valida si el usuario ingresó un nombre de usuario
        if (m_userInput.text == "")
        {
            m_texto.text = "Ingrese nombre del Usuario.";
        }
        else
        {
            // Registra al usuario
            this.submitRegister();

            // Espera a que "Cinematica" se cargue antes de cargar "SampleScene"
            StartCoroutine(CargarEscenasSecuencialmente());
        }
    }

    private IEnumerator CargarEscenasSecuencialmente()
    {
        // Carga la escena "Video"
        SceneManager.LoadScene("Video");

        yield return null;


        // Carga la escena "SampleScene"
        SceneManager.LoadScene("SampleScene");
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
    //Activa la vista con los score de los 5 jugadores
    public void showScore()
    {
        m_score.SetActive(true);
        m_home.SetActive(false);
    }
    //Activa la vista de inicio del juego
    public void showHome()
    {
        m_score.SetActive(false);
        m_home.SetActive(true);

    }

    public void Awake()
    {
        m_BDconexion = GameObject.FindObjectOfType<BDconexion>();
    }

    //Proceso de registro del usuario 
    public void submitRegister()
    {
        m_texto.text = "Procesando";
        objetoConexion = new GameObject("ObjetoConexion");
        m_BDconexion = objetoConexion.AddComponent<BDconexion>();

        if (m_BDconexion != null)
        {
            m_BDconexion.crearUsuario(m_userInput.text, delegate (Response response)
            {   //Captura del mensaje
                m_texto.text = response.message;
            }
           );

        }

    }
    //Proceso de listado de los mejores jugadores
    public void scoreUsuarios()
    {
        Debug.Log("Procesando scoreUsuarios");
        objetoConexion = new GameObject("ObjetoConexion");
        m_BDconexion = objetoConexion.AddComponent<BDconexion>();

        if (m_BDconexion != null)
        {
            Debug.Log("Procesando scoreUsuarios... if");
            m_BDconexion.consultarUsuarios(delegate (ResponseUser response)
            {
                // Bucle for que se ejecuta 5 veces
                for (int i = 0; i < 5; i++)
                {
                    //Actualiza el score con los mejores 5 jugadores
                    m_txtIDArray[i].text = response.newUsers[i].idjugador + "";
                    m_txtNameArray[i].text = response.newUsers[i].usuario + "";
                    m_txtScoreArray[i].text = response.newUsers[i].score + "";
                }
            }
           );

        }

        showScore();
    }
    //Proceso actualizacion del score
    public void actualizarScore()
    {
        m_texto.text = "Procesando...";
        objetoConexion = new GameObject("ObjetoConexion");
        m_BDconexion = objetoConexion.AddComponent<BDconexion>();

        if (m_BDconexion != null)
        {   //Se debe asignar los txt correctos....
            m_BDconexion.actualizarScore(m_txtnombre.text, m_txtscore.text, delegate (Response response)
            {   //Captura del mensaje
                m_texto.text = response.message;
            }
           );

        }

    }

    [SerializeField] private Text[] m_txtNameArray = new Text[5];
    [SerializeField] private Text[] m_txtScoreArray = new Text[5];
    [SerializeField] private Text[] m_txtIDArray = new Text[5];
    [SerializeField] private Text m_txtnombre = null;
    [SerializeField] private Text m_txtscore = null;


}
