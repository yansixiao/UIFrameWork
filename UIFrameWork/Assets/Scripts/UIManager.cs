using SUIFW;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    /// <summary>
    /// UI界面路径<窗口名字，路径>
    /// </summary>
    Dictionary<string, string> UIPaths;

    /// <summary>
    /// 缓存的UI界面
    /// </summary>
    Dictionary<string, BaseUI> cacheUIs;

    /// <summary>
    /// 当前展示的UI
    /// </summary>
    Dictionary<string, BaseUI> showUIs;  

    /// <summary>
    /// UI根节点
    /// </summary>
    Transform traRoot;
    /// <summary>
    /// 全屏幕显示的节点
    /// </summary>
    Transform traNormal;
    /// <summary>
    /// 固定显示的节点
    /// </summary>
    Transform traFixed;
    /// <summary>
    /// 弹出节点
    /// </summary>
    Transform traPopUp;
    /// <summary>
    /// UI脚本管理节点
    /// </summary>
    Transform traUISprites;

    private void Awake()
    {

    }

    /// <summary>
    /// 加载与判断指定的UI窗体的名字，加载到"所有UI窗体"缓存里
    /// </summary>
    /// <param name="UIName"></param>
    /// <returns></returns>
    BaseUI LoadUIToCacheUIs(string UIName)
    {
        BaseUI baseUI;

        //得到就返回 得不到返回null
        cacheUIs.TryGetValue(UIName, out baseUI);
        if (baseUI == null)
        {
            LoadUI(UIName);
        }
        return baseUI;
    }

    /// <summary>
    /// 根据不同位置信息，加载到root下不同的节点
    /// </summary>
    BaseUI LoadUI(string UIName)
    {
        string uiPath;
        GameObject UIPrefabs = null;
        BaseUI baseUI = null;

        UIPaths.TryGetValue(UIName, out uiPath);
        if (!string.IsNullOrEmpty(uiPath))
        {
            UIPrefabs = ResourcesMgr.GetInstance().LoadAsset(uiPath, false);
        }

        if (traRoot != null && UIPrefabs != null)
        {
            baseUI = UIPrefabs.GetComponent<BaseUI>();

            if (baseUI == null)
                return null;

            switch (baseUI.currentUIType.type)
            {
                case UIFormType.Normal:
                    UIPrefabs.transform.SetParent(traNormal, false);
                    break;
                case UIFormType.Fixed:
                    UIPrefabs.transform.SetParent(traFixed, false);
                    break;
                case UIFormType.PopUp:
                    UIPrefabs.transform.SetParent(traPopUp, false);
                    break;
                default:
                    break;
            }

            UIPrefabs.SetActive(false);
            cacheUIs.Add(UIName, baseUI);
            return baseUI;
        }

        return null;
    }

    /// <summary>
    /// 将当前界面加载到当前显示界面字典中
    /// </summary>
    /// <param name="UIName"></param>
    void LoadUIToShowUIs(string UIName)
    {
        //当前展示UI
        BaseUI baseUI;
        //缓存UI
        BaseUI baseUIFormCache;

        showUIs.TryGetValue(UIName, out baseUI);

        if (baseUI == null)
            return;

        cacheUIs.TryGetValue(UIName, out baseUIFormCache);
        if (baseUIFormCache != null)
        {
            showUIs.Add(UIName, baseUIFormCache);
            baseUIFormCache.ActiveTrue();
        }

    }
}
