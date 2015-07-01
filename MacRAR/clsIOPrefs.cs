using System;

using Foundation;
using AppKit;

namespace MacRAR
{
	public class clsIOPrefs
	{

		public string GetStringValue(string key)
		{
			string value = string.Empty;
			value = NSUserDefaults.StandardUserDefaults.StringForKey(key); 
			if (value == null)
				value = "";
			
			return value;
			
		}

		public void SetStringValue(string key,string value)
		{
			NSUserDefaults.StandardUserDefaults.SetString(value.ToString (), key); 
			NSUserDefaults.StandardUserDefaults.Synchronize ();

		}
			
	}
}

