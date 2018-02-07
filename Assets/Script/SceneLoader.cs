using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public void StartGame() {
         SceneManager.LoadScene("Test");
    }

    public void Exit() {
         Application.Quit();
    }

    public void Inst() {
        Debug.Log("Instrucoes aqui");
    }

    public void Credits() {
        Debug.Log("By Chieppe");
    }
}
