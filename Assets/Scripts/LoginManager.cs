using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Text.RegularExpressions;

public class LoginManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI usernameText_UI;
    [SerializeField] TextMeshProUGUI therapistMailText_UI;
    [SerializeField] TextMeshProUGUI errorText_UI;


    private void Start()
    {
        if (PlayerPrefs.HasKey("username"))
        {
            transform.localScale = Vector3.zero;
        }
        else
        {
            transform.localScale= Vector3.one;
        }
    }

    public void Login()
    {
        string username = usernameText_UI.text;
        string therapistMail = therapistMailText_UI.text;

        if (string.IsNullOrEmpty(username))
        {
            errorText_UI.text = "Username cannot be empty.";
            Debug.LogError("Username cannot be empty.");
            return;
        }

        if (!IsValidEmail(therapistMail))
        {
            errorText_UI.text = "Invalid email format.";
            Debug.LogError("Invalid email format.");
            return;
        }
        errorText_UI.text = "";
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetString("therapistMail", therapistMail);
        transform.localScale = Vector3.zero;
    }

    private bool IsValidEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }
}
