﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VR
{
    public class LaserPointer : MonoBehaviour
    {
        public bool IsActive = true;            //稼働フラグ
        public float defaultLength = 0.5f;      //ヒットなしのときのレーザーの長さ

        public bool shotRay = true;             //Ray を撃つ(false のときは target に指す位置を入れる)
        public float rayLength = 100f;          //Ray の長さ
        public LayerMask rayExclusionLayers;    //Ray 判定を除外するレイヤー

        public Transform target;                //指す位置（shotRay=true のときはヒットしたオブジェクトの transform が入る）
        public Transform anchor;                //発射位置（コントローラの位置）
        public LineRenderer lineRenderer;       //レーザーを描画するラインレンダラ
        [SerializeField]
        GameObject cursor;
        public float cursorSize = 0.04f;
        public Color laserColor = new Color(1, 1, 0);
        // Use this for initialization
        void Awake()
        {
            if (lineRenderer == null)
                lineRenderer = GetComponent<LineRenderer>();

            
            cursor.transform.SetParent(transform, false);
        }

        // Update is called once per frame
        void Update()
        {
            if (!IsActive)
            {
                lineRenderer.enabled = false;
                return;
            }

            if (shotRay)
            {
                Ray ray = new Ray(anchor.position, anchor.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, rayLength))
                {
                    target = hit.transform;
                    DrawTo(hit.point);     //ヒットした位置にしたいため
                    cursor.transform.position = hit.point;
                    cursor.GetComponent<Renderer>().enabled = true;
                    return;
                }

                target = null;
            }

            if (target != null)
            {
                cursor.GetComponent<Renderer>().enabled = false;
                DrawTo(target.position);
            }
            else
                DrawTo(anchor.position + anchor.forward * defaultLength);   //コントローラの正面方向へ一定の長さ
        }

        //レーザーを描く
        void DrawTo(Vector3 pos)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, anchor.position);
            lineRenderer.SetPosition(1, pos);
        }
    }
}
