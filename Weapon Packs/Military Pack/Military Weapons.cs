using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions.Behaviors;
using blankdisplay;
using AncientMonkey;

namespace WeaponPacks;

// #### Common ####

public class Sniper : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Sniper";
    public override string CodeName => "Sniper";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.EvenFasterFiringUpgradeIcon);
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SniperMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Sub : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Sub";
    public override string CodeName => "Sub";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BarbedDartsUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeySub").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class MonkeyAce : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Monkey Ace";
    public override string CodeName => "MonkeyAce";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RapidFireUpgradeIcon);
    public override string? Notes => "Notes: Gains a flying Ace\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var ace = Game.instance.model.GetTowerFromId("MonkeyAce").GetBehavior<AirUnitModel>().Duplicate();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyAce").GetBehavior<AttackAirUnitModel>().Duplicate();
        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        ace.AddBehavior(wpn);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(ace);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class Shell : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Shell";
    public override string CodeName => "Shell";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FasterReloadUpgradeIcon2);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MortarMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveBehaviors<TargetSelectedPointModel>();
        wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
        wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
        wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
        wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class LargeCalibre : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Large Calibre";
    public override string CodeName => "LongCalibre";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.LongCalibreUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-202").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class AirburstDarts : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Airburst Darts";
    public override string CodeName => "AirburstDarts";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.AirburstDartsUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeySub-022").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GrapeShot : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Grape Shot";
    public override string CodeName => "GrapeShot";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GrapeShotUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-012").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.GetBehavior<RotateToTargetModel>().additionalRotation = 0;
        wpn.weapons[0].emission.RemoveBehavior<EmissionRotationOffTowerDirectionModel>();
        wpn.weapons[0].ejectX = 0;
        wpn.weapons[0].ejectY = 0;
        wpn.weapons[0].ejectX = 0;
        wpn.weapons[1].ejectX = 0;
        wpn.weapons[1].ejectY = 0;
        wpn.weapons[1].ejectX = 0;
        wpn.weapons[2].ejectX = 0;
        wpn.weapons[2].ejectY = 0;
        wpn.weapons[2].ejectX = 0;
        wpn.weapons[2].emission.RemoveBehavior<EmissionArcRotationOffTowerDirectionModel>();
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class LotsMoreDarts : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Lots More Darts";
    public override string CodeName => "LotsMoreDarts";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.LotsMoreDartsUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Gains a flying Ace\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var ace = Game.instance.model.GetTowerFromId("MonkeyAce-220").GetBehavior<AirUnitModel>().Duplicate();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-220").GetBehavior<AttackAirUnitModel>().Duplicate();
        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        ace.AddBehavior(wpn);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(ace);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class QuadDarts : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Quad Darts";
    public override string CodeName => "QuadDarts";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.QuadDartsUpgradeIcon);
    public override string? Notes => "Notes: Gains a flying Heli\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var heli = Game.instance.model.GetTowerFromId("HeliPilot-100").GetBehavior<AirUnitModel>().Duplicate();
        var wpn = Game.instance.model.GetTowerFromId("HeliPilot-100").GetBehavior<AttackModel>().Duplicate();
        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        heli.AddBehavior(wpn);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(heli);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class BurnyStuff : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Burny Stuff";
    public override string CodeName => "BurnyStuff";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BurnyStuffUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Stronger Compound", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-022").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveBehaviors<TargetSelectedPointModel>();
        wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
        wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
        wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
        wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class LaserShock : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Laser Shock";
    public override string CodeName => "LaserShock";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.LaserShockUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast",
"Tracking", "Stronger Compound", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-210").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class BouncingBullet : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Bouncing Bullet";
    public override string CodeName => "BouncingBullet";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BouncingBulletUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-230").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class FullAutoRifle : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Full Auto Rifle";
    public override string CodeName => "FullAutoRifle";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FullAutoRifleUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-104").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BallisticMissile : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Ballistic Missile";
    public override string CodeName => "BallisticMissile";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BallisticMissileUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Only attacks in range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeySub-032").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class ArmorPiercingDarts : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Armor Piercing Darts";
    public override string CodeName => "ArmorPiercingDarts";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ArmorPiercingDartsUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeySub-024").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Destroyer : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Destroyer";
    public override string CodeName => "Destroyer";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.DestroyerUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast",
"Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-302").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.GetBehavior<RotateToTargetModel>().additionalRotation = 0;
        wpn.weapons[0].emission.RemoveBehavior<EmissionRotationOffTowerDirectionModel>();
        wpn.weapons[0].ejectX = 0;
        wpn.weapons[0].ejectY = 0;
        wpn.weapons[0].ejectX = 0;
        wpn.weapons[1].ejectX = 0;
        wpn.weapons[1].ejectY = 0;
        wpn.weapons[1].ejectX = 0;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class CannonShip : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Cannon Ship";
    public override string CodeName => "CannonShip";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CannonShipUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Double Tap", "Tracking", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyBuccaneer-032").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.GetBehavior<RotateToTargetModel>().additionalRotation = 0;
        wpn.weapons[0].emission.RemoveBehavior<EmissionArcRotationOffTowerDirectionModel>();
        wpn.weapons[0].ejectX = 0;
        wpn.weapons[0].ejectY = 0;
        wpn.weapons[0].ejectX = 0;
        wpn.weapons[1].ejectX = 0;
        wpn.weapons[1].ejectY = 0;
        wpn.weapons[1].ejectX = 0;
        wpn.weapons[2].ejectX = 0;
        wpn.weapons[2].ejectY = 0;
        wpn.weapons[2].ejectX = 0;
        wpn.weapons[2].emission.RemoveBehavior<EmissionRotationOffTowerDirectionModel>();
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class OperationDartStorm : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Operation: Dart Storm";
    public override string CodeName => "OperationDartStorm";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.OperationDartStormUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Gains a flying Ace\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wither", "Freezing Touch"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var ace = Game.instance.model.GetTowerFromId("MonkeyAce-420").GetBehavior<AirUnitModel>().Duplicate();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-420").GetBehavior<AttackAirUnitModel>().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-420").GetBehaviors<AttackAirUnitModel>()[1].Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("MonkeyAce-420").GetBehaviors<AttackAirUnitModel>()[2].Duplicate();
        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        ace.AddBehavior(wpn);
        ace.AddBehavior(wpn2);
        ace.AddBehavior(wpn3);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(ace);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class BomberAce : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Bomber Ace";
    public override string CodeName => "BomberAce";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BomberAceUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Gains a flying Ace\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wither", "Freezing Touch"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var ace = Game.instance.model.GetTowerFromId("MonkeyAce-230").GetBehavior<AirUnitModel>().Duplicate();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-230").GetBehavior<AttackAirUnitModel>().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-230").GetBehaviors<AttackAirUnitModel>()[1].Duplicate();
        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        ace.AddBehavior(wpn);
        ace.AddBehavior(wpn2);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(ace);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class TheBigOne : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "The Big One";
    public override string CodeName => "TheBIgOne";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TheBIgOneUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Stronger Compound", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-402").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveBehaviors<TargetSelectedPointModel>();
        wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
        wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
        wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
        wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class ArtilleryBattery : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Artillery Battery";
    public override string CodeName => "ArtilleryBattery";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ArtilleryBatteryUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-240").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveBehaviors<TargetSelectedPointModel>();
        wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
        wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
        wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
        wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class LaserCannon : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Laser Cannon";
    public override string CodeName => "LaserCannon";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.LaserCannonUpgradeIcon);
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast",
"Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-300").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class HydraRocketPods : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Hydra Rocket Pods";
    public override string CodeName => "HydraRockets";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.HydraRocketsUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Tracking", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-030").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Buckshot : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Buckshot";
    public override string CodeName => "Buckshot";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BuckshotUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-023").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class CrippleMOAB : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Cripple MOAB";
    public override string CodeName => "CrippleMoab";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CrippleMoabUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class EliteDefender : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Elite Defender";
    public override string CodeName => "EliteDefender";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.EliteDefenderUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Incendiary", "God Boost", "Wind Blast", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SniperMonkey-025").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class SubCommander : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Sub Commander";
    public override string CodeName => "SubCommander";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SubCommanderUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeySub-025").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}/*
