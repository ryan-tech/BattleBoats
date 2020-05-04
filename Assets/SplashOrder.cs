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
        if (scenenum == 2){
            StartCoroutine(ToInstructionScene());
        }


    }

    IEnumerator ToProductionTeamSplash () {
        yield return new WaitForSeconds(4);
        scenenum = 1;
        SceneManager.LoadScene(1);
    }

    IEnumerator ToTitleScene () {
        yield return new WaitForSeconds(2);
        scenenum = 2;
        SceneManager.LoadScene(2);
    }

    IEnumerator ToInstructionScene () {
        yield return new WaitForSeconds(2);
        scenenum = 3;
        SceneManager.LoadScene(3);
    }
}
