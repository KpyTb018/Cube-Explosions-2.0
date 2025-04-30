using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MouseInput))]
[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Exploder))]

public class Hit : MonoBehaviour
{
    private MouseInput _mouseInput;
    private Spawner _spawner;
    private Exploder _exploder;

    private void Awake()
    {
        _spawner = GetComponent<Spawner>();
        _mouseInput = GetComponent<MouseInput>();
        _exploder = GetComponent<Exploder>();
    }

    private void OnEnable()
    {
        _mouseInput.CubeSelected += TryDivide;
    }

    private void OnDisable()
    {
        _mouseInput.CubeSelected -= TryDivide;
    }

    private void TryDivide(Cube cube)
    {
        if (cube.IsDivide())
            _spawner.CreateCubes(cube);
        else
            _exploder.ExplodeTarget(cube.explosionForce, cube.transform.position, cube.explosionRadius);

        Destroy(cube.gameObject);
    }
}
