using System.Collections;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private FallingCube _prefab;

    private CubePool _cubePool;
    private readonly float _repeatRate = 1.0f;
    private bool _isSpawning = true;

    private void Awake()
    {
        _cubePool = GetComponent<CubePool>();
        _cubePool.Initialize(_prefab);
    }

    private void Start()
    {
        StartCoroutine(SpawnCubes());
    }

    private IEnumerator SpawnCubes()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_repeatRate);

        while (_isSpawning)
        {
            Vector3 spawnPosition = GetStarterPoint();
            _cubePool.GetCube(spawnPosition);
            yield return waitForSeconds;
        }
    }

    private Vector3 GetStarterPoint()
    {
        float height = 8f;
        float minValue = -7.0f;
        float maxValue = 7.0f;

        return new Vector3(Random.Range(minValue, maxValue), height, Random.Range(minValue, maxValue));
    }
}
