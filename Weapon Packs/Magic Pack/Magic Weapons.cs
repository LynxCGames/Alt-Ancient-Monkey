using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using AncientMonkey;

namespace WeaponPacks;

// #### Common ####

public class Magic : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Magic";
    public override string CodeName => "Magic";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.IntenseMagicUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Fireball : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Fireball";
    public override string CodeName => "Fireball";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FireballUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-010").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Shuriken : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Shuriken";
    public override string CodeName => "Shuriken";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SharpShurikensUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("NinjaMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Acid : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Acid";
    public override string CodeName => "Acid";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.LargerPotionsUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap",
"Hawk Eye", "Stronger Compound", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Alchemist").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Thorn : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Thorn";
    public override string CodeName => "Thorn";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ThornSwarmUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Druid").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Trident : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Trident";
    public override string CodeName => "Trident";
    public override SpriteReference Icon => CreateSpriteReference("c2d408c737294434ca03e0b27d4aea61");
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Mermonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class WallOfFire : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Wall of Fire";
    public override string CodeName => "WallOfFire";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.WallOfFireUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Can be targeted\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-120").GetAttackModel(2).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class SuperMonkey : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Super Monkey";
    public override string CodeName => "SuperMonkey";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.EpicRangeUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Incendiary", "God Boost", "Wind Blast",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SuperMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class DoubleShot : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Double Shot";
    public override string CodeName => "DoubleShot";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.DoubleShotUpgradeIcon2);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("NinjaMonkey-300").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class HeartOfThunder : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Heart of Thunder";
    public override string CodeName => "HeartOfThunder";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.HeartofThunderUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Druid-200").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.RemoveWeapon(wpn.weapons[0]);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class ArcaneMastery : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Arcane Mastery";
    public override string CodeName => "ArcaneMastery";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ArcaneMasteryUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-302").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class DragonsBreath : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Dragon's Breath";
    public override string CodeName => "DragonsBreath";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.DragonsBreathUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Explosive Rounds", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-030").GetAttackModel(3).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Necromancer : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Necromancer";
    public override string CodeName => "Necromancer";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.NecromancerUnpoppedArmyUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Has infinite graveyard\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-004").GetAttackModel(2).Duplicate();
        var targetSelect = Game.instance.model.GetTowerFromId("EngineerMonkey-025").GetAttackModel(1).GetBehavior<TargetSelectedPointModel>().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.AddBehavior(targetSelect);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class PlasmaBlasts : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Plasma Blasts";
    public override string CodeName => "PlasmaBlasts";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PlasmaBlastUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Incendiary", "God Boost", "Wind Blast",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-200").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class DarkKnight : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Dark Knight";
    public override string CodeName => "DarkKnight";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.DarkKnightUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Incendiary", "God Boost", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-003").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class StickyBomb : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Sticky Bomb";
    public override string CodeName => "StickyBomb";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.StickyBombUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Sticky Bomb doesn't get stronger\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("NinjaMonkey-204").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("NinjaMonkey-204").GetAttackModel(2).Duplicate();
        wpn.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        towerModel.AddBehavior(wpn2);
        tower.UpdateRootModel(towerModel);
    }
}
public class BallLightning : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Ball Lightning";
    public override string CodeName => "BallLightning";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BallLightningUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Tracking", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Druid-400").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class AbyssalWarrior : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Abyssal Warrior";
    public override string CodeName => "AbyssalWarrior";
    public override SpriteReference Icon => CreateSpriteReference("0973c30d220ec4a488dd919b1e86e45a");
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Stronger Compound", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Mermonkey-402").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class RiptideChampion : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Riptide Champion";
    public override string CodeName => "RiptideChampion";
    public override SpriteReference Icon => CreateSpriteReference("babc6dbc7e96e164896786290c010498");
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Mermonkey-230").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class ArcaneSpike : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Arcane Spike";
    public override string CodeName => "ArcaneSpike";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ArcaneSpikeUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("WizardMonkey-402").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class SunAvatar : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Sun Avatar";
    public override string CodeName => "SunAvatar";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SunAvatarUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Incendiary", "God Boost",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-320").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GrandmasterNinja : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Grandmaster Ninja";
    public override string CodeName => "GrandmasterNinja";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GrandmasterNinjaUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Incendiary", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("NinjaMonkey-501").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class LordOfTheAbyss : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Lord Of The Abyss";
    public override string CodeName => "LordOfTheAbyss";
    public override SpriteReference Icon => CreateSpriteReference("8b68da25def34ea4790d05a1760fa835");
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Only attacks in close range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("Mermonkey-502").GetAttackModel(1).Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("Mermonkey-502").GetAttackModel(2).Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("Mermonkey-502").GetAttackModel(3).Duplicate();
        var wpn4 = Game.instance.model.GetTowerFromId("Mermonkey-502").GetAttackModel(4).Duplicate();
        var wpn5 = Game.instance.model.GetTowerFromId("Mermonkey-502").GetAttackModel(5).Duplicate();
        var wpn6 = Game.instance.model.GetTowerFromId("Mermonkey-502").GetAttackModel(6).Duplicate();
        var wpn7 = Game.instance.model.GetTowerFromId("Mermonkey-502").GetAttackModel(7).Duplicate();
        var wpn8 = Game.instance.model.GetTowerFromId("Mermonkey-502").GetAttackModel(8).Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        wpn4.name = "Attack4" + WeaponRarity + CodeName;
        wpn5.name = "Attack5" + WeaponRarity + CodeName;
        wpn6.name = "Attack6" + WeaponRarity + CodeName;
        wpn7.name = "Attack7" + WeaponRarity + CodeName;
        wpn8.name = "Attack8" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        wpn3.range = tower.towerModel.range;
        wpn4.range = tower.towerModel.range;
        wpn5.range = tower.towerModel.range;
        wpn6.range = tower.towerModel.range;
        wpn7.range = tower.towerModel.range;
        wpn8.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn4, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn5, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn6, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn7, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn8, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        towerModel.AddBehavior(wpn3);
        towerModel.AddBehavior(wpn4);
        towerModel.AddBehavior(wpn5);
        towerModel.AddBehavior(wpn6);
        towerModel.AddBehavior(wpn7);
        towerModel.AddBehavior(wpn8);
        tower.UpdateRootModel(towerModel);
    }
}
public class Popseidon : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Popseidon";
    public override string CodeName => "Popseidon";
    public override SpriteReference Icon => CreateSpriteReference("897071237de03fe4b9bea8152498a8ae");
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Mermonkey-250").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class Archmage : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Archmage";
    public override string CodeName => "Archmage";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ArchmageUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("WizardMonkey-502").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("WizardMonkey-502").GetAttackModel(1).Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("WizardMonkey-502").GetAttackModel(2).Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        wpn3.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        towerModel.AddBehavior(wpn3);
        tower.UpdateRootModel(towerModel);
    }
}
public class TrueSunGod : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "True Son God";
    public override string CodeName => "TrueSonGod";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TrueSonGodUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Incendiary", "God Boost",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-502").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.weapons[0].RemoveBehavior<CheckTempleCanFireModel>();
        wpn.ApplyDisplay<blankdisplay.BlankDisplay>();
        wpn.weapons[0].ejectZ = 7f;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class LegendOfTheNight : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Legend Of The Night";
    public override string CodeName => "LegendOfTheNight";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.LegendOfTheNightUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Incendiary", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SuperMonkey-205").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class SuperStorm : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Super Storm";
    public override string CodeName => "SuperStorm";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SuperStormUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Tracking", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Druid-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class AvatarOfWrath : WeaponTemplate
{
    public override string WeaponPack => "MagicPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Avatar Of Wrath";
    public override string CodeName => "AvatarOfWrath";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.AvatarofWrathUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Druid-025").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}