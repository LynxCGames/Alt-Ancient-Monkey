using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Components;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Linq;
using UnityEngine;
using static AncientMonkey.AncientMonkey;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;

namespace AncientMonkey.Menus;

public class ChallengeModes : BloonsTD6Mod
{
    public static void FoolsGold()
    {
        foreach (var tower in InGame.instance.GetTowers())
        {
            if (tower.towerModel.name.Contains("AncientMonkey-AncientMonkey"))
            {
                Il2CppSystem.Random rnd = new Il2CppSystem.Random();
                var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();

                for (int i = 0; i < 5; i++)
                {
                    int attackNum = rnd.Next(0, towerModel.GetAttackModels().Count);

                    if (towerModel.GetAttackModel() == null)
                    {
                        break;
                    }
                    else if (!towerModel.GetAttackModel(attackNum).name.Contains("Gilded"))
                    {
                        towerModel.RemoveBehavior(towerModel.GetAttackModel(attackNum));
                    }
                }

                tower.UpdateRootModel(towerModel);
            }
        }
    }

    public static void ErrorCode()
    {
        float[] costValues = [
            mod.weaponCost,
            mod.weaponSlotCost,
            mod.abilityCost,
            mod.abilitySlotCost,
            mod.strengthCost,
            mod.strengthSlotCost,
            mod.luckCost,
            mod.gildedCost,
            mod.moneyCost,
            mod.upgradeCost,
            mod.gildEffectCost,
        ];

        for (int i = 0; i < costValues.Count(); i++)
        {
            Il2CppSystem.Random rnd = new Il2CppSystem.Random();
            float errorNum = rnd.Next(50, 151);
            float errorMultiplier = 1;

            if (errorNum < 100)
            {
                errorMultiplier = 2 - (errorNum / 100);
                costValues[i] /= errorMultiplier;
            }
            else if (errorNum >= 100)
            {
                errorMultiplier = errorNum / 100;
                costValues[i] *= errorMultiplier;
            }
        }

        mod.weaponCost = costValues[0];
        mod.weaponSlotCost = costValues[1];
        mod.abilityCost = costValues[2];
        mod.abilitySlotCost = costValues[3];
        mod.strengthCost = costValues[4];
        mod.strengthSlotCost = costValues[5];
        mod.luckCost = costValues[6];
        mod.gildedCost = costValues[7];
        mod.moneyCost = costValues[8];
        mod.upgradeCost = costValues[9];
        mod.gildEffectCost = costValues[10];

        if (mod.upgradeActive == true)
        {
            MenuUi.weaponCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)MathF.Round(mod.weaponCost));
            MenuUi.abilityCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)MathF.Round(mod.abilityCost));
            MenuUi.strengthCostText.GetComponent<ModHelperText>().Text.text = "$" + TextManager.ConvertCostText((int)MathF.Round(mod.strengthCost));
        }

        if (mod.extrasActive == true)
        {
            MenuUi.weaponSlotText.GetComponent<ModHelperText>().Text.text = $"Additional Weapon Slot: $" + TextManager.ConvertCostText((int)MathF.Round(mod.weaponSlotCost));
            MenuUi.abilitySlotText.GetComponent<ModHelperText>().Text.text = $"Additional Ability Slot: $" + TextManager.ConvertCostText((int)MathF.Round(mod.abilitySlotCost));
            MenuUi.strengthSlotText.GetComponent<ModHelperText>().Text.text = $"Additional Strength Slot: $" + TextManager.ConvertCostText((int)MathF.Round(mod.strengthSlotCost));

            MenuUi.luckCostText.GetComponent<ModHelperText>().Text.text = $"Upgrade: $" + TextManager.ConvertCostText((int)MathF.Round(mod.luckCost));
            MenuUi.gildedCostText.GetComponent<ModHelperText>().Text.text = $"Upgrade: $" + TextManager.ConvertCostText((int)MathF.Round(mod.gildedCost));
            MenuUi.moneyCostText.GetComponent<ModHelperText>().Text.text = $"Upgrade: $" + TextManager.ConvertCostText((int)MathF.Round(mod.moneyCost));

            if (mod.level < 4)
            {
                MenuUi.extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("upgradePanel").
                GetComponentFromChildrenByName<ModHelperText>("upgradeTitle").Text.text = $"Tower Upgrade: $" + TextManager.ConvertCostText((int)Mathf.Round(mod.upgradeCost));
            }
            else
            {
                MenuUi.extrasMenu.GetComponentFromChildrenByName<ModHelperPanel>("upgradePanel").
                GetComponentFromChildrenByName<ModHelperText>("upgradeTitle").Text.text = $"7ow&r Up9r@d3: $" + TextManager.ConvertCostText((int)Mathf.Round(mod.upgradeCost));
            }
        }
    }
}