using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    [SerializeField] private int _separationChance = 100;

    private Material _material;
    private Rigidbody _rigidBody;
    private int _minSeparationChance = 0;
    private int _maxSeparationChance = 101;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _material = GetComponent<Renderer>().material;
        _material.color = Random.ColorHSV();       
    }

    public Rigidbody rigidBody => _rigidBody;
    public float explosionRadius => _explosionRadius;
    public float explosionForce => _explosionForce;

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

    public bool TryDivide() => 
        _separationChance >= Random.Range(_minSeparationChance, _maxSeparationChance);
}
