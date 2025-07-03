using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour
{
    public float speed = 1f;
    public float distance = 2f;

    private void Update()
    {
        // move up and down with math

        float newY = Mathf.Sin(Time.time * speed) * distance;
        Vector3 newPosition = new Vector3(transform.position.x, newY-2, transform.position.z);
        transform.position = newPosition;

    }
}
