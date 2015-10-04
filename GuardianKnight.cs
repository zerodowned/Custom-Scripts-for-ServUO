using System;
using Server;
using Server.Misc;
using Server.Items;

namespace Server.Mobiles 
{ 
	[CorpseName( "corpse of the Guardian Knight" )] 
	public class GuardianKnight : BaseCreature 
	{ 
	
		//public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }
	
		[Constructable] 
		public GuardianKnight () : base( AIType.AI_Melee, FightMode.Closest, 15, 5, 0.4, 0.5 ) 
		{ 
			SpeechHue = Utility.RandomDyedHue();
			Name = NameList.RandomName("male");
			Title = "the Guardian Knight";
			Body = 400;
			Hue = Utility.RandomNeutralHue();
			
			AddItem(new PlateChest());
			AddItem(new PlateArms());
			AddItem(new PlateLegs());
			AddItem(new PlateGorget());
			AddItem(new PlateHelm());
			AddItem(new DoubleAxe());
			//PlateGorget
			//PlateHelm
			
			Utility.AssignRandomHair( this );
			Utility.AssignRandomFacialHair( this );
			//Hue = ;

			SetStr( 100, 125 );
			SetDex( 100, 130 );
			SetInt( 40, 75 );

			SetHits( 100 );

			SetDamage( 10, 12 );

			SetDamageType( ResistanceType.Physical, 100 );
			

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			//SetSkill( SkillName.EvalInt, 75.1, 100.0 );
			//SetSkill( SkillName.Magery, 75.1, 100.0 );
			SetSkill( SkillName.MagicResist, 75.0, 97.5 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Wrestling, 20.2, 60.0 );

			Fame = 5000;
			Karma = -5000;

			VirtualArmor = 16;
			//PackReg( 6 );
			
		}
		
		// public override bool CanRegenHits { get { return false; } }
		
		public override void OnHitsChange( int oldvalue )
		{
			//if( m is BaseCreature )
				//GuardianKnight BaseCreature = (GuardianKnight) m;
			
			if (this.Hits <= ( ( HitsMax / 2 ) + ( HitsMax / 4 ) )  )
			{
					Item helm = this.FindItemOnLayer(Layer.Helm);
					//PlateHelm helm;
					
					if ( this.FindItemOnLayer(Layer.Helm) != null & this.FindItemOnLayer(Layer.Helm) is PlateHelm )
					{ 	
						helm.Delete();
						//PlateHelm.MoveToWorld( new Point3D( mobile.X + Utility.RandomMinMax( -1, 1 ), this.Y + Utility.RandomMinMax( -1, 1 ), this.Z ), this.Map );
					}
			}
		
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.MedScrolls );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int TreasureMapLevel{ get{ return Core.AOS ? 1 : 0; } }

		public GuardianKnight( Serial serial ) : base( serial )
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
		}
	}
}