using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class GameManager : MonoBehaviour
{
    /*
    todo:
    Give the user the ability to position the ball with the keyboard. 
    A simple left and right movement with the keyboard, 
    make sure to restrict the movement to stay within the lane.

    The ball should move realistically, 
    hit the pins and make them fall or be stuck in one of the gutters and do nothing.

    Create a UI showing the score. 

    Create a button to reset the ball.
    */
    private static GameManager _instance;
    public static GameManager Instance{get {return _instance;}}
    public GameObject pinsPrefab;
    public GameObject currentPinsObj;
    public GameObject ballPrefab;
    public GameObject currentBallObj;
    public GameObject arrowPrefab;
    public Transform pinsResetTransform;
    public Transform ballResetTransform;
    public Transform cameraSwitchPos;
    public Transform cameraDefaultPos;
    public float EndRoundTimer;
    public float ArrowMoveSensitivity;
    public float ballShootForce;
    public GameObject mainCamera;
    public List<PinBehavior> pinsHit;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } 
        else {
            _instance = this;
        }
    }
    void Start()
    {
        StartCoroutine("EndCurrentRound");
        
    }
    void OnShootBall(){
        Debug.Log("Ball shot");
        UIManager.Instance.resetButton.interactable = true;
        currentBallObj.GetComponent<Rigidbody>().AddForce(arrowPrefab.transform.forward * -ballShootForce,ForceMode.Impulse);
        arrowPrefab.SetActive(false);
    }
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnShootBall();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            arrowPrefab.transform.eulerAngles +=  new Vector3(0, -1*ArrowMoveSensitivity*Time.deltaTime, 0);
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            arrowPrefab.transform.eulerAngles +=  new Vector3(0,1*ArrowMoveSensitivity*Time.deltaTime, 0);
        }
    }
    public IEnumerator EndCurrentRound(){
        pinsHit.Clear();
        arrowPrefab.transform.SetPositionAndRotation(arrowPrefab.transform.position, Quaternion.identity);
        UIManager.Instance.UpdateUI(0);
        //yield return new WaitForSeconds(EndRoundTimer);
        mainCamera.transform.position = cameraDefaultPos.position;
        mainCamera.transform.rotation = cameraDefaultPos.rotation;
        Destroy(currentBallObj);
        Destroy(currentPinsObj);
        currentBallObj = ResetPrefab(ballPrefab, ballResetTransform);
        currentPinsObj = ResetPrefab(pinsPrefab, pinsResetTransform);
        arrowPrefab.SetActive(true);
        yield return null;
    }    
    public void StartCoro(string coroname){
        StartCoroutine(coroname);
    }
    public GameObject ResetPrefab(GameObject prefab, Transform prefabPos){
        return Instantiate(prefab, prefabPos.position, Quaternion.identity);
        //prefab.transform.position = prefabPos.position;
    }

}
