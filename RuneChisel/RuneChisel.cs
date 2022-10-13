using System;
using Server;
using Server.Network;
using Server.Gumps;
using Server.Items;
using Server.Targeting;

namespace Server.Gumps
{
	public class RuneChiselGump : Gump
	{
        private RuneChisel m_Chisel;
		private Item m_item;
        private int m_Page;
		
		public RuneChiselGump( Mobile from, RuneChisel chisel, Item item, int page ) : base( 100, 100 )
		{
            m_Chisel = chisel;
			m_item = item;
            m_Page = page;
			
			Closable=true; 
            Disposable=true; 
            Dragable=true; 
            Resizable=false;

			AddPage(0);
		
			
			AddBackground(0, 0, 550, 750, 1755);
            
			AddHtml( 5,5, 537,61, "<BASEFONT COLOR=#FFFFFF><center><big>Rune Chisel</big><br>Select the attribute below that you want to attempt to remove.<br>Chance of failure to remove completely increases with higher attribute values.", (bool)false, (bool)false);

            AddButton(8,7, 30, 30, 10, GumpButtonType.Reply, 0); //68x27
            AddImageTiled(16, 10, 51, 20, 306);
            AddHtml( 16, 10, 51, 20, "<BASEFONT COLOR=#0663CE><center>wiki", (bool)false, (bool)false);

            int lazybuffer = 3;
            AddBackground(5 + lazybuffer,74 , 235, 35, 10500);
            AddButton( 12 + lazybuffer,85 , 30009, 30009, 1, GumpButtonType.Reply, 0);
            AddHtml( 29 + lazybuffer, 84, 200, 22, "<BASEFONT COLOR=#FFFFFF>AoS Attribute", (bool)false, (bool)false);

            AddBackground(5 + lazybuffer,114 , 235, 35, 10500);
            AddButton(12 + lazybuffer,125 , 30009, 30009, 2, GumpButtonType.Reply, 0);
            AddHtml( 29 + lazybuffer, 123 , 200, 20, "<BASEFONT COLOR=#FFFFFF>Negative Attributes", (bool)false, (bool)false);

            AddBackground(5 + lazybuffer,154, 235, 35, 10500);
            AddButton(12 + lazybuffer,165, 30009, 30009, 3, GumpButtonType.Reply, 0);
            AddHtml( 29 + lazybuffer, 163, 200, 20, "<BASEFONT COLOR=#FFFFFF>Absorption Attributes", (bool)false, (bool)false);

            AddBackground(5 + lazybuffer,194, 235, 35, 10500);
            AddButton(12 + lazybuffer,205, 30009, 30009, 4, GumpButtonType.Reply, 0);
            AddHtml( 29 + lazybuffer, 203, 200, 20, "<BASEFONT COLOR=#FFFFFF>Weapon Attributes", (bool)false, (bool)false);

            AddBackground(5 + lazybuffer,234, 235, 35, 10500);
            AddButton(12 + lazybuffer,245, 30009, 30009, 5, GumpButtonType.Reply, 0);
            AddHtml( 29 + lazybuffer, 243, 200, 20, "<BASEFONT COLOR=#FFFFFF>AoS Element Attributes", (bool)false, (bool)false);

            AddBackground(5 + lazybuffer,274, 235, 35, 10500);
            AddButton(12 + lazybuffer,285, 30009, 30009, 6, GumpButtonType.Reply, 0);
            AddHtml( 29 + lazybuffer, 283, 200, 20, "<BASEFONT COLOR=#FFFFFF>Extended Weapon Attributes", (bool)false, (bool)false);

            AddBackground(5 + lazybuffer,314, 235, 35, 10500);
            AddButton(12 + lazybuffer,325, 30009, 30009, 7, GumpButtonType.Reply, 0);
            AddHtml( 29 + lazybuffer, 323, 200, 20, "<BASEFONT COLOR=#FFFFFF>AoS Armor Attributes", (bool)false, (bool)false);

            int AosAttributeID = 1;
            int attrsValue = 0;
            int nextEntry = 0;

            switch(m_Page)
            {
                case 1:
                {
                    // All
                    if(m_item is BaseWeapon || m_item is BaseArmor || m_item is BaseClothing || m_item is BaseJewel || m_item is Spellbook || m_item is BaseTalisman || m_item is BaseQuiver)
                    {
                        foreach (AosAttribute attrs in Enum.GetValues(typeof(AosAttribute)))
                        { 
                            if (attrs != null)
                            {
                                // Find Item Type
                                {
                                    if(m_item is BaseWeapon )
                                    {
                                        BaseWeapon itemSelected = (BaseWeapon)m_item;
                                        attrsValue = (int)itemSelected.Attributes[attrs];
                                    }
                                    else if(m_item is BaseArmor )
                                    {
                                        BaseArmor itemSelected = (BaseArmor)m_item;
                                        attrsValue = (int)itemSelected.Attributes[attrs];
                                    }
                                    else if(m_item is BaseClothing )
                                    {
                                        BaseClothing itemSelected = (BaseClothing)m_item;
                                        attrsValue = (int)itemSelected.Attributes[attrs];
                                    }
                                    else if(m_item is BaseJewel )
                                    {
                                        BaseJewel itemSelected = (BaseJewel)m_item;
                                        attrsValue = (int)itemSelected.Attributes[attrs];
                                    }
                                    else if(m_item is Spellbook )
                                    {
                                        Spellbook itemSelected = (Spellbook)m_item;
                                        attrsValue = (int)itemSelected.Attributes[attrs];
                                    }
                                    else if(m_item is BaseTalisman )
                                    {
                                        BaseTalisman itemSelected = (BaseTalisman)m_item;
                                        attrsValue = (int)itemSelected.Attributes[attrs];
                                    }
                                    else if(m_item is BaseQuiver )
                                    {
                                        BaseQuiver itemSelected = (BaseQuiver)m_item;
                                        attrsValue = (int)itemSelected.Attributes[attrs];
                                    }
                                }

                                // If property is greater than 0, send to method so it's added to the gump
                                if(attrsValue > 0)
                                {  
                                    AosAttributes(attrs, attrsValue, this, AosAttributeID, nextEntry);
                                    nextEntry++;
                                }
                        
                                AosAttributeID++;
                            }
                        }
                    }

                    break;
                }
                case 2:
                {
                    AosAttributeID = 1;
                    nextEntry = 0;

                    // All except basequiver
                    if(m_item is BaseWeapon || m_item is BaseArmor || m_item is BaseClothing || m_item is BaseJewel || m_item is Spellbook || m_item is BaseTalisman)
                    {
                        foreach (NegativeAttribute attrs in Enum.GetValues(typeof(NegativeAttribute)))
                        { 
                            if (attrs != null)
                            {
                                // Find Item Type
                                {
                                    if(m_item is BaseWeapon )
                                    {
                                        BaseWeapon targetedItem = (BaseWeapon)m_item;
                                        attrsValue = (int)targetedItem.NegativeAttributes[attrs];
                                    }
                                    else if(m_item is BaseArmor )
                                    {
                                        BaseArmor targetedItem = (BaseArmor)m_item;
                                        attrsValue = (int)targetedItem.NegativeAttributes[attrs];
                                    }
                                    else if(m_item is BaseClothing )
                                    {
                                        BaseClothing targetedItem = (BaseClothing)m_item;
                                        attrsValue = (int)targetedItem.NegativeAttributes[attrs];
                                    }
                                    else if(m_item is BaseJewel )
                                    {
                                        BaseJewel targetedItem = (BaseJewel)m_item;
                                        attrsValue = (int)targetedItem.NegativeAttributes[attrs];
                                    }
                                    else if(m_item is Spellbook )
                                    {
                                        Spellbook targetedItem = (Spellbook)m_item;
                                        attrsValue = (int)targetedItem.NegativeAttributes[attrs];
                                    }
                                    else if(m_item is BaseTalisman )
                                    {
                                        BaseTalisman targetedItem = (BaseTalisman)m_item;
                                        attrsValue = (int)targetedItem.NegativeAttributes[attrs];
                                    }
                                }

                                // If property is greater than 0, send to method so it's added to the gump
                                if(attrsValue > 0)
                                {  
                                    NegativeAttributes(attrs, attrsValue, this, AosAttributeID, nextEntry);
                                    nextEntry++;
                                }
                        
                                AosAttributeID++;
                            }
                        }
                    }

                    break;
                }
                case 3:
                {
                    AosAttributeID = 1;
                    nextEntry = 0;

                    // All except jewel, spellbook, and quiver
                    if(m_item is BaseWeapon || m_item is BaseArmor || m_item is BaseClothing || m_item is BaseTalisman)
                    {
                        foreach (SAAbsorptionAttribute attrs in Enum.GetValues(typeof(SAAbsorptionAttribute)))
                        { 
                            if (attrs != null)
                            {
                                // Find Item Type
                                {
                                    if(m_item is BaseWeapon )
                                    {
                                        BaseWeapon targetedItem = (BaseWeapon)m_item;
                                        attrsValue = (int)targetedItem.AbsorptionAttributes[attrs];
                                    }
                                    else if(m_item is BaseArmor )
                                    {
                                        BaseArmor targetedItem = (BaseArmor)m_item;
                                        attrsValue = (int)targetedItem.AbsorptionAttributes[attrs];
                                    }
                                    else if(m_item is BaseClothing )
                                    {
                                        BaseClothing targetedItem = (BaseClothing)m_item;
                                        attrsValue = (int)targetedItem.SAAbsorptionAttributes[attrs];
                                    }
                                    else if(m_item is BaseTalisman )
                                    {
                                        BaseTalisman targetedItem = (BaseTalisman)m_item;
                                        attrsValue = (int)targetedItem.SAAbsorptionAttributes[attrs];
                                    }
                                }

                                // If property is greater than 0, send to method so it's added to the gump
                                if(attrsValue > 0)
                                {
                                    SAAbsorptionAttributes(attrs, attrsValue, this, AosAttributeID, nextEntry);
                                    nextEntry++;
                                }
                        
                                AosAttributeID++;
                            }
                        }
                    }

                    break;
                }
                case 4:
                {
                    /* AosAttributeID = 1;
                    nextEntry = 0; */

                    // BASEWEAPON, BASEARMOR, BASECLOTHING
                    if(m_item is BaseWeapon || m_item is BaseArmor || m_item is BaseClothing)
                    {
                        foreach (AosWeaponAttribute attrs in Enum.GetValues(typeof(AosWeaponAttribute)))
                        { 
                            if (attrs != null)
                            {
                                // Find Item Type
                                {
                                    if(m_item is BaseWeapon )
                                    {
                                        BaseWeapon targetedItem = (BaseWeapon)m_item;
                                        attrsValue = (int)targetedItem.WeaponAttributes[attrs];
                                    }
                                    else if(m_item is BaseArmor )
                                    {
                                        BaseArmor targetedItem = (BaseArmor)m_item;
                                        attrsValue = (int)targetedItem.WeaponAttributes[attrs];
                                    }
                                    else if(m_item is BaseClothing )
                                    {
                                        BaseClothing targetedItem = (BaseClothing)m_item;
                                        attrsValue = (int)targetedItem.WeaponAttributes[attrs];
                                    }
                                }

                                // If property is greater than 0, send to method so it's added to the gump
                                if(attrsValue > 0)
                                {  
                                    WeaponAttributes(attrs, attrsValue, this, AosAttributeID, nextEntry);
                                    nextEntry++;
                                }
                        
                                AosAttributeID++;
                            }
                        }
                    }

                    break;
                }
                case 5:
                {
                    AosAttributeID = 1;
                    nextEntry = 0;

                    // BASECLOTHING, BASEJEWEL, BASEQUIVER
                    if(m_item is BaseClothing || m_item is BaseJewel || m_item is BaseQuiver)
                    {
                        foreach (AosElementAttribute attrs in Enum.GetValues(typeof(AosElementAttribute)))
                        { 
                            if (attrs != null)
                            {
                                // Find Item Type
                                {
                                    if(m_item is BaseClothing )
                                    {
                                        BaseClothing targetedItem = (BaseClothing)m_item;
                                        attrsValue = (int)targetedItem.Resistances[attrs];
                                    }
                                    else if(m_item is BaseJewel )
                                    {
                                        BaseJewel targetedItem = (BaseJewel)m_item;
                                        attrsValue = (int)targetedItem.Resistances[attrs];
                                    }
                                    else if(m_item is BaseQuiver )
                                    {
                                        BaseQuiver targetedItem = (BaseQuiver)m_item;
                                        attrsValue = (int)targetedItem.Resistances[attrs];
                                    }
                                }

                                // If property is greater than 0, send to method so it's added to the gump
                                if(attrsValue > 0)
                                {  
                                    AosElementAttribute(attrs, attrsValue, this, AosAttributeID, nextEntry);
                                    nextEntry++;
                                }
                        
                                AosAttributeID++;
                            }
                        }
                    }

                    break;
                }
                case 6:
                {
                    AosAttributeID = 1;
                    nextEntry = 0;

                    // baseweapon
                    if(m_item is BaseWeapon)
                    {
                        foreach (ExtendedWeaponAttribute attrs in Enum.GetValues(typeof(ExtendedWeaponAttribute)))
                        { 
                            if (attrs != null)
                            {
                                //Find Type
                                {
                                    if(m_item is BaseWeapon )
                                    {
                                        BaseWeapon targetedItem = (BaseWeapon)m_item;
                                        attrsValue = (int)targetedItem.ExtendedWeaponAttributes[attrs];
                                    }
                                }

                                // If property is greater than 0, send to method so it's added to the gump
                                if(attrsValue > 0)
                                {  
                                    ExtendedWeaponAttribute(attrs, attrsValue, this, AosAttributeID, nextEntry);
                                    nextEntry++;
                                }
                        
                                AosAttributeID++;
                            }
                        }
                    }

                    break;
                }
                case 7:
                {
                    AosAttributeID = 1;
                    nextEntry = 0;

                    // BASEARMOR, BASECLOTING
                    if(m_item is BaseArmor || m_item is BaseClothing)
                    {
                        foreach (AosArmorAttribute attrs in Enum.GetValues(typeof(AosArmorAttribute)))
                        { 
                            if (attrs != null)
                            {
                                //Find Type
                                {
                                    if(m_item is BaseArmor )
                                    {
                                        BaseArmor targetedItem = (BaseArmor)m_item;
                                        attrsValue = (int)targetedItem.ArmorAttributes[attrs];
                                    }

                                    if(m_item is BaseClothing)
                                    {
                                        BaseClothing targetedItem = (BaseClothing)m_item;
                                        attrsValue = (int)targetedItem.ClothingAttributes[attrs];
                                    }
                                }

                                // If property is greater than 0, send to method so it's added to the gump
                                if(attrsValue > 0)
                                {  
                                    AosArmorAttribute(attrs, attrsValue, this, AosAttributeID, nextEntry);
                                    nextEntry++;
                                }
                        
                                AosAttributeID++;
                            }
                        }
                    }

                    break;
                }
            }
            
		}
		
