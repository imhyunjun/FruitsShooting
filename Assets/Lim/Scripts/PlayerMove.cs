using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float playerXAxis;
    float playerYAxis;
    
    [SerializeField]
    private float playerSpeed;

    Vector3 playerMoveVec;

    Rigidbody2D playerRigid;

    private void Start()
    {
        playerSpeed = 10f;
        playerRigid = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        playerXAxis = Input.GetAxisRaw("Horizontal");
        playerYAxis = Input.GetAxisRaw("Vertical");
        playerMoveVec.Set(playerXAxis, playerYAxis, 0f);
    }

    private void FixedUpdate()
    {
        
        //transform.position += playerMoveVec * playerSpeed * Time.fixedDeltaTime;
        playerRigid.MovePosition(transform.position + playerMoveVec * playerSpeed * Time.fixedDeltaTime);

    }
}
