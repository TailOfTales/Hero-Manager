using UnityEngine;
using UnityEngine.UI;

public class DynamicGridLayout : MonoBehaviour {

    public int col, row;

    void Start () {

        RectTransform parrent = gameObject.GetComponent<RectTransform>();
        GridLayoutGroup grid = gameObject.GetComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(parrent.rect.width/col, parrent.rect.height/row);
    }
}