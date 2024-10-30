using UnityEngine;

[RequireComponent (typeof(Renderer))]
[RequireComponent (typeof(BoxCollider))]
[RequireComponent (typeof(Rigidbody))]
public class FallingCube : MonoBehaviour
{
    private Renderer _renderer;
    private bool _hasCollided = false;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_hasCollided == false && collision.gameObject.TryGetComponent<Platform>(out var platform))
        {
            _renderer.material.color = new Color(Random.value, Random.value, Random.value);
            _hasCollided = true;
            Destroy(gameObject, GetRandomDelay());
        }
    }

    private float GetRandomDelay()
    {
        const float minDelay = 2.0f;
        const float maxDelay = 5.0f;

        return Random.Range(minDelay, maxDelay);
    }
}