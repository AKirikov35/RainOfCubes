using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class FallingCube : MonoBehaviour
{
    private Renderer _renderer;
    private Color _defaultColor;
    private bool _hasCollided = false;

    private CubePool _cubePool;

    public void Initialize(CubePool cubePool)
    {
        _cubePool = cubePool;
        _renderer.material.color = _defaultColor;
        _hasCollided = false;
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _defaultColor = _renderer.material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasCollided == false && collision.gameObject.TryGetComponent<Platform>(out _))
        {
            _renderer.material.color = new Color(Random.value, Random.value, Random.value);
            _hasCollided = true;
            StartCoroutine(ReturnToPool(GetRandomDelay()));
        }
    }

    private IEnumerator ReturnToPool(float delay)
    {
        yield return new WaitForSeconds(delay);
        _cubePool.ReturnToPool(this);
    }

    private float GetRandomDelay()
    {
        const float minDelay = 2.0f;
        const float maxDelay = 5.0f;

        return Random.Range(minDelay, maxDelay);
    }
}
