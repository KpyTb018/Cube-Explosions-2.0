using System;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Ray _ray;
    private RaycastHit _hit;

    public event Action<Cube> CubeSelected;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
                if (_hit.collider.TryGetComponent(out Cube cube))
                    CubeSelected(cube);
        }
    }
}
