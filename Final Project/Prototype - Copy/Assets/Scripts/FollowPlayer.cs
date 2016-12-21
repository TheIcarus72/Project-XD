using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	[SerializeField]private GameObject player;
	[SerializeField]private GameObject camLookTarget;
	[SerializeField]private float offsetX = 0.0f;
	[SerializeField]private float offsetY = 0.0f;
	[SerializeField]private float offsetZ = 0.0f;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x + offsetX, player.transform.position.y + offsetY, player.transform.position.z + offsetZ);

		transform.LookAt(camLookTarget.transform.position);

		// Euler angles are easier to deal with. You could use Quaternions here also
		// C# requires you to set the entire rotation variable. You can't set the individual x and z (UnityScript can), so you make a temp Vec3 and set it back
		Vector3 eulerAngles = transform.rotation.eulerAngles;
		eulerAngles.x = 0;
		eulerAngles.z = 0;

		// Set the altered rotation back
		transform.rotation = Quaternion.Euler(eulerAngles);
		//transform.rotation = Quaternion.Slerp(transform.rotation, eulerAngles, Time.deltaTime * dampening);

	}
}
