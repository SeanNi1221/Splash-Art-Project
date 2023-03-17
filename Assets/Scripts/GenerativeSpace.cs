using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GenerativeSpace
{
  public float Width, Height, Interval;
  public Vector3 LeftBottom => new Vector3(xMin, yMin, 0);
  public Vector3 LeftTop => new Vector3(xMin, yMax, 0);
  public Vector3 RightBottom => new Vector3(xMax, yMin, 0);
  public Vector3 RightTop => new Vector3(xMax, yMax, 0);
  public int Count { get; private set; }
  public Vector3 Next {
    get {
      Vector3 next;
      Vector3 current;
      if (_current == null) {
        current = LeftBottom;
        next = current;
      } else {
        current = (Vector3)_current;

        var x = current.x + Interval;
        if (x > xMax) {
          x = xMin;
          newRow = true;
        }

        var y = current.y;
        if (newRow) {
          y += Interval;
          if (y > yMax) {
            y = yMin;
            newLayer = true;
          }
          newRow = false;
        }

        var z = current.z;
        if (newLayer) {
          z += Interval;
          newLayer = false;
        }

        next = new Vector3(x, y, z);
      }
      _current = next;
      Count++;
      return next;
    }
  }
  private Vector3 _origin => LeftBottom;
  private Vector3? _current;
  private float xMin => -Width/2;
  private float xMax => Width/2;
  private float yMin => 0;
  private float yMax => Height;
  private bool newRow { get; set; }
  private bool newLayer { get; set; }
}
