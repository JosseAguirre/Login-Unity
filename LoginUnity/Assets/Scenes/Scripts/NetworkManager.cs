using System;
using System.Collections;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    public void crearUsuario(string correo, string paralelo, string contraseña, Action<Response> response)
    {
        StartCoroutine(CO_crearUsuario(correo, paralelo, contraseña, response));
    }

    public IEnumerator CO_crearUsuario(string correo, string paralelo, string contraseña, Action<Response> response) {
        WWWForm from = new WWWForm();
        from.AddField("correo", correo);
        from.AddField("paralelo", paralelo);
        from.AddField("contraseña", contraseña);

        WWW w = new WWW("http://localhost:8000", from);

        yield return w;
        Debug.Log(w.text);
        response(JsonUtility.FromJson<Response>(w.text));
    }

    public void logUsuario(string correo, string contraseña, Action<Response> response)
    {
        StartCoroutine(CO_logUsuario(correo, contraseña, response));
    }

    public IEnumerator CO_logUsuario(string correo, string contraseña, Action<Response> response)
    {
        WWWForm from = new WWWForm();
        from.AddField("correo", correo);
        from.AddField("contraseña", contraseña);

        WWW w = new WWW("http://localhost:8000/logUser.php", from);

        yield return w;
        Debug.Log(w.text);
        response(JsonUtility.FromJson<Response>(w.text));
    }

}


[Serializable]
public class Response {
    public bool done = false;
    public string mensaje = "";
}
