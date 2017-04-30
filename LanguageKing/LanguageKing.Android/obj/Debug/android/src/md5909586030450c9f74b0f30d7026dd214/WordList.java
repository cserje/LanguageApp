package md5909586030450c9f74b0f30d7026dd214;


public class WordList
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("LanguageKing.WordList, LanguageKing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", WordList.class, __md_methods);
	}


	public WordList () throws java.lang.Throwable
	{
		super ();
		if (getClass () == WordList.class)
			mono.android.TypeManager.Activate ("LanguageKing.WordList, LanguageKing, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
