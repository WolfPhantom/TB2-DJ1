using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using UnityEngine.UI;

public class ListaUsuariosController : MonoBehaviour
{
    public Button btnCargar;

    public GameObject usuario;


    private List<string> nombres;
    void Start()
    {
        btnCargar.onClick.AddListener(() => Cargar());
        nombres = new List<string>();
        
        Select();

        
    
    }
    void Cargar() 
    {
        for (int i = 0; i < nombres.Count; i++) 
        {
            
                usuario.name = nombres[i];
                Instantiate(usuario);
            


        }
        
    }
   
    void Select()
    {
        
        FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(task => {
            if (task.IsFaulted)
            {
                // Handle the error...
            }
            else if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;

                foreach (var usuarios in snapshot.Children) // usuarios
                {
                    
                    Debug.LogFormat("Key = {0}", usuarios.Key);  // "Key = usuario"
                    nombres.Add(usuarios.Key.ToString());

                } 
            }
        });

  
    }
 

}
