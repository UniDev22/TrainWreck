using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string gameString;
    public string menuString;
    public Animator animator;
    public void StartGame(){
        StartCoroutine(LoadScene(gameString));
    }
    public void BackToMenu(){
        StartCoroutine(LoadScene(menuString));
    }
    public void Quit(){
        Application.Quit();
    }
    IEnumerator LoadScene(string sceneName){
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        while(!asyncLoad.isDone){
            yield return null;
        }
    }

    

}
