using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float initialSpeed = 8f; // Velocidad inicial del personaje en el eje Z
    public float maxSpeed = 15f; // Velocidad máxima permitida
    public float speedIncreaseRate = 0.5f; // Tasa de incremento de la velocidad con el tiempo
    public float speedIncreaseInterval = 3f; // Intervalo para aumentar la velocidad
    public float laneOffset = 2f; // Distancia entre carriles
    public float smoothness = 0.1f; // Suavidad del movimiento entre carriles
    public Text scoreText; // Referencia al texto para mostrar la velocidad
    private float timeElapsed = 0f; // Tiempo transcurrido desde el inicio
    private int playerScore = 0; // Puntaje del jugador

    private CharacterController controller;
    private float currentSpeed;
    private int currentSpeedInt; // Variable para la velocidad como entero

    private int currentLane = 1; // 0: izquierda, 1: medio, 2: derecha
    private float[] lanePositions; // Posiciones de los carriles
    private float smoothVelocity = 0; // Velocidad suavizada para el cambio de carril
    public Animator anim;

    void Start()
    {

        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // Inicializar las posiciones de los carriles
        lanePositions = new float[3];
        lanePositions[0] = -laneOffset;
        lanePositions[1] = 0;
        lanePositions[2] = laneOffset;

        currentSpeed = initialSpeed;
    }

    void Update()
    {
        // Aumentar gradualmente la velocidad dentro de un intervalo
        currentSpeed += speedIncreaseRate * Time.deltaTime;
        currentSpeed = Mathf.Clamp(currentSpeed, initialSpeed, maxSpeed); // Limitar la velocidad a maxSpeed

        // Moverse automáticamente en el eje Z
        Vector3 move = Vector3.forward * currentSpeed * Time.deltaTime;
        controller.Move(move);
        anim.SetFloat("VelY", 1);

        // Incrementar el tiempo transcurrido
        timeElapsed += Time.deltaTime;
        // Calcular el puntaje basado en el tiempo (puedes ajustar esta fórmula según desees)
        playerScore = Mathf.FloorToInt(timeElapsed * 10); // Por ejemplo, 10 puntos por segundo

        // Actualizar el texto con el puntaje actual
        if (scoreText != null)
        {
            scoreText.text = "Score: " + playerScore.ToString();
        }

        // Cambio de carril suavizado
        float targetX = lanePositions[currentLane];
        float smoothX = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothVelocity, smoothness);
        transform.position = new Vector3(smoothX, transform.position.y, transform.position.z);

        // Cambio de carril
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
            anim.SetFloat("VelX", 1);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
            anim.SetFloat("VelX", -1);
        }
    }

    void IncreaseSpeed()
    {
        if (currentSpeed < maxSpeed)
        {
            float remainingSpeed = maxSpeed - currentSpeed;
            float increment = Mathf.Log(currentSpeed + 1) * speedIncreaseRate;

            if (increment > remainingSpeed)
            {
                increment = remainingSpeed;
            }

            currentSpeed += increment;
        }
    }

    public int getScore()
    {
        return playerScore;
    }
}
