using System;

using Server.Targeting;


namespace Server.Items
{
    public class TreasureMapDecoder : Item
    {
        private bool requiresCharges;
        private int charges;

        [CommandProperty(AccessLevel.GameMaster)]
        public bool RequiresCharges
        {
            get => requiresCharges;
            set
            {
                requiresCharges = value;
                InvalidateProperties();
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public int Charges
        {
            get => charges;
            set
            {
                charges = value;
                InvalidateProperties();
            }
        }

        [Constructable]
        public TreasureMapDecoder() : base(22398)
        {
            Movable = true;
            Hue = 1266;
            Weight = 0.0;
            Name = "Treasure Map Instant Transporter";
            LootType = LootType.Blessed;

            RequiresCharges = false;
        }

        public TreasureMapDecoder(Serial serial) : base(serial)
        {
        }

        public override void GetProperties(ObjectPropertyList list)
        {
            base.GetProperties(list);

            list.Add("Creates a gateway directly to the<br>Chest location of a treasure map");

            if (RequiresCharges)
                list.Add(string.Format("Uses Remaining: {0}", Charges));
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (!from.Player)
                return;

            if ( IsChildOf( from.Backpack ) )
            {
                UseBook(from);
            }
            else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}

            /* if (from.InRange(GetWorldLocation(), 1))
                UseBook(from);
            else
                from.SendLocalizedMessage(500446); // That is too far away.  */
        }

        public bool UseBook(Mobile m)
        {
            if (m.Criminal)
            {
                m.SendLocalizedMessage(1005561, "", 0x22); // Thou'rt a criminal and cannot escape so easily. 
                return false;
            }
            else if (Server.Spells.SpellHelper.CheckCombat(m))
            {
                m.SendLocalizedMessage(1005564, "", 0x22); // Wouldst thou flee during the heat of battle?? 
                return false;
            }
            else if (Server.Misc.WeightOverloading.IsOverloaded(m))
            {
                m.SendLocalizedMessage(502359, "", 0x22); // Thou art too encumbered to move.
                return false;
            }
            else if (m.Region is Server.Regions.Jail)
            {
                m.SendLocalizedMessage(1041530, "", 0x35); // You'll need a better jailbreak plan then that!
                return false;
            }

            else if (m.Spell != null)
            {
                m.SendLocalizedMessage(1049616); // You are too busy to do that at the moment. 
                return false;
            }

            else if (RequiresCharges & Charges < 1)
            {
                m.SendMessage("This book does not have any uses remaining.");
                return false;
            }

            else
            {
                m.Target = new TmapTarget(this);
                m.SendMessage("Target a Treasure Map");
                //Effects.PlaySound( m.Location, m.Map, 0x20E ); 
                return true;
            }
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version 

            writer.Write(requiresCharges);
            writer.Write(charges);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            requiresCharges = reader.ReadBool();
            charges = reader.ReadInt();
        }
    }

    public class TmapTarget : Target // Create our targeting class (which we derive from the base target class)
    {
        private readonly TreasureMapDecoder mapDecoder;

        public TmapTarget(TreasureMapDecoder MapDecoder) : base(1, false, TargetFlags.None)
        {
            mapDecoder = MapDecoder;
        }

        protected override void OnTarget(Mobile from, object target) // Override the protected OnTarget() for our feature
        {
            if (target is TreasureMap)
            {
                Item item = (Item)target;

                if (item.Deleted /* || item.RootParent != from */)
                    return;

                /*    
                *      THIS SECTION FINDS THE AVERAGE Z FOR THE AREA AND SETS THE GATE TO GO THERE
                *      TREASURE MAP LOCATIONS DO NOT HAVE A Z LOCATION, THEY HAVE X AND Y ONLY
                *      SO EDITS TO THIS SECTION MAY CAUSE THE PLAYER TO END UP ABOVE OR UNDER GROUND
                */
                TreasureMap ts = (TreasureMap)target;

                if (ts.Decoder != null && ts.Decoder != from)
                {
                    from.SendMessage("Someone else has already decyphered this map!");
                    return;
                }

                if (ts.Completed)
                {
                    from.SendMessage("That map has already been completed.");
                    return;
                }

                TmapBookMoongate gate = new TmapBookMoongate();
                Map map = from.Map;
                gate.TargetMap = ts.Facet;

                ts.Decoder = from;

                int z;
                z = gate.TargetMap.GetAverageZ(ts.ChestLocation.X, ts.ChestLocation.Y);
                Point3D p = new Point3D(ts.ChestLocation.X, ts.ChestLocation.Y, z);

                gate.Target = new Point3D(p);
                gate.MoveToWorld(new Point3D(from.Location), from.Map);

                if (mapDecoder.RequiresCharges)
                    mapDecoder.Charges--;
            }
            else
            {
                from.SendMessage("You can only use this on Treasure Maps!");
            }
        }
    }

    public class TmapBookMoongate : Moongate
    {
        public override bool ShowFeluccaWarning => false;

        [Constructable]
        public TmapBookMoongate() : base()
        {
            InternalTimer t = new InternalTimer(this);
            t.Start();
        }

        private class InternalTimer : Timer
        {
            private readonly Item m_Item;

            public InternalTimer(Item item)
                : base(TimeSpan.FromSeconds(30.0))
            {
                Priority = TimerPriority.OneSecond;
                m_Item = item;
            }

            protected override void OnTick()
            {
                m_Item.Delete();
            }
        }

        public override void OnGateUsed(Mobile m)
        {
            base.OnGateUsed(m);

            Delete();
        }

        public TmapBookMoongate(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();

            Delete();
        }
    }


}