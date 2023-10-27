using UnityEngine;
using UnityEngine.SceneManagement;

public class PlumasManager : MonoBehaviour
{
    public GameObject[] players;
    public float gameTime = 60f; // Duración del juego en segundos
    private bool gameIsRunning = false;

    private void Start()
    {
        // Inicia el juego cuando se inicia la escena
        StartGame();
    }

    private void Update()
    {
        if (gameIsRunning)
        {
            gameTime -= Time.deltaTime;
            if (gameTime <= 0)
            {
                EndGame();
            }
        }
    }

    public void StartGame()
    {
        gameTime = 60f;
        gameIsRunning = true;
        // Aquí puedes reiniciar los jugadores y las plumas
    }

    public void EndGame()
    {
        gameIsRunning = false;
        // Aquí puedes determinar quién recolectó la mayor cantidad de plumas y declararlo como ganador
        GameObject winner = DetermineWinner();

        // Reiniciar la escena después de un breve retraso
        Invoke(nameof(RestartGame), 3f);
    }

    private GameObject DetermineWinner()
    {
        GameObject winningPlayer = null;
        int maxFeathers = 0;

        foreach (GameObject player in players)
        {
            int feathersCollected = 0;
            if (feathersCollected > maxFeathers)
            {
                maxFeathers = feathersCollected;
                winningPlayer = player;
            }
        }

        return winningPlayer;
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
