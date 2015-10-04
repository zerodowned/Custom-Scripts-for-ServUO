using System; 
using System.Collections.Generic; 
using Server; 

namespace Server.Mobiles 
{ 
	public class AIOButcher : BaseAIOVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		[Constructable]
		public AIOButcher() : base( "the butcher" ) 
		{ 
		
			CantWalk = true;
			SetSkill( SkillName.Anatomy, 45.0, 68.0 );
		} 
		
		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBButcher() ); 
		//	m_SBInfos.Add( new SBSellAll() );
		}

		public override void InitOutfit()
		{
			base.InitOutfit();

			AddItem( new Server.Items.HalfApron() );
			AddItem( new Server.Items.Cleaver() );
		}

		public AIOButcher( Serial serial ) : base( serial ) 
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
		} 
	} 
}