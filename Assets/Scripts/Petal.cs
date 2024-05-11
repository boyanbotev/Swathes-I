using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Petal : MonoBehaviour
{
    public void OnClick()
    {
        Debug.Log("on click");
        transform.localScale *= 1.5f;
    }
}
