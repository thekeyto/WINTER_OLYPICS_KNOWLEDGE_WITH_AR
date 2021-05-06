using System;
using System.Collections;
using System.Collections.Generic;
using cn.sharesdk.unity3d;
using LitJson;
using UnityEngine;
using UnityEngine.UI;

public class ShareSDKManager : MonoBehaviour
{
    public Text myConsole;
    private QQUser user;

    private static ShareSDKManager _instance;
    public static ShareSDKManager Instance
    {
        get
        {
            return _instance;
        }
    }
    private ShareSDK shareSdk;

    void Awake()
    {
        _instance = this;
        shareSdk = gameObject.GetComponent<ShareSDK>();

        shareSdk.authHandler = AuthHandler;

        EventCenter.AddListener(EventTypes.RequestAuth, OnRequestAuth);
        EventCenter.AddListener(EventTypes.CancelAuth, OnCancelAuth);
    }
    /// <summary>
    /// 请求授权
    /// </summary>
    /// <param name="data"></param>
    private void OnRequestAuth(object data)
    {
        shareSdk.Authorize(PlatformType.QQ);
    }
    /// <summary>
    /// 请求取消授权
    /// </summary>
    private void OnCancelAuth(object data)
    {
        shareSdk.CancelAuthorize(PlatformType.QQ);
    }

    /// <summary>
    /// 授权回调
    /// </summary>
    /// <param name="reqID"></param>
    /// <param name="state"></param>
    /// <param name="type"></param>
    /// <param name="data"></param>
    private void AuthHandler(int reqID, ResponseState state, PlatformType type, Hashtable data)
    {
        switch (state)
        {
            case ResponseState.Begin:// 开始授权
                break;
            case ResponseState.Success:// 授权成功
                AuthSucess();
                break;
            case ResponseState.Fail:// 授权失败
                break;
            case ResponseState.Cancel:// 取消授权
                break;
            case ResponseState.BeginUPLoad:// 开始加载
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 授权成功
    /// </summary>
    private void AuthSucess()
    {
        // 获取到授权信息
        Hashtable info = shareSdk.GetAuthInfo(PlatformType.QQ);
        // 解析json
        JsonData data = JsonMapper.ToObject(MiniJSON.jsonEncode(info));
        string userID = data["userID"].ToString();
        string username = data["userName"].ToString();
        string userIconUrl = data["userIcon"].ToString();
        string token = data["token"].ToString();
        user = new QQUser(userID, username, userIconUrl, token);
        EventCenter.Broadcast(EventTypes.AuthSuccess, user);
    }
    public void fenxiang__QQ() //QQ分享
    {
        ShareContent content = new ShareContent();
        content.SetTitle("冬奥会知识比拼");
        content.SetText("我获得了所有碎片，你能吗");
        content.SetTitleUrl(
            "https://pan.download.com");
        content.SetImageUrl(
            "https://image.baidu.com/search/index?tn=baiduimage&ct=201326592&lm=-1&cl=2&ie=gb18030&word=%B6%AC%D4%CB%BB%E1%BC%AA%CF%E9%CE%EF&fr=ala&ala=1&alatpl=adress&pos=0&hs=2&xthttps=000000");
        content.SetShareType(ContentType.Image);
        shareSdk.ShareContent(PlatformType.QQ, content);
    }
    public void fenxiang__ALL() //所有界面
    {
        ShareContent content = new ShareContent();
        content.SetTitle("测试");
        content.SetText("测试文本");
        content.SetTitleUrl(
            "https://www.gamersky.com/showimage/id_gamersky.shtml?http://img1.gamersky.com/image2019/07/20190725_ls_red_141_2/gamersky_042origin_083_2019725182972C.jpg");
        content.SetImageUrl(
            "https://www.gamersky.com/showimage/id_gamersky.shtml?http://img1.gamersky.com/image2019/07/20190725_ls_red_141_2/gamersky_042origin_083_2019725182972C.jpg");
        content.SetShareType(ContentType.Image);
        shareSdk.ShowPlatformList(null, content, 100, 100);
    }
    public void fenxiang_WX()
    {
        ShareContent content = new ShareContent();
        content.SetTitle("标题");
        content.SetText("内容");
        content.SetImageUrl("https://www.gamersky.com/showimage/id_gamersky.shtml?http://img1.gamersky.com/image2019/07/20190725_ls_red_141_2/gamersky_042origin_083_2019725182972C.jpg");
        content.SetUrl("");
        content.SetShareType(ContentType.Image);
        shareSdk.ShareContent(PlatformType.WeChat, content);
    }

    private void OnDestroy()
    {
        // 移除事件监听
        EventCenter.RemoveListener(EventTypes.RequestAuth, OnRequestAuth);
    }
}
/// <summary>
/// 定义一个QQUser类，用来存储登录返回的用户信息
/// </summary>
public class QQUser
{
    /// <summary>
    /// 用户ID
    /// </summary>
    public string UserID { get; private set; }
    /// <summary>
    /// 用户名
    /// </summary>
    public string Username { get; private set; }
    /// <summary>
    /// 用户头像的url
    /// </summary>
    public string UserIconUrl { get; private set; }
    /// <summary>
    /// 用户记号
    /// </summary>
    public string Token { get; private set; }

    public QQUser(string userID, string username, string userIconUrl, string token)
    {
        this.UserID = userID;
        this.Username = username;
        this.UserIconUrl = userIconUrl;
        this.Token = token;
    }
}
/// <summary>
/// 事件中心
/// </summary>
public class EventCenter
{
    private static Dictionary<EventTypes, Action<object>> m_EventDict = new Dictionary<EventTypes, Action<object>>();

    /// <summary>
    /// 添加事件监听
    /// </summary>
    public static void AddListener(EventTypes eventType, Action<object> callback)
    {
        if (!m_EventDict.ContainsKey(eventType))
        {
            m_EventDict.Add(eventType, null);
        }
        m_EventDict[eventType] += callback;
    }

    /// <summary>
    /// 移除事件监听
    /// </summary>
    public static void RemoveListener(EventTypes eventType, Action<object> callback)
    {
        if (!m_EventDict.ContainsKey(eventType))
            return;

        if (m_EventDict[eventType] == null)
            return;

        m_EventDict[eventType] -= callback;
    }

    /// <summary>
    /// 广播
    /// </summary>
    public static void Broadcast(EventTypes eventType, object data)
    {
        if (!m_EventDict.ContainsKey(eventType))
            return;

        Action<object> callback = m_EventDict[eventType];

        if (callback != null)
        {
            callback(data);
        }
    }

}

/// <summary>
/// 事件类型枚举
/// </summary>
public enum EventTypes
{
    RequestAuth,    // 请求授权
    AuthSuccess,    // 授权成功
    AuthFail,       // 授权失败
    CancelAuth,     // 取消授权
}