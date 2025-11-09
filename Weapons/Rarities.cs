using System.Collections.Generic;
using WeaponPacks;

namespace AncientMonkey.Weapons.Rarities;

public class Common : WeaponRarityTemplate
{
    public override float RarityIncreaser => 0f;
    public override float TrueMinimumValue => 0;
    public override Rarity WeaponRarity => Rarity.Common;
    public override int Level => 0;
    public override int Order => 0;
    public override void WeaponList(List<WeaponTemplate> weaponList)
    {
        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.enabled && weapon.WeaponRarity == WeaponTemplate.Rarity.Common)
            {
                weaponList.Add(weapon);
            }
        }
    }
}
public class Rare : WeaponRarityTemplate
{
    public override float RarityIncreaser => 5f;
    public override float TrueMinimumValue => 0;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override int Level => 1;
    public override int Order => 1;
    public override void WeaponList(List<WeaponTemplate> weaponList)
    {
        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.enabled && weapon.WeaponRarity == WeaponTemplate.Rarity.Rare)
            {
                weaponList.Add(weapon);
            }
        }
    }
}
public class Epic : WeaponRarityTemplate
{
    public override float RarityIncreaser => 2f;
    public override float TrueMinimumValue => 1;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override int Level => 1;
    public override int Order => 2;
    public override void WeaponList(List<WeaponTemplate> weaponList)
    {
        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.enabled && weapon.WeaponRarity == WeaponTemplate.Rarity.Epic)
            {
                weaponList.Add(weapon);
            }
        }
    }
}
public class Legendary : WeaponRarityTemplate
{
    public override float RarityIncreaser => 1f;
    public override float TrueMinimumValue => 20;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override int Level => 1;
    public override int Order => 3;
    public override void WeaponList(List<WeaponTemplate> weaponList)
    {
        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.enabled && weapon.WeaponRarity == WeaponTemplate.Rarity.Legendary)
            {
                weaponList.Add(weapon);
            }
        }
    }
}
public class Mythic : WeaponRarityTemplate
{
    public override float RarityIncreaser => 0.5f;
    public override float TrueMinimumValue => 50;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override int Level => 1;
    public override int Order => 4;
    public override void WeaponList(List<WeaponTemplate> weaponList)
    {
        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.enabled && weapon.WeaponRarity == WeaponTemplate.Rarity.Mythic)
            {
                weaponList.Add(weapon);
            }
        }
    }
}
public class Godly : WeaponRarityTemplate
{
    public override float RarityIncreaser => 0.3f;
    public override float TrueMinimumValue => 75;
    public override Rarity WeaponRarity => Rarity.Godly;
    public override int Level => 2;
    public override int Order => 5;
    public override void WeaponList(List<WeaponTemplate> weaponList)
    {
        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.enabled && weapon.WeaponRarity == WeaponTemplate.Rarity.Godly)
            {
                weaponList.Add(weapon);
            }
        }
    }
}
public class Omega : WeaponRarityTemplate
{
    public override float RarityIncreaser => 0.15f;
    public override float TrueMinimumValue => 90;
    public override Rarity WeaponRarity => Rarity.Omega;
    public override int Level => 3;
    public override int Order => 6;
    public override void WeaponList(List<WeaponTemplate> weaponList)
    {
        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.enabled && weapon.WeaponRarity == WeaponTemplate.Rarity.Omega)
            {
                weaponList.Add(weapon);
            }
        }
    }
}
public class Glitched : WeaponRarityTemplate
{
    public override float RarityIncreaser => 0.08f;
    public override float TrueMinimumValue => 99;
    public override Rarity WeaponRarity => Rarity.Glitched;
    public override int Level => 4;
    public override int Order => 7;
    public override void WeaponList(List<WeaponTemplate> weaponList)
    {
        foreach (var weapon in GetContent<WeaponTemplate>())
        {
            if (weapon.enabled && weapon.WeaponRarity == WeaponTemplate.Rarity.Glitched)
            {
                weaponList.Add(weapon);
            }
        }
    }
}