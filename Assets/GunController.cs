using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public GameObject bullet;
    public float delayTime = 5;

    private float counter = 0;

    AudioSource gunAS;
    public AudioClip shootAC;

    public ParticleSystem muzzleflash;

    Animator anim;

	// Use this for initialization
	void Start () {
        gunAS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        muzzleflash.Stop();
	}
	
	// Update is called once per frame
	void Update () {


            if (Input.GetKey(KeyCode.Mouse0) && counter > delayTime)
            {
                Instantiate(bullet, transform.position, transform.rotation);
                StartCoroutine(WeaponEffects());
                gunAS.PlayOneShot(shootAC);
                counter = 0;
            }
        counter += Time.deltaTime;
    }
     

    IEnumerator WeaponEffects()
    {
        muzzleflash.Play();
        yield return new WaitForEndOfFrame();
        muzzleflash.Stop();
        
    }

}
