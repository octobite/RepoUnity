using UnityEngine;
using System.Collections;

public class SmoothLookAt : MonoBehaviour {

    public Transform target;
    public float damping = 6.0F;
    public bool smooth = true;
    public bool initialized = false;

	// Use this for initialization
	void Start () {
		// Make the rigid body not change rotation
   	    if (rigidbody){
		    rigidbody.freezeRotation = true;
        }
	}


    public void initializeCamera() {
        initialized = true;
    }

    public void stopCamera() {
        initialized = false;
    }


	// Update is called once per frame
	void Update () {
	
	}

    void LateUpdate(){
        if(initialized){
            if(target){
                Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
            }else{
                transform.LookAt(target);
                    
            }

        }
    }
}



