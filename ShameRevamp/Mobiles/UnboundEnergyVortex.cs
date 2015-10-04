using System;
using Server;
using Server.Items;
using System.Collections;

/*
Detect Hidden, teleports targets to itself, receives half damage from the summons and pets.

*/

namespace Server.Mobiles
{
 [CorpseName( "an unbound energy vortex corpse" )]
 public class UnboundEnergyVortex : BaseCreature
 {
  

  [Constructable]
  public UnboundEnergyVortex ()
   : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
  {
   Name = "an unbound energy vortex";

   Body = 164;
   

   SetStr( 450 );
   SetDex( 200 );
   SetInt( 100 );

   SetHits( 20000);
   SetStam( 250 );
   SetMana( 0 );

   SetDamage( 21, 23 );

   SetDamageType( ResistanceType.Physical, 0 );
   SetDamageType( ResistanceType.Energy, 100 );

   SetResistance( ResistanceType.Physical, 60, 70 );
   SetResistance( ResistanceType.Fire, 65, 75 );
   SetResistance( ResistanceType.Cold, 65, 75 );
   SetResistance( ResistanceType.Poison, 55, 65 );
   SetResistance( ResistanceType.Energy, 100 );

   SetSkill( SkillName.MagicResist, 100.0, 105.0 );
   SetSkill( SkillName.Tactics, 115.0, 130.0 );
   SetSkill( SkillName.Wrestling, 125.0, 135.0 );

   Fame = 22500;
   Karma = -22500;

   VirtualArmor = 40;
   
  }

 public override void GenerateLoot()
  {
   AddLoot( LootPack.FilthyRich );
   AddLoot( LootPack.Rich );
   //5 Crystal of Shame, 4 Void Core, 1 Imbuing Ingredient, Gold  891 
  }


  public override bool BleedImmune{ get{ return true; } }
  public override Poison PoisonImmune { get { return Poison.Lethal; } }

  public override int GetAngerSound()
  {
   return 0x15;
  }

  public override int GetAttackSound()
  {
   return 0x28;
  }

  


  public UnboundEnergyVortex ( Serial serial )
   : base( serial )
  {
  }

  public override void Serialize( GenericWriter writer )
  {
   base.Serialize( writer );

   writer.Write( (int) 0 ); // version
  }

  public override void Deserialize( GenericReader reader )
  {
   base.Deserialize( reader );

   int version = reader.ReadInt();

   if ( BaseSoundID == 263 )
    BaseSoundID = 0;
  }
 }
}