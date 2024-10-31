using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    private readonly int _poolCapacity = 5;
    private readonly int _poolMaxSize = 10;

    private ObjectPool<FallingCube> _pool;

    public void Initialize(FallingCube cube)
    {
        _pool = new ObjectPool<FallingCube>(
            createFunc: () => Instantiate(cube),
            actionOnGet: (cube) => GetAction(cube),
            actionOnRelease: (cube) => ReleaseAction(cube),
            actionOnDestroy: (cube) => Destroy(cube.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    public void GetCube(Vector3 position)
    {
        FallingCube cube = _pool.Get();
        cube.transform.position = position;
        cube.Initialize(this);
    }

    public void ReturnToPool(FallingCube cube)
    {
        _pool.Release(cube);
    }

    private void GetAction(FallingCube cube)
    {
        cube.gameObject.SetActive(true);
    }

    private void ReleaseAction(FallingCube cube)
    {
        cube.gameObject.SetActive(false);
        cube.Initialize(this);
    }
}
