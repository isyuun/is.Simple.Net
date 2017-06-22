using GameData;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CGameManager : _MonoBehaviour
{
    public Text _infoText;

    public Text _idText;
    public Text _countText;
    public Text _bestText;
    public Image _shipTypeImage;

    public Text _timeText;

    public Sprite[] _ufoShipPrefabs;

    internal void ShowClickCount(int clickCount)
    {
        if (_time <= 0)
        {
            return;
        }

        _countText.text = clickCount.ToString();

        int bCount = int.Parse(_bestText.text);
        int count = int.Parse(_countText.text);

        if (count > bCount)
        {
            _bestText.text = _countText.text;
            PlayerPrefs.SetInt("BEST_CLICK_COUNT", int.Parse(_bestText.text));
        }
    }

    private void Start()
    {
        _idText.text = PlayerPrefs.GetString("ID").ToString();

        _bestText.text = PlayerPrefs.GetInt("BEST_CLICK_COUNT").ToString();

        //_countText.text = PlayerPrefs.GetInt("TOTAL_CLICK_COUNT").ToString();

        int ctype = PlayerPrefs.GetInt("CTYPE");

        _shipTypeImage.sprite = _ufoShipPrefabs[ctype];

        StartCoroutine(GameTimerNetCoroutine());
    }

    public int _time;

    private IEnumerator GameTimerNetCoroutine()
    {
        while (_time > 0)
        {
            yield return new WaitForSeconds(1.0f);
            _time--;
            _timeText.text = _time.ToString(/*"mm:ss"*/);
        }

        int total_click_count = PlayerPrefs.GetInt("TOTAL_CLICK_COUNT");
        total_click_count += int.Parse(_countText.text);

        //string url = "http://localhost/12/.account/update.php";
        string url = "http://13.124.104.81/12php/account/update.php";

        WWWForm form = new WWWForm();
        form.AddField("id", _idText.text.Trim());
        form.AddField("best_click_count", _bestText.text.Trim());
        form.AddField("total_click_count", total_click_count.ToString().Trim());
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
        Debug.Log(this.GetMethodName() + "[RESPONSE][result_count]" + responseData["result_count"]);
        Debug.Log(this.GetMethodName() + "[RESPONSE][result_code]" + responseData["result_code"]);
        Debug.Log(this.GetMethodName() + "[RESPONSE][error_code]" + responseData["error_code"]);
        Debug.Log(this.GetMethodName() + "[RESPONSE][error_messge]" + responseData["error_messge"]);

        _infoText.text = result_code;

        if (result_code.Equals("UPDATE_SUCCESS"))
        {
            Invoke("GoEnd", 3.0f);
        }
    }

    private void GoEnd()
    {
        SceneManager.LoadScene("End");
    }
}
