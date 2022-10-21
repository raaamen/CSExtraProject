using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.gameObject.name);
        if (!GameManager.Instance.pinsHit.Contains(this) && other.gameObject.name!="Pin")
            {
                GameManager.Instance.pinsHit.Add(this);
                UIManager.Instance.UpdateUI(GameManager.Instance.pinsHit.Count);
            }
    }

}
