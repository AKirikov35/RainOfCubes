using System;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public event Action<GameObject> WasCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(ObjectTag.Cube.ToString()))
            WasCollision?.Invoke(collision.gameObject);
    }
}