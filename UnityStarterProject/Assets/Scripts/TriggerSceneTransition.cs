using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerSceneTransition : MonoBehaviour
{

    public string sceneToLoad;
    private GameObject tempTargetObject;

    private void OnTriggerEnter(Collider other)
    {
        tempTargetObject = other.gameObject;

        if (!tempTargetObject.CompareTag("Ground"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