		public void Resend( Mobile from )
		{
			if( from.HasGump(typeof(RuneChiselGump)) ) 
			{
				from.CloseGump(typeof(RuneChiselGump));
			}

			from.SendGump( new RuneChiselGump(from, m_Chisel, m_item, m_Page));
		}

        public void Resend( Mobile from, int page )
		{
			if( from.HasGump(typeof(RuneChiselGump)) ) 
			{
				from.CloseGump(typeof(RuneChiselGump));
			}

			from.SendGump( new RuneChiselGump(from, m_Chisel, m_item, page));
		}
	
		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile from = sender.Mobile;

            if(m_Chisel.Deleted || m_Chisel.Uses <= 0)
                return;

            if(info.ButtonID == 10)
                from.LaunchBrowser("https://app.legendkeeper.com/a/worlds/cl1z82kchjqmt0808sqyfyqtv/wiki/cl1z85tmz000f0268lc4lfhwn");

            if(info.ButtonID >= 1 && info.ButtonID <= 7)
            {    
                m_Page = info.ButtonID;
                Resend(from);
            }
			
            if(info.ButtonID >= 100 && info.ButtonID <= 199)
            {
                int buttonid = (info.ButtonID - 100);
                int indexid = GetIndexID(buttonid);
                
                if(m_item is BaseWeapon) 
                    ((BaseWeapon)m_item).Attributes[ (AosAttribute)indexid ] = NewValue( (int)((BaseWeapon)m_item).Attributes[ (AosAttribute)indexid ] );
                else if(m_item is BaseArmor)
                    ((BaseArmor)m_item).Attributes[ (AosAttribute)indexid ] = NewValue( (int)((BaseArmor)m_item).Attributes[ (AosAttribute)indexid ] );
                else if(m_item is BaseClothing)
                    ((BaseClothing)m_item).Attributes[ (AosAttribute)indexid ] = NewValue( (int)((BaseClothing)m_item).Attributes[ (AosAttribute)indexid ] );
                else if(m_item is BaseJewel)
                    ((BaseJewel)m_item).Attributes[ (AosAttribute)indexid ] = NewValue( (int)((BaseJewel)m_item).Attributes[ (AosAttribute)indexid ] );
                else if(m_item is Spellbook)
                    ((Spellbook)m_item).Attributes[ (AosAttribute)indexid ] = NewValue( (int)((Spellbook)m_item).Attributes[ (AosAttribute)indexid ] );
                else if(m_item is BaseTalisman)
                    ((BaseTalisman)m_item).Attributes[ (AosAttribute)indexid ] = NewValue( (int)((BaseTalisman)m_item).Attributes[ (AosAttribute)indexid ] );
                else if(m_item is BaseQuiver)
                    ((BaseQuiver)m_item).Attributes[ (AosAttribute)indexid ] = NewValue( (int)((BaseQuiver)m_item).Attributes[ (AosAttribute)indexid ] );
                
                Resend(from, 1);
            }

