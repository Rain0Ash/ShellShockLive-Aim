// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;

namespace Ruler.Common.Forms
{
    public class PowerBox : ValueBox
    {
        protected override void SetValue(Int32 value)
        {
            base.SetValue(value);            
            EventsAndGlobalsController.Power = value;
        }
    }
}