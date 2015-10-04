using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
 [CorpseName( "an air elemental corpse" )]
 public class ShameAirElemental : BaseCreature
 {
 // public override double DispelDifficulty{ get{ return 117.5; } }
  //public override double DispelFocus{ get{ return 45.0; } }

  [Constructable]
  public ShameAirElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
  {
   Name = "an air elemental";
   Body = 13;
   Hue = 0x4001;
   BaseSoundID = 655;

   SetStr( 275, 315 );
   SetDex( 190, 200 );
   SetInt( 150, 160 );

   SetHits( 750, 770 );
   SetStam( 195, 200 );
   SetMana( 730, 780 );

   SetDamage( 8, 10 );

   SetDamageType( ResistanceType.Physical, 20 );
   SetDamageType( ResistanceType.Cold, 40 );
   SetDamageType( ResistanceType.Energy, 40 );

   SetResistance( ResistanceType.Physical, 85, 90 );
   SetResistance( ResistanceType.Fire, 55, 65 );
   SetResistance( ResistanceType.Cold, 55, 65 );
   SetResistance( ResistanceType.Poison, 55, 60 );
   SetResistance( ResistanceType.Energy, 50, 55 );

   SetSkill( SkillName.EvalInt, 100.0, 106.0 );
   SetSkill( SkillName.Magery, 102.0, 110.0 );
   SetSkill( SkillName.MagicResist, 95.0, 100.0 );
   SetSkill( SkillName.Tactics, 98.0, 105.0 );
   SetSkill( SkillName.Wrestling, 100.0, 102.0 );

   Fame = 4500;
   Karma = -4500;

   VirtualArmor = 40;
   //ControlSlots = 2;
  }

  public override void GenerateLoot()
  {
   AddLoot( LootPack.Average );
   AddLoot( LootPack.Meager );
   AddLoot( LootPack.LowScrolls );
   AddLoot( LootPack.MedScrolls );
  }

  public override bool BleedImmune{ get{ return true; } }
  public override int TreasureMapLevel{ get{ return 2; } }

  public ShameAirElemental ( Serial serial ) : base( serial )
  {
  }

  public override void Serialize( GenericWriter writer )
  {
   base.Serialize( writer );
   writer.Write( (int) 0 );
  }

  public override void Deserialize( GenericReader reader )
  {
   base.Deserialize( reader );
   int version = reader.ReadInt();

   if ( BaseSoundID == 263 )
    BaseSoundID = 655;
  }
 }
}

 