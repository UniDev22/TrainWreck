using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [HideInInspector]
    public static int coinCount = 0;
    public PlayerC playerC;
    public Image fadePlane;
    public Vector3 offset;
    public Vector3 coinOffset;
    int scoreMultiplier = 1;
    int mission = 50;
    int score = 0;

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI goText;
    public Button retryButton;
    public Button menuButton;
    public Transform go;
    public Transform goCT;
    public Transform goST;
    
    void Start()
    {
        fadePlane.color = Color.clear;
        goText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
    }

    void Update()
    {

        if(playerC.isDead == false){
            score = score += 1 * scoreMultiplier;
            coinText.text = coinCount.ToString();
            scoreText.text = score.ToString("000000000");
            if(coinCount == mission){
                scoreMultiplier++;
                mission = mission + 50;
            }
        }
        else{
            StartCoroutine(GameOver(Color.clear, new Color(255f, 255f, 255f, 1f), 1));
        }
        if(Input.GetKeyDown(KeyCode.C)){
            coinCount += 50;
        }
        if(Input.GetKeyDown(KeyCode.P)){
            score += 1000;
        }
    }
    	IEnumerator GameOver(Color from, Color to, float time) {
		float speed = 1 / time;
		float percent = 0;

		while (percent < 1) {
			percent += Time.deltaTime * speed;
			fadePlane.color = Color.Lerp(from,to,percent);
			yield return null;
		}
        if(percent >= 1){
            goText.gameObject.SetActive(true);
            go.position = goCT.position + coinOffset;
            scoreText.gameObject.transform.position = goST.position + offset;
            retryButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);  
            int coinTotal = 0;
            float lerp = 0f, duration = 3.5f;
            lerp += Time.deltaTime / duration;
            coinCount = (int)Mathf.Lerp(coinCount, coinTotal, lerp);
            coinText.text = coinCount.ToString();  
        }

	}
    
}
