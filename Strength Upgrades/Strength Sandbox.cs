using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Api.Enums;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppTMPro;
using System;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppSystem.IO;

namespace AncientMonkey;

public class StrengthSandbox : BloonsTD6Mod
{
    public static void StrengthSandboxPanel(RectTransform rect, Tower tower)
    {
        mod.panelOpen = true;

        if (mod.strengthActive == false)
        {
            mod.strengthActive = true;

            ModHelperPanel panel = rect.gameObject.AddModHelperPanel(new Info("Panel_", 0, 0, 1800, 1900), VanillaSprites.MainBGPanelBlue);
            MenuUi strengthUi = panel.AddComponent<MenuUi>();
            MenuUi.strengthMenu = strengthUi;

            ModHelperButton exit = panel.AddButton(new Info("exit", 850, 925, 135, 135), VanillaSprites.RedBtn, new System.Action(() => {
                tower.SetSelectionBlocked(false);
                panel.Hide();
                mod.panelOpen = false;
                if (mod.isSelected == true)
                {
                    MenuUi.CreateUpgradeMenu(rect, tower);
                }
            }));
            ModHelperText x = exit.AddText(new Info("x", 0, 0, 135, 135), "X", 80);


            // Damage Bonus

            panel.AddText(new Info("damageText", 0, 837, 900, 150), "Damage Boost:", 80, TextAlignmentOptions.Left);
            ModHelperText damageValue = panel.AddText(new Info("text", 0, 662, 600, 150), TextManager.ConvertCostText(mod.damageBonus), 100);
            ModHelperButton damageReset = panel.AddButton(new Info("pierceReset", 400, 837, 150), VanillaSprites.RestartBtn, new System.Action(() => {
                mod.damageBonus = 0;
                damageValue.Text.text = TextManager.ConvertCostText(mod.damageBonus);
            }));

            ModHelperButton damageInc1 = panel.AddButton(new Info("Increase1", 400, 662, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.damageBonus += 1;
                damageValue.Text.text = TextManager.ConvertCostText(mod.damageBonus);
            }));
            ModHelperButton damageInc10 = panel.AddButton(new Info("Increase10", 575, 662, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.damageBonus += 10;
                damageValue.Text.text = TextManager.ConvertCostText(mod.damageBonus);
            }));
            ModHelperButton damageInc100 = panel.AddButton(new Info("Increase100", 750, 662, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.damageBonus += 100;
                damageValue.Text.text = TextManager.ConvertCostText(mod.damageBonus);
            }));

            ModHelperButton damageDec1 = panel.AddButton(new Info("Decrease1", -400, 662, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                mod.damageBonus -= 1;
                if (mod.damageBonus < 0)
                {
                    mod.damageBonus = 0;
                }
                damageValue.Text.text = TextManager.ConvertCostText(mod.damageBonus);
            }));
            ModHelperButton damageDec10 = panel.AddButton(new Info("Decrease10", -575, 662, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.damageBonus >= 10)
                {
                    mod.damageBonus -= 10;
                }
                damageValue.Text.text = TextManager.ConvertCostText(mod.damageBonus);
            }));
            ModHelperButton damageDec100 = panel.AddButton(new Info("Decrease100", -750, 662, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.damageBonus >= 100)
                {
                    mod.damageBonus -= 100;
                }
                damageValue.Text.text = TextManager.ConvertCostText(mod.damageBonus);
            }));

            damageInc1.AddText(new Info("", 0, 0, 150), "+1", 75);
            damageInc10.AddText(new Info("", 0, 0, 150), "+10", 70);
            damageInc100.AddText(new Info("", 0, 0, 150), "+100", 65);

            damageDec1.AddText(new Info("", 0, 0, 150), "-1", 75);
            damageDec10.AddText(new Info("", 0, 0, 150), "-10", 70);
            damageDec100.AddText(new Info("", 0, 0, 150), "-100", 65);


            // Pierce Bonus
            panel.AddText(new Info("pierceText", 0, 462, 900, 150), "Pierce Boost:", 80, TextAlignmentOptions.Left);
            ModHelperText pierceValue = panel.AddText(new Info("text", 0, 287, 600, 150), TextManager.ConvertCostText(mod.pierceBonus), 100);
            ModHelperButton pierceReset = panel.AddButton(new Info("pierceReset", 400, 462, 150), VanillaSprites.RestartBtn, new System.Action(() => {
                mod.pierceBonus = 0;
                pierceValue.Text.text = TextManager.ConvertCostText(mod.pierceBonus);
            }));

            ModHelperButton pierceInc1 = panel.AddButton(new Info("Increase1", 400, 287, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.pierceBonus += 1;
                pierceValue.Text.text = TextManager.ConvertCostText(mod.pierceBonus);
            }));
            ModHelperButton pierceInc10 = panel.AddButton(new Info("Increase10", 575, 287, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.pierceBonus += 10;
                pierceValue.Text.text = TextManager.ConvertCostText(mod.pierceBonus);
            }));
            ModHelperButton pierceInc100 = panel.AddButton(new Info("Increase100", 750, 287, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.pierceBonus += 100;
                pierceValue.Text.text = TextManager.ConvertCostText(mod.pierceBonus);
            }));

            ModHelperButton pierceDec1 = panel.AddButton(new Info("Decrease1", -400, 287, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                mod.pierceBonus -= 1;
                if (mod.pierceBonus < 0)
                {
                    mod.pierceBonus = 0;
                }
                pierceValue.Text.text = TextManager.ConvertCostText(mod.pierceBonus);
            }));
            ModHelperButton pierceDec10 = panel.AddButton(new Info("Decrease10", -575, 287, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.pierceBonus >= 10)
                {
                    mod.pierceBonus -= 10;
                }
                pierceValue.Text.text = TextManager.ConvertCostText(mod.pierceBonus);
            }));
            ModHelperButton pierceDec100 = panel.AddButton(new Info("Decrease100", -750, 287, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.pierceBonus >= 100)
                {
                    mod.pierceBonus -= 100;
                }
                pierceValue.Text.text = TextManager.ConvertCostText(mod.pierceBonus);
            }));

            pierceInc1.AddText(new Info("", 0, 0, 150), "+1", 75);
            pierceInc10.AddText(new Info("", 0, 0, 150), "+10", 70);
            pierceInc100.AddText(new Info("", 0, 0, 150), "+100", 65);

            pierceDec1.AddText(new Info("", 0, 0, 150), "-1", 75);
            pierceDec10.AddText(new Info("", 0, 0, 150), "-10", 70);
            pierceDec100.AddText(new Info("", 0, 0, 150), "-100", 65);


            // Range Bonus
            panel.AddText(new Info("rangeText", 0, 87, 900, 150), "Range Boost:", 80, TextAlignmentOptions.Left);
            ModHelperText rangeValue = panel.AddText(new Info("text", 0, -87, 600, 150), $"{mod.rangeBonus}x", 100);
            ModHelperButton rangeReset = panel.AddButton(new Info("rangeReset", 400, 87, 150), VanillaSprites.RestartBtn, new System.Action(() => {
                mod.rangeBonus = 1;
                rangeValue.Text.text = $"{MathF.Round(mod.rangeBonus, 2)}x";
            }));

            ModHelperButton rangeInc1 = panel.AddButton(new Info("Increase1", 400, -87, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.rangeBonus += 0.01f;
                rangeValue.Text.text = $"{MathF.Round(mod.rangeBonus, 2)}x";
            }));
            ModHelperButton rangeInc10 = panel.AddButton(new Info("Increase10", 575, -87, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.rangeBonus += 0.1f;
                rangeValue.Text.text = $"{MathF.Round(mod.rangeBonus, 2)}x";
            }));
            ModHelperButton rangeInc100 = panel.AddButton(new Info("Increase100", 750, -87, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.rangeBonus += 1f;
                rangeValue.Text.text = $"{MathF.Round(mod.rangeBonus, 2)}x";
            }));

            ModHelperButton rangeDec1 = panel.AddButton(new Info("Decrease1", -400, -87, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                mod.rangeBonus -= 0.01f;
                if (mod.rangeBonus < 1f)
                {
                    mod.rangeBonus = 1f;
                }
                rangeValue.Text.text = $"{MathF.Round(mod.rangeBonus, 2)}x";
            }));
            ModHelperButton rangeDec10 = panel.AddButton(new Info("Decrease10", -575, -87, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.rangeBonus >= 1.1f)
                {
                    mod.rangeBonus -= 0.1f;
                }
                rangeValue.Text.text = $"{MathF.Round(mod.rangeBonus, 2)}x";
            }));
            ModHelperButton rangeDec100 = panel.AddButton(new Info("Decrease100", -750, -87, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.rangeBonus >= 2f)
                {
                    mod.rangeBonus -= 1f;
                }
                rangeValue.Text.text = $"{MathF.Round(mod.rangeBonus, 2)}x";
            }));

            rangeInc1.AddText(new Info("", 0, 0, 150), "+0.01", 63);
            rangeInc10.AddText(new Info("", 0, 0, 150), "+0.1", 70);
            rangeInc100.AddText(new Info("", 0, 0, 150), "+1", 75);

            rangeDec1.AddText(new Info("", 0, 0, 150), "-0.01", 63);
            rangeDec10.AddText(new Info("", 0, 0, 150), "-0.1", 70);
            rangeDec100.AddText(new Info("", 0, 0, 150), "-1", 75);


            // Rate Bonus
            panel.AddText(new Info("rateText", 0, -287, 900, 150), "Rate Boost:", 80, TextAlignmentOptions.Left);
            ModHelperText rateValue = panel.AddText(new Info("text", 0, -462, 600, 150), $"{mod.attackSpeedBonus}x", 100);
            ModHelperButton rateReset = panel.AddButton(new Info("rateReset", 400, -287, 150), VanillaSprites.RestartBtn, new System.Action(() => {
                mod.attackSpeedBonus = 1;
                rateValue.Text.text = $"{MathF.Round(mod.attackSpeedBonus, 2)}x";
            }));

            ModHelperButton rateInc1 = panel.AddButton(new Info("Increase1", 400, -462, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.attackSpeedBonus += 0.01f;
                rateValue.Text.text = $"{MathF.Round(mod.attackSpeedBonus, 2)}x";
            }));
            ModHelperButton rateInc10 = panel.AddButton(new Info("Increase10", 575, -462, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.attackSpeedBonus += 0.1f;
                rateValue.Text.text = $"{MathF.Round(mod.attackSpeedBonus, 2)}x";
            }));
            ModHelperButton rateInc100 = panel.AddButton(new Info("Increase100", 750, -462, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.attackSpeedBonus += 1f;
                rateValue.Text.text = $"{MathF.Round(mod.attackSpeedBonus, 2)}x";
            }));

            ModHelperButton rateDec1 = panel.AddButton(new Info("Decrease1", -400, -462, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                mod.attackSpeedBonus -= 0.01f;
                if (mod.attackSpeedBonus < 1f)
                {
                    mod.attackSpeedBonus = 1f;
                }
                rateValue.Text.text = $"{MathF.Round(mod.attackSpeedBonus, 2)}x";
            }));
            ModHelperButton rateDec10 = panel.AddButton(new Info("Decrease10", -575, -462, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.attackSpeedBonus >= 1.1f)
                {
                    mod.attackSpeedBonus -= 0.1f;
                }
                rateValue.Text.text = $"{MathF.Round(mod.attackSpeedBonus, 2)}x";
            }));
            ModHelperButton rateDec100 = panel.AddButton(new Info("Decrease100", -750, -462, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.attackSpeedBonus >= 2f)
                {
                    mod.attackSpeedBonus -= 1f;
                }
                rateValue.Text.text = $"{MathF.Round(mod.attackSpeedBonus, 2)}x";
            }));

            rateInc1.AddText(new Info("", 0, 0, 150), "+0.01", 63);
            rateInc10.AddText(new Info("", 0, 0, 150), "+0.1", 70);
            rateInc100.AddText(new Info("", 0, 0, 150), "+1", 75);

            rateDec1.AddText(new Info("", 0, 0, 150), "-0.01", 63);
            rateDec10.AddText(new Info("", 0, 0, 150), "-0.1", 70);
            rateDec100.AddText(new Info("", 0, 0, 150), "-1", 75);


            // Money Bonus
            panel.AddText(new Info("moneyText", 0, -662, 900, 150), "Money Boost:", 80, TextAlignmentOptions.Left);
            ModHelperText moneyValue = panel.AddText(new Info("text", 0, -837, 600, 150), $"{mod.moneyBonus}x", 100);
            ModHelperButton moneyReset = panel.AddButton(new Info("moneyReset", 400, -662, 150), VanillaSprites.RestartBtn, new System.Action(() => {
                mod.moneyBonus = 1;
                moneyValue.Text.text = $"{MathF.Round(mod.moneyBonus, 2)}x";
            }));

            ModHelperButton moneyInc1 = panel.AddButton(new Info("Increase1", 400, -837, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.moneyBonus += 0.01f;
                moneyValue.Text.text = $"{MathF.Round(mod.moneyBonus, 2)}x";
            }));
            ModHelperButton moneyInc10 = panel.AddButton(new Info("Increase10", 575, -837, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.moneyBonus += 0.1f;
                moneyValue.Text.text = $"{MathF.Round(mod.moneyBonus, 2)}x";
            }));
            ModHelperButton moneyInc100 = panel.AddButton(new Info("Increase100", 750, -837, 150), VanillaSprites.GreenBtnSquare, new System.Action(() => {
                mod.moneyBonus += 1f;
                moneyValue.Text.text = $"{MathF.Round(mod.moneyBonus, 2)}x";
            }));

            ModHelperButton moneyDec1 = panel.AddButton(new Info("Decrease1", -400, -837, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                mod.moneyBonus -= 0.01f;
                if (mod.moneyBonus < 1f)
                {
                    mod.moneyBonus = 1f;
                }
                moneyValue.Text.text = $"{MathF.Round(mod.moneyBonus, 2)}x";
            }));
            ModHelperButton moneyDec10 = panel.AddButton(new Info("Decrease10", -575, -837, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.moneyBonus >= 1.1f)
                {
                    mod.moneyBonus -= 0.1f;
                }
                moneyValue.Text.text = $"{MathF.Round(mod.moneyBonus, 2)}x";
            }));
            ModHelperButton moneyDec100 = panel.AddButton(new Info("Decrease100", -750, -837, 150), VanillaSprites.RedBtnSquare, new System.Action(() => {
                if (mod.moneyBonus >= 2f)
                {
                    mod.moneyBonus -= 1f;
                }
                moneyValue.Text.text = $"{MathF.Round(mod.moneyBonus, 2)}x";
            }));

            moneyInc1.AddText(new Info("", 0, 0, 150), "+0.01", 63);
            moneyInc10.AddText(new Info("", 0, 0, 150), "+0.1", 70);
            moneyInc100.AddText(new Info("", 0, 0, 150), "+1", 75);

            moneyDec1.AddText(new Info("", 0, 0, 150), "-0.01", 63);
            moneyDec10.AddText(new Info("", 0, 0, 150), "-0.1", 70);
            moneyDec100.AddText(new Info("", 0, 0, 150), "-1", 75);


            ModHelperButton selectWpnBtn = panel.AddButton(new Info("selectWpnBtn", 0, -1035, 400, 120), VanillaSprites.GreenBtnLong, new System.Action(() => { SandboxUpgrade(tower); }));
            ModHelperText selectWpn = selectWpnBtn.AddText(new Info("selectWpn", 0, 0, 400, 120), "Edit", 70);
        }
        else
        {
            MenuUi.strengthMenu.Show();
            mod.panelOpen = true;
        }
    }

    public static void SandboxUpgrade(Tower tower)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

        foreach (var weapon in towerModel.GetAttackModels())
        {
            weapon.range *= mod.rangeBonus;

            if (weapon.name.Contains("Gilded"))
            {
                weapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += mod.pierceBonus);
                weapon.GetDescendants<DamageModel>().ForEach(model => model.damage += mod.damageBonus * 3);

                weapon.range *= mod.rangeBonus;
                weapon.GetDescendants<TravelStraitModel>().ForEach(model => model.lifespan *= mod.rangeBonus);

                weapon.GetDescendants<CashModel>().ForEach(model => model.minimum *= (mod.moneyBonus * 2) - 1);
                weapon.GetDescendants<CashModel>().ForEach(model => model.maximum *= (mod.moneyBonus * 2) - 1);

                foreach (var attack in weapon.weapons)
                {
                    attack.rate /= mod.attackSpeedBonus;

                    if (attack.rate < 0.1f)
                    {
                        attack.rate *= 10;
                        attack.GetDescendants<DamageModel>().ForEach(model => model.damage *= 10);
                    }
                }

                if (!weapon.name.Contains("BaseAttackModel"))
                {
                    if (weapon.weapons[0].projectile.HasBehavior<CreateTowerModel>())
                    {
                        var sentry = weapon.weapons[0].projectile.GetDescendant<CreateTowerModel>().tower;
                        foreach (var senWeapon in sentry.GetAttackModels())
                        {
                            senWeapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += mod.pierceBonus);
                            senWeapon.GetDescendants<DamageModel>().ForEach(model => model.damage += mod.damageBonus * 3);

                            senWeapon.range *= mod.rangeBonus;
                            senWeapon.GetDescendants<TravelStraitModel>().ForEach(model => model.lifespan *= mod.rangeBonus);

                            foreach (var attack in weapon.weapons)
                            {
                                attack.rate /= mod.attackSpeedBonus;

                                if (attack.rate < 0.1f)
                                {
                                    attack.rate *= 10;
                                    attack.GetDescendants<DamageModel>().ForEach(model => model.damage *= 10);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                weapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += mod.pierceBonus);
                weapon.GetDescendants<DamageModel>().ForEach(model => model.damage += mod.damageBonus);

                weapon.range *= mod.rangeBonus;
                weapon.GetDescendants<TravelStraitModel>().ForEach(model => model.lifespan *= mod.rangeBonus);

                weapon.GetDescendants<CashModel>().ForEach(model => model.minimum *= mod.moneyBonus);
                weapon.GetDescendants<CashModel>().ForEach(model => model.maximum *= mod.moneyBonus);

                foreach (var attack in weapon.weapons)
                {
                    attack.rate /= mod.attackSpeedBonus;

                    if (attack.rate < 0.1f)
                    {
                        attack.rate *= 10;
                        attack.GetDescendants<DamageModel>().ForEach(model => model.damage *= 10);
                    }
                }

                if (!weapon.name.Contains("BaseAttackModel"))
                {
                    if (weapon.weapons[0].projectile.HasBehavior<CreateTowerModel>())
                    {
                        var sentry = weapon.weapons[0].projectile.GetDescendant<CreateTowerModel>().tower;
                        foreach (var senWeapon in sentry.GetAttackModels())
                        {
                            senWeapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += mod.pierceBonus);
                            senWeapon.GetDescendants<DamageModel>().ForEach(model => model.damage += mod.damageBonus);

                            senWeapon.range *= mod.rangeBonus;
                            senWeapon.GetDescendants<TravelStraitModel>().ForEach(model => model.lifespan *= mod.rangeBonus);

                            foreach (var attack in weapon.weapons)
                            {
                                attack.rate /= mod.attackSpeedBonus;

                                if (attack.rate < 0.1f)
                                {
                                    attack.rate *= 10;
                                    attack.GetDescendants<DamageModel>().ForEach(model => model.damage *= 10);
                                }
                            }
                        }
                    }
                }
            }
        }

        foreach (var weapon in towerModel.GetBehaviors<TowerCreateTowerModel>())
        {
            if (weapon.name.Contains("Gilded"))
            {
                weapon.towerModel.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += mod.pierceBonus);
                weapon.towerModel.GetDescendants<DamageModel>().ForEach(model => model.damage += mod.damageBonus * 3);

                foreach (var attack in weapon.towerModel.GetDescendants<WeaponModel>().ToArray())
                {
                    attack.rate /= mod.attackSpeedBonus;

                    if (attack.rate < 0.1f)
                    {
                        attack.rate *= 10;
                        attack.GetDescendants<DamageModel>().ForEach(model => model.damage *= 10);
                    }
                }
            }
            else
            {
                weapon.towerModel.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += mod.pierceBonus);
                weapon.towerModel.GetDescendants<DamageModel>().ForEach(model => model.damage += mod.damageBonus);

                foreach (var attack in weapon.towerModel.GetDescendants<WeaponModel>().ToArray())
                {
                    attack.rate /= mod.attackSpeedBonus;

                    if (attack.rate < 0.1f)
                    {
                        attack.rate *= 10;
                        attack.GetDescendants<DamageModel>().ForEach(model => model.damage *= 10);
                    }
                }
            }
        }

        foreach (var weapon in towerModel.GetBehaviors<PerRoundCashBonusTowerModel>())
        {
            if (!weapon.name.Contains("ExtrasMoneyGenerate"))
            {
                if (weapon.name.Contains("Gilded"))
                {
                    weapon.cashPerRound *= (mod.moneyBonus * 3) - 2;
                }
                else
                {
                    weapon.cashPerRound *= mod.moneyBonus;
                }
            }
        }

        towerModel.range *= mod.rangeBonus;
        tower.UpdateRootModel(towerModel);
    }
}