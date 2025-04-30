using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Exploder))]

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    private Exploder _exploder;

    private void Awake()
    {
        _exploder = GetComponent<Exploder>();
    }

    public void CreateCubes(Cube cube)
    {
        int minObjects = 2;
        int maxObjects = 6;
        int numberNewObjects = Random.Range(minObjects, maxObjects + 1);

        List<Rigidbody> explorableObjects = new();

        cube.UpdateParameters();

        for (int i = 0; i < numberNewObjects; i++)
        {
            Cube newCube = Instantiate(cube, cube.transform.position, Quaternion.identity);
            explorableObjects.Add(newCube.RigidBody);
        }

        _exploder.Explode(_explosionForce, cube.transform.position, _explosionRadius, explorableObjects);
    }
}
