using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionControls : MonoBehaviour
{
    public void pressed()
    {
        SceneManager.LoadScene("ControlsInstructionScene");
    }
}
