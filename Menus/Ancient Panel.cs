using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.ChallengeEditor;
using Il2CppAssets.Scripts.Unity.UI_New;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppNinjaKiwi.Common;
using System;

namespace AncientMonkey.Menus;

public class AncientPanel : ModGameMenu<ExtraSettingsScreen>
{
    private static ModHelperButton packs;
    private static ModHelperButton challenges;
    private static ModHelperButton artifacts;
    private static ModHelperButton report;

    public override bool OnMenuOpened(Il2CppSystem.Object data)
    {
        CommonForegroundScreen.instance.heading.SetActive(true);
        CommonForegroundHeader.SetText("Ancient Settings");
        var panelTransform = GameMenu.gameObject.GetComponentInChildrenByName<RectTransform>("Panel");
        var panel = panelTransform.gameObject;
        panel.DestroyAllChildren();
        var mainPanel = panel.AddModHelperPanel(new Info("AncientPanelMenu", 0, 0));

        packs = mainPanel.AddButton(new Info("PackButton", -500, 200, 600, 600, new Vector2(1, 0), new Vector2(0.5f, 0)), VanillaSprites.MilitaryMonkeyIcon, new Action(OpenPacksPanel));
        packs.AddText(new Info("Text", 0, -225, 625, 200), "Weapon Packs", 90f);

        challenges = mainPanel.AddButton(new Info("PackButton", 500, 200, 600, 600, new Vector2(1, 0), new Vector2(0.5f, 0)), VanillaSprites.ChallengesIcon, new Action(OpenChallengePanel));
        challenges.AddText(new Info("Text", 0, -225, 625, 200), "Ancient Challenges", 90f);

        artifacts = mainPanel.AddButton(new Info("PackButton", -500, -600, 500, 600, new Vector2(1, 0), new Vector2(0.5f, 0)), VanillaSprites.SharpShotsUpgradeIcon, new Action(OpenArtifactPanel));
        artifacts.AddText(new Info("Text", 0, -225, 625, 200), "Artifacts", 90f);

        report = mainPanel.AddButton(new Info("PackButton", 500, -600, 500, 600, new Vector2(1, 0), new Vector2(0.5f, 0)), VanillaSprites.LangUniversalIcon, new Action(OpenReportPanel));
        report.AddText(new Info("Text", 0, -225, 625, 200), "Report Feedback", 90f);

        return false;
    }
    private static void OpenPacksPanel()
    {
        Open<PackPanel>();
    }
    private static void OpenChallengePanel()
    {
        Open<ChallengePanel>();
    }
    private static void OpenArtifactPanel()
    {
        Open<ArtifactPanel>();
    }
    private static void OpenReportPanel()
    {
        Open<ReportPanel>();
    }
}
