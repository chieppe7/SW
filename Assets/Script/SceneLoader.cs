using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

    private bool iI=false;
    public Image I;
    private bool iU=false;
    public Image U;

    public void StartGame() {
        Debug.Log("Start");
        SceneManager.LoadScene("Test");
    }

    public void Exit() {
        Application.Quit();
    }

    public void Inst() {
        iI = !iI;
        I.gameObject.SetActive(iI);
    }

    public void Upgadres() {
        iU = !iU;
        U.gameObject.SetActive(iU);
    }

    public void Menu() {
        SceneManager.LoadScene("Menu");
    }

}
