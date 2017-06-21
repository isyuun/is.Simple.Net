using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUFO : _MonoBehaviour
{
    public int ClickCount = 0;
    public CGameManager _gameManager;

    public void OnMouseDown()
    {
        //Debug.Log(this.GetMethodName());
        ClickCount++;
        _gameManager.ShowClickCount(ClickCount);
    }
}