            if(info.ButtonID >= 200 && info.ButtonID <= 299)
            {
                int buttonid = (info.ButtonID - 200);
                int indexid = GetIndexID(buttonid);
                
                if(m_item is BaseWeapon) 
                    ((BaseWeapon)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] = NewValue( (int)((BaseWeapon)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] );
                else if(m_item is BaseArmor)
                    ((BaseArmor)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] = NewValue( (int)((BaseArmor)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] );
                else if(m_item is BaseClothing)
                    ((BaseClothing)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] = NewValue( (int)((BaseClothing)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] );
                else if(m_item is BaseJewel)
                    ((BaseJewel)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] = NewValue( (int)((BaseJewel)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] );
                else if(m_item is Spellbook)
                    ((Spellbook)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] = NewValue( (int)((Spellbook)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] );
                else if(m_item is BaseTalisman)
                    ((BaseTalisman)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] = NewValue( (int)((BaseTalisman)m_item).NegativeAttributes[ (NegativeAttribute)indexid ] );
                //else if(m_item is BaseQuiver)
                //    ((BaseQuiver)m_item).Attributes[ (NegativeAttribute)indexid ] = NewValue( (int)((BaseQuiver)m_item).Attributes[ (NegativeAttribute)indexid ] );
                
                Resend(from, 2);
            }

