using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppTMPro;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using System;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons;


namespace AncientMonkey;

public class ExtrasPanels : BloonsTD6Mod
{
    public static void ExtrasPanel(RectTransform rect, Tower tower)
    {
        mod.panelOpen = true;

        if (mod.extrasActive == false)
        {
            mod.extrasActive = true;
            mod.panelOpen = true;
            MenuUi.upgradeMenu.Hide();

            // Extras Panel
            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", -1525, 0, 700, 1050), VanillaSprites.BrownInsertPanel);
            MenuUi.extrasMenu = panel.AddComponent<MenuUi>();
            ModHelperPanel indicator = panel.AddPanel(new Info("indicatorPanel", 0, 0, 0), VanillaSprites.BlueBtnSquare);

            panel.AddText(new Info("helpText", 0, 425, 700, 100), "Gilded Weapons", 70);
            panel.AddText(new Info("helpText", 0, -75, 650, 800), "Gilded weapons are a new variant of existing weapons. Any time a new weapon is rolled, it has a chance of being gilded. " +
                "Gilded variants have a degree and a randomized effect. A positive degree increases the stats of the weapon by 10% per degree level. A negative degree decreases the stats of " +
                "the weapon by 10% per degree level. A zero degree neither increases nor decreases the weapon's stats. Luck does NOT affect the chance for a weapon to be gilded but does " +
                "increase the chance for a positive degree.", 40, TextAlignmentOptions.TopLeft);

            ModHelperPanel slotsPanel = panel.AddPanel(new Info("slotsPanel", 950, 300, 1100, 1600), VanillaSprites.BrownInsertPanel);
            ModHelperPanel luckPanel = panel.AddPanel(new Info("luckPanel", 2100, 300, 1100, 1600), VanillaSprites.BrownInsertPanel);
            ModHelperPanel lagPanel = panel.AddPanel(new Info("lagPanel", 0, -850, 700, 400), VanillaSprites.BrownInsertPanel);

            ModHelperButton exit = luckPanel.AddButton(new Info("exit", 500, 775, 135), VanillaSprites.RedBtn, new Action(() => {
                tower.SetSelectionBlocked(false);
                panel.Hide();
                mod.panelOpen = false;
                if (mod.isSelected == true)
                {
                    MenuUi.CreateUpgradeMenu(rect, tower);
                }
            }));
            exit.AddText(new Info("x", 0, 0, 135, 135), "X", 80);


            // Lag Button
            lagPanel.AddText(new Info("lagText", 0, 150, 700, 100), "Lag Button", 80);
            lagPanel.AddText(new Info("lagText", 0, -75, 650, 300), "For all current weapons:\nHalves attack speed but doubles damage. Repeatable.", 43, TextAlignmentOptions.TopLeft);
            ModHelperButton lagButton = lagPanel.AddButton(new Info("lagButton", 0, -200, 500, 150), VanillaSprites.BlueBtnLong, new Action(() => {
                var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

                foreach (var weapon in towerModel.GetAttackModels())
                {
                    weapon.GetDescendants<WeaponModel>().ForEach(model => model.rate *= 2);
                    weapon.GetDescendants<DamageModel>().ForEach(model => model.damage *= 2);
                }

                foreach (var weapon in towerModel.GetBehaviors<TowerCreateTowerModel>())
                {
                    weapon.towerModel.GetDescendants<WeaponModel>().ForEach(model => model.rate *= 2);
                    weapon.towerModel.GetDescendants<DamageModel>().ForEach(model => model.damage *= 2);
                }

                tower.UpdateRootModel(towerModel);
            }));
            lagButton.AddText(new Info("lagButtonText", 0, 0, 500, 150), "Reduce Lag", 60);


            // Upgrade Panel
            ModHelperPanel upgradePanel = panel.AddPanel(new Info("upgradePanel", 1525, -850, 2250, 600), VanillaSprites.BrownInsertPanel);
            ModHelperText upgradeText = upgradePanel.AddText(new Info("upgradeTitle", 0, 250, 2000, 100), $"Tower Upgrade: ${mod.upgradeCost}", 80);
            ModHelperText upgradeRewardLeft = upgradePanel.AddText(new Info("upgradeTextLeft", -525, 0, 1050, 350), "" +
                "- Unlocks Godly weapons and abilities\n" +
                "- Unlocks more upgrade slots\n" +
                "- Removes all non-gilded Common weapons from the tower", 60, TextAlignmentOptions.Left);
            ModHelperText upgradeRewardRight = upgradePanel.AddText(new Info("upgradeTextRight", 525, 0, 1050, 350), "" +
                "- Increases the maximum Gilded Chance upgrade\n" +
                "- Upgrades luck once for free\n" +
                "- Resets the cost of all upgrades\n" +
                "- Removes Common upgrades", 60, TextAlignmentOptions.Left);

            ModHelperButton upgradeBtn = upgradePanel.AddButton(new Info("upgradeButton", 0, -300, 600, 150), VanillaSprites.GreenBtnLong, new System.Action(() => {
                InGame game = InGame.instance;

                if (game.GetCash() >= mod.upgradeCost && mod.level == 2)
                {
                    game.AddCash(-mod.upgradeCost);
                    tower.worth += MathF.Round(mod.upgradeCost * 0.7f);
                    upgradeRewardLeft.Text.text = "No more upgrades at this time";
                    upgradeRewardRight.Text.text = "";
                    upgradeText.Text.text = "Tower Upgrade: Maxed";
                    OmegaUpgrade.UpgradeTower();
                }

                if (game.GetCash() >= mod.upgradeCost && mod.level == 1)
                {
                    game.AddCash(-mod.upgradeCost);
                    tower.worth += MathF.Round(mod.upgradeCost * 0.7f);
                    mod.upgradeCost = 1000000;
                    upgradeRewardLeft.Text.text =
                        "- Unlocks Omega weapons\n" +
                        "- Unlocks more upgrade slots\n" +
                        "- Removes all non-gilded Rare weapons from the tower";
                    upgradeRewardRight.Text.text =
                        "- Increases the maximum Gilded Chance upgrade\n" +
                        "- Resets the cost of all upgrades\n" +
                        "- Removes Rare upgrades";
                    upgradeText.Text.text = $"Tower Upgrade: ${mod.upgradeCost}";
                    GodlyUpgrade.UpgradeTower();
                }
            }));
            upgradeBtn.AddText(new Info("upgrade", 0, 0, 600, 150), "Upgrade", 80);


            // New Weapon Slots
            slotsPanel.AddText(new Info("weaponText", 0, 680, 1000, 150), "Weapon Slots", 80, TextAlignmentOptions.Left);
            ModHelperPanel weaponSlotInd1 = slotsPanel.AddPanel(new Info("weaponSlotPanel", 25, 520, 100), VanillaSprites.RedBtnSquare);
            ModHelperPanel weaponSlotInd2 = slotsPanel.AddPanel(new Info("weaponSlotPanel", 150, 520, 100), VanillaSprites.RedBtnSquare);
            ModHelperPanel weaponSlotInd3 = slotsPanel.AddPanel(new Info("weaponSlotPanel", 275, 520, 100), VanillaSprites.RedBtnSquare);

            ModHelperButton weaponSlotBtn = slotsPanel.AddButton(new Info("weaponSlotBtn", -300, 520, 400, 150), VanillaSprites.GreenBtnLong, new System.Action(() => {
                InGame game = InGame.instance;

                if (game.GetCash() >= mod.weaponSlotCost && mod.weaponSlots - 3 < mod.level && mod.weaponSlots < 6 && mod.oneSlot == false)
                {
                    game.AddCash(-mod.weaponSlotCost);
                    tower.worth += MathF.Round(mod.weaponSlotCost * 0.7f);
                    mod.weaponSlotCost = MathF.Round(mod.weaponSlotCost * 1.5f);
                    mod.weaponSlots += 1;
                    mod.weaponActive = false;

                    if (mod.weaponSlots - 3 == 1) { weaponSlotInd1.Background.sprite = indicator.Background.sprite; }
                    else if (mod.weaponSlots - 3 == 2) { weaponSlotInd2.Background.sprite = indicator.Background.sprite; }
                    else if (mod.weaponSlots - 3 == 3) { weaponSlotInd3.Background.sprite = indicator.Background.sprite; }

                    if (mod.weaponSlots - 3 >= mod.level | mod.weaponSlots >= 6)
                    {
                        MenuUi.weaponSlotText.GetComponent<ModHelperText>().Text.text = "Upgrade Tower to Unlock More Slots";
                    }
                    else
                    {
                        MenuUi.weaponSlotText.GetComponent<ModHelperText>().Text.text = $"Additional Weapon Slot: ${mod.weaponSlotCost}";
                    }
                }
            }));
            weaponSlotBtn.AddText(new Info("weaponBtnText", 0, 0, 400, 150), "Buy", 80);

            ModHelperText wpnSlotCostText = slotsPanel.AddText(new Info("weaponSlotText", 0, 350, 1000, 150), $"", 50, TextAlignmentOptions.Left);
            MenuUi.weaponSlotText = wpnSlotCostText.AddComponent<MenuUi>();

            if (mod.oneSlot == true) { MenuUi.weaponSlotText.GetComponent<ModHelperText>().Text.text = "Additional Weapon Slot: Disabled"; }
            else { MenuUi.weaponSlotText.GetComponent<ModHelperText>().Text.text = $"Additional Weapon Slot: ${mod.weaponSlotCost}"; }


            // Ability Slots
            slotsPanel.AddText(new Info("abilityText", 0, 160, 1000, 150), "Ability Slots", 80, TextAlignmentOptions.Left);
            ModHelperPanel abilitySlotInd1 = slotsPanel.AddPanel(new Info("abilitySlotPanel", 25, 0, 100), VanillaSprites.RedBtnSquare);
            ModHelperPanel abilitySlotInd2 = slotsPanel.AddPanel(new Info("abilitySlotPanel", 150, 0, 100), VanillaSprites.RedBtnSquare);
            ModHelperPanel abilitySlotInd3 = slotsPanel.AddPanel(new Info("abilitySlotPanel", 275, 0, 100), VanillaSprites.RedBtnSquare);

            ModHelperButton abilitySlotBtn = slotsPanel.AddButton(new Info("abilitySlotBtn", -300, 0, 400, 150), VanillaSprites.GreenBtnLong, new System.Action(() => {
                InGame game = InGame.instance;

                if (game.GetCash() >= mod.abilitySlotCost && mod.abilitySlots - 2 < mod.level && mod.abilitySlots < 5 && mod.oneSlot == false)
                {
                    game.AddCash(-mod.abilitySlotCost);
                    tower.worth += MathF.Round(mod.abilitySlotCost * 0.7f);
                    mod.abilitySlotCost = MathF.Round(mod.abilitySlotCost * 1.5f);
                    mod.abilitySlots += 1;
                    mod.abilityActive = false;

                    if (mod.abilitySlots - 2 == 1) { abilitySlotInd1.Background.sprite = indicator.Background.sprite; }
                    else if (mod.abilitySlots - 2 == 2) { abilitySlotInd2.Background.sprite = indicator.Background.sprite; }
                    else if (mod.abilitySlots - 2 == 3) { abilitySlotInd3.Background.sprite = indicator.Background.sprite; }

                    if (mod.abilitySlots - 2 >= mod.level | mod.abilitySlots >= 5)
                    {
                        MenuUi.abilitySlotText.GetComponent<ModHelperText>().Text.text = "Upgrade Tower to Unlock More Slots";
                    }
                    else
                    {
                        MenuUi.abilitySlotText.GetComponent<ModHelperText>().Text.text = $"Additional Ability Slot: ${mod.abilitySlotCost}";
                    }
                }
            }));
            abilitySlotBtn.AddText(new Info("abilityBtnText", 0, 0, 400, 150), "Buy", 80);

            ModHelperText abSlotCostText = slotsPanel.AddText(new Info("abilitySlotText", 0, -160, 1000, 150), $"", 50, TextAlignmentOptions.Left);
            MenuUi.abilitySlotText = abSlotCostText.AddComponent<MenuUi>();

            if (mod.oneSlot == true) { MenuUi.abilitySlotText.GetComponent<ModHelperText>().Text.text = "Additional Ability Slot: Disabled"; }
            else { MenuUi.abilitySlotText.GetComponent<ModHelperText>().Text.text = $"Additional Ability Slot: ${mod.abilitySlotCost}"; }


            // Strength Slots
            slotsPanel.AddText(new Info("strengthText", 0, -360, 1000, 150), "Strength Slots", 80, TextAlignmentOptions.Left);
            ModHelperPanel strengthSlotInd1 = slotsPanel.AddPanel(new Info("strengthSlotPanel", 25, -520, 100), VanillaSprites.RedBtnSquare);
            ModHelperPanel strengthSlotInd2 = slotsPanel.AddPanel(new Info("strengthSlotPanel", 150, -520, 100), VanillaSprites.RedBtnSquare);
            ModHelperPanel strengthSlotInd3 = slotsPanel.AddPanel(new Info("strengthSlotPanel", 275, -520, 100), VanillaSprites.RedBtnSquare);

            ModHelperButton strengthSlotBtn = slotsPanel.AddButton(new Info("strengthSlotBtn", -300, -520, 400, 150), VanillaSprites.GreenBtnLong, new System.Action(() => {
                InGame game = InGame.instance;

                if (game.GetCash() >= mod.strengthSlotCost && mod.strengthSlots - 3 < mod.level && mod.strengthSlots < 6 && mod.oneSlot == false)
                {
                    game.AddCash(-mod.strengthSlotCost);
                    tower.worth += MathF.Round(mod.strengthSlotCost * 0.7f);
                    mod.strengthSlotCost = MathF.Round(mod.strengthSlotCost * 1.5f);
                    mod.strengthSlots += 1;
                    mod.strengthActive = false;

                    if (mod.strengthSlots - 3 == 1) { strengthSlotInd1.Background.sprite = indicator.Background.sprite; }
                    else if (mod.strengthSlots - 3 == 2) { strengthSlotInd2.Background.sprite = indicator.Background.sprite; }
                    else if (mod.strengthSlots - 3 == 3) { strengthSlotInd3.Background.sprite = indicator.Background.sprite; }

                    if (mod.strengthSlots - 3 >= mod.level | mod.strengthSlots >= 6)
                    {
                        MenuUi.strengthSlotText.GetComponent<ModHelperText>().Text.text = "Upgrade Tower to Unlock More Slots";
                    }
                    else
                    {
                        MenuUi.strengthSlotText.GetComponent<ModHelperText>().Text.text = $"Additional Strength Slot: ${mod.strengthSlotCost}";
                    }
                }
            }));
            strengthSlotBtn.AddText(new Info("strengthBtnText", 0, 0, 400, 150), "Buy", 80);

            ModHelperText strSlotCostText = slotsPanel.AddText(new Info("strengthSlotText", 0, -680, 1000, 150), $"", 50, TextAlignmentOptions.Left);
            MenuUi.strengthSlotText = strSlotCostText.AddComponent<MenuUi>();

            if (mod.oneSlot == true) { MenuUi.strengthSlotText.GetComponent<ModHelperText>().Text.text = "Additional Strength Slot: Disabled"; }
            else { MenuUi.strengthSlotText.GetComponent<ModHelperText>().Text.text = $"Additional Strength Slot: ${mod.strengthSlotCost}"; }


            // Luck
            luckPanel.AddText(new Info("luckText", 0, 680, 1000, 150), "Luck", 80, TextAlignmentOptions.Left);
            ModHelperPanel luckScorePanel = luckPanel.AddPanel(new Info("luckScorePanel", 200, 520, 600, 150), VanillaSprites.BrownInsertPanel);
            ModHelperPanel luckScoreBar = luckScorePanel.AddPanel(new Info("luckScoreBar", 15 * mod.luck, 75, 30 * mod.luck, 150, new Vector2()), VanillaSprites.MainBGPanelBlue);
            ModHelperText luckValue = luckScorePanel.AddText(new Info("luckText", 0, 0, 450, 150), $"Level {mod.luck}: {mod.luck * 5}%", 60, TextAlignmentOptions.Left);
            ModHelperText luckCost = luckPanel.AddText(new Info("luckText", 0, 350, 1000, 150), $"Upgrade: ${mod.luckCost}", 60, TextAlignmentOptions.Left);
            MenuUi.luckValueText = luckValue.AddComponent<MenuUi>();
            MenuUi.luckCostText = luckCost.AddComponent<MenuUi>();
            ModHelperButton luckBtn = luckPanel.AddButton(new Info("luckBtn", -300, 520, 400, 150), VanillaSprites.GreenBtnLong, new Action(() => {
                InGame game = InGame.instance;

                if (game.GetCash() >= mod.luckCost && mod.luck < 20)
                {
                    game.AddCash(-mod.luckCost);
                    tower.worth += MathF.Round(mod.luckCost * 0.7f);
                    mod.luckCost = MathF.Round(mod.luckCost * 1.35f);
                    mod.luck += 1;
                    MenuUi.luckValueText.GetComponent<ModHelperText>().Text.text = $"Level {mod.luck}: {mod.luck * 5}%";

                    if (mod.luck >= 20)
                    {
                        MenuUi.luckCostText.GetComponent<ModHelperText>().Text.text = "Upgrade: Maxed";
                    }
                    else
                    {
                        MenuUi.luckCostText.GetComponent<ModHelperText>().Text.text = $"Upgrade: ${mod.luckCost}";
                    }

                    luckScoreBar.SetInfo(new Info("luckScoreBar", 15 * mod.luck, 75, 30 * mod.luck, 150, new Vector2()));
                    
                }
            }));
            luckBtn.AddText(new Info("luckBtnText", 0, 0, 400, 150), "Buy", 80);


            // Gilded
            var barLength = 600 * (mod.gildedChance / mod.gildedMax);
            luckPanel.AddText(new Info("gildText", 0, 160, 1000, 150), "Gilded Chance", 80, TextAlignmentOptions.Left);
            ModHelperPanel gildScorePanel = luckPanel.AddPanel(new Info("gildScorePanel", 200, 0, 600, 150), VanillaSprites.BrownInsertPanel);
            ModHelperPanel gildScoreBar = gildScorePanel.AddPanel(new Info("gildScoreBar", barLength / 2, 75, barLength, 150, new Vector2()), VanillaSprites.MainBGPanelBlue);
            ModHelperText gildedChance = gildScorePanel.AddText(new Info("gildText", 0, 0, 450, 150), $"{mod.gildedChance}% Chance", 60, TextAlignmentOptions.Left);
            ModHelperText gildedCost = luckPanel.AddText(new Info("gildText", 0, -160, 1000, 150), $"", 60, TextAlignmentOptions.Left);
            MenuUi.gildedChanceText = gildedChance.AddComponent<MenuUi>();
            MenuUi.gildedCostText = gildedCost.AddComponent<MenuUi>();

            if (mod.blingedOut == true) { MenuUi.gildedCostText.GetComponent<ModHelperText>().Text.text = "Upgrade: Maxed"; }
            else if (mod.powerCreep == true | mod.mastery == true) { MenuUi.gildedCostText.GetComponent<ModHelperText>().Text.text = "Upgrade: Disabled"; }
            else { MenuUi.gildedCostText.GetComponent<ModHelperText>().Text.text = $"Upgrade: ${mod.gildedCost}"; }

            ModHelperButton gildBtn = luckPanel.AddButton(new Info("gildBtn", -300, 0, 400, 150), VanillaSprites.GreenBtnLong, new Action(() => {
                InGame game = InGame.instance;

                if (game.GetCash() >= mod.gildedCost && mod.gildedChance < mod.gildedMax)
                {
                    game.AddCash(-mod.gildedCost);
                    tower.worth += MathF.Round(mod.gildedCost * 0.7f);
                    mod.gildedCost = MathF.Round(mod.gildedCost * 1.35f);

                    if (mod.foolsGold == true) { mod.gildedChance += 1; }
                    else { mod.gildedChance += 5; }

                    MenuUi.gildedChanceText.GetComponent<ModHelperText>().Text.text = $"{mod.gildedChance}% Chance";

                    if (mod.gildedChance >= mod.gildedMax)
                    {
                        MenuUi.gildedCostText.GetComponent<ModHelperText>().Text.text = "Upgrade: Maxed";
                    }
                    else
                    {
                        MenuUi.gildedCostText.GetComponent<ModHelperText>().Text.text = $"Upgrade: ${mod.gildedCost}";
                    }

                    gildScoreBar.SetInfo(new Info("gildScoreBar", 300 * (mod.gildedChance / mod.gildedMax), 75, 600 * (mod.gildedChance / mod.gildedMax), 150, new Vector2()));
                }
            }));
            gildBtn.AddText(new Info("gildBtnText", 0, 0, 400, 150), "Buy", 80);


            // Money
            luckPanel.AddText(new Info("moneyText", 0, -360, 1000, 150), "Cash Generator", 80, TextAlignmentOptions.Left);
            ModHelperPanel moneyScorePanel = luckPanel.AddPanel(new Info("moneyScorePanel", 200, -520, 600, 150), VanillaSprites.BrownInsertPanel);
            ModHelperPanel moneyScoreBar = moneyScorePanel.AddPanel(new Info("moneyScoreBar", 60 * mod.moneyLevel, 75, 120 * mod.moneyLevel, 150, new Vector2()), VanillaSprites.MainBGPanelBlue);
            ModHelperText moneyBonus = moneyScorePanel.AddText(new Info("moneyText", 0, 0, 500, 150), $"$0 per round", 60, TextAlignmentOptions.Left);
            ModHelperText moneyCost = luckPanel.AddText(new Info("moneyText", 0, -680, 1000, 150), $"Upgrade: ${mod.moneyCost}", 60, TextAlignmentOptions.Left);
            luckPanel.AddText(new Info("moneyText", 300, -680, 400, 150), $"Not affected by money boost", 45, TextAlignmentOptions.Right);
            MenuUi.moneyBonusText = moneyBonus.AddComponent<MenuUi>();
            MenuUi.moneyCostText = moneyCost.AddComponent<MenuUi>();
            ModHelperButton moneyBtn = luckPanel.AddButton(new Info("moneyBtn", -300, -520, 400, 150), VanillaSprites.GreenBtnLong, new Action(() => {
                InGame game = InGame.instance;

                if (game.GetCash() >= mod.moneyCost && mod.moneyLevel < 5)
                {
                    game.AddCash(-mod.moneyCost);
                    tower.worth += MathF.Round(mod.moneyCost * 0.7f);
                    mod.moneyCost = MathF.Round(mod.moneyCost * 2f);
                    mod.moneyLevel += 1;
                    mod.moneyGenerate *= 2;
                    MenuUi.moneyBonusText.GetComponent<ModHelperText>().Text.text = $"${mod.moneyGenerate} per round";

                    if (mod.moneyLevel >= 5)
                    {
                        MenuUi.moneyCostText.GetComponent<ModHelperText>().Text.text = "Upgrade: Maxed";
                    }
                    else
                    {
                        MenuUi.moneyCostText.GetComponent<ModHelperText>().Text.text = $"Upgrade: ${mod.moneyCost}";
                    }

                    var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
                    foreach (var money in towerModel.GetBehaviors<PerRoundCashBonusTowerModel>())
                    {
                        if (money.name.Contains("ExtrasMoneyGenerate"))
                        {
                            money.cashPerRound = mod.moneyGenerate;
                            tower.UpdateRootModel(towerModel);
                        }
                    }

                    moneyScoreBar.SetInfo(new Info("moneyScoreBar", 60 * mod.moneyLevel, 75, 120 * mod.moneyLevel, 150, new Vector2()));
                }
            }));
            moneyBtn.AddText(new Info("moneyBtnText", 0, 0, 400, 150), "Buy", 80);
        }
        else
        {
            MenuUi.extrasMenu.Show();
            mod.panelOpen = true;
        }
    }
}