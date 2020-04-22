using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public void changemenuscene (string scenename) {
        SceneManager.LoadScene (scenename);
    }
}