            if(info.ButtonID >= 300 && info.ButtonID <= 399)
            {
                int buttonid = (info.ButtonID - 300);
                int indexid = GetIndexID(buttonid);
                
                if(m_item is BaseWeapon) 
                    ((BaseWeapon)m_item).AbsorptionAttributes[ (SAAbsorptionAttribute)indexid ] = NewValue( (int)((BaseWeapon)m_item).AbsorptionAttributes[ (SAAbsorptionAttribute)indexid ] );
                else if(m_item is BaseArmor)
                    ((BaseArmor)m_item).AbsorptionAttributes[ (SAAbsorptionAttribute)indexid ] = NewValue( (int)((BaseArmor)m_item).AbsorptionAttributes[ (SAAbsorptionAttribute)indexid ] );
                else if(m_item is BaseClothing)
                    ((BaseClothing)m_item).SAAbsorptionAttributes[ (SAAbsorptionAttribute)indexid ] = NewValue( (int)((BaseClothing)m_item).SAAbsorptionAttributes[ (SAAbsorptionAttribute)indexid ] );
                //else if(m_item is BaseJewel)
                //    ((BaseJewel)m_item).Attributes[ (SAAbsorptionAttribute)indexid ] = NewValue( (int)((BaseJewel)m_item).Attributes[ (SAAbsorptionAttribute)indexid ] );
                //else if(m_item is Spellbook)
                //    ((Spellbook)m_item).Attributes[ (SAAbsorptionAttribute)indexid ] = NewValue( (int)((Spellbook)m_item).Attributes[ (SAAbsorptionAttribute)indexid ] );
                else if(m_item is BaseTalisman)
                    ((BaseTalisman)m_item).SAAbsorptionAttributes[ (SAAbsorptionAttribute)indexid ] = NewValue( (int)((BaseTalisman)m_item).SAAbsorptionAttributes[ (SAAbsorptionAttribute)indexid ] );
                //else if(m_item is BaseQuiver)
                //    ((BaseQuiver)m_item).Attributes[ (SAAbsorptionAttribute)indexid ] = NewValue( (int)((BaseQuiver)m_item).Attributes[ (SAAbsorptionAttribute)indexid ] );
                
                Resend(from, 3);
            }

