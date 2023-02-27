using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 offset;

    private void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
