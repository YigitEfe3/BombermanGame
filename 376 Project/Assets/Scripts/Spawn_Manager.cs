using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _powerupPrefab;
    private bool _stopSpawning = false;
    private bool _powerupOnScene = false;
    [SerializeField]
    private Vector3[] _spawnPoints;

    void Start()
    {
        StartCoroutine(SpawnPowerupRoutine());
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpawning == false)
        {
            int randomPosition = Random.Range(0, 9);

            if(_powerupOnScene == false)
            {
                Instantiate(_powerupPrefab, _spawnPoints[randomPosition], Quaternion.identity);
                _powerupOnScene = true;
            }
            yield return new WaitForSeconds(10f);
        }
    }
    public void powerupObtained()
    {
        _powerupOnScene = false;
    }
    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
}