            if(info.ButtonID >= 400 && info.ButtonID <= 499)
            {
                int buttonid = (info.ButtonID - 400);
                int indexid = GetIndexID(buttonid);
                
                if(m_item is BaseWeapon) 
                    ((BaseWeapon)m_item).WeaponAttributes[ (AosWeaponAttribute)indexid ] = NewValue( (int)((BaseWeapon)m_item).WeaponAttributes[ (AosWeaponAttribute)indexid ] );
                else if(m_item is BaseArmor)
                    ((BaseArmor)m_item).WeaponAttributes[ (AosWeaponAttribute)indexid ] = NewValue( (int)((BaseArmor)m_item).WeaponAttributes[ (AosWeaponAttribute)indexid ] );
                else if(m_item is BaseClothing)
                    ((BaseClothing)m_item).WeaponAttributes[ (AosWeaponAttribute)indexid ] = NewValue( (int)((BaseClothing)m_item).WeaponAttributes[ (AosWeaponAttribute)indexid ] );
               /*  else if(m_item is BaseJewel)
                    ((BaseJewel)m_item).Attributes[ (AosWeaponAttribute)indexid ] = NewValue( (int)((BaseJewel)m_item).Attributes[ (AosWeaponAttribute)indexid ] );
                else if(m_item is Spellbook)
                    ((Spellbook)m_item).Attributes[ (AosWeaponAttribute)indexid ] = NewValue( (int)((Spellbook)m_item).Attributes[ (AosWeaponAttribute)indexid ] );
                else if(m_item is BaseTalisman)
                    ((BaseTalisman)m_item).Attributes[ (AosWeaponAttribute)indexid ] = NewValue( (int)((BaseTalisman)m_item).Attributes[ (AosWeaponAttribute)indexid ] );
                else if(m_item is BaseQuiver)
                    ((BaseQuiver)m_item).Attributes[ (AosWeaponAttribute)indexid ] = NewValue( (int)((BaseQuiver)m_item).Attributes[ (AosWeaponAttribute)indexid ] );
                 */
                Resend(from, 4);
            }

