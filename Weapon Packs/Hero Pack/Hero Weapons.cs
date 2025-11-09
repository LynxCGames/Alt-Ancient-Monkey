using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppNinjaKiwi.Common.ResourceUtils;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using AncientMonkey;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;

namespace WeaponPacks;

// #### Common ####

public class Quincy : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Quincy";
    public override string CodeName => "Quincy";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.QuincyIcon);
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Quincy").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Ezili : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 1;
    public override Rarity WeaponRarity => Rarity.Common;
    public override string WeaponName => "Ezili";
    public override string CodeName => "Ezili";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.EziliIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Stronger Compound", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Ezili").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Rare ####

public class Obyn : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Obyn";
    public override string CodeName => "Obyn";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.ObynGreenFootIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("ObynGreenfoot").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Gwendolin : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Gwendolin";
    public override string CodeName => "Gwendolin";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GwendolinIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Gwendolin").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Sauda : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Sauda";
    public override string CodeName => "Sauda";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SaudaIcon);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Sauda").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Churchill : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Churchill";
    public override string CodeName => "Churchill";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CaptainChurchillIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("CaptainChurchill").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Adora : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Adora";
    public override string CodeName => "Adora";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.AdoraIcon);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Adora").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Psi : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Psi";
    public override string CodeName => "Psi";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PsiIcon);
    public override bool IsCamo => true;
    public override string? Notes => "Notes: Global Range\n";
    public override string[] GildedEffects =>
    ["Fast Hands", "God Boost", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Psi").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class RosaliaLaser : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Rosalia Laser";
    public override string CodeName => "RosaliaLaser";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RosaliaIcon);
    public override string? Notes => "Notes: Only Rosalia's laser weapon\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.weapons[0] = Game.instance.model.GetTowerFromId("Rosalia 2").GetBehavior<AttackAirUnitModel>().weapons[0].Duplicate();
        wpn.weapons[0].RemoveBehavior<FireFromAirUnitModel>();
        wpn.weapons[0].RemoveBehavior<AnimateAirUnitOnFireModel>();
        wpn.weapons[0].RemoveBehavior<SwapProjectileModel>();
        wpn.weapons[0].projectile = Game.instance.model.GetTowerFromId("Rosalia 2").GetBehavior<AttackAirUnitModel>().weapons[0].GetBehavior<SwapProjectileModel>().projectileModelA.Duplicate();
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class RosaliaBomb : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Rosalia Grenade";
    public override string CodeName => "RosaliaGrenade";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RosaliaIcon);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Only Rosalia's grenade launcher\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.weapons[0] = Game.instance.model.GetTowerFromId("Rosalia 2").GetBehavior<AttackAirUnitModel>().weapons[0].Duplicate();
        wpn.weapons[0].RemoveBehavior<FireFromAirUnitModel>();
        wpn.weapons[0].RemoveBehavior<AnimateAirUnitOnFireModel>();
        wpn.weapons[0].RemoveBehavior<SwapProjectileModel>();
        wpn.weapons[0].projectile = Game.instance.model.GetTowerFromId("Rosalia 2").GetBehavior<AttackAirUnitModel>().weapons[0].GetBehavior<SwapProjectileModel>().projectileModelB.Duplicate();
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Silas : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 2;
    public override Rarity WeaponRarity => Rarity.Rare;
    public override string WeaponName => "Silas";
    public override string CodeName => "Silas";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SilasIcon);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Stronger Compound", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Silas").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Epic ####

public class Quincy10 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Quincy Lvl 10";
    public override string CodeName => "Quincy10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.QuincyPortraitLvl10);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Quincy 10").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Obyn10 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Obyn Lvl 10";
    public override string CodeName => "Obyn10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MountainObynPortraitsLvl10);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("ObynGreenfoot 10").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Gwendolin10 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Gwendolin Lvl 10";
    public override string CodeName => "Gwendolin10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GwendolinPortraitLvl10);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Double Tap",
"Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Explosive Rounds", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Gwendolin 10").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Sauda10 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Sauda Lvl 10";
    public override string CodeName => "Sauda10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SaudaPortraitLvl10);
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Sauda 10").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Churchill10 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Churchill Lvl 10";
    public override string CodeName => "Churchill10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CaptainChurchillPortraitLvl10);
    public override bool IsLead => true;
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost",
"Tracking", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("CaptainChurchill 10").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Adora10 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Adora Lvl 10";
    public override string CodeName => "Adora10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.AdoraPortraitLvl10);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Adora 10").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Psi10 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Psi Lvl 10";
    public override string CodeName => "Psi10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PsiPortraitLvl10);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global Range\n";
    public override string[] GildedEffects =>
    ["Fast Hands", "God Boost", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Psi 10").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Rosalia10Laser : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Rosalia Lvl 10 Laser";
    public override string CodeName => "Rosalia10Laser";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RosaliaPortraitLvl13);
    public override string? Notes => "Notes: Only Rosalia's laser weapon\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.weapons[0] = Game.instance.model.GetTowerFromId("Rosalia 10").GetBehavior<AttackAirUnitModel>().weapons[0].Duplicate();
        wpn.weapons[0].RemoveBehavior<FireFromAirUnitModel>();
        wpn.weapons[0].RemoveBehavior<AnimateAirUnitOnFireModel>();
        wpn.weapons[0].RemoveBehavior<SwapProjectileModel>();
        wpn.weapons[0].RemoveBehavior<DuplicateProjectilePerEmitModel>();
        wpn.weapons[0].GetBehavior<ChangeProjectilePerEmitModel>().effectBeforeChangedProjectileModel = null;
        wpn.weapons[0].projectile = Game.instance.model.GetTowerFromId("Rosalia 10").GetBehavior<AttackAirUnitModel>().weapons[0].GetBehavior<SwapProjectileModel>().projectileModelA.Duplicate();
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Rosalia10Bomb : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Rosalia Lvl 10 Grenade";
    public override string CodeName => "Rosalia10Grenade";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RosaliaPortraitLvl13);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Only Rosalia's grenade launcher\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap",
"Hawk Eye", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.weapons[0] = Game.instance.model.GetTowerFromId("Rosalia 10").GetBehavior<AttackAirUnitModel>().weapons[0].Duplicate();
        wpn.weapons[0].RemoveBehavior<FireFromAirUnitModel>();
        wpn.weapons[0].RemoveBehavior<AnimateAirUnitOnFireModel>();
        wpn.weapons[0].RemoveBehavior<SwapProjectileModel>();
        wpn.weapons[0].RemoveBehavior<ChangeProjectilePerEmitModel>();
        wpn.weapons[0].GetBehavior<DuplicateProjectilePerEmitModel>().effectBeforeDuplicatedProjectileModel = null;
        wpn.weapons[0].projectile = Game.instance.model.GetTowerFromId("Rosalia 10").GetBehavior<AttackAirUnitModel>().weapons[0].GetBehavior<SwapProjectileModel>().projectileModelB.Duplicate();
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Silas20 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 3;
    public override Rarity WeaponRarity => Rarity.Epic;
    public override string WeaponName => "Silas Lvl 20";
    public override string CodeName => "Silas20";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SilasPortraitsLvl20);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "God Boost", "Wind Blast", "Double Tap",
"Hawk Eye", "Stronger Compound", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Silas 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Legendary ####

public class Quincy20 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Quincy Lvl 20";
    public override string CodeName => "Quincy20";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.QuincyPortraitLvl20);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Incendiary", "God Boost", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Quincy 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Ezili10 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Ezili Lvl 10";
    public override string CodeName => "Ezili10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.EziliPortraitLvl10);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Stronger Compound", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Ezili 10").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Obyn20 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Obyn Lvl 20";
    public override string CodeName => "Obyn20";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.MountainObynPortraitsLvl20);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("ObynGreenfoot 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Gwendolin20 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Gwendolin Lvl 20";
    public override string CodeName => "Gwendolin20";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.GwendolinPortraitLvl20);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "God Boost", "Hawk Eye", "Tracking", "Stronger Compound", "Wither", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Gwendolin 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Sauda20 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Sauda Lvl 20";
    public override string CodeName => "Sauda20";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.SaudaPortraitLvl20);
    public override bool IsLead => true;
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "Incendiary", "God Boost", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Sauda 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Churchill20 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Churchill Lvl 20";
    public override string CodeName => "Churchill10";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.CaptainChurchillPortraitLvl20);
    public override bool IsLead => true;
    public override bool IsCamo => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost",
"Tracking", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("CaptainChurchill 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Adora20 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Adora Lvl 20";
    public override string CodeName => "Adora20";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.AdoraPortraitLvl20);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Rosalia20Laser : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Rosalia Lvl 20 Laser";
    public override string CodeName => "Rosalia20Laser";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RosaliaPortraitLvl20);
    public override string? Notes => "Notes: Only Rosalia's laser weapon\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap",
