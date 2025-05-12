using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControladorVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        // Suscribe el método VideoTerminado al evento de finalización del video
        videoPlayer.loopPointReached += VideoTerminado;
    }

    private void VideoTerminado(VideoPlayer vp)
    {
        // Desuscribe el método para evitar llamadas duplicadas si el video se reproduce nuevamente
        videoPlayer.loopPointReached -= VideoTerminado;

        // Cargar la siguiente escena
        SceneManager.LoadScene("SampleScene");
    }
}