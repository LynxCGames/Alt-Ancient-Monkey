using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using WeaponPacks;

namespace AncientMonkey;

public class AbilityPanels : BloonsTD6Mod
{
    public static void NewAbilityPanel(RectTransform rect, Tower tower)
    {
        if (mod.abilityActive == false)
        {
            mod.abilityActive = true;
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

            // Ability Select Panel
            float abilityPanelWidth = 700;
            float abilityPanelX = 400;
            float panelWidth = (mod.abilitySlots * abilityPanelWidth) + 100;

            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 300, panelWidth, 1200), sprites[mod.level]);
            MenuUi.abilityMenu = panel.AddComponent<MenuUi>();
            panel.AddText(new Info("selectAb", 0, 600, 1000, 120), "Select New Ability", 100);


            // Ability Panels
            MenuUi[] panelArray = new MenuUi[mod.abilitySlots];
            for (int i = 0; i < mod.abilitySlots; i++)
            {
                ModHelperPanel abPanel = panel.AddPanel(new Info("abPanel", abilityPanelX, 600, 500, 800, new Vector2()), VanillaSprites.BrownInsertPanel);
                abilityPanelX += abilityPanelWidth;

                ModHelperPanel rarityPanel = abPanel.AddPanel(new Info("rarityPanel", 0, 0, 600, 1000), VanillaSprites.GreyInsertPanel);
                rarityPanel.AddText(new Info("abilityStack", 0, 500, 600, 100), "", 80, Il2CppTMPro.TextAlignmentOptions.Right);
                rarityPanel.AddText(new Info("abilityRarity", 0, 400, 600, 100), "", 80);
                rarityPanel.AddText(new Info("abilityName", 0, 225, 600, 150), "", 60, Il2CppTMPro.TextAlignmentOptions.Top);
                rarityPanel.AddImage(new Info("abilityImage", 0, -100, 400), VanillaSprites.SharpShotsUpgradeIcon);
                ModHelperButton abSelect = rarityPanel.AddButton(new Info("abilitySelect", 0, -400, 400, 150), VanillaSprites.GreenBtnLong, null);
                abSelect.AddText(new Info("abBtn", 0, 0, 400, 150), "Select", 80);

                panelArray[i] = abPanel.AddComponent<MenuUi>();
            }
            MenuUi.abilityPanels = panelArray;


            // Ability Note
            ModHelperPanel notesPanel = panel.AddPanel(new Info("abilityNotesPanel", 0, -1000, 1600, 600), sprites[mod.level]);
            ModHelperText notesName = notesPanel.AddText(new Info("notesText", 0, 300, 1600, 150), "Quick Note on Abilities", 90);
            ModHelperText notesText = notesPanel.AddText(new Info("notesText", 0, -50, 1500, 400), 
                "If abilities do not show up on the bottom of the screen, place any tower down to update the game.", 80, Il2CppTMPro.TextAlignmentOptions.TopLeft);
            MenuUi.abilityNotePanel = notesPanel.AddComponent<MenuUi>();

            NewAbilityRoll(tower);
        }
        else
        {
            MenuUi.abilityMenu.Show();
            mod.panelOpen = true;
            NewAbilityRoll(tower);
        }
    }

    public static void NewAbilityRoll(Tower tower)
    {
        for (int i = 0; i < mod.abilitySlots; i++)
        {
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();
            float rarityNum = rnd.Next(1, 100);
            rarityNum += mod.luck / 2;
            if (rarityNum > 100)
            {
                rarityNum = 100;
            }

            List<AbilityTemplate> abilityList = new List<AbilityTemplate>();
            foreach (var raritySelect in ModContent.GetContent<AbilityRarityTemplate>())
            {
                if (rarityNum > raritySelect.minValue && rarityNum <= raritySelect.maxValue && mod.level >= raritySelect.Level)
                {
                    raritySelect.AbilityList(abilityList);
                }
            }

            var num = rnd.Next(0, abilityList.Count);
            var ability = abilityList[num];
            var rarity = ability.AbilityRarity;
            var name = ability.AbilityName;
            var img = ability.Icon;

            var panel = MenuUi.abilityPanels[i].GetComponent<ModHelperPanel>().GetComponentFromChildrenByName<ModHelperPanel>("rarityPanel");
            panel.Background.sprite = MenuUi.panelSprites[ability.SandboxIndex].GetComponent<ModHelperPanel>().Background.sprite;
            panel.SetInfo(new Info("rarityPanel", 0, 0, 600, 1000));
            panel.GetComponentFromChildrenByName<ModHelperText>("abilityStack").Text.text = $"{ability.stackIndex}";
            panel.GetComponentFromChildrenByName<ModHelperText>("abilityRarity").Text.text = $"{rarity}";
            panel.GetComponentFromChildrenByName<ModHelperText>("abilityName").Text.text = name;
            if (ability.CustomIcon != null)
            {
                panel.GetComponentFromChildrenByName<ModHelperImage>("abilityImage").Image.sprite = ability.CustomIcon;
            }
            else
            {
                panel.GetComponentFromChildrenByName<ModHelperImage>("abilityImage").Image.LoadSprite(img);
            }            
                        
            panel.GetComponentFromChildrenByName<ModHelperButton>("abilitySelect").Button.SetOnClick(new Function(() =>
            {
                MenuUi.abilityMenu.Hide();
                AbilityMethods.AbilitySelected(ability, tower);
            }));
        }
    }
}