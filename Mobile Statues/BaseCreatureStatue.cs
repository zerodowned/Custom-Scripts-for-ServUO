/*

	Base script and idea made with help from Talow.
	
	See the example files for how to make your own, or use them as is if you want.
	
	If you need help with figuring out what Animation and Frame number to use, try out my Animation Locator + Freeze Frame script.
	
	~ zerodowned 

*/

using System;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using System.Collections;
using System.Collections.Generic;

namespace Server.Mobiles
{
    public class BaseCreatureStatue : BaseCreature
    {
		//Values are hues for solidhueoverride
		public enum ResType
		{
			Iron = 929,
			Copper = 2413
		}
		
        ResType mResTyp;
		Direction mDirection;

        //people shouldn't play with the base.
        private CreatureStatueBase m_base;

        private ResType m_ResType;
       
        [CommandProperty(AccessLevel.GameMaster)]
        public ResType ResourceType{
            get{return m_ResType;}
            set{m_ResType = value;}
        }
       
        //Allows to change all base creature and res type.
        public BaseCreatureStatue(int BodyValue, ResType restype, Direction direction, AIType ai, FightMode mode, int RangePerception, int RangeFight,
            double ActiveSpeed, double PassiveSpeed) 
			: base(AIType.AI_Melee,FightMode.Closest, 10, 1, 0.2, 0.4) 
        {
			Body = BodyValue;
			mResTyp = restype;
			mDirection = direction;
			AI = ai;
			FightMode = mode;
			RangePerception = RangePerception;
			RangeFight = RangeFight;
			ActiveSpeed = ActiveSpeed;
			PassiveSpeed = PassiveSpeed;
            m_ResType = restype;

			CantWalk = true;
			Paralyzed = true;
			Blessed = true;

            Timer.DelayCall(TimeSpan.Zero, Freeze);
            Timer.DelayCall(TimeSpan.Zero, SetUpBase);
           
            SolidHueOverride = (int)m_ResType;
			
			 //One base for each creature.
            m_base = new CreatureStatueBase(this);

        }
		
		/*	In the mobile you want to make use the method
			public override void Freeze()
			{
				base.Freeze();
				Animate( Animation#, Frame#, 1, false, false, 255 );
			}
		*/	
        public virtual void Freeze()
        {
            if (CantWalk == true)
                Timer.DelayCall(TimeSpan.FromSeconds(0.5), Freeze);
        }
		
		public void RetrictMovement()
		{
			CantWalk = true;
			Paralyzed = true;
			Combatant = null;
			Blessed = true;
			Direction = mDirection;
		
		}

        public void SetUpBase()
        {
            if (m_base != null && !m_base.Deleted && this.Map != null)
                //place base at creature location.
                m_base.MoveToWorld(new Point3D(this.X, this.Y, this.Z), this.Map);

            this.Home = this.Location;

            // Place the mobile on top of the base
            this.Z += 5;
        }
		
		public void MoveToBase()
		{
			this.Location = m_base.Location;
			this.Z += 5;
		}
		

        public override void OnThink() 
		{
            base.OnThink();
			
			if ( this == null ) { return; }
			
			foreach( Mobile mob in this.GetMobilesInRange( 20 ) ) {
				if( mob.AccessLevel > AccessLevel.Player ) { return; } //don't activate for staff 
				if( mob is PlayerMobile ) { 
					if( Utility.InRange(mob.Location, this.Location, 1) ) {
						if( CantWalk == true ) {
							mob.SendMessage("You awaken the statue!");
							
							CantWalk = false;
							Paralyzed = false;
							Blessed = false;
							
							if( Combatant == null ) {
								Combatant = mob;
							}
						}
					}
					else if( !(Utility.InRange(mob.Location, this.Location, 15) ) ) {
						if( CantWalk == false ) {
							MoveToBase();
							RetrictMovement();
							Freeze();
							
						}
					} //else if
				} // if
			} // foreach
		} // OnThink

        public override void OnDeath(Container c)
        {
            base.OnDeath(c);

            if (m_base != null && !m_base.Deleted)
                m_base.Delete();

            DropResource(c.X, c.Y, c.Z, c.Map);

            if (this.Corpse != null && !this.Corpse.Deleted)
            {
                ((Corpse)this.Corpse).Delete();
            }
        }

        public override void OnDelete() {
            base.OnDelete();
            if (m_base != null && !m_base.Deleted)
            {
                m_base.Delete();
                this.Delete();
            }

        }

        public void DropResource(int x, int y, int z, Map map)
        {
            Item Gold = new Gold(100, 200);
            Gold.MoveToWorld(new Point3D(x + Utility.RandomMinMax(-1, 1), y + Utility.RandomMinMax(-1, 1), z), map);

            Item item;

            switch (m_ResType)
            {
                case ResType.Iron:
                    {
                        item = new IronIngot();
                        item.MoveToWorld(new Point3D(x + Utility.RandomMinMax(-1, 1), y + Utility.RandomMinMax(-1, 1), z), map);
                        item.Amount = 100; break;
                    };
                case ResType.Copper:
                    {
                        item = new CopperIngot();
                        item.MoveToWorld(new Point3D(x + Utility.RandomMinMax(-1, 1), y + Utility.RandomMinMax(-1, 1), z), map);
                        item.Amount = 100; break;
                    };
            }
        }

        public BaseCreatureStatue(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write((int)0);

            writer.Write((int)m_ResType);
            writer.Write((Item)m_base);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            //All true as there are no players here at this point.
            Frozen = true;
            CantWalk = true;
            Paralyzed = true;

            m_ResType = (ResType)reader.ReadInt();
            SolidHueOverride = (int)m_ResType;
            m_base = (CreatureStatueBase)reader.ReadItem();

            //freeze when loaded. No players will be here at this point anyways
            //they have to log in.
            Timer.DelayCall(TimeSpan.FromSeconds(0.5), Freeze);
        }
    }

    //The Base The Statue Stands On.
    public class CreatureStatueBase : Item
    {
        private BaseCreatureStatue m_Parent;

        public CreatureStatueBase(BaseCreatureStatue parent) : base() {
            if (parent != null && !parent.Deleted)
                m_Parent = parent;

            ItemID = 1801;
            Name = "Statue Base";
            Hue = m_Parent.SolidHueOverride;
            Movable = false;
        }

        public override void Delete()
        {
            base.Delete();

            if (m_Parent != null && !m_Parent.Deleted)
            {
                m_Parent.Delete();
                this.Delete();
            }

        }

        public CreatureStatueBase(Serial serial) : base(serial) { }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version

            writer.Write((Mobile)m_Parent);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            m_Parent = (BaseCreatureStatue)reader.ReadMobile();
        }
    }

}