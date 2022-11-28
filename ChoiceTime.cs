using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceTime : MonoBehaviour
{
    [Tooltip("箭头图片")]
    public Sprite[] Arrows;
    //显示时间的文字
    public Text ShowText;
    //显示箭头的图片
    public Image ArrowsImage;
    //选择时间界面
    public GameObject ChoiceTimeObj;
    //按钮
    public Button ChoiceBtn;
    //是否选择时间
    public bool isShowChoiceTime;
    public DatePickerGroup iDatePickerGroup;
    public Main iMain;
    public FindUser iFindUser;
    // Use this for initialization
    void Start()
    {
        ChoiceBtn.onClick.AddListener(StartChoiceTime);
        ShowText.text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
    }

    public void Open()
    {
        iMain.ChoiceTime.SetActive(true);
        ShowText.text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        iDatePickerGroup.Init();

    }
    public void Open(DateTime dt)
    {
        iMain.ChoiceTime.SetActive(true);
        ShowText.text = dt.ToString("yyyy年MM月dd日 HH:mm:ss");
        iDatePickerGroup.Init(dt);

    }
    public void Comfit()
    {
        iMain.ChoiceTime.SetActive(false);
        for (int i = 0; i < iMain.UserMakerItemList.Count; i++)
        {
            if (iMain.UserMakerItemList[i].id == iMain.NowUserId)
            {
                if (iMain.UserStartEnd == 0)//start
                {
                    iMain.UserMakerItemList[i].Text_Time_Start.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
                    iMain.UserMakerItemList[i]._StartTime = DatePickerGroup._selectTime;
                }
                else
                {
                    iMain.UserMakerItemList[i].Text_Time_End.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
                    iMain.UserMakerItemList[i]._EndTime = DatePickerGroup._selectTime;
                }
            }
        }
        if (iMain.UserStartEnd == 0)//start
        {
            iFindUser.iUserMakerItem.Text_Time_Start.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
            iFindUser.iUserMakerItem._StartTime = DatePickerGroup._selectTime;
            iFindUser.Text_Time_Start.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
            iFindUser._StartTime = DatePickerGroup._selectTime;
        }
        else
        {
            iFindUser.iUserMakerItem.Text_Time_End.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm: ss");
            iFindUser.iUserMakerItem._EndTime = DatePickerGroup._selectTime;
            iFindUser.Text_Time_End.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
            iFindUser._EndTime = DatePickerGroup._selectTime;
        }
    }
    public void EntranceGuard_ChooseTimeOver()
    {
        iMain.ChoiceTime.SetActive(false);

        if (iMain.EntranceGuardChoiceTimeType == 0)//start
        {
            iMain.Now_EntranceGuardStartTime = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
            iMain.Text_EntranceGuardStartTime.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        else if (iMain.EntranceGuardChoiceTimeType == 1)
        {
            iMain.Now_EntranceGuardEndTime = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
            iMain.Text_EntranceGuardEndTime.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        iMain.EntranceGuardChoiceTimeType = 100;

    }
    public void PlayBack_ChooseTimeOver()
    {
        iMain.ChoiceTime.SetActive(false);

        if (iMain.PlayBackChoiceTimeType == 0)//start
        {
            iMain.Now_PlayBackStartTime = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
            iMain.Text_PlayBackStartTime.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        else if (iMain.PlayBackChoiceTimeType == 1)
        {
            iMain.Now_PlayBackEndTime = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
            iMain.Text_PlayBackEndTime.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        iMain.PlayBackChoiceTimeType = 100;

    }
    public void AlarmList_ChooseTimeOver()
    {
        iMain.ChoiceTime.SetActive(false);

        if (iMain.AlarmListChoiceTimeType == 0)//start
        {
            iMain.Text_AlarmListStartTime.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        else if (iMain.AlarmListChoiceTimeType == 1)
        {
            iMain.Text_AlarmListEndTime.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        iMain.AlarmListChoiceTimeType = 100;

    }

    public void XJLog_ChooseTimeOver()
    {
        iMain.ChoiceTime.SetActive(false);

        if (iMain.XJLogChoiceTimeType == 0)//start
        {
            iMain.Now_XJ_Log_StartTime = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
            iMain.Text_XJ_Log_StartTime.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        else if (iMain.XJLogChoiceTimeType == 1)
        {
            iMain.Now_XJ_Log_EndTime = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
            iMain.Text_XJ_Log_EndTime.text = DatePickerGroup._selectTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        iMain.XJLogChoiceTimeType = 100;

    }
    // Update is called once per frame
    void Update()
    {
        if (ChoiceTimeObj.activeSelf)
        {
            isShowChoiceTime = true;
        }
        else
        {
            isShowChoiceTime = false;
        }
    }


    public void StartChoiceTime()
    {
        //作战时间的number为1,开始时间的number为2   
        if (!isShowChoiceTime)
        {
            //显示选择时间界面
            ChoiceTimeObj.SetActive(true);
            //箭头向下
            ArrowsImage.sprite = Arrows[1];


        }
        else
        {
            //关闭选择时间界面
            ChoiceTimeObj.SetActive(false);
            //是否显示时间选择界面为false
            isShowChoiceTime = false;
            //箭头向上
            ArrowsImage.sprite = Arrows[0];
            //判断选没选择日期，当只点开选择框没有选择时，默认的日期会变为001年。所以要判断下
            if (DatePickerGroup._selectTime.ToString("yyyy年MM月dd日 HH:mm:ss").Substring(0, 3) == "000")
            {
                ShowText.text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
            }
            else
            {
                ShowText.text = DatePickerGroup._selectTime.ToString("yyyy年MM月dd日 HH:mm:ss");
            }
        }
    }
}
