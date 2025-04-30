using UnityEngine;

[RequireComponent(typeof(Renderer))]
[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    [SerializeField] private int _separationChance = 100;

    private Renderer _renderer;
    private Rigidbody _rigidBody;
    private int _minSeparationChance = 0;
    private int _maxSeparationChance = 101;

    public Rigidbody RigidBody => _rigidBody;
    public float explosionRadius => _explosionRadius;
    public float explosionForce => _explosionForce;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();  
    }

    private void OnEnable()
    {
        SetRandomColor();
    }

    public void UpdateParameters()
    {
        int reduceChance = 2;
        int reduceScale = 2;
        int increaseForse = 2;
        int increaseRadius = 2;

        _separationChance /= reduceChance;
        transform.localScale /= reduceScale;
        _explosionForce *= increaseForse;
        _explosionRadius += increaseRadius;
    } 

    public bool IsDivide() => 
        _separationChance >= Random.Range(_minSeparationChance, _maxSeparationChance);

    private void SetRandomColor() => _renderer.material.color = Random.ColorHSV();
}
