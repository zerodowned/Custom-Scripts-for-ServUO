/////////////////////////////////////////////////////////////////////////
/////	License: GNU/GPL
/////				Free to edit and distribute as you see fit.
/////				All credit notes to remain intact.
/////
/////   Destroyable Walls by Bryan Fury (02.02.2010)
/////   a stripped down version of Attackable Items By Vorspire
/////
//////////////////////////////////////////////////////////////////////////
/////
/////
/////	Attackable Items By Vorspire
/////
/////	Email: admin@vorspire.com
/////
/////	Created: 28th April, 2008 :: 03:40
/////
/////	Updated: 30th April, 2008 :: 19:21
/////
/////	For: Rhovanion-PK :: http://rpk.vorspire.com
/////
/////	Description:
/////
/////	This script was created to bring fun and uniqueness
/////	to any shard that wishes to use it. It is a base class
/////	you can use to derive custom Attackable Items from!
/////	It currently includes features such as; Levels of Strength,
/////	LootBox, Damage Over Time Effects, but you can configure
/////	it however you like!
/////
/////	The script has been supplied as-is, with a simple
/////	configuration. All configuration options have been annotated
/////	to help the user understand better as to what each part of
/////	the script does.
/////
/////	Known Bugs:
/////
/////	None.
/////
/////	Note From The Creator:
/////
/////	I hope you enjoy using, editing and reading this script
/////	as much as I did writing and testing it :)
/////
/////	Please leave this credit note intact!
/////
/////		Best regards,
/////						Vorspire :)
/////
//////////////////////////////////////////////////////////////////////////
/*
*	Edited to allow child mobile to move and attack.
*	The child's corpse will delete 'almost instantly' after death. 
*	This allows items/loot to be dropped on the ground, but in testing is fast enough to prevent       *	Razor/Steam/etc from opening the corpse container.
*	I tried to leave all of the original code in place so you can see where I made edits.
*
*	- zerodowned
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Server;
using Server.Multis;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Targets;

namespace Server.Items
{
	public class DamageableItem2 : Item
	{
		public enum ItemLevel
		{
			NotSet,
			VeryEasy,
			Easy,
			Average,
			Hard,
			VeryHard,
			Insane
		}

		private int m_Hits;
		private int m_HitsMax;
		private int m_StartID;
		private int m_DestroyedID;
		private int m_HalfHitsID;
		private ItemLevel m_ItemLevel;
		private IDamageableItem2 m_Child;

		[CommandProperty( AccessLevel.GameMaster )]
		public IDamageableItem2 Link
		{
			get
			{
				return m_Child;
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public ItemLevel Level
		{
			get
			{
				return m_ItemLevel;
			}
			set
			{
				m_ItemLevel = value;

				double bonus = ( double )( ( ( int )m_ItemLevel * 100.0 ) * ( ( int )m_ItemLevel * 5 ) );

				HitsMax = ( ( int )( 100 + bonus ) );
				Hits = ( ( int )( 100 + bonus ) );

				InvalidateProperties( );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int IDStart
		{
			get
			{
				return m_StartID;
			}
			set
			{
				if( value < 0 )
					m_StartID = 0;
				else if( value > int.MaxValue )
					m_StartID = int.MaxValue;
				else
					m_StartID = value;

				if( m_Hits >= ( m_HitsMax * 0.5 ) )
				{
					if( ItemID != m_StartID )
						ItemID = m_StartID;
				}

				InvalidateProperties( );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int IDHalfHits
		{
			get
			{
				return m_HalfHitsID;
			}
			set
			{
				if( value < 0 )
					m_HalfHitsID = 0;
				else if( value > int.MaxValue )
					m_HalfHitsID = int.MaxValue;
				else
					m_HalfHitsID = value;

				if( m_Hits < ( m_HitsMax * 0.5 ) )
				{
					if( ItemID != m_HalfHitsID )
						ItemID = m_HalfHitsID;
				}

				InvalidateProperties( );
			}
		}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public int Hits
		{
			get
			{
				return m_Hits;
			}
			set
			{
				if( value > m_HitsMax )
					m_Hits = m_HitsMax;
				else
					m_Hits = value;

				if( m_Child != null && ( m_Hits > m_Child.Hits || m_Hits < m_Child.Hits ) )
					UpdateHitsToEntity( );

				InvalidateProperties( );
			}
		}

		[CommandProperty( AccessLevel.GameMaster )]
		public int HitsMax
		{
			get
			{
				return m_HitsMax;
			}
			set
			{
				if( value > int.MaxValue )
					m_HitsMax = int.MaxValue;
				else
					m_HitsMax = value;

				if( Hits > m_HitsMax )
					Hits = m_HitsMax;

				if( m_Child != null && ( m_HitsMax > m_Child.HitsMax || m_HitsMax < m_Child.HitsMax ) )
					UpdateMaxHitsToEntity( );

				InvalidateProperties( );
			}
		}

		[Constructable]
		public DamageableItem2( int StartID, int HalfID )
			: base( StartID )
		{
			Name = "Damageable Item";
			Hue = 0;
			Movable = true;
			//Weight = null;

			Level = ItemLevel.NotSet;

			IDStart = StartID;
			IDHalfHits = HalfID;
			
			Timer.DelayCall(TimeSpan.Zero, ProvideEntity);
		}

		public virtual void OnDamage( int amount, Mobile from, bool willKill )
		{
			return;
		}

		public virtual bool OnBeforeDestroyed( )
		{
			return true;
		}
		
		public virtual void OnDeathDestroyed( )
		{
			return;
		}

		public virtual void OnDestroyed( WoodenBox lootbox )
		{
			return;
		}

		public void UpdateMaxHitsToEntity( )
		{
			m_Child.SetHits( HitsMax );
		}

		public void UpdateHitsToEntity( )
		{
			m_Child.Hits = Hits;
		}

		public void Damage( int amount, Mobile from, bool willKill )
		{
			if( willKill )
			{
				Destroy( );
				return;
			}

			Hits -= amount;

			if( Hits >= ( HitsMax * 0.5 ) )
			{
				ItemID = IDStart;
			}
			else if( Hits < ( HitsMax * 0.5 ) )
			{
				ItemID = IDHalfHits;
			}
			else if( Hits <= 0 )
			{
				Destroy( );
				return;
			}

			OnDamage( amount, from, willKill );
		}
		
		
		
		

		public bool Destroy( )
		{
			if( this == null || this.Deleted )
				return false;

			if( OnBeforeDestroyed( ) )
			{
				if( m_Child != null && !m_Child.Deleted && !m_Child.Alive )
				{
					if( m_Child != null )
					
						//m_Child.Delete( );
						//m_Child.OnDeath( c );
					
					OnDeathDestroyed( );
				//	Delete( );
					return true;
				}
				else
				{
					OnDeathDestroyed( );
				//	Delete( );
					return true;
				}
			}

			return false;
		}


		//Provides the Parent Item (this) with a new Entity Link
		private void ProvideEntity( )
		{
			if( m_Child != null )
			{
				m_Child.Delete( );
			}

			IDamageableItem2 Idam = new IDamageableItem2( this );

			if( Idam != null && !Idam.Deleted && this.Map != null )
			{
				m_Child = Idam;
				m_Child.Update( );
			}
		}
	
/*	
			//If the child Link is not at our location, bring it back!
	public override void OnLocationChange( Point3D oldLocation )
		{
		//	if( this.Location != oldLocation )
			//{
				if( m_Child != null && !m_Child.Deleted )
				{
					if( this.Location != m_Child.Location )
						this.Update( );
						//m_Child.Update();
				}
			//}

			base.OnLocationChange( oldLocation );
		}
*/		
		public void Update( )
		{
			
				//this.Home = m_Parent.Location;
				this.Location = m_Child.Location;
				this.Map = m_Child.Map;

				return;
			
		}
		
	
		
		

		//This Wraps the target and resets the targeted ITEM to it's child BASECREATURE
		//Unfortunately, there is no accessible Array for a player's followers,
		//so we must use the GetMobilesInRage(int range) method for our reference checks!
		public override bool CheckTarget( Mobile from, Target targ, object targeted )
		{
			#region CheckEntity
			
			//Check to see if we have an Entity Link (Child BaseCreature)
			//If not, create one!
			//(Without Combatant Change, since this is for pets)
			
			PlayerMobile pm = from as PlayerMobile;

			if( pm != null )
			{
			 
				if( m_Child != null && !m_Child.Deleted )
				{
					m_Child.Update( );
				}
				else
				{
					ProvideEntity( );

					if( m_Child != null && !m_Child.Deleted )
					{
						m_Child.Update( );
					}
				}
			}
			#endregion
		
			if( targ is AIControlMobileTarget && targeted == this )
			{
				//Wrap the target
				AIControlMobileTarget t = targ as AIControlMobileTarget;
				//Get the OrderType
				OrderType order = t.Order;

				//Search for our controlled pets within screen range
				foreach( Mobile m in from.GetMobilesInRange( 16 ) )
				{
					if( !( m is BaseCreature ) )
						continue;

					BaseCreature bc = m as BaseCreature;

					if( from != null && !from.Deleted && from.Alive )
					{
						if( bc == null || bc.Deleted || !bc.Alive || !bc.Controlled || bc.ControlMaster != from )
							continue;

						//Reset the pet's ControlTarget and OrderType.
						bc.ControlTarget = m_Child;
						bc.ControlOrder = t.Order;
					}
				}
			}

			return base.CheckTarget( from, targ, targeted );
		}

		public override void OnDoubleClick( Mobile from )
		{
			#region CheckEntity

			//Check to see if we have an Entity Link (Child BaseCreature)
			//If not, create one!
			//(With Combatant change to simulate Attacking)

			PlayerMobile pm = from as PlayerMobile;

			if( pm != null )
			{
				if( m_Child != null && !m_Child.Deleted )
				{
					m_Child.Update( );
					pm.Warmode = true;
					pm.Combatant = m_Child;
				}
				else
				{
					ProvideEntity( );

					if( m_Child != null && !m_Child.Deleted )
					{
						m_Child.Update( );
						pm.Warmode = true;
						pm.Combatant = m_Child;
					}
				}
			}
			#endregion

			base.OnDoubleClick( from );
		}

		public override bool OnDragLift( Mobile from )
		{
			return ( from.AccessLevel >= AccessLevel.Counselor );
		}

		public override void Delete( )
		{
			base.Delete( );
		
			if( m_Child != null && !m_Child.Deleted )
			{
				m_Child.Kill();
				return;
			}
		
		}

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			ArrayList strings = new ArrayList( );

			//strings.Add( "-Strength-" );
			//strings.Add( Name + " ");
			strings.Add( "HP " + m_Hits + "/" + m_HitsMax );

			string toAdd = "";
			int amount = strings.Count;
			int current = 1;

			foreach( string str in strings )
			{
				toAdd += str;

				if( current != amount )
					toAdd += "\n";

				++current;
			}

			if( toAdd != "" )
				list.Add( 1070722, toAdd );
		}

		public DamageableItem2( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( ( int )0 ); // version

			writer.Write( ( Mobile )m_Child );
			writer.Write( ( int )m_StartID );
			writer.Write( ( int )m_HalfHitsID );
			writer.Write( ( int )m_DestroyedID );
			writer.Write( ( int )m_ItemLevel );
			writer.Write( ( int )m_Hits );
			writer.Write( ( int )m_HitsMax );
			writer.Write( ( bool )Movable );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt( );

			m_Child = ( IDamageableItem2 )reader.ReadMobile( );
			m_StartID = ( int )reader.ReadInt( );
			m_HalfHitsID = ( int )reader.ReadInt( );
			m_DestroyedID = ( int )reader.ReadInt( );
			m_ItemLevel = ( ItemLevel )reader.ReadInt( );
			m_Hits = ( int )reader.ReadInt( );
			m_HitsMax = ( int )reader.ReadInt( );
			Movable = ( bool )reader.ReadBool( );
		}
	}

	public class IDamageableItem2 : BaseCreature
	{
		private DamageableItem2 m_Parent;
		//public override bool DoesNotBleed{ get{ return true;}}
		
		[CommandProperty( AccessLevel.GameMaster )]
		public DamageableItem2 Link
		{
			get
			{
				return m_Parent;
			}
		}

		[Constructable]
		public IDamageableItem2( DamageableItem2 parent )
			: base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			if( parent != null && !parent.Deleted )
				m_Parent = parent;
				
			//Nullify the name, so it doeesn't pop up when we come into range
			Name = null;

			Body = 803; //Mustache is barely visible!
			BodyValue = 803; //Mustache is barely visible!
			//Body = 1; //Ogre for testing
			//BodyValue = 1; //Ogre for testing
			Hue = 0;
			BaseSoundID = 0; //QUIET!!!
			Fame = 0;
			Karma = 0;
			ControlSlots = 0;
			Tamable = false;

			//Frozen = true;
			//Paralyzed = true;
			//CantWalk = true;

			DamageMin = 10;
			DamageMax = 25;
			
			SetInt( 96, 120 );
			SetDex( 91, 115 );
			SetStr( 25, 30);
			
			SetDamageType( ResistanceType.Physical, 30 );
			SetDamageType( ResistanceType.Fire, 70 );

			SetResistance( ResistanceType.Physical, 15, 20 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Poison, 5, 10 );
			SetResistance( ResistanceType.Energy, 5, 10 );

			SetSkill( SkillName.EvalInt, 75.1, 100.0 );
			SetSkill( SkillName.Magery, 75.1, 100.0 );
			SetSkill( SkillName.MagicResist, 75.0, 97.5 );
			SetSkill( SkillName.Tactics, 65.0, 87.5 );
			SetSkill( SkillName.Wrestling, 20.2, 60.0 );

			SetHits( m_Parent.HitsMax );
			Hits = m_Parent.Hits;

		}
		
		public override bool CanRegenHits { get { return false; } }

		public override void GetProperties( ObjectPropertyList list )
		{
			base.GetProperties( list );

			ArrayList strings = new ArrayList( );

			//strings.Add( "-Strength-" );
			strings.Add( "HP " + m_Parent.Hits + " / " + m_Parent.HitsMax );

			string toAdd = "";
			int amount = strings.Count;
			int current = 1;

			foreach( string str in strings )
			{
				toAdd += str;

				if( current != amount )
					toAdd += "\n";

				++current;
			}

			if( toAdd != "" )
				list.Add( toAdd );
		}
		
		public override void OnHitsChange( int oldvalue )
		{
			if ( m_Parent.Hits != Hits )
			{ m_Parent.Hits = Hits; }
			InvalidateProperties();
			
			
		}

	/*public virtual void OnMovement( Mobile m, Point3D oldLocation )
	//	{
		//}

		int FollowRange = 1;
			if (m_Mobile.FollowRange > 0)
			FollowRange = m_Mobile.FollowRange;
		
		
	*/	
	
		//If the child Link is not at our location, bring it back!
	protected override void OnLocationChange( Point3D oldLocation )
		{
		//	if( this.Location != oldLocation )
			//{
				if( m_Parent != null && !m_Parent.Deleted )
				{
					if( m_Parent.Location != this.Location )
						m_Parent.Update( );
						//m_Child.Update();
				}
			//}

			base.OnLocationChange( oldLocation );
		}
		
		public void Update( )
		{
			if( this == null || this.Deleted )
				return;
		
			if( m_Parent != null && !m_Parent.Deleted )
			{
				this.Home = m_Parent.Location;
				this.Location = m_Parent.Location;
				this.Map = m_Parent.Map;

				//return;
			}
		
			if( m_Parent == null || m_Parent.Deleted )
			{
				Delete( );
				return;
			}
		}

		public override void Delete( )
		{
			base.Delete( );
			
			if( m_Parent != null && !m_Parent.Deleted )
			{
				m_Parent.Delete();
			//	this.Delete();
				
				return;
			}
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			base.OnDamage( amount, from, willKill );

			if( m_Parent != null && !m_Parent.Deleted )
			{
				m_Parent.Damage( amount, from, willKill );
			}
		}
		
	

		public override void OnDeath( Container c )
		{
			base.OnDeath( c );

			if( m_Parent != null && !m_Parent.Deleted ) {
				m_Parent.Destroy( );
			}
			Item Gold = new Gold( 100, 200 );
			Gold.MoveToWorld( new Point3D( c.X + Utility.RandomMinMax( -1, 1 ), c.Y + Utility.RandomMinMax( -1, 1 ), c.Z ), c.Map );	
				
			if( this.Corpse != null && !this.Corpse.Deleted ) {
				((Corpse)this.Corpse).Delete();
			}
			
		}
		
		
		
		public override bool OnBeforeDeath()
		{
			
				
			return base.OnBeforeDeath();
		}

		public IDamageableItem2( Serial serial )
			: base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( ( int )0 );

			writer.Write( ( Item )m_Parent );
		//	writer.Write( ( bool )Frozen );
			//writer.Write( ( bool )Paralyzed );
		//	writer.Write( ( bool )CantWalk );
			writer.Write( ( int )DamageMin );
			writer.Write( ( int )DamageMax );
			writer.Write( ( int )BodyValue );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt( );

			m_Parent = ( DamageableItem2 )reader.ReadItem( );
		//	Frozen = ( bool )reader.ReadBool( );
		//	Paralyzed = ( bool )reader.ReadBool( );
		//	CantWalk = ( bool )reader.ReadBool( );
			DamageMin = ( int )reader.ReadInt( );
			DamageMax = ( int )reader.ReadInt( );
			BodyValue = ( int )reader.ReadInt( );
		}
	}
}