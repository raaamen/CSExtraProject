using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    private static UIManager _instance;
    public static UIManager Instance{get {return _instance;}}
    public TextMeshProUGUI scoreText;
    public Button resetButton;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateUI(int score){
        if (score == 10)
        {
            scoreText.text = "Score for this round: Strike!";
        }
        else if (score == 9){
            scoreText.text = "Score for this round: Spare!";
        }
        else scoreText.text = "Score for this round: "+score;
    }
}
