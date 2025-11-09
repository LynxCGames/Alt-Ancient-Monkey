using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;

namespace AncientMonkey;

public class StrengthPanels : BloonsTD6Mod
{
    public static void NewStrengthPanel(RectTransform rect, Tower tower)
    {
        if (mod.strengthActive == false)
        {
            mod.strengthActive = true;
            mod.panelOpen = true;
            MenuUi.upgradeMenu.Hide();

            string[] sprites = [
                VanillaSprites.PortraitContainerParagon,
                VanillaSprites.BrownInsertPanel,
                VanillaSprites.BlueInsertPanel,
                VanillaSprites.MainBgPanelParagon,
                VanillaSprites.MainBGPanelYellow,
                VanillaSprites.MainBgPanelWhiteSmall,
                VanillaSprites.MainBGPanelSilver,
                VanillaSprites.MainBgPanelHematite,
                VanillaSprites.GreenToggleUiMain,
            ];

            // Strength Select Panel
            float strengthPanelWidth = 700;
            float strengthPanelX = 400;
            float panelWidth = (mod.strengthSlots * strengthPanelWidth) + 100;

            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 300, panelWidth, 1200), sprites[mod.level]);
            MenuUi.strengthMenu = panel.AddComponent<MenuUi>();
            panel.AddText(new Info("selectStr", 0, 600, 1500, 120), "Select Strength Card", 100);


            // Strength Panels
            MenuUi[] panelArray = new MenuUi[mod.strengthSlots];
            for (int i = 0; i < mod.strengthSlots; i++)
            {
                ModHelperPanel strPanel = panel.AddPanel(new Info("strPanel", strengthPanelX, 600, 500, 800, new Vector2()), VanillaSprites.BrownInsertPanel);
                strengthPanelX += strengthPanelWidth;

                ModHelperPanel rarityPanel = strPanel.AddPanel(new Info("rarityPanel", 0, 0, 600, 1000), VanillaSprites.GreyInsertPanel);
                rarityPanel.AddText(new Info("strengthStack", 0, 500, 600, 100), "", 80, Il2CppTMPro.TextAlignmentOptions.Right);
                rarityPanel.AddText(new Info("strengthRarity", 0, 400, 600, 100), "", 80);
                rarityPanel.AddText(new Info("strengthName", 0, 225, 600, 150), "", 60, Il2CppTMPro.TextAlignmentOptions.Top);
                rarityPanel.AddText(new Info("strengthDesc", 0, -50, 500), "", 55, Il2CppTMPro.TextAlignmentOptions.Left);
                ModHelperButton strSelect = rarityPanel.AddButton(new Info("strengthSelect", 0, -400, 400, 150), VanillaSprites.GreenBtnLong, null);
                strSelect.AddText(new Info("strBtn", 0, 0, 400, 150), "Select", 80);

                panelArray[i] = strPanel.AddComponent<MenuUi>();
            }
            MenuUi.strengthPanels = panelArray;


            // Strength Note
            ModHelperPanel notesPanel = panel.AddPanel(new Info("strengthNotesPanel", 0, -1000, 1600, 600), sprites[mod.level]);
            ModHelperText notesName = notesPanel.AddText(new Info("notesText", 0, 300, 1600, 150), "Quick Note on Strength Cards", 90);
            ModHelperText notesText = notesPanel.AddText(new Info("notesText", 0, -50, 1500, 400),
                "Strength cards only affect the weapons currently on the tower. Weapon attack speed can scale infinitely.", 70, Il2CppTMPro.TextAlignmentOptions.TopLeft);
            MenuUi.strengthNotePanel = notesPanel.AddComponent<MenuUi>();

            NewStrengthRoll(tower);
        }
        else
        {
            MenuUi.strengthMenu.Show();
            mod.panelOpen = true;
            NewStrengthRoll(tower);
        }
    }

    public static void NewStrengthRoll(Tower tower)
    {
        for (int i = 0; i < mod.strengthSlots; i++)
        {
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();
            float rarityNum = rnd.Next(1, 100);
            rarityNum += mod.luck / 2;
            if (rarityNum > 100)
            {
                rarityNum = 100;
            }

            List<StrengthTemplate> strengthList = new List<StrengthTemplate>();
            foreach (var raritySelect in ModContent.GetContent<StrengthRarityTemplate>())
            {
                if (rarityNum > raritySelect.minValue && rarityNum <= raritySelect.maxValue && mod.level >= raritySelect.Level)
                {
                    raritySelect.StrengthList(strengthList);
                }
            }

            var num = rnd.Next(0, strengthList.Count);
            var strength = strengthList[num];
            var rarity = strength.StrengthRarity;
            var name = strength.StrengthName;
            var description = strength.Description;

            var panel = MenuUi.strengthPanels[i].GetComponent<ModHelperPanel>().GetComponentFromChildrenByName<ModHelperPanel>("rarityPanel");
            panel.Background.sprite = MenuUi.panelSprites[strength.Index].GetComponent<ModHelperPanel>().Background.sprite;
            panel.SetInfo(new Info("rarityPanel", 0, 0, 600, 1000));
            panel.GetComponentFromChildrenByName<ModHelperText>("strengthRarity").Text.text = $"{rarity}";
            panel.GetComponentFromChildrenByName<ModHelperText>("strengthName").Text.text = name;
            panel.GetComponentFromChildrenByName<ModHelperText>("strengthDesc").Text.text = description;

            panel.GetComponentFromChildrenByName<ModHelperButton>("strengthSelect").Button.SetOnClick(new Function(() =>
            {
                MenuUi.strengthMenu.Hide();
                strength.EditTower(tower);
            }));
        }
    }
}