/**
 * UI界面基类
 * 四个生命周期
 * 1.Display显示状态
 * 2.Hiding隐藏状态
 * 3.ReDisplay再显示状态
 * 4.Freeze冻结状态
 * **/
using SUIFW;
using System.Collections;
using System.Collections.Generic;
using UIFrameWork;
using UnityEngine;

/// <summary>
/// 界面类型
/// </summary>
public class UIType
{
    /// <summary>
    /// 是否清空"栈"
    /// </summary>
    public bool isClearStack = false;

    public UIFormType type = UIFormType.Normal;

    public UIFormShowType showType = UIFormShowType.Normal;

    public UIFormLucencyType lucencyType = UIFormLucencyType.Lucency;
}

public class BaseUI : MonoBehaviour
{
    public UIType currentUIType { get; set; } = new UIType();

    #region 界面四种状态
    public virtual void ActiveTrue()
    {
        gameObject.SetActive(true);
    }

    public virtual void ActiveFalse()
    {
        gameObject.SetActive(false);
    }

    public virtual void ReActiveTrue()
    {
        gameObject.SetActive(true);
    }

    public virtual void Freeze()
    {
        gameObject.SetActive(true);
    }
    #endregion

    /// <summary>
    /// 注册按钮时间
    /// </summary>
    void RigisterBtnOnClick(string btnName, EventTriggerListener.VoidDelegate del)
    {
        Transform btn = UnityHelper.Find(gameObject.transform, btnName);
        EventTriggerListener.Get(btn?.gameObject).onClick = del;
    }

    /// <summary>
    /// 打开UI界面
    /// </summary>
    /// <param name="UIName"></param>
    void Open(string UIName)
    {

    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    void Close()
    {

    }

}
