using UnityEngine;
using System.Collections;

public class CameraFollow1 : MonoBehaviour {

	//Variables visible in the inspector
    public float distance;
    public float height;
	public float smoothness;
	public float smoothness1;

	public Transform camTarget;
	public GameObject Enemy;

    private void Start()
    {
		Enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    Vector3 velocity;
 
    void LateUpdate(){
		//Check if the camera has a target to follow
        if(!camTarget)
            return;
		
		Vector3 pos = Vector3.zero;
		pos.x = camTarget.position.x;
		pos.y = camTarget.position.y + height;
		pos.z = camTarget.position.z - distance;


		Vector3 pos1 = Vector3.zero;
		pos1.x = Enemy.transform.rotation.x;
		pos1.y = Enemy.transform.rotation.y;
		pos1.z = Enemy.transform.rotation.z;

		transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothness);

		transform.position = Vector3.SmoothDamp(transform.position, pos1, ref velocity, smoothness1);
		//transform.LookAt(camTarget.position);
	}
}