            if(info.ButtonID >= 500 && info.ButtonID <= 599)
            {
                int buttonid = (info.ButtonID - 500);
                int indexid = GetIndexID(buttonid);
                
                //if(m_item is BaseWeapon) 
                //    ((BaseWeapon)m_item).Attributes[ (AosElementAttribute)indexid ] = NewValue( (int)((BaseWeapon)m_item).Attributes[ (AosElementAttribute)indexid ] );
                //else if(m_item is BaseArmor)
                //    ((BaseArmor)m_item).Attributes[ (AosElementAttribute)indexid ] = NewValue( (int)((BaseArmor)m_item).Attributes[ (AosElementAttribute)indexid ] );
                if(m_item is BaseClothing)
                    ((BaseClothing)m_item).Resistances[ (AosElementAttribute)indexid ] = NewValue( (int)((BaseClothing)m_item).Resistances[ (AosElementAttribute)indexid ] );
                else if(m_item is BaseJewel)
                    ((BaseJewel)m_item).Resistances[ (AosElementAttribute)indexid ] = NewValue( (int)((BaseJewel)m_item).Resistances[ (AosElementAttribute)indexid ] );
                //else if(m_item is Spellbook)
                //    ((Spellbook)m_item).Attributes[ (AosElementAttribute)indexid ] = NewValue( (int)((Spellbook)m_item).Attributes[ (AosElementAttribute)indexid ] );
               // else if(m_item is BaseTalisman)
                //    ((BaseTalisman)m_item).Attributes[ (AosElementAttribute)indexid ] = NewValue( (int)((BaseTalisman)m_item).Attributes[ (AosElementAttribute)indexid ] );
                else if(m_item is BaseQuiver)
                    ((BaseQuiver)m_item).Resistances[ (AosElementAttribute)indexid ] = NewValue( (int)((BaseQuiver)m_item).Resistances[ (AosElementAttribute)indexid ] );
                
                Resend(from, 5);
            }

            if(info.ButtonID >= 600 && info.ButtonID <= 699)
            {
                int buttonid = (info.ButtonID - 600);
                int indexid = GetIndexID(buttonid);
                
                if(m_item is BaseWeapon) 
                    ((BaseWeapon)m_item).ExtendedWeaponAttributes[ (ExtendedWeaponAttribute)indexid ] = NewValue( (int)((BaseWeapon)m_item).ExtendedWeaponAttributes[ (ExtendedWeaponAttribute)indexid ] );
                /* else if(m_item is BaseArmor)
                    ((BaseArmor)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] = NewValue( (int)((BaseArmor)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] );
                else if(m_item is BaseClothing)
                    ((BaseClothing)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] = NewValue( (int)((BaseClothing)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] );
                else if(m_item is BaseJewel)
                    ((BaseJewel)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] = NewValue( (int)((BaseJewel)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] );
                else if(m_item is Spellbook)
                    ((Spellbook)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] = NewValue( (int)((Spellbook)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] );
                else if(m_item is BaseTalisman)
                    ((BaseTalisman)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] = NewValue( (int)((BaseTalisman)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] );
                else if(m_item is BaseQuiver)
                    ((BaseQuiver)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] = NewValue( (int)((BaseQuiver)m_item).Attributes[ (ExtendedWeaponAttribute)indexid ] );
                 */
                Resend(from, 6);
            }

            if(info.ButtonID >= 700 && info.ButtonID <= 799)
            {
                int buttonid = (info.ButtonID - 700);
                int indexid = GetIndexID(buttonid);
                
                //if(m_item is BaseWeapon) 
                //    ((BaseWeapon)m_item).Attributes[ (AosArmorAttribute)indexid ] = NewValue( (int)((BaseWeapon)m_item).Attributes[ (AosArmorAttribute)indexid ] );
                if(m_item is BaseArmor)
                    ((BaseArmor)m_item).ArmorAttributes[ (AosArmorAttribute)indexid ] = NewValue( (int)((BaseArmor)m_item).ArmorAttributes[ (AosArmorAttribute)indexid ] );
                else if(m_item is BaseClothing)
                    ((BaseClothing)m_item).ClothingAttributes[ (AosArmorAttribute)indexid ] = NewValue( (int)((BaseClothing)m_item).ClothingAttributes[ (AosArmorAttribute)indexid ] );
                /* else if(m_item is BaseJewel)
                    ((BaseJewel)m_item).Attributes[ (AosArmorAttribute)indexid ] = NewValue( (int)((BaseJewel)m_item).Attributes[ (AosArmorAttribute)indexid ] );
                else if(m_item is Spellbook)
                    ((Spellbook)m_item).Attributes[ (AosArmorAttribute)indexid ] = NewValue( (int)((Spellbook)m_item).Attributes[ (AosArmorAttribute)indexid ] );
                else if(m_item is BaseTalisman)
                    ((BaseTalisman)m_item).Attributes[ (AosArmorAttribute)indexid ] = NewValue( (int)((BaseTalisman)m_item).Attributes[ (AosArmorAttribute)indexid ] );
                else if(m_item is BaseQuiver)
                    ((BaseQuiver)m_item).Attributes[ (AosArmorAttribute)indexid ] = NewValue( (int)((BaseQuiver)m_item).Attributes[ (AosArmorAttribute)indexid ] );
                 */
                Resend(from, 7);
            }

