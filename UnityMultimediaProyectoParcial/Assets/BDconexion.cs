using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BDconexion : MonoBehaviour
{
    //--------------------------------------------------------------------
    //Envia la peticion por metodo POST para registrar al jugador
    public void crearUsuario(string userName, Action<Response> response)
    {
        StartCoroutine(co_createUser(userName, response));
    }

    public IEnumerator co_createUser(string userName, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", userName);

        WWW w = new WWW("http://localhost:8081/Game/createUser.php", form);

        yield return w;
        Debug.Log(w.text);
        Debug.Log(w);
        //Estructura json con la respuesta 
        Debug.Log("JSON recibido: " + w.text);
        response(JsonUtility.FromJson<Response>(w.text));

    }
    //-------------------------------------------------------
    //Envia la peticion por metodo POST para obtener el listado de 5 mejores jugadores
    public void consultarUsuarios(Action<ResponseUser> response)
    {
        StartCoroutine(co_consultarUsuarios(response));
    }

    public IEnumerator co_consultarUsuarios(Action<ResponseUser> responseObject)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", "prueba");
        WWW w = new WWW("http://localhost:8081/Game/score.php", form);
        yield return w;
        Debug.Log(w.text);
        Debug.Log(w);
        Debug.Log("JSON recibido: " + w.text);
        responseObject(JsonUtility.FromJson<ResponseUser>(w.text));

    }
    //---------------------------------------------------------
    //Actualiza el score del jugador
    public void actualizarScore(string userName, string score, Action<Response> response)
    {
        StartCoroutine(co_actualizarScore(userName, score, response));
    }

    public IEnumerator co_actualizarScore(string userName, string score, Action<Response> response)
    {
        WWWForm form = new WWWForm();
        form.AddField("username", userName);
        form.AddField("userScore", score);

        WWW w = new WWW("http://localhost:8081/Game/modificarUser.php", form);
        yield return w;
        Debug.Log(w.text);
        Debug.Log(w);
        Debug.Log("JSON recibido: " + w.text);
        response(JsonUtility.FromJson<Response>(w.text));
    }
}

[System.Serializable]
public class Response
{
    public bool done = false;
    public string message = "";
}

[System.Serializable]
public class Player
{
    public string idjugador;
    public string usuario;
    public string score;
}

[System.Serializable]
public class ResponseUser
{
    public List<Player> newUsers;
}