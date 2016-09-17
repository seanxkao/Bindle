using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EditPanel : MonoBehaviour {
    public StageEditor stageEditor;
    public InputField posXText;
    public InputField posYText;

    public void onSelected()
    {
        GameObject selected = stageEditor.selected;
        if (selected!=null)
        {
            posXText.text = selected.transform.position.x.ToString();
            posYText.text = selected.transform.position.y.ToString();
        }
        else
        {
            posXText.text = "";
            posYText.text = "";
        }

    }
    public void setObject()
    {
        GameObject selected = stageEditor.selected;
        selected.transform.position = new Vector3(float.Parse(posXText.text), float.Parse(posYText.text), 0f);
    }
}
