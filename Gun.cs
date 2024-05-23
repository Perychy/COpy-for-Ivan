using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform SpawnTransform;
    [SerializeField] private float ShotPeriod;
    [SerializeField] private AudioSource _shotSound;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private GameObject Flash;
    [SerializeField] private float BulletSpeed = 0.1f;
    [SerializeField] private float _timer = 2f;

    void Start()
    {
        Flash.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > ShotPeriod && Input.GetMouseButton(0))
        {
            _timer = 0;
            GameObject bullet = Instantiate(BulletPrefab, SpawnTransform.position, SpawnTransform.rotation);
            _shotSound.Play();
            bullet.GetComponent<Rigidbody>().velocity = SpawnTransform.forward * BulletSpeed;

            Flash.SetActive(true);
            Invoke(nameof(HideFlash), 0.12f);

        }
    }
    void HideFlash() 
    { Flash.SetActive(false); }
}
