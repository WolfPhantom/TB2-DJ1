
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
public class FirebaseDB 
{

    public static string url = "https://dj1-sem9.firebaseio.com/";
    public static DatabaseReference reference;

    public static void init() 
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(url);
        reference = FirebaseDatabase.DefaultInstance.RootReference;
    
    }
}
