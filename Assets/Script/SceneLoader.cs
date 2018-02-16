using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    private bool iI=false;
    public Image I;

    private void Update()
    {
        if(I)
            I.gameObject.SetActive(iI);
    }

    public void StartGame() {
        SceneManager.LoadScene("Test");
    }

    public void Exit() {
        Application.Quit();
    }

    public void Inst() {
        iI = !iI;
    }

    public void Credits() {
        
    }

}
