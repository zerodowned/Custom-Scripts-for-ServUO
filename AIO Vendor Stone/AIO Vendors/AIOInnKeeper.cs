using System; 
using System.Collections.Generic; 
using Server; 

namespace Server.Mobiles 
{ 
	public class AIOInnKeeper : BaseAIOVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		[Constructable]
		public AIOInnKeeper() : base( "the innkeeper" ) 
		{ 
				CantWalk = true;
		} 
		
		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBInnKeeper() ); 
			//m_SBInfos.Add( new SBSellAll() );
			
			if ( IsTokunoVendor )
				m_SBInfos.Add( new SBSEFood() );
		} 

		public override VendorShoeType ShoeType
		{
			get{ return Utility.RandomBool() ? VendorShoeType.Sandals : VendorShoeType.Shoes; }
		}

		public AIOInnKeeper( Serial serial ) : base( serial ) 
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