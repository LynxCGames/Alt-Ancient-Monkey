using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppTMPro;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppNinjaKiwi.Common;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;
using Il2CppAssets.Scripts.Unity.UI_New.Popups;
using System.Net.Http;
using System.Threading.Tasks;
using Il2CppSystem;
using System.Net.Http.Headers;
using UnityEngine.UI;
using System.Text;

namespace AncientMonkey.Menus;

public class ReportPanel : ModGameMenu<HotkeysScreen>
{
    ModHelperPanel panel;
    ModHelperScrollPanel reportPanel;
    public override bool OnMenuOpened(Il2CppSystem.Object data)
    {
        CommonForegroundScreen.instance.heading.SetActive(true);
        CommonForegroundHeader.SetText("Report Feedback");
        var gameObject = GameMenu.gameObject;
        gameObject.DestroyAllChildren();
        GameMenu.saved = true;

        panel = gameObject.AddModHelperPanel(new Info("Panel", 0, 0));
        var MainPanel = panel.AddPanel(new Info("FeedbackReportMenu", 3600, 1900));
        CreateFeedbackPanel(MainPanel);

        return false;
    }
    private void CreateFeedbackPanel(ModHelperPanel MainPanel)
    {
        reportPanel = MainPanel.AddScrollPanel(new Info("MainFeedbackMenu", 0, 0, 2100, 2000), RectTransform.Axis.Vertical, VanillaSprites.MainBgPanel, 20, 50);
        LoadReportContent();
    }
    private int currentMode = 0;
    private string playerName = "Player Name";
    private string title = "Title";
    private string description = "Description (Send log if possible (only bug reports))";
    private DateTime lastFeedbackTime = DateTime.MinValue;
    private TimeSpan feedbackCooldown = TimeSpan.FromSeconds(30);
    public void LoadReportContent()
    {
        reportPanel.ScrollContent.transform.DestroyAllChildren();
        var modeButton = ModHelperButton.Create(new Info("idea", 1000, 200), VanillaSprites.GreenBtnLong, new System.Action(() => {
            if (currentMode == 1) { currentMode = 0; } else { currentMode = 1; }
            LoadReportContent();
        }));
        string modeString = currentMode == 1 ? "Give Idea Mode" : "Report Bug Mode";
        modeButton.AddText(new Info("idea", 1500, 200), modeString, 100);
        var playerNameValue = ModHelperInputField.Create(new Info("playerNameValue", 1000, 165), playerName, VanillaSprites.BlueInsertPanelRound, new System.Action<string>(value => { }), 70, TMP_InputField.CharacterValidation.None);
        playerNameValue.GetComponent<Mask>().enabled = false;
        playerNameValue.GetComponent<Mask>().enabled = true;
        playerNameValue.InputField.lineType = TMP_InputField.LineType.MultiLineNewline;
        playerNameValue.InputField.textComponent.enableWordWrapping = true;
        playerNameValue.InputField.textComponent.overflowMode = TextOverflowModes.Overflow;
        playerNameValue.InputField.onValueChanged.AddListener(new System.Action<string>(value =>
        {
            playerName = value;
            playerNameValue.GetComponent<Mask>().enabled = false;
            playerNameValue.GetComponent<Mask>().enabled = true;
        }));
        playerNameValue.InputField.characterLimit = 25;
        var titleValue = ModHelperInputField.Create(new Info("titleValue", 1000, 165), title, VanillaSprites.BlueInsertPanelRound, new System.Action<string>(value => { }), 70, TMP_InputField.CharacterValidation.None);
        titleValue.GetComponent<Mask>().enabled = false;
        titleValue.GetComponent<Mask>().enabled = true;
        titleValue.InputField.lineType = TMP_InputField.LineType.MultiLineNewline;
        titleValue.InputField.textComponent.enableWordWrapping = true;
        titleValue.InputField.textComponent.overflowMode = TextOverflowModes.Overflow;
        titleValue.InputField.onValueChanged.AddListener(new System.Action<string>(value => {
            title = value;
            titleValue.GetComponent<Mask>().enabled = false;
            titleValue.GetComponent<Mask>().enabled = true;
        }));
        titleValue.InputField.characterLimit = 20;
        var descriptionValue = ModHelperInputField.Create(new Info("descriptionValue", 2000, 330), description, VanillaSprites.BlueInsertPanelRound, new System.Action<string>(value => { }), 70, TMP_InputField.CharacterValidation.None);
        descriptionValue.GetComponent<Mask>().enabled = false;
        descriptionValue.GetComponent<Mask>().enabled = true;
        descriptionValue.InputField.lineType = TMP_InputField.LineType.MultiLineNewline;
        descriptionValue.InputField.textComponent.enableWordWrapping = true;
        descriptionValue.InputField.textComponent.overflowMode = TextOverflowModes.Overflow;
        descriptionValue.InputField.textComponent.alignment = TextAlignmentOptions.TopLeft;
        descriptionValue.InputField.onValueChanged.AddListener(new System.Action<string>(value => {
            description = value;
            descriptionValue.GetComponent<Mask>().enabled = false;
            descriptionValue.GetComponent<Mask>().enabled = true;
        }));
        descriptionValue.InputField.characterLimit = 10000;

        var sendReport = ModHelperButton.Create(new Info("idea", 1000, 200), VanillaSprites.GreenBtnLong, new System.Action(() => {
            SendFeedback(currentMode == 1 ? "idea" : "bug", title, description, playerName);
        }));
        string modeStringSend = currentMode == 1 ? "Send Idea" : "Report Bug";
        sendReport.AddText(new Info("idea", 1500, 200), modeStringSend, 100);


        reportPanel.AddScrollContent(modeButton);
        reportPanel.AddScrollContent(playerNameValue);
        reportPanel.AddScrollContent(titleValue);
        reportPanel.AddScrollContent(descriptionValue);
        reportPanel.AddScrollContent(sendReport);
    }
    private static readonly HttpClient httpClient = new HttpClient();

    public async Task<HttpResponseMessage> GetDataAsync(string type, string title, string description, string playerName)
    {
        String url = "https://report-handler.bananapoire12.workers.dev";

        string json = $"{{\"type\":\"{type}\",\"title\":\"{title}\",\"description\":\"{description}\",\"userName\":\"{playerName}\"}}";

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        request.Content = new StringContent(json, Encoding.UTF8);
        request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");


        return await httpClient.SendAsync(request);
    }
    public void SendFeedback(string type, string title, string description, string playerName)
    {
        DateTime now = DateTime.Now;
        if (now - lastFeedbackTime < feedbackCooldown)
        {
            double secondsLeft = (feedbackCooldown - (now - lastFeedbackTime)).TotalSeconds;
            PopupScreen.instance.ShowOkPopup($"Please wait {secondsLeft:F1} more seconds before sending another report.", null);
            return;
        }
        lastFeedbackTime = now;
        PopupScreen.instance.ShowOkPopup($"Correctly received report, {playerName}, your feedback will be looked at and thank you :)", null);
        Task.Run(async () =>
        {
            try
            {

                HttpResponseMessage response = await GetDataAsync(type, title, description, playerName);
            }
            catch (System.Exception)
            {
            }
        });
    }
}
