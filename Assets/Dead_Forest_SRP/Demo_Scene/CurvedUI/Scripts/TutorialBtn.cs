using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class TutorialBtn : MonoBehaviour
{
    public void ChangeDemo()
    {
        SceneManager.LoadScene(1);
    }

    public void ChangeVictory()
    {
        SceneManager.LoadScene(4);
    }

    public void ChangeStart()
    {
        SceneManager.LoadScene(0);
    }
}
