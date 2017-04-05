using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public PlayerStats PlayerStats;

	[SerializeField]
	public float Speed, Gravity;

	Vector3 NextMovement;

	void Update() {

		CharacterController Character = GetComponent<CharacterController>();

		if(!Can_Run()) {
			Speed = PlayerStats.Get_Walk_Speed();
		}

		if(Input.GetKey(KeyCode.LeftShift) && Can_Run()) {
			Speed = PlayerStats.Get_Run_Speed();
			if(PlayerStats.Get_Stamina() > 0) {
				PlayerStats.Set_Stamina(PlayerStats.Get_Stamina() - 50 * Time.deltaTime);
			}
		}

		if(!Input.GetKey(KeyCode.LeftShift)) {
			Speed = PlayerStats.Get_Walk_Speed();
			if(PlayerStats.Get_Stamina() < 100) {
				PlayerStats.Set_Stamina(PlayerStats.Get_Stamina() + 50 * Time.deltaTime);
			}
		}

		NextMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		Character.Move(transform.TransformDirection(NextMovement) * (Character.isGrounded ? Speed : Speed * 0.75f) * Time.deltaTime);

        Apply_Gravity(Character);

        if(Input.GetKeyDown(KeyCode.Space) && Character.isGrounded) {
        	Gravity -= PlayerStats.Get_Jump_Height();
        }

	}

	void Apply_Gravity(CharacterController _Character) {
		Gravity += PlayerStats.Get_Gravity_Acceleration ();
		_Character.Move(transform.TransformDirection(Vector3.down) * Gravity * Time.deltaTime);
		if(_Character.isGrounded) {
			Gravity = 0f;
		}
	}

	bool Can_Run() {
		return PlayerStats.Get_Stamina() > 0;
	}

}
