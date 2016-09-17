using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EntityPanel : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject stageEditor;
    public GameObject button;

    void Start()
    {
        int stageNum = stageEditor.GetComponent<StageEditor>().entityPrefabs.Length;
        for (int i = 0; i < stageNum; i++)
        {
            int id = i;
            GameObject newButton = (GameObject)Instantiate(button);
            RectTransform btnRect = newButton.GetComponent<RectTransform>();
            btnRect.parent = transform;
            btnRect.anchoredPosition = new Vector2(5 + i * 100, 0);

            Button btn = newButton.GetComponent<Button>();
            btn.onClick.AddListener(() =>
                stageEditor.GetComponent<StageEditor>().addEntity(id)
            );

            newButton.transform.GetChild(0).GetComponent<Text>().text = stageEditor.GetComponent<StageEditor>().entityPrefabs[i].name;

        }
    }
}
