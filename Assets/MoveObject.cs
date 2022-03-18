using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float _speed;
    public float _maxDistance;

    private Vector3 spawnPosition = Vector3.zero;

    private void Start()
    {
        spawnPosition = transform.position;
    }

    private void Update()
    {
        Move();
        if (CurrentDistanse() >= _maxDistance) Destroy(gameObject);

    }

    private void Move()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);
    }

    private float CurrentDistanse()
    {
        float distance = Vector3.Distance(spawnPosition, transform.position);
        return distance;
    }
}
