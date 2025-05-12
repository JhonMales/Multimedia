using UnityEngine;

public class FollowPlayerZ : MonoBehaviour
{
    public float smoothSpeed = 0.5f; // Suavidad con la que la cámara sigue al jugador en el eje Z
    public float offsetZ = -15f; // Distancia inicial en el eje Z entre la cámara y el objeto jugador

    void LateUpdate()
    {
        // Encuentra el objeto del jugador por etiqueta
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Obtiene la posición actual de la cámara
            Vector3 currentPosition = transform.position;

            // Calcula la nueva posición solo en el eje Z para seguir al jugador
            float desiredZ = player.transform.position.z + offsetZ;

            // Interpola suavemente la posición actual de la cámara hacia la posición deseada solo en el eje Z
            float smoothedZ = Mathf.Lerp(currentPosition.z, desiredZ, smoothSpeed * Time.deltaTime);

            // Actualiza la posición de la cámara solo en el eje Z
            transform.position = new Vector3(currentPosition.x, currentPosition.y, smoothedZ);
        }
    }
}
