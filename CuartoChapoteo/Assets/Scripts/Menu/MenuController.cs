using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    [Header("Botones")]
    public Button btnPlay;
    public Button btnUsuarios;
    void Start()
    {
        btnPlay.onClick.AddListener(() => goGame());
        btnUsuarios.onClick.AddListener(() => goUsuarios());
    }

    void goGame()
    {
        SceneManager.LoadScene("Game");
    }
    void goUsuarios()
    {
        SceneManager.LoadScene("Usuarios");
    }

}
