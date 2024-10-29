using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    private readonly int _poolCapacity = 5;
    private readonly int _poolMaxSize = 5;

    private ObjectPool<GameObject> _pool;

    public void Initialize(GameObject cube)
    {
        _pool = new ObjectPool<GameObject>(
        createFunc: () => Instantiate(cube),
        actionOnGet: (obj) => ActionOnGet(obj),
        actionOnRelease: (obj) => obj.SetActive(false),
        actionOnDestroy: (obj) => Destroy(obj),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    public void GetCube()
    {
        _pool.Get();
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.transform.position = GetStarterPoint();
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.SetActive(true);
    }

    private Vector3 GetStarterPoint()
    {
        float height = 8f;
        float minValue = -7.0f;
        float maxValue = 7.0f;

        return new Vector3(Random.Range(minValue, maxValue), height, Random.Range(minValue, maxValue));
    }
}