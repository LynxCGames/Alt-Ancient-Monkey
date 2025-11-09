using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New;
using Il2CppTMPro;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppNinjaKiwi.Common;
using Il2CppAssets.Scripts.Unity.UI_New.Settings;

namespace AncientMonkey.Menus;

public class ChallengePanel : ModGameMenu<HotkeysScreen>
{
    ModHelperPanel panel;
    ModHelperScrollPanel ScrollPanel;
    public override bool OnMenuOpened(Il2CppSystem.Object data)
    {
        CommonForegroundScreen.instance.heading.SetActive(true);
        CommonForegroundHeader.SetText("Ancient Challenges");
        var gameObject = GameMenu.gameObject;
        gameObject.DestroyAllChildren();
        GameMenu.saved = true;

        panel = gameObject.AddModHelperPanel(new Info("Panel", 0, 0));
        var MainPanel = panel.AddPanel(new Info("AncientChallengesMenu", 3600, 1900));
        CreateChallengesListPanel(MainPanel);

        return false;
    }
    private void CreateChallengesListPanel(ModHelperPanel MainPanel)
    {
        ScrollPanel = MainPanel.AddScrollPanel(new Info("MainScrollMenu", 0, 0, 3300, 2000), RectTransform.Axis.Vertical, VanillaSprites.MainBgPanel, 50, 50);
        LoadChallengesPanels();
    }
    public void LoadChallengesPanels()
    {
        ScrollPanel.ScrollContent.transform.DestroyAllChildren();

        for (int i = 0; i < GetContent<ChallengeTemplate>().Count; i++)
        {
            foreach (var challenge in GetContent<ChallengeTemplate>())
            {
                if (challenge.Order == i)
                {
                    ScrollPanel.AddScrollContent(CreateChallenge(challenge));
                }
            }
        }
    }
    public ModHelperPanel CreateChallenge(ChallengeTemplate challenge)
    {
        var panel = ModHelperPanel.Create(new Info("ChallengePanel" + challenge.ChallengeName, 0, 0, 3150, 250), challenge.Background);
        panel.AddText(new Info("ChallengeName", -1150, 0, 800, 100), challenge.ChallengeName, 80, TextAlignmentOptions.MidlineLeft);
        panel.AddImage(new Info("image", 400, 0, 225, 225), challenge.Icon);

        if (challenge.isSelected == false)
        {
            var button = panel.AddButton(new Info("ChallengeIcon", 780, 0, 500, 150), VanillaSprites.GreenBtnLong, new System.Action(() =>
            {
                challenge.Edit();

                foreach (var challengeSelect in GetContent<ChallengeTemplate>())
                {
                    challengeSelect.isSelected = false;
                }

                challenge.isSelected = true;
                LoadChallengesPanels();
            }));
            ModHelperText select = button.AddText(new Info("select", 0, 0, 700, 160), "Select", 80);
        }
        else
        {
            var button = panel.AddButton(new Info("ChallengeIcon", 780, 0, 500, 150), VanillaSprites.RedBtnLong, new System.Action(() => { }));
            ModHelperText select = button.AddText(new Info("select", 0, 0, 700, 160), "Active", 80);
        }

        var description = panel.AddScrollPanel(new Info("ChallengeDesc", -300, 0, 1000, 250), RectTransform.Axis.Vertical, VanillaSprites.MainBGPanelHighlightTab);
        ModHelperText descriptionText = ModHelperText.Create(new Info("DescPanel", 0, 0, 900, 800), "\n" + challenge.Description, 50, TextAlignmentOptions.TopLeft);
        description.AddScrollContent(descriptionText);

        return panel;
    }
}
