using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    public GameObject arrow;
    public GameObject cakePrefab;
    public float moveSpeed = 10f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xVal = Input.GetAxis("Horizontal");
        Vector3 movementVector = new Vector3(xVal, 0, 0);

        if (xVal != 0) {            
            arrow.transform.position += movementVector * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            var cake = Instantiate(cakePrefab);
            cake.transform.position = arrow.transform.position + new Vector3(0, -1, 0);
        }
    }
}
