using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractableObject : MonoBehaviour
{

    public string[] interactionType = new string[] { "Visibility Switcher", "Animation", "Material Color", "Switch Scene" };
    public int selectedOptionIndex = 0;

    //object visibility variables
    public GameObject targetObject;

    //object animation variables
    public Animator targetAnimation;
    public string animationStateName;
    bool isPlaying = false;

    //object material variables
    public MeshRenderer targetRenderer;
    public bool randomColor = false;
    public Color targetColor = Color.white;

    //switch scene stuff
    public string targetSceneName;


    public void SwitchObjectOnOff()
    {
        //check if target object is not null
        if (targetObject != null)
        {
            //turn object on OR off
            if (targetObject.gameObject.activeInHierarchy)
                targetObject.gameObject.SetActive(false);
            else
            {
                targetObject.gameObject.SetActive(true);
            }
        }
    }

    public void PlayAnimation()
    {
        if(targetAnimation != null)
        {
            if (!isPlaying)
            {
                targetAnimation.Play(animationStateName);
            }
            isPlaying = !isPlaying;
        }
    }


    public void ChangeMaterialColor()
    {
        if(targetRenderer != null)
        {
            if(randomColor)
                targetRenderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); 
            else
            {
                targetRenderer.material.color = targetColor;
            }

        }
    }

    public void SwitchScene()
    {
        if(!string.IsNullOrEmpty(targetSceneName))
            SceneManager.LoadScene(targetSceneName);
    }
}


#if UNITY_EDITOR

[CustomEditor(typeof(InteractableObject))]
public class InteractableObjectEditor : Editor
{
    override public void OnInspectorGUI()
    {
        var myScript = target as InteractableObject;

        myScript.selectedOptionIndex = EditorGUILayout.Popup(myScript.selectedOptionIndex, myScript.interactionType);


        switch(myScript.selectedOptionIndex)
        {
            case 0:        //if visibility switcher is selected
                myScript.targetObject = (GameObject)EditorGUILayout.ObjectField("Target Object", myScript.targetObject, typeof(GameObject), true);
                break;
            case 1:        //if animation player is selected
                myScript.targetAnimation = (Animator)EditorGUILayout.ObjectField("Target Animator", myScript.targetAnimation, typeof(Animator), true);
                myScript.animationStateName = EditorGUILayout.TextField("Animation Name", myScript.animationStateName);
                break;
            case 2:        //if material color is selected
                myScript.targetRenderer = (MeshRenderer)EditorGUILayout.ObjectField("Target Renderer", myScript.targetRenderer, typeof(MeshRenderer), true);
                myScript.randomColor = GUILayout.Toggle(myScript.randomColor, "Random Color");
                if(!myScript.randomColor)
                    myScript.targetColor = EditorGUILayout.ColorField("Target Color", myScript.targetColor);
                break;
            case 3:
                myScript.targetSceneName = EditorGUILayout.TextField("Scene Name", myScript.targetSceneName);
                break;
            default:
                break;


        }






    }
}

#endif
