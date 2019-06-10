using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UziController : MonoBehaviour
{
    private AudioSource uziAS;
    public float delayTime = 0.1f;
    private float counter = 0;
    public AudioClip uzishootAC;
    public ParticleSystem muzzleflash;

    // Use this for initialization
    void Start()
    {
        uziAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0) && counter > delayTime)
        {
            uziAS.PlayOneShot(uzishootAC);
            StartCoroutine(WeaponEffects());
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
