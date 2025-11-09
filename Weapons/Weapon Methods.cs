using BTD_Mod_Helper;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using static AncientMonkey.AncientMonkey;
using UnityEngine;
using Il2CppAssets.Scripts.Simulation.Towers;
using System.Collections.Generic;
using WeaponPacks;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using AncientMonkey.Menus;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;

namespace AncientMonkey;

public class WeaponMethods : BloonsTD6Mod
{
    public static void RaritySetter()
    {
        List<WeaponRarityTemplate> rarityList = new List<WeaponRarityTemplate>();
        for (int i = 0; i < ModContent.GetContent<WeaponRarityTemplate>().Count; i++)
        {
            foreach (var rarity in ModContent.GetContent<WeaponRarityTemplate>())
            {
                if (mod.level >= rarity.Level && rarity.Order == i)
                {
                    rarityList.Add(rarity);
                }
            }
        }

        for (var i = 1; i < rarityList.Count; i++)
        {
            if (rarityList[i - 1].minValue < 80)
            {
                rarityList[i].minValue -= (rarityList[i].RarityIncreaser + (mod.luck * 0.1f * rarityList[i].RarityIncreaser)) * mod.level;
            }

            if (rarityList[i].minValue < rarityList[i].trueMinimum)
            {
                rarityList[i].minValue = rarityList[i].trueMinimum;
            }
        }
        for (var i = 1; i < rarityList.Count; i++)
        {
            rarityList[i - 1].maxValue = rarityList[i].minValue;
        }
    }

    public static void WeaponSelected(WeaponTemplate weapon, Tower tower)
    {
        mod.panelOpen = false;
        InGame game = InGame.instance;
        RectTransform rect = game.uiRect;

        weapon.stackIndex += 1;
        weapon.EditTower(tower, false, "", 0);
        RaritySetter();

        if (mod.isSelected == true)
        {
            MenuUi.CreateUpgradeMenu(rect, tower);
        }
    }

    public static void GildedSelected(WeaponTemplate weapon, Tower tower, string effect, int degree)
    {
        mod.panelOpen = false;
        InGame game = InGame.instance;
        RectTransform rect = game.uiRect;

        weapon.stackIndex += 1;
        weapon.EditTower(tower, true, effect, degree);
        RaritySetter();

        if (mod.isSelected == true)
        {
            MenuUi.CreateUpgradeMenu(rect, tower);
        }
    }

    public static void AfterEffects(AttackModel weapon, bool gilded, string effect, int degree)
    {
        if (gilded == true)
        {
            float multiplier;
            weapon.name += "Gilded";

            if (degree > 0)
            {
                multiplier = 1 + ((float)degree / 10);

                weapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce *= multiplier);
                weapon.GetDescendants<DamageModel>().ForEach(model => model.damage *= multiplier);
                weapon.GetDescendants<WeaponModel>().ForEach(model => model.rate /= multiplier);
                weapon.GetDescendants<CashModel>().ForEach(model => model.minimum *= multiplier);
                weapon.GetDescendants<CashModel>().ForEach(model => model.maximum *= multiplier);
            }
            else if (degree < 0)
            {
                multiplier = 1 + ((float)degree / -10);

                weapon.GetDescendants<ProjectileModel>().ForEach(model => model.pierce /= multiplier);
                weapon.GetDescendants<DamageModel>().ForEach(model => model.damage /= multiplier);
                weapon.GetDescendants<WeaponModel>().ForEach(model => model.rate *= multiplier);
                weapon.GetDescendants<CashModel>().ForEach(model => model.minimum /= multiplier);
                weapon.GetDescendants<CashModel>().ForEach(model => model.maximum /= multiplier);
            }

            foreach (var gildEffects in ModContent.GetContent<GildedTemplate>())
            {
                if (gildEffects.EffectName == effect)
                {
                    gildEffects.Gild(weapon);
                }
            }
        }

        foreach (var artifact in ModContent.GetContent<ArtifactTemplate>())
        {
            if (artifact.enabled)
            {
                artifact.EditModel(weapon);
            }
        }
    }
}