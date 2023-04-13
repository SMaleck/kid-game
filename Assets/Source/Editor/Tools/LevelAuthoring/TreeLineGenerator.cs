using Game.Data.Sources;
using Game.Utility;
using Game.Utility.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Source.Editor.Tools.LevelAuthoring
{
    public class TreeLineGenerator : EditorWindow
    {
        private const string NameStart = "background_start";
        private const string NameEnd = "background_end";

        private Transform _parent;
        private Transform _startAt;
        private Transform _endAt;
        private Vector3 _groundOffset = new Vector3(0f, 1.5f, 1f);
        private float _offsetFactor = 1f;
        private LevelElementsDataSource _levelData;

        [MenuItem(ProjectConst.MenuRoot + "Level Generator/Background")]
        public static void Open()
        {
            GetWindow<TreeLineGenerator>("Level Generator").Initialize();
        }

        private void Initialize()
        {
            _levelData = AssetDatabase.FindAssets($"t:{nameof(LevelElementsDataSource)}")
                .Select(AssetDatabase.GUIDToAssetPath)
                .Take(1)
                .Select(e => (LevelElementsDataSource)AssetDatabase.LoadAssetAtPath(e, typeof(LevelElementsDataSource)))
                .FirstOrDefault();

            Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            _parent = (Transform)EditorGUILayout.ObjectField("Parent", _parent, typeof(Transform), true);
            _startAt = (Transform)EditorGUILayout.ObjectField("Start At", _startAt, typeof(Transform), true);
            _endAt = (Transform)EditorGUILayout.ObjectField("End At", _endAt, typeof(Transform), true);
            //_groundOffset = EditorGUILayout.Vector3Field("Ground Offset", _groundOffset);
            _offsetFactor = EditorGUILayout.FloatField("Offset Factor", _offsetFactor);

            EditorGUILayout.Space();
            _levelData = (LevelElementsDataSource)EditorGUILayout.ObjectField("Level Data", _levelData, typeof(LevelElementsDataSource), true);
            EditorGUILayout.Space();

            TryFindAnchors();

            if (GUILayout.Button("Generate"))
            {
                Clear();
                GenerateTreeLine();
            }

            EditorGUILayout.Space();
            if (GUILayout.Button("Clear"))
            {
                Clear();
            }
        }

        private void TryFindAnchors()
        {
            if (_parent && !_startAt)
            {
                _startAt = FindWithName(_parent, NameStart);
            }
            if (_parent && !_endAt)
            {
                _endAt = FindWithName(_parent, NameEnd);
            }
        }

        private Transform FindWithName(Transform parent, string nameMarker)
        {
            return parent
                .GetComponentsInChildren<Transform>()
                .FirstOrDefault(e => e.name.ToLowerInvariant().Contains(nameMarker));
        }

        // ToDo Generate Backing Ground as well
        // ----------------------------------- GENERATOR: Trees
        private List<GameObject> _created;

        private void GenerateTreeLine()
        {
            _created = new List<GameObject>();

            while (CanCreate())
            {
                var last = _created.Count > 0 ? _created[^1] : null;
                var next = CreateNext(last);

                _created.Add(next);
            }
        }

        private bool CanCreate()
        {
            if (_created.Count <= 0) return true;

            var last = _created[^1];
            return last.transform.position.x < _endAt.position.x;
        }

        private GameObject CreateNext(GameObject last)
        {
            var prefab = RollObject();
            var next = GameObject.Instantiate(prefab, _parent);

            next.transform.position = GetPosition(last, next);
            return next;
        }

        private GameObject RollObject()
        {
            return _levelData.Trees.GetRandom();
        }

        private Vector3 GetPosition(GameObject last, GameObject next)
        {
            if (last == null) return _startAt.position;

            var lastPos = last.transform.position;
            var lastSize = last.GetComponent<MeshRenderer>().bounds.size;
            var nextSize = next.GetComponent<MeshRenderer>().bounds.size;

            var offsetX = (lastSize.x / 2) + (nextSize.x / 2);
            offsetX *= _offsetFactor;

            return new Vector3(lastPos.x + offsetX, lastPos.y, lastPos.z);
        }

        private void Clear()
        {
            var count = _parent.childCount;
            for (var i = count - 1; i >= 0; i--)
            {
                var child = _parent.GetChild(i);
                if (IsAnchor(child.gameObject)) continue;

                GameObject.DestroyImmediate(child.gameObject);
            }
        }

        private bool IsAnchor(GameObject go)
        {
            return go.name.ToLowerInvariant().Contains(NameStart) ||
                   go.name.ToLowerInvariant().Contains(NameEnd);
        }
    }
}
