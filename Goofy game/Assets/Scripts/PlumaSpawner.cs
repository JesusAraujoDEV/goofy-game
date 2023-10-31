using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumaSpawner : MonoBehaviour
{
    public GameObject plumaPrefab;
    public int cantidadPlumas = 8; // Cambia la cantidad de plumas según tus necesidades.
    public Vector2 spawnArea = new Vector2(10f, 10f); // Ajusta el área donde quieres que aparezcan las plumas.
    public float spawnInterval = 8f; // Intervalo de tiempo en segundos entre las oleadas de plumas.

    void Start()
    {
        // Invoca la función SpawnPlumas cada spawnInterval segundos, comenzando después de 0 segundos.
        InvokeRepeating("SpawnPlumas", 0f, spawnInterval);
    }

    void SpawnPlumas()
    {
        for (int i = 0; i < cantidadPlumas; i++)
        {
            Vector2 randomPosition = new Vector2(
                transform.position.x + Random.Range(-spawnArea.x, spawnArea.x) + 0.5f,
                transform.position.y + Random.Range(-spawnArea.y, spawnArea.y) + 0.5f
            );

            Instantiate(plumaPrefab, randomPosition, Quaternion.identity);
        }
    }
}