"Hawk Eye", "Tracking", "Wither", "Explosive Rounds", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.weapons[0] = Game.instance.model.GetTowerFromId("Rosalia 20").GetBehavior<AttackAirUnitModel>().weapons[0].Duplicate();
        wpn.weapons[0].RemoveBehavior<FireFromAirUnitModel>();
        wpn.weapons[0].RemoveBehavior<AnimateAirUnitOnFireModel>();
        wpn.weapons[0].RemoveBehavior<SwapProjectileModel>();
        wpn.weapons[0].RemoveBehavior<DuplicateProjectilePerEmitModel>();
        wpn.weapons[0].GetBehavior<ChangeProjectilePerEmitModel>().effectBeforeChangedProjectileModel = null;
        wpn.weapons[0].projectile = Game.instance.model.GetTowerFromId("Rosalia 20").GetBehavior<AttackAirUnitModel>().weapons[0].GetBehavior<SwapProjectileModel>().projectileModelA.Duplicate();
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Rosalia20Bomb : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 4;
    public override Rarity WeaponRarity => Rarity.Legendary;
    public override string WeaponName => "Rosalia Lvl 20 Grenade";
    public override string CodeName => "Rosalia20Grenade";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.RosaliaPortraitLvl20);
    public override bool IsLead => true;
    public override string? Notes => "Notes: Only Rosalia's grenade launcher\n";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Double Tap",
"Hawk Eye", "Wither", "Freezing Touch", "Multishot"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("DartMonkey").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.weapons[0] = Game.instance.model.GetTowerFromId("Rosalia 20").GetBehavior<AttackAirUnitModel>().weapons[0].Duplicate();
        wpn.weapons[0].RemoveBehavior<FireFromAirUnitModel>();
        wpn.weapons[0].RemoveBehavior<AnimateAirUnitOnFireModel>();
        wpn.weapons[0].RemoveBehavior<SwapProjectileModel>();
        wpn.weapons[0].RemoveBehavior<ChangeProjectilePerEmitModel>();
        wpn.weapons[0].GetBehavior<DuplicateProjectilePerEmitModel>().effectBeforeDuplicatedProjectileModel = null;
        wpn.weapons[0].projectile = Game.instance.model.GetTowerFromId("Rosalia 20").GetBehavior<AttackAirUnitModel>().weapons[0].GetBehavior<SwapProjectileModel>().projectileModelB.Duplicate();
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}

// #### Mythic ####

public class Ezili20 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Ezili Lvl 20";
    public override string CodeName => "Ezili20";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.EziliPortraitLvl20);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Super Strength", "Fast Hands", "God Boost", "Double Tap", "Stronger Compound", "Wither", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Ezili 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class Psi20 : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Psi Lvl 20";
    public override string CodeName => "Psi20";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.PsiPortraitLvl20);
    public override bool IsCamo => true;
    public override bool IsLead => true;
    public override string? Notes => "Notes: Global Range\n";
    public override string[] GildedEffects =>
    ["Fast Hands", "God Boost", "Explosive Rounds"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Psi 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}
public class SunGodAdora : WeaponTemplate
{
    public override string WeaponPack => "HeroPack";
    public override int SandboxIndex => 5;
    public override Rarity WeaponRarity => Rarity.Mythic;
    public override string WeaponName => "Sun God Adora";
    public override string CodeName => "SunGodAdora";
    public override SpriteReference Icon => CreateSpriteReference(VanillaSprites.AdoraPortraitLvl20SunGod);
    public override bool IsLead => true;
    public override string? Notes => "";
    public override string[] GildedEffects =>
    ["Piercing Winds", "Super Strength", "Fast Hands", "Incendiary", "God Boost", "Hawk Eye", "Wither", "Explosive Rounds", "Freezing Touch"];
    public override void EditTower(Tower tower, bool gilded, string gildedEffect, int degree)
    {
        var towerModel = tower.rootModel.Duplicate().Cast<TowerModel>();
        var wpn = Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().Duplicate();
        wpn.name = "Attack" + WeaponRarity + CodeName;
        wpn.range = tower.towerModel.range;
        wpn.GetDescendants<ProjectileModel>().ForEach(model => model.pierce += 30);
        wpn.GetDescendants<DamageModel>().ForEach(model => model.damage += 8);
        WeaponMethods.AfterEffects(wpn, gilded, gildedEffect, degree);
        towerModel.AddBehavior(wpn);
        tower.UpdateRootModel(towerModel);
    }
}