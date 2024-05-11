using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Petal : MonoBehaviour
{
    Animator animator;
    private float minSeconds = 4f;
    private float maxSeconds = 20f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ShakeRoutine());
    }

    public void OnClick()
    {
        animator.SetTrigger("blink");
    }

    private void Shake()
    {
        animator.SetTrigger("shake");
    }


    private IEnumerator ShakeRoutine()
    {
        var seconds = Random.Range(minSeconds, maxSeconds);
        yield return new WaitForSeconds(seconds);

        Shake();
        StartCoroutine(ShakeRoutine());
    }
}
