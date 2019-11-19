using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pendulum : MonoBehaviour
{
    int direction = 1;
    float rotationSpeed = 0.8F;
    public AudioClip clip;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == 1) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(90, Vector3.forward), rotationSpeed * Time.deltaTime);
        } else if (direction == -1) {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(-90, Vector3.forward), rotationSpeed * Time.deltaTime);
        }
        
        if (transform.rotation.z > 0.65) {
            SoundManager.instance.PlayClip(clip, this.transform.GetChild(1).transform.position);
            direction = -1;
        }
        if (transform.rotation.z < -0.65) {
            SoundManager.instance.PlayClip(clip, this.transform.GetChild(1).transform.position);
            direction = 1;
        }
    }

    void fixedUpdate() {
    }
}
