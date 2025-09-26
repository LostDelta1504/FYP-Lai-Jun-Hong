using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionScript : MonoBehaviour
{
    public void pressed()
    {
        SceneManager.LoadScene("GameModeScene");
    }
}
