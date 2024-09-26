using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{
    public TextMeshProUGUI[] tmps;
    public Image[] images;
    public Image arrow;

    private int selectedIndex = 0;
    private Vector3[] originalScales;
    private Color[] originalColors;

    void Start()
    {
        originalScales = new Vector3[tmps.Length];
        originalColors = new Color[tmps.Length];

        for (int i = 0; i < tmps.Length; i++)
        {
            originalScales[i] = tmps[i].transform.localScale;
            originalColors[i] = tmps[i].color;
            images[i].gameObject.SetActive(false);
        }

        SelectTMP(0);
        UpdateArrowPosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { MoveSelection(-2); }
        if (Input.GetKeyDown(KeyCode.A)) { MoveSelection(-1); }
        if (Input.GetKeyDown(KeyCode.S)) { MoveSelection(2); }
        if (Input.GetKeyDown(KeyCode.D)) { MoveSelection(1); }
    }

    void MoveSelection(int offset)
    {
        int newIndex = selectedIndex + offset;

        if (selectedIndex == 0 && offset == -1) newIndex = 2; // A -> C | A의 색이 계속 됨 | w를 누르면 공격으로 가짐. 그렇지만 탐색에 화살표가 있음
        else if (selectedIndex == 1 && offset == -1) newIndex = 3; // B -> D
        else if (selectedIndex == 2 && offset == 1) newIndex = 0; // C -> A
        else if (selectedIndex == 2 && offset == 1) newIndex = 1; // C -> B
        else if (selectedIndex == 3 && offset == 1) newIndex = 2; // D -> C

        if (newIndex < 0) newIndex += tmps.Length;
        if (newIndex >= tmps.Length) newIndex -= tmps.Length;

        if (newIndex == selectedIndex) return;

        DeselectTMP(selectedIndex);
        SelectTMP(newIndex);
        selectedIndex = newIndex;
        UpdateArrowPosition();
    }

    void SelectTMP(int index)
    {
        tmps[index].transform.localScale = originalScales[index] * 1.1f;
        tmps[index].color = Color.yellow;

        images[index].gameObject.SetActive(true);
        RectTransform imageRect = images[index].GetComponent<RectTransform>();
        RectTransform tmpRect = tmps[index].GetComponent<RectTransform>();

        imageRect.anchoredPosition = new Vector2(tmpRect.anchoredPosition.x + 100, -190);
    }

    void DeselectTMP(int index)
    {
        tmps[index].transform.localScale = originalScales[index];
        tmps[index].color = originalColors[index];
        images[index].gameObject.SetActive(false);
    }

    void UpdateArrowPosition()
    {
        RectTransform tmpRect = tmps[selectedIndex].GetComponent<RectTransform>();
        RectTransform arrowRect = arrow.GetComponent<RectTransform>();


        arrowRect.anchoredPosition = new Vector2(tmpRect.anchoredPosition.x + 100, tmpRect.anchoredPosition.y - 290);
        arrow.gameObject.SetActive(true);
    }
}
