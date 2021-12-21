﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace EasySee.UI
{
    public class LayoutVertical : MonoBehaviour
    {
        //[SerializeField]
        List<RectTransform> children;
        RectTransform transform;

        /*[SerializeField]
        float childrenSize = 100;
        [SerializeField]
        float childrenWidth = 100;*/

        [SerializeField]
        Vector2 childrenSizeVector = new Vector2();

        [SerializeField]
        float padding = 0;

        [SerializeField]
        bool fitSizeToContent = false;

        [SerializeField]
        RectTransform.Edge edgeToSnap = RectTransform.Edge.Top;

        void Start()
        {
            transform = GetComponent<RectTransform>();
            GetRectAndCalculate();
        }


        /// <summary>
        /// Called to get all the children in the list and refresh the position of the children.
        /// </summary>
        public void GetRectAndCalculate() 
        {
            GetChildrenRects();
            CalculatePosition();
        }

        /// <summary>
        /// Called to collect all the children in the list.
        /// </summary>
        public void GetChildrenRects()
        {
            if (children == null)
            {
                children = new List<RectTransform>();
            }
            if (children.Count > 0)
            {
                children.Clear();
            }
            if (transform == null)
            {
                Debug.Log("Parent transform is null.");
            }
            else
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    children.Add(transform.GetChild(i).GetComponent<RectTransform>());
                }
            }
        }

        /// <summary>
        /// This is called when we need to refresh the positioning of the children.
        /// </summary>
        public void CalculatePosition()
        {
            if (children == null || children.Count <= 0)
            {
                Debug.Log("No Children to calculate position for.");
                return;
            }
            float offset = 0;
            foreach (RectTransform child in children)
            {
                if (child.gameObject.activeSelf)
                {

                    child.sizeDelta = new Vector2(transform.rect.width, child.rect.height);
                    child.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, offset, childrenSizeVector.y);
                    child.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, childrenSizeVector.x);
                    offset += childrenSizeVector.y + padding;
                }
            }
            if (fitSizeToContent)
            {
                transform.sizeDelta = new Vector2(0, offset);
            }
        }
    }
}