            if(info.ButtonID >= 100)
            {
                if(m_Chisel.Uses <= 1)
                {
                    m_Chisel.Delete();
                    //from.PlaySound(0x2A);
                    from.SendMessage("You have worn out the Rune Chisel.");
                }
                else
                {
                    m_Chisel.Uses--;
                    //from.PlaySound(0x2A);
                    from.SendMessage("You use the Rune Chisel on the item.");
                   // Resend(from);
                }
            }

            //from.SendMessage($"{info.ButtonID.ToString()}");
		}

        private int NewValue(int oldvalue)
        {
            int newValue = 0;

            if(GetChance(oldvalue) > Utility.RandomDouble())
            {
                int amount = Utility.RandomMinMax(2, 15);

                if(oldvalue >= oldvalue)
                    return (oldvalue -= amount);

                else
                    return oldvalue >= 5 ? (oldvalue -= 5) : 0;
            }
            else
            {
                return (oldvalue - 1);
            }


            return oldvalue;
        }

        private static double GetChance(int oldvalue)
        {
            double chance = 0.0;

            switch( oldvalue >= 100 ? "100+" :
                    oldvalue >= 90 ? "90+" :
                    oldvalue >= 75 ? "75+" :
                    oldvalue >= 60 ? "60+" :
                    oldvalue >= 45 ? "45+" :
                    oldvalue >= 25 ? "25+" :
                    oldvalue >= 1 ? "1+" : "0" 
                )
            {
                case "100+": chance = 0.01; break;
                case "90+": chance = 0.05; break;
                case "75+": chance = 0.08; break;
                case "60+": chance = 0.10; break;
                case "45+": chance = 0.15; break;
                case "25+": chance = 0.18; break;
                case "1+": chance = 0.20; break;

            }

            return chance;
        }

        private int GetIndexID(int buttonid)
        {
            int indexid = 0;

            switch (buttonid)
            {
                case 1: indexid = 1; break;
                case 2: indexid = 2; break;
                case 3: indexid = 4; break;
                case 4: indexid = 8; break;
                case 5: indexid = 16; break;
                case 6: indexid = 32; break;
                case 7: indexid = 64; break;
                case 8: indexid = 128; break;
                case 9: indexid = 256; break;
                case 10: indexid = 512; break;
                case 11: indexid = 1024; break;
                case 12: indexid = 2048; break;
                case 13: indexid = 4096; break;
                case 14: indexid = 8192; break;
                case 15: indexid = 16384; break;
                case 16: indexid = 32768; break;
                case 17: indexid = 65536; break;
                case 18: indexid = 131072; break;
                case 19: indexid = 262144; break;
                case 20: indexid = 524288; break;
                case 21: indexid = 1048576; break;
                case 22: indexid = 2097152; break;
                case 23: indexid = 4194304; break;
                case 24: indexid = 8388608; break;
                case 25: indexid = 16777216; break;
                case 26: indexid = 33554432; break;
                case 27: indexid = 67108864; break;
            }

            return indexid;
        }
		

        public static void AosAttributes(AosAttribute attrs, int attrsValue, Gump g, int AosAttributeID, int entryID)
        {
            string attString = $"{attrs.ToString()} {attrsValue}"; 
            string chance = $"<basefont color=#0021AE>{GetChance(attrsValue).ToString("P0")}";

            int buttonID = (AosAttributeID + 100);

            if( attrsValue > 0)
            {
                g.AddButton( 270, 78 + (entryID * 30), 1210, 1209, buttonID, GumpButtonType.Reply, 0); //68x27
                g.AddHtml( 285, 75 + (entryID * 30), 260, 25, attString, (bool)true, (bool)false);
                g.AddHtml( 500, 77 + (entryID * 30), 40, 25, chance, (bool)false, (bool)false);
            }
        }
		
