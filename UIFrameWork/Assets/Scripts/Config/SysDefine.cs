/**
 * UI框架核心参数
 * 1.系统常量
 * 2.全局性方法
 * 3.系统枚举类型
 * 4.委托定义
 * **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI界面位置类型
/// </summary>
public enum UIFormType
{
    /// <summary>
    /// 普通界面
    /// </summary>
    Normal,
    /// <summary>
    /// 固定界面
    /// </summary>
    Fixed,
    /// <summary>
    /// 弹窗
    /// </summary>
    PopUp,
}

/// <summary>
/// 界面动画
/// </summary>
public enum UIFormShowType
{
    Normal,
    Reverse,
    HideOther,
}

/// <summary>
/// 界面遮罩透明类型
/// </summary>
public enum UIFormLucencyType
{
    /// <summary>
    /// 全透明，不可穿透
    /// </summary>
    Lucency,
    /// <summary>
    /// 半透明，不可穿透
    /// </summary>
    Translucence,
    /// <summary>
    /// 低透明，不可穿透
    /// </summary>
    ImPenerable,
    /// <summary>
    /// 可穿透
    /// </summary>
    Pentrate,
}

public class SysDefine
{
    /// <summary>
    /// 路径常量
    /// </summary>
    public const string canvasPath = "Canvas";
    /// <summary>
    /// 标签常量
    /// </summary>
    public const string canvasTag = "Canvas";

    //全局性方法

    //委托的定义
}
