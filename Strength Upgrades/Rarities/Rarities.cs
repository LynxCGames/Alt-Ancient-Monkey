using System.Collections.Generic;

namespace AncientMonkey.Strengths.Rarities;

public class Common : StrengthRarityTemplate
{
    public override float RarityIncreaser => 0;
    public override float TrueMinimumValue => 0;
    public override Rarity StrengthRarity => Rarity.Common;
    public override int Level => 1;
    public override int Order => 0;
    public override void StrengthList(List<StrengthTemplate> strengthList)
    {
        foreach (var strength in GetContent<StrengthTemplate>())
        {
            if (strength.StrengthRarity == StrengthTemplate.Rarity.Common)
            {
                Il2CppSystem.Random rnd = new Il2CppSystem.Random();
                int damageBoost = rnd.Next(0, 2);
                int pierceBoost = rnd.Next(0, 3);
                float rangeBoost = rnd.Next(0, 4);
                float attackSpeedBoost = rnd.Next(0, 4);
                float moneyBoost = rnd.Next(0, 4);
                float projSpeed = rnd.Next(3, 6);
                float debuff = rnd.Next(3, 6);

                if (strength.StrengthName == "Damage Boost")
                {
                    damageBoost += 1;
                    strength.damageBonus = damageBoost;
                }
                if (strength.StrengthName == "Attack Speed Boost")
                {
                    attackSpeedBoost += 3;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                }
                if (strength.StrengthName == "Range Boost")
                {
                    rangeBoost += 3;
                    pierceBoost += 1;
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                }
                if (strength.StrengthName == "Money Boost")
                {
                    moneyBoost += 2;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Multi Boost")
                {
                    strength.damageBonus = damageBoost;
                    strength.pierceBonus = pierceBoost;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Projectile Speed")
                {
                    attackSpeedBoost += 1;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.projectileSpeed = 1 + (projSpeed / 100);
                }
                if (strength.StrengthName == "Debuff Duration")
                {
                    strength.debuffDuration = 1 + (debuff / 100);
                }

                strengthList.Add(strength);
            }
        }
    }
}
public class Rare : StrengthRarityTemplate
{
    public override float RarityIncreaser => 5f;
    public override float TrueMinimumValue => 1;
    public override Rarity StrengthRarity => Rarity.Rare;
    public override int Level => 1;
    public override int Order => 1;
    public override void StrengthList(List<StrengthTemplate> strengthList)
    {
        foreach (var strength in GetContent<StrengthTemplate>())
        {
            if (strength.StrengthRarity == StrengthTemplate.Rarity.Rare)
            {
                Il2CppSystem.Random rnd = new Il2CppSystem.Random();
                int damageBoost = rnd.Next(1, 4);
                int pierceBoost = rnd.Next(2, 4);
                float rangeBoost = rnd.Next(2, 6);
                float attackSpeedBoost = rnd.Next(2, 6);
                float moneyBoost = rnd.Next(2, 6);
                float projSpeed = rnd.Next(5, 9);
                float debuff = rnd.Next(5, 9);

                if (strength.StrengthName == "Damage Boost")
                {
                    damageBoost += 2;
                    strength.damageBonus = damageBoost;
                }
                if (strength.StrengthName == "Attack Speed Boost")
                {
                    attackSpeedBoost += 5;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                }
                if (strength.StrengthName == "Range Boost")
                {
                    rangeBoost += 5;
                    pierceBoost += 2;
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                }
                if (strength.StrengthName == "Money Boost")
                {
                    moneyBoost += 3;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Multi Boost")
                {
                    strength.damageBonus = damageBoost;
                    strength.pierceBonus = pierceBoost;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Projectile Speed")
                {
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.projectileSpeed = 1 + (projSpeed / 100);
                }
                if (strength.StrengthName == "Debuff Duration")
                {
                    strength.debuffDuration = 1 + (debuff / 100);
                }

                strengthList.Add(strength);
            }
        }
    }
}
public class Epic : StrengthRarityTemplate
{
    public override float RarityIncreaser => 2f;
    public override float TrueMinimumValue => 2;
    public override Rarity StrengthRarity => Rarity.Epic;
    public override int Level => 1;
    public override int Order => 2;
    public override void StrengthList(List<StrengthTemplate> strengthList)
    {
        foreach (var strength in GetContent<StrengthTemplate>())
        {
            if (strength.StrengthRarity == StrengthTemplate.Rarity.Epic)
            {
                Il2CppSystem.Random rnd = new Il2CppSystem.Random();
                int damageBoost = rnd.Next(2, 6);
                int pierceBoost = rnd.Next(2, 6);
                float rangeBoost = rnd.Next(4, 8);
                float attackSpeedBoost = rnd.Next(4, 8);
                float moneyBoost = rnd.Next(4, 8);
                float projSpeed = rnd.Next(8, 12);
                float debuff = rnd.Next(8, 12);

                if (strength.StrengthName == "Damage Boost")
                {
                    damageBoost += 3;
                    strength.damageBonus = damageBoost;
                }
                if (strength.StrengthName == "Attack Speed Boost")
                {
                    attackSpeedBoost += 5;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                }
                if (strength.StrengthName == "Range Boost")
                {
                    rangeBoost += 5;
                    pierceBoost += 3;
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                }
                if (strength.StrengthName == "Money Boost")
                {
                    moneyBoost += 4;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Multi Boost")
                {
                    strength.damageBonus = damageBoost;
                    strength.pierceBonus = pierceBoost;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Projectile Speed")
                {
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.projectileSpeed = 1 + (projSpeed / 100);
                }
                if (strength.StrengthName == "Debuff Duration")
                {
                    strength.debuffDuration = 1 + (debuff / 100);
                }

                strengthList.Add(strength);
            }
        }
    }
}
public class Legendary : StrengthRarityTemplate
{
    public override float RarityIncreaser => 1;
    public override float TrueMinimumValue => 20;
    public override Rarity StrengthRarity => Rarity.Legendary;
    public override int Level => 1;
    public override int Order => 3;
    public override void StrengthList(List<StrengthTemplate> strengthList)
    {
        foreach (var strength in GetContent<StrengthTemplate>())
        {
            if (strength.StrengthRarity == StrengthTemplate.Rarity.Legendary)
            {
                Il2CppSystem.Random rnd = new Il2CppSystem.Random();
                int damageBoost = rnd.Next(4, 9);
                int pierceBoost = rnd.Next(4, 9);
                float rangeBoost = rnd.Next(6, 12);
                float attackSpeedBoost = rnd.Next(6, 12);
                float moneyBoost = rnd.Next(6, 10);
                float projSpeed = rnd.Next(12, 16);
                float debuff = rnd.Next(12, 16);
                float cooldown = rnd.Next(1, 3);

                if (strength.StrengthName == "Damage Boost")
                {
                    damageBoost += 4;
                    strength.damageBonus = damageBoost;
                }
                if (strength.StrengthName == "Attack Speed Boost")
                {
                    attackSpeedBoost += 6;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                }
                if (strength.StrengthName == "Range Boost")
                {
                    rangeBoost += 6;
                    pierceBoost += 4;
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                }
                if (strength.StrengthName == "Money Boost")
                {
                    moneyBoost += 5;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Multi Boost")
                {
                    strength.damageBonus = damageBoost;
                    strength.pierceBonus = pierceBoost;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Projectile Speed")
                {
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.projectileSpeed = 1 + (projSpeed / 100);
                }
                if (strength.StrengthName == "Debuff Duration")
                {
                    strength.debuffDuration = 1 + (debuff / 100);
                }
                if (strength.StrengthName == "Ability Cooldown")
                {
                    strength.abilityCooldown = 1 + (cooldown / 100);
                }
                
                strengthList.Add(strength);
            }
        }
    }
}
public class Mythic : StrengthRarityTemplate
{
    public override float RarityIncreaser => 0.5f;
    public override float TrueMinimumValue => 50;
    public override Rarity StrengthRarity => Rarity.Mythic;
    public override int Level => 1;
    public override int Order => 4;
    public override void StrengthList(List<StrengthTemplate> strengthList)
    {
        foreach (var strength in GetContent<StrengthTemplate>())
        {
            if (strength.StrengthRarity == StrengthTemplate.Rarity.Mythic)
            {
                Il2CppSystem.Random rnd = new Il2CppSystem.Random();
                int damageBoost = rnd.Next(5, 11);
                int pierceBoost = rnd.Next(5, 11);
                float rangeBoost = rnd.Next(8, 16);
                float attackSpeedBoost = rnd.Next(8, 16);
                float moneyBoost = rnd.Next(8, 12);
                float projSpeed = rnd.Next(15, 20);
                float debuff = rnd.Next(15, 20);
                float cooldown = rnd.Next(3, 5);

                if (strength.StrengthName == "Damage Boost")
                {
                    damageBoost += 1;
                    strength.damageBonus = damageBoost;
                }
                if (strength.StrengthName == "Attack Speed Boost")
                {
                    attackSpeedBoost += 7;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                }
                if (strength.StrengthName == "Range Boost")
                {
                    rangeBoost += 7;
                    pierceBoost += 1;
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                }
                if (strength.StrengthName == "Money Boost")
                {
                    moneyBoost += 5;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Multi Boost")
                {
                    strength.damageBonus = damageBoost;
                    strength.pierceBonus = pierceBoost;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Projectile Speed")
                {
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.projectileSpeed = 1 + (projSpeed / 100);
                }
                if (strength.StrengthName == "Debuff Duration")
                {
                    strength.debuffDuration = 1 + (debuff / 100);
                }
                if (strength.StrengthName == "Ability Cooldown")
                {
                    strength.abilityCooldown = 1 + (cooldown / 100);
                }

                strengthList.Add(strength);
            }
        }
    }
}
public class Godly : StrengthRarityTemplate
{
    public override float RarityIncreaser => 0.3f;
    public override float TrueMinimumValue => 75;
    public override Rarity StrengthRarity => Rarity.Godly;
    public override int Level => 2;
    public override int Order => 5;
    public override void StrengthList(List<StrengthTemplate> strengthList)
    {
        foreach (var strength in GetContent<StrengthTemplate>())
        {
            if (strength.StrengthRarity == StrengthTemplate.Rarity.Godly)
            {
                Il2CppSystem.Random rnd = new Il2CppSystem.Random();
                int damageBoost = rnd.Next(7, 14);
                int pierceBoost = rnd.Next(7, 14);
                float rangeBoost = rnd.Next(10, 20);
                float attackSpeedBoost = rnd.Next(10, 20);
                float moneyBoost = rnd.Next(10, 14);
                float projSpeed = rnd.Next(18, 24);
                float debuff = rnd.Next(18, 24);
                float cooldown = rnd.Next(5, 7);

                if (strength.StrengthName == "Damage Boost")
                {
                    damageBoost += 1;
                    strength.damageBonus = damageBoost;
                }
                if (strength.StrengthName == "Attack Speed Boost")
                {
                    attackSpeedBoost += 9;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                }
                if (strength.StrengthName == "Range Boost")
                {
                    rangeBoost += 9;
                    pierceBoost += 1;
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                }
                if (strength.StrengthName == "Money Boost")
                {
                    moneyBoost += 5;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Multi Boost")
                {
                    strength.damageBonus = damageBoost;
                    strength.pierceBonus = pierceBoost;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Projectile Speed")
                {
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.projectileSpeed = 1 + (projSpeed / 100);
                }
                if (strength.StrengthName == "Debuff Duration")
                {
                    strength.debuffDuration = 1 + (debuff / 100);
                }
                if (strength.StrengthName == "Ability Cooldown")
                {
                    strength.abilityCooldown = 1 + (cooldown / 100);
                }

                strengthList.Add(strength);
            }
        }
    }
}
public class Omega : StrengthRarityTemplate
{
    public override float RarityIncreaser => 0.15f;
    public override float TrueMinimumValue => 90;
    public override Rarity StrengthRarity => Rarity.Omega;
    public override int Level => 3;
    public override int Order => 6;
    public override void StrengthList(List<StrengthTemplate> strengthList)
    {
        foreach (var strength in GetContent<StrengthTemplate>())
        {
            if (strength.StrengthRarity == StrengthTemplate.Rarity.Omega)
            {
                Il2CppSystem.Random rnd = new Il2CppSystem.Random();
                int damageBoost = rnd.Next(10, 18);
                int pierceBoost = rnd.Next(10, 18);
                float rangeBoost = rnd.Next(12, 24);
                float attackSpeedBoost = rnd.Next(12, 24);
                float moneyBoost = rnd.Next(12, 16);
                float projSpeed = rnd.Next(22, 27);
                float debuff = rnd.Next(22, 27);
                float cooldown = rnd.Next(7, 9);

                if (strength.StrengthName == "Damage Boost")
                {
                    damageBoost += 1;
                    strength.damageBonus = damageBoost;
                }
                if (strength.StrengthName == "Attack Speed Boost")
                {
                    attackSpeedBoost += 12;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                }
                if (strength.StrengthName == "Range Boost")
                {
                    rangeBoost += 12;
                    pierceBoost += 1;
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                }
                if (strength.StrengthName == "Money Boost")
                {
                    moneyBoost += 5;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Multi Boost")
                {
                    strength.damageBonus = damageBoost;
                    strength.pierceBonus = pierceBoost;
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.rangeBonus = 1 + (rangeBoost / 100);
                    strength.pierceBonus = pierceBoost;
                    strength.moneyBonus = 1 + (moneyBoost / 100);
                }
                if (strength.StrengthName == "Projectile Speed")
                {
                    strength.attackSpeedBonus = 1 + (attackSpeedBoost / 100);
                    strength.projectileSpeed = 1 + (projSpeed / 100);
                }
                if (strength.StrengthName == "Debuff Duration")
                {
                    strength.debuffDuration = 1 + (debuff / 100);
                }
                if (strength.StrengthName == "Ability Cooldown")
                {
                    strength.abilityCooldown = 1 + (cooldown / 100);
                }

                strengthList.Add(strength);
            }
        }
    }
}