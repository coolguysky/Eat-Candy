using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove = true;
    [SerializeField] float maxPos;
    [SerializeField] float moveSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        if (canMove)
        {
            Move();
        }
    }

    private void Move()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(inputX * moveSpeed * Time.deltaTime, 0, 0);
        float xPos = Mathf.Clamp(transform.position.x, -maxPos, maxPos);
        transform.position = new Vector3(xPos,transform.position.y, transform.position.z);
    }
}
