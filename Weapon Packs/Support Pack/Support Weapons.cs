using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using AncientMonkey;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace WeaponPacks;

// #### Common ####

public class Spikes : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Spikes";
    public override string CodeName => "Spikes";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BiggerStacksUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Bananas : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Bananas";
    public override string CodeName => "Bananas";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.IncreasedProductionUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects => ["Shiny", "Fertilizer"];
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BananaFarm").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Nail : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Nail";
    public override string CodeName => "Nail";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.LargerServiceAreaUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class WhiteHotSpikes : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "White Hot Spikes";
    public override string CodeName => "WhiteHotSpikes";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.WhiteHotSpikesUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-220").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class GreaterProduction : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Greater Production";
    public override string CodeName => "GreaterProduction";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GreaterProductionUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects => ["Shiny", "Fertilizer"];
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BananaFarm-200").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class FasterEngineering : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Faster Engineering";
    public override string CodeName => "FasterEngineering";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.FasterEngineeringUpgradeIcon);
    public override string? Notes => "Notes: Creates sentries nearby\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot", "Sentry Upgrade"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-200").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        if (gildedEffect == "Sentry Upgrade") { wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = Game.instance.model.GetTowerFromId("SentryCrushing").Duplicate(); }
        WeaponMethods.AfterEffects(wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower.GetAttackModel(), gilded, gildedEffect, degree);       
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class DoubleGun : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Double Gun";
    public override string CodeName => "DoubleGun";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.DoubleGunUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-023").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class SpikedBalls : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Spiked Balls";
    public override string CodeName => "SpikedBalls";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SpikedBallsUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-320").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class MOABSHREDR : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "MOAB SHREDR";
    public override string CodeName => "MOABSHREDR";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MOABSHREDRUpgradeIcon);
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-130").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class DeadlySpikes : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Deadly Spikes";
    public override string CodeName => "DeadlySpikes";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.DeadlySpikesUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-204").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveBehavior<TargetSelectedPointModel>();
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BananaPlantation : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Banana Plantation";
    public override string CodeName => "BananaPlantation";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BananaPlantationUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects => ["Shiny", "Fertilizer"];
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BananaFarm-320").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Marketplace : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Marketplace";
    public override string CodeName => "Marketplace";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MarketplaceUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects => ["Shiny", "Fertilizer"];
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BananaFarm-023").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class SentryExpert : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Sentry Expert";
    public override string CodeName => "SentryExpert";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SentryExpertUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-400").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        var senWpn = wpn.weapons[0].projectile.GetBehavior<CreateTypedTowerModel>();
        var crushing = senWpn.crushingTower.GetAttackModel();
        var boom = senWpn.boomTower.GetAttackModel();
        var energy = senWpn.energyTower.GetAttackModel();
        var frost = senWpn.coldTower.GetAttackModel();
        WeaponMethods.AfterEffects(crushing, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(boom, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(energy, gilded, gildedEffect, degree);
        WeaponMethods.AfterEffects(frost, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BloonTrap : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Bloon Trap";
    public override string CodeName => "BloonTrap";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BloonTrapUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Can be targeted";
    public override string[] GildedEffects => ["Hawk Eye", "Trap Upgrade"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-004").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class SpikedMines : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Spiked Mines";
    public override string CodeName => "SpikedMines";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SpikedMinesUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-420").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class PermaSpike : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Perma Spike";
    public override string CodeName => "PermaSpike";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PermaSpikeUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-205").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.RemoveBehavior<TargetSelectedPointModel>();
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BananaResearchFacility : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Banana Research Facility";
    public override string CodeName => "BananaResearchFacility";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BananaResearchFacilityUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects => ["Shiny", "Fertilizer"];
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BananaFarm-420").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class PrimaryExpertise : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Primary Expertise";
    public override string CodeName => "PrimaryExpertise";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PrimaryExpertiseUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global Range\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("MonkeyVillage-520").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class SentryChampion : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Sentry Champion";
    public override string CodeName => "SentryChampion";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SentryParagonUpgradeIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Creates sentries nearby\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot", "Sentry Upgrade"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-500").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        if (gildedEffect == "Sentry Upgrade") { wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower = Game.instance.model.GetTowerFromId("SentryParagonChild").Duplicate(); }
        WeaponMethods.AfterEffects(wpn.weapons[0].projectile.GetBehavior<CreateTowerModel>().tower.GetAttackModel(), gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class SuperMines : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Super Mines";
    public override string CodeName => "SuperMines";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SuperMinesUpgradeIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Change targeting\n";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Wither"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("SpikeFactory-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class BananaCentral : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Banana Central";
    public override string CodeName => "BananaCentral";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.BananaCentralUpgradeIcon);
    public override string? Notes => "";
    public override string[] GildedEffects => ["Shiny", "Fertilizer"];
    public override bool MoneyMaker => true;
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("BananaFarm-520").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class XXXLTrap : WeaponTemplate
{
    public override string WeaponPack => "SupportPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.XXXLUpgradeIcon);
    public override string WeaponName => "XXXL Trap";
    public override string CodeName => "XXXLTrap";
    public override bool IsLead => true;
    public override string? Notes => "Notes: Can be targeted";
    public override string[] GildedEffects => ["Hawk Eye", "Trap Upgrade"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("EngineerMonkey-015").GetAttackModel(1).Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}