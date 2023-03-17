using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMotion : MonoBehaviour
{
    private const float _speed = 1;
    private const float _distance = 1f;
    private const float _rotateSpeed = 1;
    private Vector3 startPosition;
    private float bias { get; set; }
    void Start() {
      startPosition = transform.position;
      bias = Random.Range(0f, 2f);
    }
    void Update() {
      float pingpong = Mathf.PingPong((Time.time + bias) * _speed, _distance);
      transform.position = startPosition + Vector3.up * pingpong;
      transform.Rotate(Vector3.up, _rotateSpeed);
    }
}
