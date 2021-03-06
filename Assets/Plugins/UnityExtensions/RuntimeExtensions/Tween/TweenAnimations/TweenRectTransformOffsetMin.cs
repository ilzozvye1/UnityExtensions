﻿using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityExtensions
{
    [TweenAnimation("Rect Transform/Offset Min", "Rect Transform Offset Min")]
    class TweenRectTransformOffsetMin : TweenVector2
    {
        public RectTransform targetRectTransform;


        public override Vector2 current
        {
            get
            {
                if (targetRectTransform)
                {
                    return targetRectTransform.offsetMin;
                }
                return default;
            }
            set
            {
                if (targetRectTransform)
                {
                    targetRectTransform.offsetMin = value;
                }
            }
        }


#if UNITY_EDITOR

        public override void Reset()
        {
            base.Reset();
            targetRectTransform = GetComponent<RectTransform>();
            from = current;
            to = current;
        }


        [CustomEditor(typeof(TweenRectTransformOffsetMin))]
        new class Editor : Editor<TweenRectTransformOffsetMin>
        {
            SerializedProperty _targetRectTransformProp;


            protected override void OnEnable()
            {
                base.OnEnable();
                _targetRectTransformProp = serializedObject.FindProperty("targetRectTransform");
            }


            protected override void OnPropertiesGUI(Tween tween)
            {
                EditorGUILayout.Space();

                EditorGUILayout.PropertyField(_targetRectTransformProp);

                base.OnPropertiesGUI(tween);
            }
        }

#endif
    }

} // namespace UnityExtensions