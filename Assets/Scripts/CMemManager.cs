using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameData;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class CMemManager : _MonoBehaviour
{
    public Text _infoText;

    public InputField _idInputField;
    public InputField _pwInputField;

    private void Start()
    {
        //test
        _idInputField.text = "Iser1";
        _pwInputField.text = "1234";
    }


    private IEnumerator PostNetCoroutine()
    {
        string url = "http://localhost/12/account.php";

        WWWForm form = new WWWForm();
        form.AddField("id", _idInputField.text.Trim());
        form.AddField("pw", _pwInputField.text.Trim());

        WWW www = new WWW(url, form);

        yield return www;

        if (www.error == null)
        {
            Debug.LogWarning(this.GetMethodName() + "[RESPONSE][DATA]\n" + www.text);
        }
        else
        {
            Debug.LogWarning("[ERROR][MSG]\n" + www.error);
        }

        Dictionary<string, object> responseData = MiniJSON.jsonDecode(www.text.Trim()) as Dictionary<string, object>;
        Debug.Log("[RESPONSE][DATA]\n" + responseData);

        string login_result = responseData["login_result"] as string;
        Debug.Log(this.GetMethodName() + "[RESPONSE][login_result]" + login_result);

        _infoText.text = login_result;

        if (login_result.Equals("SUCCESS"))
        {
            Dictionary<string, object> userData = responseData["login_info"] as Dictionary<string, object>;

            PlayerPrefs.SetString("ID", userData["id"].ToString());

            int best_click_count = int.Parse(userData["best_click_count"].ToString());
            PlayerPrefs.SetInt("BEST_CLICK_COUNT", best_click_count);

            int ctype = int.Parse(userData["ship_type"].ToString());
            PlayerPrefs.SetInt("CTYPE", ctype);

            SceneManager.LoadScene("Game");
        }
    }

    private IEnumerator GetNetCoroutine()
    {
        string url = "http://localhost/12/account.php";

        url += "?id=" + _idInputField.text;
        url += "&pw=" + _pwInputField.text;

        WWW www = new WWW(url);

        yield return www;

        if (www.error == null)
        {
            Debug.LogWarning(this.GetMethodName() + "[RESPONSE][DATA]\n" + www.text);
        }
        else
        {
            Debug.LogWarning("[ERROR][MSG]\n" + www.error);
        }

        Dictionary<string, object> responseData = MiniJSON.jsonDecode(www.text.Trim()) as Dictionary<string, object>;
        Debug.Log("[RESPONSE][DATA]\n" + responseData);

        string login_result = responseData["login_result"] as string;
        Debug.Log(this.GetMethodName() + "[RESPONSE][login_result]" + login_result);

        _infoText.text = login_result;

        if (login_result.Equals("SUCCESS"))
        {
            Dictionary<string, object> userData = responseData["login_info"] as Dictionary<string, object>;

            PlayerPrefs.SetString("ID", userData["id"].ToString());

            int best_click_count = int.Parse(userData["best_click_count"].ToString());
            PlayerPrefs.SetInt("BEST_CLICK_COUNT", best_click_count);

            int ctype = int.Parse(userData["ship_type"].ToString());
            PlayerPrefs.SetInt("CTYPE", ctype);

            SceneManager.LoadScene("Game");
        }
    }

    public void OnLoginButtonClick()
    {
        //Debug.Log(this.GetMethodName());
        //StartCoroutine(GetNetCoroutine());
        //StartCoroutine(PostNetCoroutine());
        StartCoroutine(LoginCoroutine());
    }

    private IEnumerator LoginCoroutine()
    {
        string url = "http://localhost/12/.account/select.php";

        WWWForm form = new WWWForm();
        form.AddField("id", _idInputField.text.Trim());
        //form.AddField("pw", _pwInputField.text.Trim());
        //form.AddField("ctype", UnityEngine.Random.Range(0, 4));

        WWW www = new WWW(url, form);

        yield return www;

        if (www.error == null)
        {
            Debug.LogWarning(this.GetMethodName() + "[RESPONSE][DATA]\n" + www.text);
        }
        else
        {
            Debug.LogWarning("[ERROR][MSG]\n" + www.error);
        }

        Dictionary<string, object> responseData = MiniJSON.jsonDecode(www.text.Trim()) as Dictionary<string, object>;
        Debug.Log("[RESPONSE][DATA]\n" + responseData);

        string result_code = responseData["result_code"] as string;
        Debug.Log(this.GetMethodName() + "[RESPONSE][result_code]" + responseData["result_code"]);
        Debug.Log(this.GetMethodName() + "[RESPONSE][error_code]" + responseData["error_code"]);
        Debug.Log(this.GetMethodName() + "[RESPONSE][error_messge]" + responseData["error_messge"]);

        _infoText.text = result_code;

        if (result_code.Equals("SELECT_SUCCESS"))
        {
            Dictionary<string, object> userData = responseData["result_data"] as Dictionary<string, object>;

            PlayerPrefs.SetString("ID", userData["id"].ToString());

            int best_click_count = int.Parse(userData["best_click_count"].ToString());
            PlayerPrefs.SetInt("BEST_CLICK_COUNT", best_click_count);

            int total_click_count = int.Parse(userData["total_click_count"].ToString());
            PlayerPrefs.SetInt("TOTAL_CLICK_COUNT", total_click_count);

            int ctype = int.Parse(userData["ctype"].ToString());
            PlayerPrefs.SetInt("CTYPE", ctype);

            SceneManager.LoadScene("Game");
        }
    }

    public void OnJoinButtonClick()
    {
        //Debug.Log(this.GetMethodName());
        StartCoroutine(JoinNetCoroutine());
    }

    private IEnumerator JoinNetCoroutine()
    {
        string url = "http://localhost/12/.account/insert.php";

        WWWForm form = new WWWForm();
        form.AddField("id", _idInputField.text.Trim());
        form.AddField("pw", _pwInputField.text.Trim());
        form.AddField("ctype", UnityEngine.Random.Range(0, 4));

        WWW www = new WWW(url, form);

        yield return www;

        if (www.error == null)
        {
            Debug.LogWarning(this.GetMethodName() + "[RESPONSE][DATA]\n" + www.text);
        }
        else
        {
            Debug.LogWarning("[ERROR][MSG]\n" + www.error);
        }

        Dictionary<string, object> responseData = MiniJSON.jsonDecode(www.text.Trim()) as Dictionary<string, object>;
        Debug.Log("[RESPONSE][DATA]\n" + responseData);

        string result_code = responseData["result_code"] as string;
        Debug.Log(this.GetMethodName() + "[RESPONSE][result_code]" + responseData["result_code"]);
        Debug.Log(this.GetMethodName() + "[RESPONSE][error_code]" + responseData["error_code"]);
        Debug.Log(this.GetMethodName() + "[RESPONSE][error_messge]" + responseData["error_messge"]);

        _infoText.text = result_code;

        if (result_code.Equals("INSERT_SUCCESS"))
        {
        }
    }
}
