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
    Vector2 playerViewPos;          //플레이어 viewport좌표
    Vector2 playerWorldPos;         //플레이어 world 좌표

    Animator playerAnimator;        //플레이어 애니메이션

    private void Start()
    { 
        playerSpeed = 10f;
        transform.position = Vector2.zero;
        playerAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        playerXAxis = Input.GetAxisRaw("Horizontal");
        playerYAxis = Input.GetAxisRaw("Vertical");
        playerMoveVec.Set(playerXAxis, playerYAxis, 0f);
       if (playerXAxis != 0)
       {
            transform.localScale = new Vector3(-1f * playerXAxis, 1, 0);
       }
        playerAnimator.SetFloat("PlayerMoveX", playerXAxis);
       //else
       //    transform.localScale = new Vector3(1, 0, 0);
    }

    private void FixedUpdate()
    {
        transform.Translate(playerMoveVec.normalized * playerSpeed * Time.fixedDeltaTime);
        RestricPlayerMovement();
    }

    //플레이어 움직임 제한
    void RestricPlayerMovement()
    {
        playerViewPos = Camera.main.WorldToViewportPoint(transform.position);                           //플레이어월드 좌표 뷰포트 좌표로 변환
        playerViewPos.x = Mathf.Clamp01(playerViewPos.x);                                               //플레이어 뷰포트 x좌표를 0에서 1사이로 제한
        playerViewPos.y = Mathf.Clamp01(playerViewPos.y);                                               //플레이어 뷰포트 y좌표를 0에서 1사이로 제한
        playerWorldPos = Camera.main.ViewportToWorldPoint(playerViewPos);                               //뷰포트 좌표 월드좌표로 변환
        transform.position = playerWorldPos;
    }
}
