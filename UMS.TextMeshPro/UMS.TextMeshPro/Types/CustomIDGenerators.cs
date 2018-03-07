﻿using UMS.Behaviour;
using TMPro;

namespace UMS.TMP.Types
{
    public class CustomIDGenerators
    {
        [CustomIDGenerator(typeof(TextMeshProUGUI))]
        public static int GetTextID(TextMeshProUGUI text)
        {
            return text.GetHashCode();
        }
    }    
}
