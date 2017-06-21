using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour
{
    public Text _idText;
    public Text _countText;
    public Text _bestText;
    public Image _shipTypeImage;

    public Sprite[] _ufoShipPrefabs;

    private void Start()
    {
        _idText.text = PlayerPrefs.GetString("ID").ToString();

        _bestText.text = PlayerPrefs.GetInt("BEST_CLICK_COUNT").ToString();

        //_countText.text = PlayerPrefs.GetInt("TOTAL_CLICK_COUNT").ToString();

        int ctype = PlayerPrefs.GetInt("CTYPE");

        _shipTypeImage.sprite = _ufoShipPrefabs[ctype];
    }
}
