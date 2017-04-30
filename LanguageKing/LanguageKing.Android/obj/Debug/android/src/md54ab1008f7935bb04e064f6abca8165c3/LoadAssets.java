package md54ab1008f7935bb04e064f6abca8165c3;


public class LoadAssets
	extends md5b60ffeb829f638581ab2bb9b1a7f4f3f.FormsAppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("LanguageKing.Droid.LoadAssets, LanguageKing.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", LoadAssets.class, __md_methods);
	}


	public LoadAssets () throws java.lang.Throwable
	{
		super ();
		if (getClass () == LoadAssets.class)
			mono.android.TypeManager.Activate ("LanguageKing.Droid.LoadAssets, LanguageKing.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
