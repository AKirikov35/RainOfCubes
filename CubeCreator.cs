using UnityEngine;

public class CubeCreator
{
    private const string Cube = nameof(Cube);

    private readonly Mesh _mesh;
    private readonly Material _material;
    private Quaternion _rotation;
    private Vector3 _position;

    public CubeCreator(Mesh mesh, Material material)
    {
        _mesh = mesh;
        _material = material;
        _rotation = Quaternion.identity;
        _position = Vector3.zero;
    }

    public GameObject Create()
    {
        GameObject cube = new GameObject(Cube);

        MeshFilter filter = cube.AddComponent<MeshFilter>();
        filter.mesh = _mesh;

        MeshRenderer renderer = cube.AddComponent<MeshRenderer>();
        renderer.material = _material;

        BoxCollider boxCollider = cube.AddComponent<BoxCollider>();
        boxCollider.size = filter.mesh.bounds.size;

        cube.transform.SetPositionAndRotation(_position, _rotation);

        cube.AddComponent<Rigidbody>();

        cube.tag = ObjectTag.Cube.ToString();

        return cube;
    }
}