using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{
    public TextMeshProUGUI[] tmps;
    public Image[] images;

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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) { MoveSelection((selectedIndex - 1 + tmps.Length) % tmps.Length); }
        if (Input.GetKeyDown(KeyCode.A)) { MoveSelection((selectedIndex - 1 + tmps.Length) % tmps.Length); }
        if (Input.GetKeyDown(KeyCode.S)) { MoveSelection((selectedIndex + 1) % tmps.Length); }
        if (Input.GetKeyDown(KeyCode.D)) { MoveSelection((selectedIndex + 1) % tmps.Length); }
    }

    void MoveSelection(int newIndex)
    {
        if (newIndex == selectedIndex) return;

        DeselectTMP(selectedIndex);
        SelectTMP(newIndex);
        selectedIndex = newIndex;
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
}
