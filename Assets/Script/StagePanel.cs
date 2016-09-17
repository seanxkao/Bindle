using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StagePanel : MonoBehaviour {
    public GameObject mainPanel;
    public GameObject stageEditor;
    public GameObject button;

    void Start()
    {
        int stageNum = stageEditor.GetComponent<StageEditor>().stagePrefabs.Length;
        for (int i = 0; i < stageNum; i++) {
            int id = i;
            GameObject newButton = (GameObject)Instantiate(button);
            RectTransform rect = newButton.GetComponent<RectTransform>();
            rect.SetParent(transform);
            rect.anchoredPosition = new Vector2(5+i*100, 0);
            Button b = newButton.GetComponent<Button>();
            b.onClick.AddListener(() =>
                stageEditor.GetComponent<StageEditor>().setStage(id)
            );
            newButton.transform.GetChild(0).GetComponent<Text>().text = stageEditor.GetComponent<StageEditor>().stagePrefabs[i].name;

        }
	}
}
