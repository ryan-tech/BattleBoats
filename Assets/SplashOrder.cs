using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SplashOrder : MonoBehaviour
{
    public static int scenenum;


    void Start()
    {
        if (scenenum == 0) {
            StartCoroutine(ToProductionTeamSplash());
        }

        if (scenenum == 1){
            StartCoroutine(ToTitleScene());
        }

        
    }

    IEnumerator ToProductionTeamSplash () {
        yield return new WaitForSeconds(5);
        scenenum = 1;
        SceneManager.LoadScene(1); 
    }
    
    IEnumerator ToTitleScene () {
        yield return new WaitForSeconds(5);
        scenenum = 2;
        SceneManager.LoadScene(2); 
    }
}
