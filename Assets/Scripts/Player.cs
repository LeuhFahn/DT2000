using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public GameObject t_head;
	public float m_fWalkSpeed = 5.0f;
	public float m_fVelocityRotation = 0.2f;

	float m_fAngleY = 0.0f;
	CharacterController cc;
	// Use this for initialization
	void Start ()
	{
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Move();
		MoveHead();
		cc.SimpleMove(Physics.gravity);
	}

	void Move()
	{
		Vector3 v3_move = Vector3.zero;

		v3_move = Input.GetAxis("Vertical")*transform.forward + Input.GetAxis("Horizontal")*transform.right ;
		v3_move *= m_fWalkSpeed;

		cc.Move(v3_move * Time.deltaTime);
	}

	void MoveHead()
	{
		float fAngleMax = -4.0f;
		float fAngleMin = 4.0f;
		float fAngleBeforeY = m_fAngleY;
		
		m_fAngleY += -Input.GetAxis("Mouse Y");
		
		if(m_fAngleY < fAngleMax)
			m_fAngleY = fAngleMax;
		else if(m_fAngleY > fAngleMin)
			m_fAngleY = fAngleMin;
		
		transform.RotateAround(new Vector3(0,1,0),m_fVelocityRotation * Input.GetAxis("Mouse X"));
		t_head.transform.RotateAroundLocal(new Vector3(1,0,0), m_fVelocityRotation * (m_fAngleY - fAngleBeforeY));
	}
}
