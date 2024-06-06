using System;
using System.Collections;
using UnityEngine;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
public sealed class ChessBoardPlacementHandler : MonoBehaviour {
    [SerializeField] private GameObject[] _rowsArray;
    [SerializeField] private GameObject _highlightPrefab;
    private GameObject[,] _chessBoard;
    private GameObject PlayerPosition;

    public GameObject selected;
    [SerializeField] float selectrange;

    internal static ChessBoardPlacementHandler Instance;

    private void Awake() {
        Instance = this;
        GenerateArray();
    }

    private void GenerateArray() {
        _chessBoard = new GameObject[8, 8];
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                _chessBoard[i, j] = _rowsArray[i].transform.GetChild(j).gameObject;
            }
        }
    }

    internal GameObject GetTile(int i, int j) {
        try {
            return _chessBoard[i, j];
        } catch (Exception) {
            Debug.LogError("Invalid row or column.");
            return null;
        }
    }

    internal void Highlight(int row, int col) {

        if ((row > 7 || col > 7) || (row < 0 || col < 0)) return; //out of range

        var tile = GetTile(row, col).transform;
        if (tile == null)
        {
            Debug.LogError("Invalid row or column.");
            return;
        }
       

        Instantiate(_highlightPrefab, tile.transform.position, Quaternion.identity, tile.transform);
    }

    internal void ClearHighlights() {
        for (var i = 0; i < 8; i++) {
            for (var j = 0; j < 8; j++) {
                var tile = GetTile(i, j);
                if (tile.transform.childCount <= 0) continue;
                foreach (Transform childTransform in tile.transform) {
                    Destroy(childTransform.gameObject);
                }
            }
        }
    }

    internal bool validatetile(int row, int col)
    {
        Debug.Log("validation ....");
        foreach (Chess.Scripts.Core. ChessPlayerPlacementHandler placementHandler in FindObjectsOfType<Chess.Scripts.Core.ChessPlayerPlacementHandler>())
        {
            if (placementHandler != null && placementHandler != this &&
                row == placementHandler.row && col == placementHandler.column)
            {
                return false;
            }
        }

        Debug.Log("tileclear");
        return true;
    }
    #region Highlight Testing

    // private void Start() {
    //     StartCoroutine(Testing());
    // }

    // private IEnumerator Testing() {
    //     Highlight(2, 7);
    //     yield return new WaitForSeconds(1f);
    //
    //     ClearHighlights();
    //     Highlight(2, 7);
    //     Highlight(2, 6);
    //     Highlight(2, 5);
    //     Highlight(2, 4);
    //     yield return new WaitForSeconds(1f);
    //
    //     ClearHighlights();
    //     Highlight(7, 7);
    //     Highlight(2, 7);
    //     yield return new WaitForSeconds(1f);
    // }

    #endregion


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y,Camera.main.nearClipPlane));
            Ray ray = Camera.main.ScreenPointToRay(mousePos);

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("detectable"))
            {
                Vector3 objScreenPos = Camera.main.WorldToScreenPoint(obj.transform.position);
                if (Mathf.Abs(objScreenPos.x - mousePos.x) < selectrange && Mathf.Abs(objScreenPos.y - mousePos.y) < selectrange)
                {
                    selected = obj;
                    ClearHighlights();
                    if (selected.GetComponent<IInteractable>() != null) selected.GetComponent<IInteractable>().highlight();
                }
            }
        }
    }
}