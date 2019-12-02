using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    public float interval;
    public Transform firePoint;
    private GameObject target;
    public AudioClip[] audioClips;
    public GameObject bulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 1F, interval);
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
    }

    void Fire()
    {
        var targetScript = target.GetComponent<simpleMovement>();
        if (!targetScript.disabled && !targetScript.levelTransition)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, transform.rotation);
            SoundManager.instance.PlayRandomClip(audioClips, this.transform.position);
            Destroy(bulletInstance, 4f);
        }
    }
}
