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

public class WeaponPanels : BloonsTD6Mod
{
    public static void NewWeaponPanel(RectTransform rect, Tower tower)
    {
        if (mod.weaponActive == false)
        {
            mod.weaponActive = true;
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

            // Weapon Select Panel
            float weaponPanelWidth = 700;
            float weaponPanelX = 400;
            float panelWidth = (mod.weaponSlots * weaponPanelWidth) + 100;

            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 300, panelWidth, 1200), sprites[mod.level]);
            MenuUi.weaponMenu = panel.AddComponent<MenuUi>();
            panel.AddText(new Info("selectWpn", 0, 600, 1000, 120), "Select New Weapon", 100);


            // Weapon Panels
            MenuUi[] panelArray = new MenuUi[mod.weaponSlots];
            for (int i = 0; i < mod.weaponSlots; i++)
            {
                ModHelperButton wpnPanel = panel.AddButton(new Info("wpnPanel", weaponPanelX, 600, 500, 800, new Vector2()), VanillaSprites.PortraitContainerParagon, null);
                weaponPanelX += weaponPanelWidth;

                ModHelperPanel gildedPanel = wpnPanel.AddPanel(new Info("gildedPanel", 0, 0, 450, 850), VanillaSprites.PortraitContainerParagon);
                ModHelperPanel rarityPanel = gildedPanel.AddPanel(new Info("rarityPanel", 0, 0, 600, 1000), VanillaSprites.GreyInsertPanel);
                rarityPanel.AddText(new Info("weaponStack", 0, 500, 600, 100), "", 80, Il2CppTMPro.TextAlignmentOptions.Right);
                rarityPanel.AddText(new Info("weaponRarity", 0, 400, 600, 100), "", 80);
                rarityPanel.AddText(new Info("weaponName", 0, 225, 600, 150), "", 60, Il2CppTMPro.TextAlignmentOptions.Top);
                rarityPanel.AddImage(new Info("weaponImage", 0, -100, 400), VanillaSprites.SharpShotsUpgradeIcon);
                rarityPanel.AddImage(new Info("weaponIsCamo", -175, -400, 100), VanillaSprites.CamoBloonIcon);
                rarityPanel.AddImage(new Info("weaponIsLead", 0, -400, 100), VanillaSprites.LeadBloonIcon);
                ModHelperPanel degreePanel = rarityPanel.AddPanel(new Info("weaponIsGilded", 175, -400, 200), VanillaSprites.UpgradeContainerParagon);
                degreePanel.AddText(new Info("degree", 200), "", 70);
                rarityPanel.AddImage(new Info("gildedEffect", -175, -500, 100), VanillaSprites.SharpShotsUpgradeIcon);

                panelArray[i] = wpnPanel.AddComponent<MenuUi>();
            }
            MenuUi.weaponPanels = panelArray;


            // Weapon Notes
            ModHelperPanel notesPanel = panel.AddPanel(new Info("weaponNotesPanel", 0, -1000, 1600, 600), sprites[mod.level]);
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
        else
        {
            MenuUi.weaponMenu.Show();
            MenuUi.weaponNotesName.GetComponent<ModHelperText>().Text.text = "Select a weapon";
            mod.panelOpen = true;
            NewWeaponRoll(tower);
        }
    }

    public static void NewWeaponRoll(Tower tower)
    {
        MenuUi.weaponNotesText.GetComponent<ModHelperText>().Text.text = "";
        MenuUi.weaponSelectBtn.GetComponent<ModHelperButton>().Button.SetOnClick(new Function(() => { }));

        for (int i = 0; i < mod.weaponSlots; i++)
        {
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();
            float rarityNum = rnd.Next(1, 100);
            rarityNum += mod.luck / 2;
            if (rarityNum > 100)
            {
                rarityNum = 100;
            }

            List<WeaponTemplate> weaponList = new List<WeaponTemplate>();
            foreach (var raritySelect in ModContent.GetContent<WeaponRarityTemplate>())
            {
                if (rarityNum > raritySelect.minValue && rarityNum <= raritySelect.maxValue && mod.level >= raritySelect.Level)
                {
                    raritySelect.WeaponList(weaponList);
                }
            }

            var gildNum = rnd.Next(0, 100);

            var num = rnd.Next(0, weaponList.Count);
            var weapon = weaponList[num];
            var rarity = weapon.WeaponRarity;
            var name = weapon.WeaponName;
            var img = weapon.Icon;

            if (gildNum < mod.gildedChance)
            {
                var degree = rnd.Next(0, 21);
                degree += (int)Mathf.Round(mod.luck / 3) - 10;
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
                panel.Background.sprite = MenuUi.panelSprites[weapon.SandboxIndex].GetComponent<ModHelperPanel>().Background.sprite;
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
                        WeaponMethods.GildedSelected(weapon, tower, effect, degree);
                    }));
                }));
            }
            else
            {
                var gildedPanel = MenuUi.weaponPanels[i].GetComponent<ModHelperButton>().GetComponentFromChildrenByName<ModHelperPanel>("gildedPanel");
                gildedPanel.SetInfo(new Info("gildedPanel", 0, 0, 450, 850));

                var panel = gildedPanel.GetComponentFromChildrenByName<ModHelperPanel>("rarityPanel");
                panel.Background.sprite = MenuUi.panelSprites[weapon.SandboxIndex].GetComponent<ModHelperPanel>().Background.sprite;
                panel.SetInfo(new Info("rarityPanel", 0, 0, 600, 1000));
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
                        WeaponMethods.WeaponSelected(weapon, tower);
                    }));
                }));
            }
        }
    }
}