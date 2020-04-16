using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physics_and_Input : MonoBehaviour
{
    public Vector3 position;
    public Vector3 velocity;
    public bool isSelected = false;
    public GameObject selectionCircle;

    void Start()
    {
        velocity = Vector3.zero;
    }


    void Update()
    {
        position = position + velocity * Time.deltaTime;
        transform.localPosition = position;

        selectionCircle.SetActive(isSelected);
    }

    
}
