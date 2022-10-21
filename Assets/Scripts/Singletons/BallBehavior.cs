using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallBehavior : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSrc;
    [SerializeField]
    private AudioClip rolling;
    [SerializeField]
    private AudioClip pinhit;
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Camera Switch")
        {
            GameManager.Instance.mainCamera.transform.position = GameManager.Instance.cameraSwitchPos.position;
            GameManager.Instance.mainCamera.transform.rotation = GameManager.Instance.cameraSwitchPos.rotation;
        } 
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Pin")
        {
            audioSrc.Play();
        }
    }

}
