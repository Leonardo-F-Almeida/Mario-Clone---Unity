using System.Linq;
using UnityEditor;
using UnityEngine;

public class SnapToGridEditor : EditorWindow
{
    private int prevHash;
    private bool doSnapPosition = true;
    private bool doSnapCollider = false;
    private float snapValue = 0.1f;

    [MenuItem("Edit/Auto Snap %_l")]

    static void Init()
    {
        var window = (SnapToGridEditor)EditorWindow.GetWindow(typeof(SnapToGridEditor));
        window.maxSize = new Vector2(200, 100);
    }

    public void OnGUI()
    {
        doSnapPosition = EditorGUILayout.Toggle("Auto Snap Position", doSnapPosition);
        doSnapCollider = EditorGUILayout.Toggle("Auto Snap Collider", doSnapCollider);
        snapValue = EditorGUILayout.FloatField("Snap Value", snapValue);
    }

    public void Update()
    {
        if ((doSnapPosition || doSnapCollider)
          && !EditorApplication.isPlaying
          && Selection.transforms.Length > 0
          && GetHash() != prevHash)
        {
            if(doSnapPosition)
                SnapPosition();
            if (doSnapCollider)
                SnapCollider();
            prevHash = GetHash();
        }
    }

    private void SnapPosition()
    {
        foreach (var transform in Selection.transforms)
        {
            RectTransform rectTrans = transform.transform as RectTransform;
            if (rectTrans)
            {
                var pos = rectTrans.anchoredPosition;
                pos.x = Round(pos.x);
                pos.y = Round(pos.y);
                rectTrans.anchoredPosition = pos;
                var size = rectTrans.sizeDelta;
                size.x = Round(size.x);
                size.y = Round(size.y);
                rectTrans.sizeDelta = size;
            }
            else {
                var t = transform.transform.position;
                t.x = Round(t.x);
                t.y = Round(t.y);
                t.z = Round(t.z);
                transform.transform.position = t;
            }
        }
    }

    private void SnapCollider()
    {
        foreach (var transform in Selection.transforms)
        {
            BoxCollider2D[] boxes = transform.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D box in boxes)
            {
                var offset = box.offset;
                offset.x = Round(offset.x);
                offset.y = Round(offset.y);
                box.offset = offset;
                var size = box.size;
                size.x = Round(size.x);
                size.y = Round(size.y);
                box.size = size;
            }
        }
    }

    private int GetHash()
    {
        if (Selection.transforms.Length == 0)
            return 0;

        int hash = Selection.transforms[0].position.GetHashCode();

        hash += Selection.transforms[0].GetComponents<BoxCollider2D>()
            .Sum(box => box.bounds.GetHashCode());

        return hash;
    }

    private float Round(float input)
    {
        return snapValue * Mathf.Round((input / snapValue));
    }
}