public class CarrierFlagship : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override bool IsLead => true;
    public override string WeaponName => "Carrier Flagship";
    public override string CodeName => "CarrierFlagship";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CarrierFlagshipUpgradeIcon);
    public override string? Notes => "Notes: NA\n\nGilded Effect: ";
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeySub-025").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}*/
public class SkyShredder : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Sky Shredder";
    public override string CodeName => "SkyShredder";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SkyShredderUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Gains a flying Ace\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wither", "Freezing Touch"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var ace = Game.instance.model.GetTowerFromId("MonkeyAce-520").GetBehavior<AirUnitModel>().Duplicate();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-520").GetBehavior<AttackAirUnitModel>().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-520").GetBehaviors<AttackAirUnitModel>()[1].Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("MonkeyAce-520").GetBehaviors<AttackAirUnitModel>()[2].Duplicate();
        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        ace.AddBehavior(wpn);
        ace.AddBehavior(wpn2);
        ace.AddBehavior(wpn3);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(ace);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class ApacheDartship : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Apache Dartship";
    public override string CodeName => "ApacheDartship";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ApacheDartshipUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Gains a flying Heli\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var heli = Game.instance.model.GetTowerFromId("HeliPilot-402").GetBehavior<AirUnitModel>().Duplicate();
        var wpn1 = Game.instance.model.GetTowerFromId("HeliPilot-402").GetAttackModel(0).Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("HeliPilot-402").GetAttackModel(1).Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("HeliPilot-402").GetAttackModel(2).Duplicate();
        wpn1.RemoveBehavior<PursuitSettingModel>();

        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        heli.AddBehavior(wpn1);
        heli.AddBehavior(wpn2);
        heli.AddBehavior(wpn3);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(heli);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class ComancheCommander : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Comanche Commander";
    public override string CodeName => "ComancheCommander";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ComancheCommanderUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Gains a flying Heli\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Tracking", "Wither", "Freezing Touch"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var heli = Game.instance.model.GetTowerFromId("HeliPilot-025").GetBehavior<AirUnitModel>().Duplicate();
        var wpn1 = Game.instance.model.GetTowerFromId("HeliPilot-025").GetAttackModel().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("HeliPilot-025").GetBehavior<AttackAirUnitModel>().Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("HeliPilot-025").GetBehavior<ComancheDefenceModel>().Duplicate();

        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3.towerModel.GetAttackModel(), gilded, gildedEffect, degree);
        heli.AddBehavior(wpn1);
        heli.AddBehavior(wpn2);
        heli.AddBehavior(wpn3);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(heli);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class TheBiggestOne : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "The Biggest One";
    public override string CodeName => "TheBiggestOne";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.TheBIggestOneUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-500").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveBehaviors<TargetSelectedPointModel>();
        wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
        wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
        wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
        wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Blooncineration : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Blooncineration";
    public override string CodeName => "Blooncineration";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BlooncinerationUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Hawk Eye", "Stronger Compound", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MortarMonkey-205").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveBehaviors<TargetSelectedPointModel>();
        wpn.AddBehavior(new TargetStrongModel("targetstrong", false, false));
        wpn.AddBehavior(new TargetCloseModel("targetclose", false, false));
        wpn.AddBehavior(new TargetFirstModel("targetfirst", false, false));
        wpn.AddBehavior(new TargetLastModel("targetlast", false, false));
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class PlasmaAccelerator : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Plasma Accelerator";
    public override string CodeName => "PlasmaAccelerator";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PlasmaAcceleratorUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "God Boost", "Stronger Compound", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-420").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BADS : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Bloon Area Denial System";
    public override string CodeName => "BloonAreaDenialSystem";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BloonAreaDenialSystemUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("DartlingGunner-024").GetAttackModel(0).Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("DartlingGunner-024").GetAttackModel(1).Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("DartlingGunner-024").GetAttackModel(2).Duplicate();
        var wpn4 = Game.instance.model.GetTowerFromId("DartlingGunner-024").GetAttackModel(3).Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        wpn4.name = "Attack4" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        wpn3.range = tower.towerModel.range;
        wpn4.range = tower.towerModel.range;
        wpn2.ApplyDisplay<BlankDisplay>();
        wpn3.ApplyDisplay<BlankDisplay>();
        wpn4.ApplyDisplay<BlankDisplay>();
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn4, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        towerModel.AddBehavior(wpn3);
        towerModel.AddBehavior(wpn4);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class FlyingFortress : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FlyingFortressUpgradeIcon);
    public override string WeaponName => "Flying Fortress";
    public override string CodeName => "FlyingFortress";
    public override bool IsLead => true;
    public override string? Notes => "Notes: Gains a flying Ace\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var ace = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehavior<AirUnitModel>().Duplicate();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehavior<AttackAirUnitModel>().Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehaviors<AttackAirUnitModel>()[1].Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehaviors<AttackAirUnitModel>()[2].Duplicate();
        var wpn4 = Game.instance.model.GetTowerFromId("MonkeyAce-205").GetBehaviors<AttackAirUnitModel>()[3].Duplicate();
        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn4, gilded, gildedEffect, degree);
        ace.AddBehavior(wpn); 
        ace.AddBehavior(wpn2);
        ace.AddBehavior(wpn3);
        ace.AddBehavior(wpn4);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(ace);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class ApachePrime : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Apache Prime";
    public override string CodeName => "ApachePrime";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ApachePrimeUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Gains a flying Heli\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Freezing Touch"];
    public override bool CreateTower => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var phoenix = Game.instance.model.GetTowerFromId("WizardMonkey-050").GetBehavior<TowerCreateTowerModel>().Duplicate();
        var heli = Game.instance.model.GetTowerFromId("HeliPilot-502").GetBehavior<AirUnitModel>().Duplicate();
        var wpn1 = Game.instance.model.GetTowerFromId("HeliPilot-502").GetAttackModel(0).Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("HeliPilot-502").GetAttackModel(1).Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("HeliPilot-502").GetAttackModel(2).Duplicate();
        wpn1.RemoveBehavior<PursuitSettingModel>();

        phoenix.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        heli.AddBehavior(wpn1);
        heli.AddBehavior(wpn2);
        heli.AddBehavior(wpn3);
        phoenix.towerModel.ApplyDisplay<BlankDisplay>();
        phoenix.towerModel.RemoveBehavior<AttackModel>();
        phoenix.towerModel.RemoveBehavior<PathMovementFromScreenCenterModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnPlaceModel>();
        phoenix.towerModel.RemoveBehavior<CreateEffectOnExpireModel>();
        phoenix.towerModel.AddBehavior(heli);

        towerModel.AddBehavior(phoenix);
        tower.UpdateRootModel(towerModel);
    }
}
public class RayOfDoom : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Ray Of Doom";
    public override string CodeName => "RayOfDoom";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RayOfDoomUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "God Boost", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class MAD : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "M.A.D.";
    public override string CodeName => "MAD";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MadUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Tracking", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartlingGunner-250").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BEZ : WeaponTemplate
{
    public override string WeaponPack => "MilitaryPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Bloon Exclusion Zone";
    public override string CodeName => "BloonExclusionZone";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BloonExclusionZoneUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn1 = Game.instance.model.GetTowerFromId("DartlingGunner-025").GetAttackModel(0).Duplicate();
        var wpn2 = Game.instance.model.GetTowerFromId("DartlingGunner-025").GetAttackModel(1).Duplicate();
        var wpn3 = Game.instance.model.GetTowerFromId("DartlingGunner-025").GetAttackModel(2).Duplicate();
        var wpn4 = Game.instance.model.GetTowerFromId("DartlingGunner-025").GetAttackModel(3).Duplicate();
        var wpn5 = Game.instance.model.GetTowerFromId("DartlingGunner-025").GetAttackModel(4).Duplicate();
        var wpn6 = Game.instance.model.GetTowerFromId("DartlingGunner-025").GetAttackModel(5).Duplicate();
        wpn1.name = "Attack1" + WeaponRarity + CodeName;
        wpn2.name = "Attack2" + WeaponRarity + CodeName;
        wpn3.name = "Attack3" + WeaponRarity + CodeName;
        wpn4.name = "Attack4" + WeaponRarity + CodeName;
        wpn5.name = "Attack5" + WeaponRarity + CodeName;
        wpn6.name = "Attack6" + WeaponRarity + CodeName;
        wpn1.range = tower.towerModel.range;
        wpn2.range = tower.towerModel.range;
        wpn3.range = tower.towerModel.range;
        wpn4.range = tower.towerModel.range;
        wpn5.range = tower.towerModel.range;
        wpn6.range = tower.towerModel.range;
        wpn2.ApplyDisplay<BlankDisplay>();
        wpn3.ApplyDisplay<BlankDisplay>();
        wpn4.ApplyDisplay<BlankDisplay>();
        wpn5.ApplyDisplay<BlankDisplay>();
        wpn6.ApplyDisplay<BlankDisplay>();
        WeaponMethods.AfterEffects(wpn1, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn2, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn3, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn4, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn5, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(wpn6, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn1);
        towerModel.AddBehavior(wpn2);
        towerModel.AddBehavior(wpn3);
        towerModel.AddBehavior(wpn4);
        towerModel.AddBehavior(wpn5);
        towerModel.AddBehavior(wpn6);
        tower.UpdateRootModel(towerModel);
    }
}