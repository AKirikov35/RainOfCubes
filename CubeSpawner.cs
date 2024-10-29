using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Mesh _cubeMesh;
    [SerializeField] private Material _cubeMaterial;
    [SerializeField] private Platform[] _platforms;

    private CubeCreator _cubeCreator;

    private CubePool _cubePool;
    private readonly float _repeatRate = 1.0f;

    private void Awake()
    {
        _cubeCreator = new CubeCreator(_cubeMesh, _cubeMaterial);
        _cubePool = gameObject.AddComponent<CubePool>();
        _cubePool.Initialize(_cubeCreator.Create());
    }

    private void Start()
    {
        InvokeRepeating(nameof(InvokeGetCube), 0.0f, _repeatRate);
    }

    private void OnEnable()
    {
        foreach (var platform in _platforms)
            if (platform != null)
                platform.WasCollision += Collision;
    }

    private void OnDisable()
    {
        foreach (var platform in _platforms)
            if (platform != null)
                platform.WasCollision -= Collision;
    }

    private void InvokeGetCube()
    {
        _cubePool.GetCube();
    }

    private void Collision(GameObject cube)
    {
        if (cube == null) 
            return;

        float delay = 5f;

        GetColor(cube);
        Destroy(cube, delay);
    }

    private void GetColor(GameObject cube)
    {
        if (cube.TryGetComponent<Renderer>(out var renderer))
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}