using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMove : MonoBehaviour
{
	public Transform target;
	public Vector3 direction;
	public float velocity;
	public float accelaration;


	// Update is called once per frame
	void Update()
	{
		MoveToTarget();
	}

	public void MoveToTarget()
	{
		target = GameObject.Find("Player").transform;

		// 플레이어의 위치와 이 객체의 위치를 빼고 단위 벡터
		direction = (target.position - transform.position).normalized;

		// 가속도
		accelaration = 0.005f;

		// 초가 아닌 한 프레임으로 가속도 계산하여 속도 증가
		// 이거 속도가 점점 빨라지는건 좋은데 가속도에 제한을 걸고 싶어요... if문으로 하는건가요..............
		velocity = (velocity + accelaration * Time.deltaTime);


		// Player와 객체 간의 거리 계산
		float distance = Vector3.Distance(target.position, transform.position);

		// 30 안에있으면 따라감
		if (distance <= 30.0f)
		{
			this.transform.position = new Vector3(transform.position.x + (direction.x * velocity),
												   transform.position.y + (direction.y * velocity),
													 transform.position.z);
		}
		// 30 밖으로 가면 초기화
		else
		{
			velocity = 0.0f;
		}
	}
}
