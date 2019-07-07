using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManger : MonoBehaviour
{
    [Header("Loggin")]
    [SerializeField] private InputField m_loginCorreoInput = null;
    [SerializeField] private InputField m_loginContraseña = null;
    [SerializeField] private Text m_logintext = null;


    [Header("Register")]
    [SerializeField] private InputField m_correoInput = null;
    [SerializeField] private InputField m_paraleloInput = null;
    [SerializeField] private InputField m_contraseña = null;
    [SerializeField] private InputField m_reingresaContraseña = null;
    [SerializeField] private Text m_text = null;

    [Header("Score")]
    [SerializeField] private Text m_puntaje = null;
    [SerializeField] private Text m_mail = null;

    [Header("User Interfaces")]
    [SerializeField] private GameObject m_registerUI = null;
    [SerializeField] private GameObject m_logginUI = null;
    [SerializeField] private GameObject m_mainScreenUI = null;
    [SerializeField] private GameObject m_scoreUI = null;

    private NetworkManager m_networkManajer = null;


    void Start()
    {
        StartCoroutine(GetScores());
    }

    public void Awake()
    {
        m_networkManajer = GameObject.FindObjectOfType<NetworkManager>();
    }


    public void submitLoggin()
    {

        if (m_loginCorreoInput.text == "" || m_loginContraseña.text == "")
        {
            m_logintext.text = "Porfavor llena todos los campos.";
            return;
        }

        m_logintext.text = "Procesando.....";

        m_networkManajer.logUsuario(m_loginCorreoInput.text, m_loginContraseña.text, delegate (Response response)
        {
            m_logintext.text = response.mensaje;

            if (response.done == true)
            {
                m_logginUI.SetActive(false);
                m_mainScreenUI.SetActive(true);
            }
        });
    }

    public void submitRegister() {

        if (m_correoInput.text == "" || m_paraleloInput.text == "" || m_contraseña.text == "" || m_reingresaContraseña.text == "")
        {
            m_text.text = "Porfavor llena todos los campos.";
            return;
        }

        if (m_contraseña.text == m_reingresaContraseña.text)
        {
            m_text.text = "Procesando.....";

            m_networkManajer.crearUsuario(m_correoInput.text, m_paraleloInput.text, m_contraseña.text, delegate (Response response)
            {
                m_text.text = response.mensaje;
            });
        }
        else
        {
            m_text.text = "Las contraseñas no son iguales. Porfavor verificar.";
        }
    }


    IEnumerator GetScores()
    {
        m_puntaje.text = "Cargando puntajes";
        WWW hs_get = new WWW("http://localhost:8000/getPuntajes.php");
        WWW hs1_get = new WWW("http://localhost:8001/getPuntajes1.php");
        yield return hs_get;
        yield return hs1_get;


        if (hs_get.error != null)
        {
            print("Hubo un error obteniendo los puntajes: " + hs_get.error);
        }
        else
        {
            m_mail.text = hs_get.text;
            m_puntaje.text = hs1_get.text;
        }
    }

    public void showLoggin()
    {
        m_registerUI.SetActive(false);
        m_logginUI.SetActive(true);
    }

    public void showRegister()
    {
        m_registerUI.SetActive(true);
        m_logginUI.SetActive(false);

    }

    public void showScore()
    {
        m_mainScreenUI.SetActive(false);
        m_scoreUI.SetActive(true);
    }

    public void showMainScreen()
    {
        m_scoreUI.SetActive(false);
        m_mainScreenUI.SetActive(true);
    }
}
