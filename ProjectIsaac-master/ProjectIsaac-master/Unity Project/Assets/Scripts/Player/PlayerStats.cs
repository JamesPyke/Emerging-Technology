using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	[SerializeField]
	float Stamina;

	[SerializeField]
	float WalkSpeed, RunSpeed, JumpHeight;

	[SerializeField]
	float Gravity_Acceleration;

	[SerializeField]
	float MouseSensitivity;

	public float Get_Stamina() {
		return Stamina;
	}

	public void Set_Stamina(float _Value) {
		Stamina = _Value;
	}

	public float Get_Walk_Speed() {
		return WalkSpeed;
	}

	public void Set_Walk_Speed(float _Value) {
		WalkSpeed = _Value;
	}

	public float Get_Run_Speed() {
		return RunSpeed;
	}

	public float Get_Jump_Height() {
		return JumpHeight;
	}

	public void Set_Jump_Height(float _Value) {
		JumpHeight = _Value;
	}

	public void Set_Run_Speed(float _Value) {
		RunSpeed = _Value;
	}

	public float Get_Mouse_Sensitivity() {
		return MouseSensitivity;
	}

	public void Set_Mouse_Sensitivity(float _Value) {
		MouseSensitivity = _Value;
	}

	public float Get_Gravity_Acceleration() {
		return Gravity_Acceleration;
	}

	public void Set_Gravity_Acceleration(float _Value) {
		Gravity_Acceleration = _Value;
	}

}