        public static void NegativeAttributes(NegativeAttribute attrs, int attrsValue, Gump g, int AosAttributeID, int entryID)
        {
            string attString = $"{attrs.ToString()} {attrsValue}"; 
            string chance = $"<basefont color=#0021AE>{GetChance(attrsValue).ToString("P0")}";
            int buttonID = (AosAttributeID + 200);

            if( attrsValue > 0)
            {
                g.AddButton( 270, 78 + (entryID * 30), 1210, 1209, buttonID, GumpButtonType.Reply, 0); //68x27
                g.AddHtml( 285, 75 + (entryID * 30), 260, 25, attString, (bool)true, (bool)false);
                g.AddHtml( 500, 77 + (entryID * 30), 40, 25, chance, (bool)false, (bool)false);
            }
        }

        public static void SAAbsorptionAttributes(SAAbsorptionAttribute attrs, int attrsValue, Gump g, int AosAttributeID, int entryID)
        {
            string attString = $"{attrs.ToString()} {attrsValue}"; 
            string chance = $"<basefont color=#0021AE>{GetChance(attrsValue).ToString("P0")}";
            int buttonID = (AosAttributeID + 300);

            if( attrsValue > 0)
            {
                g.AddButton( 270, 78 + (entryID * 30), 1210, 1209, buttonID, GumpButtonType.Reply, 0); //68x27
                g.AddHtml( 285, 75 + (entryID * 30), 260, 25, attString, (bool)true, (bool)false);
                g.AddHtml( 500, 77 + (entryID * 30), 40, 25, chance, (bool)false, (bool)false);
            }
        }

        public static void WeaponAttributes(AosWeaponAttribute attrs, int attrsValue, Gump g, int AosAttributeID, int entryID)
        {
            string attString = $"{attrs.ToString()} {attrsValue}"; 
            string chance = $"<basefont color=#0021AE>{GetChance(attrsValue).ToString("P0")}";
            int buttonID = (AosAttributeID + 400);

            if( attrsValue > 0)
            {
                g.AddButton( 270, 78 + (entryID * 30), 1210, 1209, buttonID, GumpButtonType.Reply, 0); //68x27
                g.AddHtml( 285, 75 + (entryID * 30), 260, 25, attString, (bool)true, (bool)false);
                g.AddHtml( 500, 77 + (entryID * 30), 40, 25, chance, (bool)false, (bool)false);
            }
        }

        public static void AosElementAttribute(AosElementAttribute attrs, int attrsValue, Gump g, int AosAttributeID, int entryID)
        {
            string attString = $"{attrs.ToString()} {attrsValue}"; 
            string chance = $"<basefont color=#0021AE>{GetChance(attrsValue).ToString("P0")}";
            int buttonID = (AosAttributeID + 500);

            if( attrsValue > 0)
            {
                g.AddButton( 270, 78 + (entryID * 30), 1210, 1209, buttonID, GumpButtonType.Reply, 0); //68x27
                g.AddHtml( 285, 75 + (entryID * 30), 260, 25, attString, (bool)true, (bool)false);
                g.AddHtml( 500, 77 + (entryID * 30), 40, 25, chance, (bool)false, (bool)false);
            }
        }

        public static void ExtendedWeaponAttribute(ExtendedWeaponAttribute attrs, int attrsValue, Gump g, int AosAttributeID, int entryID)
        {
            string attString = $"{attrs.ToString()} {attrsValue}"; 
            string chance = $"<basefont color=#0021AE>{GetChance(attrsValue).ToString("P0")}";
            int buttonID = (AosAttributeID + 600);

            if( attrsValue > 0)
            {
                g.AddButton( 270, 78 + (entryID * 30), 1210, 1209, buttonID, GumpButtonType.Reply, 0); //68x27
                g.AddHtml( 285, 75 + (entryID * 30), 260, 25, attString, (bool)true, (bool)false);
                g.AddHtml( 500, 77 + (entryID * 30), 40, 25, chance, (bool)false, (bool)false);
            }
        }

        public static void AosArmorAttribute(AosArmorAttribute attrs, int attrsValue, Gump g, int AosAttributeID, int entryID)
        {
            string attString = $"{attrs.ToString()} {attrsValue}"; 
            string chance = $"<basefont color=#0021AE>{GetChance(attrsValue).ToString("P0")}";
            int buttonID = (AosAttributeID + 700);

            if( attrsValue > 0)
            {
                g.AddButton( 270, 78 + (entryID * 30), 1210, 1209, buttonID, GumpButtonType.Reply, 0); //68x27
                g.AddHtml( 285, 75 + (entryID * 30), 260, 25, attString, (bool)true, (bool)false);
                g.AddHtml( 500, 77 + (entryID * 30), 40, 25, chance, (bool)false, (bool)false);
            }
        }
	}
}