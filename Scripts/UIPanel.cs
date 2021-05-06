using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI面板
/// </summary>
public class UIPanel : MonoBehaviour
{
    public Text msgText;
    public Image userIconImg;
    public Text usernameText;
    public Button loginBtn;
    public Button logoutBtn;

    private void Awake()
    {
        // 获取UI组件
        /*userIconImg = transform.Find("Img_UserIcon").GetComponent<Image>();
        msgText = transform.Find("Txt_Msg").GetComponent<Text>();
        usernameText = transform.Find("Txt_Username").GetComponent<Text>();
        loginBtn = transform.Find("Btn_Login").GetComponent<Button>();
        logoutBtn = transform.Find("Btn_Logout").GetComponent<Button>();
        */
        // 添加按钮点击事件
        loginBtn.onClick.AddListener(OnLoginBtnClicked);
        logoutBtn.onClick.AddListener(OnLogoutBtnClicked);

        logoutBtn.gameObject.SetActive(false);

        EventCenter.AddListener(EventTypes.AuthSuccess, OnAuthSuccess);
    }


    /// <summary>
    /// 登录成功
    /// </summary>
    /// <param name="data">QQUser对象</param>
    private void OnAuthSuccess(object data)
    {
        QQUser user = data as QQUser;
        usernameText.text = "用户名：" + user.Username;
        StartCoroutine(LoadUserIcon(user.UserIconUrl));
        loginBtn.gameObject.SetActive(false);
        logoutBtn.gameObject.SetActive(true);
        ShowMsg("授权成功");
    }

    /// <summary>
    /// 加载头像协程
    /// </summary>
    /// <param name="url">头像url</param>
    /// <returns></returns>
    private IEnumerator LoadUserIcon(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        Texture2D texture = www.texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        userIconImg.sprite = sprite;
    }

    /// <summary>
    /// 点击登录按钮
    /// </summary>
    public void OnLoginBtnClicked()
    {
        EventCenter.Broadcast(EventTypes.RequestAuth, null);
    }

    /// <summary>
    /// 显示提示消息
    /// </summary>
    /// <param name="msg"></param>
    private void ShowMsg(string msg)
    {
        StartCoroutine(ShowMsgCor(msg));
    }

    /// <summary>
    /// 显示提示消息协程
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    private IEnumerator ShowMsgCor(string msg)
    {
        msgText.text = msg;
        yield return new WaitForSeconds(3f);
        msgText.text = "";
    }

    /// <summary>
    /// 点击取消授权按钮
    /// </summary>
    public void OnLogoutBtnClicked()
    {
        EventCenter.Broadcast(EventTypes.CancelAuth, null);
        loginBtn.gameObject.SetActive(true);
        logoutBtn.gameObject.SetActive(false);
        usernameText.text = "";
        userIconImg.sprite = null;
    }

    private void OnDestroy()
    {
        EventCenter.RemoveListener(EventTypes.AuthSuccess, OnAuthSuccess);
    }
}