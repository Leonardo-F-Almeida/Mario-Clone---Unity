using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public AudioClip blockHitSoundClip;
    public GameObject item;
    private AudioSource _audioSource;
    private bool _used = false;

    void Start()
    {
        _audioSource        = GetComponent<AudioSource>();
        _audioSource.clip   = blockHitSoundClip;
    }

    public void OnHit()
	{
		GetComponent<Animator> ().SetTrigger ("Hit");
        _audioSource.Play();

        if(item != null && !_used)
        {
            _used = true;
            CreateItem();
        }
	}
    void CreateItem()
    {
        Vector3 newPosition = transform.parent.position;
        //Need to change
        newPosition.y = newPosition.y + (float)0.067;
        GameObject newItem = Instantiate(item, newPosition, transform.rotation);
        newItem.transform.parent = transform.parent;
    }
}
