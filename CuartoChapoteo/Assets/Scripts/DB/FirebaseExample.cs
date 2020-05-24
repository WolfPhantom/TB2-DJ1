using Firebase.Database;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FirebaseDB.init();
        User user = new User("Alex",SystemInfo.deviceUniqueIdentifier);
        string json = JsonUtility.ToJson(user);
        FirebaseDB.reference.Child("users").Child(user.id).SetRawJsonValueAsync(json);
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
        print("changed: "+args.Snapshot);
    }


    void HandleChildRemoved(object sender, ChildChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.Log(args.DatabaseError.Message);
            return;
        }
        print("removed "+args.Snapshot);
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
