using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoStartSceneTransitionScript : MonoBehaviour
{
    public void pressed()
    {
        SceneManager.LoadScene("StartingScreen");
    }
}
