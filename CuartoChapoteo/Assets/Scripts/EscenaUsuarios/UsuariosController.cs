using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;
using UnityEngine.SceneManagement;
public class UsuariosController : MonoBehaviour
{

    [Header("Botones")]
    public InputField nombre;
    public Button btnUsuarios;
    public Button btnLista;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseDB.init();
        btnUsuarios.onClick.AddListener(() => Registrar());
        btnLista.onClick.AddListener(() => goLista());
    }
    void goLista() 
    {

        SceneManager.LoadScene("ListaUsuario");
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    void Registrar()
    {

        string name = nombre.text;
        int id = Random.Range(0, 15);
        User user = new User(name, id.ToString());
        string json = JsonUtility.ToJson(user);
        FirebaseDB.reference.Child("users").Child(user.name).SetRawJsonValueAsync(json);
        FirebaseDB.reference.Child("users").ChildAdded += HandleChildAdded;
        FirebaseDB.reference.Child("users").ChildChanged += HandleChildChanged;
        FirebaseDB.reference.Child("users").ChildRemoved += HandleChildRemoved;

        print(json);


        
    }



    void HandleChildChanged(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("changed: " + args.Snapshot);
    }


    void HandleChildRemoved(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("removed " + args.Snapshot);
    }

    void HandleChildAdded(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("added: " + args.Snapshot);
    }
}
