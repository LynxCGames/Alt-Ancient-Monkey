using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api;
using System.Collections.Generic;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using WeaponPacks;

namespace AncientMonkey;

public class WeaponStart : BloonsTD6Mod
{
    public static void NewWeaponStart(RectTransform rect, Tower tower)
    {
        mod.panelOpen = true;

        // Weapon Select Panel
        float weaponPanelWidth = 700;
        float weaponPanelX = 400;
        float panelWidth = (mod.weaponSlots * weaponPanelWidth) + 100;

        ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 300, panelWidth, 1200), VanillaSprites.BrownInsertPanel);
        MenuUi.weaponMenu = panel.AddComponent<MenuUi>();
        panel.AddText(new Info("selectWpn", 0, 600, 1000, 120), "Select New Weapon", 100);


        // Weapon Panels
        MenuUi[] panelArray = new MenuUi[mod.weaponSlots];
        for (int i = 0; i < mod.weaponSlots; i++)
        {
            ModHelperButton wpnPanel = panel.AddButton(new Info("wpnPanel", weaponPanelX, 600, 500, 800, new Vector2()), VanillaSprites.PortraitContainerParagon, null);
            weaponPanelX += weaponPanelWidth;

            ModHelperPanel gildedPanel = wpnPanel.AddPanel(new Info("gildedPanel", 0, 0, 550, 950), VanillaSprites.PortraitContainerParagon);

            if (mod.superWeapons == true)
            {
                ModHelperPanel rarityPanel = gildedPanel.AddPanel(new Info("rarityPanel", 0, 0, 600, 1000), VanillaSprites.MainBGPanelYellow);
                rarityPanel.AddText(new Info("weaponStack", 0, 500, 600, 100), "", 80, Il2CppTMPro.TextAlignmentOptions.Right);
                rarityPanel.AddText(new Info("weaponRarity", 0, 400, 600, 100), "", 80);
                rarityPanel.AddText(new Info("weaponName", 0, 225, 600, 150), "", 60, Il2CppTMPro.TextAlignmentOptions.Top);
                rarityPanel.AddImage(new Info("weaponImage", 0, -100, 400), "");
                rarityPanel.AddImage(new Info("weaponIsCamo", -175, -400, 100), VanillaSprites.CamoBloonIcon);
                rarityPanel.AddImage(new Info("weaponIsLead", 0, -400, 100), VanillaSprites.LeadBloonIcon);
                ModHelperPanel degreePanel = rarityPanel.AddPanel(new Info("weaponIsGilded", 175, -400, 200), VanillaSprites.UpgradeContainerParagon);
                degreePanel.AddText(new Info("degree", 200), "", 70);
                rarityPanel.AddImage(new Info("gildedEffect", -175, -500, 100), VanillaSprites.SharpShotsUpgradeIcon);
            }
            else
            {
                ModHelperPanel rarityPanel = gildedPanel.AddPanel(new Info("rarityPanel", 0, 0, 600, 1000), VanillaSprites.GreyInsertPanel);
                rarityPanel.AddText(new Info("weaponStack", 0, 500, 600, 100), "", 80, Il2CppTMPro.TextAlignmentOptions.Right);
                rarityPanel.AddText(new Info("weaponRarity", 0, 400, 600, 100), "", 80);
                rarityPanel.AddText(new Info("weaponName", 0, 225, 600, 150), "", 60, Il2CppTMPro.TextAlignmentOptions.Top);
                rarityPanel.AddImage(new Info("weaponImage", 0, -100, 400), "");
                rarityPanel.AddImage(new Info("weaponIsCamo", -175, -400, 100), VanillaSprites.CamoBloonIcon);
                rarityPanel.AddImage(new Info("weaponIsLead", 0, -400, 100), VanillaSprites.LeadBloonIcon);
                ModHelperPanel degreePanel = rarityPanel.AddPanel(new Info("weaponIsGilded", 175, -400, 200), VanillaSprites.UpgradeContainerParagon);
                degreePanel.AddText(new Info("degree", 200), "", 70);
                rarityPanel.AddImage(new Info("gildedEffect", -175, -500, 100), VanillaSprites.SharpShotsUpgradeIcon);
            }

            panelArray[i] = wpnPanel.AddComponent<MenuUi>();
        }
        MenuUi.weaponPanels = panelArray;


        // Weapon Notes
        ModHelperPanel notesPanel = panel.AddPanel(new Info("weaponNotesPanel", 0, -1000, 1600, 600), VanillaSprites.BrownInsertPanel);
        ModHelperText notesName = notesPanel.AddText(new Info("notesText", 0, 300, 1600, 150), "Select a weapon", 90);
        ModHelperText notesText = notesPanel.AddText(new Info("notesText", 0, 0, 1500, 400), "", 80, Il2CppTMPro.TextAlignmentOptions.TopLeft);

        MenuUi.weaponNotePanel = notesPanel.AddComponent<MenuUi>();
        MenuUi.weaponNotesName = notesName.AddComponent<MenuUi>();
        MenuUi.weaponNotesText = notesText.AddComponent<MenuUi>();

        ModHelperButton wpnSelect = notesPanel.AddButton(new Info("exit", 0, -300, 400, 150), VanillaSprites.GreenBtnLong, null);
        wpnSelect.AddText(new Info("wpnBtn", 0, 0, 400, 150), "Select", 80);
        MenuUi.weaponSelectBtn = wpnSelect.AddComponent<MenuUi>();

        NewWeaponRoll(tower);
    }

    public static void NewWeaponRoll(Tower tower)
    {
        MenuUi.weaponNotesText.GetComponent<ModHelperText>().Text.text = "";
        MenuUi.weaponSelectBtn.GetComponent<ModHelperButton>().Button.SetOnClick(new Function(() => { }));

        Il2CppSystem.Random rnd = new Il2CppSystem.Random();

        for (int i = 0; i < mod.weaponSlots; i++)
        {
            List<WeaponTemplate> weaponList = new List<WeaponTemplate>();
            foreach (var raritySelect in ModContent.GetContent<WeaponRarityTemplate>())
            {
                if (mod.superWeapons == true)
                {
                    if (raritySelect.WeaponRarity == WeaponRarityTemplate.Rarity.Legendary)
                    {
                        raritySelect.WeaponList(weaponList);
                    }
                }
                else
                {
                    if (raritySelect.WeaponRarity == WeaponRarityTemplate.Rarity.Common)
                    {
                        raritySelect.WeaponList(weaponList);
                    }
                }
            }

            var num = rnd.Next(0, weaponList.Count);
            var weapon = weaponList[num];
            var rarity = weapon.WeaponRarity;
            var name = weapon.WeaponName;
            var img = weapon.Icon;

            if (mod.foolsGold == true | mod.blingedOut == true)
            {
                var degree = rnd.Next(0, 20);
                degree += (int)Mathf.Round(mod.luck / 3) - 9;
                if (degree <= 0) { degree -= 1; }
                if (degree > 10) { degree = 10; }

                var effectNum = rnd.Next(0, weapon.GildedEffects.Length);
                var effect = weapon.GildedEffects[effectNum];
                var effectDescription = "";
                var effectImage = "";

                foreach (var gildedEffect in ModContent.GetContent<GildedTemplate>())
                {
                    if (gildedEffect.EffectName == effect)
                    {
                        effectDescription = gildedEffect.Description;
                        effectImage = gildedEffect.Icon;
                    }
                }

                var gildedPanel = MenuUi.weaponPanels[i].GetComponent<ModHelperButton>().GetComponentFromChildrenByName<ModHelperPanel>("gildedPanel");
                gildedPanel.SetInfo(new Info("gildedPanel", 0, 0, 600, 1000));

                var panel = gildedPanel.GetComponentFromChildrenByName<ModHelperPanel>("rarityPanel");
                panel.SetInfo(new Info("rarityPanel", 0, 0, 550, 950));
                panel.GetComponentFromChildrenByName<ModHelperText>("weaponStack").Text.text = $"{weapon.stackIndex}";
                panel.GetComponentFromChildrenByName<ModHelperText>("weaponRarity").Text.text = $"{rarity}";
                panel.GetComponentFromChildrenByName<ModHelperText>("weaponName").Text.text = "Gilded " + name;
                if (weapon.CustomIcon != null)
                {
                    panel.GetComponentFromChildrenByName<ModHelperImage>("weaponImage").Image.sprite = weapon.CustomIcon;
                }
                else
                {
                    panel.GetComponentFromChildrenByName<ModHelperImage>("weaponImage").Image.LoadSprite(img);
                }

                panel.GetComponentFromChildrenByName<ModHelperImage>("weaponIsCamo").Hide();
                panel.GetComponentFromChildrenByName<ModHelperImage>("weaponIsLead").Hide();

                if (weapon.IsCamo && mod.mastery == false)
                {
                    panel.GetComponentFromChildrenByName<ModHelperImage>("weaponIsCamo").Show();
                }
                if (weapon.IsLead && mod.mastery == false)
                {
                    panel.GetComponentFromChildrenByName<ModHelperImage>("weaponIsLead").Show();
                }
                panel.GetComponentFromChildrenByName<ModHelperPanel>("weaponIsGilded").Show();
                panel.GetComponentFromChildrenByName<ModHelperPanel>("weaponIsGilded").GetComponentFromChildrenByName<ModHelperText>("degree").Text.text = $"{degree}";
                panel.GetComponentFromChildrenByName<ModHelperImage>("gildedEffect").Show();
                panel.GetComponentFromChildrenByName<ModHelperImage>("gildedEffect").Image.SetSprite(effectImage);

                MenuUi.weaponPanels[i].GetComponent<ModHelperButton>().Button.SetOnClick(new Function(() =>
                {
                    MenuUi.weaponNotesName.GetComponent<ModHelperText>().Text.text = "Gilded " + name;
                    MenuUi.weaponNotesText.GetComponent<ModHelperText>().Text.text = weapon.Notes + $"{effect}: {effectDescription}";

                    MenuUi.weaponSelectBtn.GetComponent<ModHelperButton>().Button.SetOnClick(new Function(() =>
                    {
                        MenuUi.weaponMenu.Hide();
                        WeaponStartSelected(weapon, tower, true, effect, degree);
                    }));
                }));
            }
            else
            {
                var gildedPanel = MenuUi.weaponPanels[i].GetComponent<ModHelperButton>().GetComponentFromChildrenByName<ModHelperPanel>("gildedPanel");
                gildedPanel.SetInfo(new Info("gildedPanel", 0, 0, 550, 950));

                var panel = gildedPanel.GetComponentFromChildrenByName<ModHelperPanel>("rarityPanel");
                panel.GetComponentFromChildrenByName<ModHelperText>("weaponStack").Text.text = $"{weapon.stackIndex}";
                panel.GetComponentFromChildrenByName<ModHelperText>("weaponRarity").Text.text = $"{rarity}";
                panel.GetComponentFromChildrenByName<ModHelperText>("weaponName").Text.text = name;
                if (weapon.CustomIcon != null)
                {
                    panel.GetComponentFromChildrenByName<ModHelperImage>("weaponImage").Image.sprite = weapon.CustomIcon;
                }
                else
                {
                    panel.GetComponentFromChildrenByName<ModHelperImage>("weaponImage").Image.LoadSprite(img);
                }

                panel.GetComponentFromChildrenByName<ModHelperImage>("weaponIsCamo").Hide();
                panel.GetComponentFromChildrenByName<ModHelperImage>("weaponIsLead").Hide();
                panel.GetComponentFromChildrenByName<ModHelperPanel>("weaponIsGilded").Hide();
                panel.GetComponentFromChildrenByName<ModHelperImage>("gildedEffect").Hide();

                if (weapon.IsCamo && mod.mastery == false)
                {
                    panel.GetComponentFromChildrenByName<ModHelperImage>("weaponIsCamo").Show();
                }
                if (weapon.IsLead && mod.mastery == false)
                {
                    panel.GetComponentFromChildrenByName<ModHelperImage>("weaponIsLead").Show();
                }

                MenuUi.weaponPanels[i].GetComponent<ModHelperButton>().Button.SetOnClick(new Function(() =>
                {
                    MenuUi.weaponNotesName.GetComponent<ModHelperText>().Text.text = name;
                    MenuUi.weaponNotesText.GetComponent<ModHelperText>().Text.text = weapon.Notes;

                    MenuUi.weaponSelectBtn.GetComponent<ModHelperButton>().Button.SetOnClick(new Function(() =>
                    {
                        MenuUi.weaponMenu.Hide();
                        WeaponStartSelected(weapon, tower, false, "", 0);
                    }));
                }));
            }
        }
    }

    public static void WeaponStartSelected(WeaponTemplate weapon, Tower tower, bool gilded, string effect, int degree)
    {
        mod.panelOpen = false;
        InGame game = InGame.instance;
        RectTransform rect = game.uiRect;

        weapon.stackIndex += 1;
        weapon.EditTower(tower, gilded, effect, degree);

        if (mod.oneSlot == true) { mod.weaponSlots = 1; }
        else { mod.weaponSlots = 3; }

        if (mod.isSelected == true)
        {
            MenuUi.CreateUpgradeMenu(rect, tower);
        }
    }
}