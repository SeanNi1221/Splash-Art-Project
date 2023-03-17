using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectGenerator : MonoBehaviour {
    public GameObject ObjectToAdd;
    public int AddCount;
    public InputField CountInput;
    public Button AddButton;
    public Text infoText;
    public GenerativeSpace Space;
    private Mesh mesh;
    void OnDrawGizmos() {
      Gizmos.color = Color.yellow;
      Gizmos.DrawLine(Space.LeftBottom, Space.LeftTop);
      Gizmos.DrawLine(Space.LeftTop, Space.RightTop);
      Gizmos.DrawLine(Space.RightTop, Space.RightBottom);
      Gizmos.DrawLine(Space.RightBottom, Space.LeftBottom);
    }
    void OnValidate() {
      if (ObjectToAdd && !ObjectToAdd.GetComponent<ObjectMotion>()) {
        ObjectToAdd.AddComponent<ObjectMotion>();
      }
    }
    void OnEnable() {
      CountInput.text = AddCount.ToString();
      mesh = ObjectToAdd.GetComponent<MeshFilter>().sharedMesh;
      AddButton.onClick.AddListener(AddObjects);
    }
    void OnDisable() {
      AddButton.onClick.RemoveListener(AddObjects);
    }
    public void AddObjects() {
      AddCount = int.Parse(CountInput.text);
      for(int i = 0; i < AddCount; i++) {
        Instantiate(ObjectToAdd, Space.Next, Quaternion.identity);
      }
      infoText.text = $"Current Count:{Space.Count}  Per object vertices:{mesh.vertexCount}";
    }
}
