package md51e82f2298f16c7de001f97d02de70bec;


public class ZoomWebViewRenderer_Droid_JavascriptCallback
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.webkit.ValueCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onReceiveValue:(Ljava/lang/Object;)V:GetOnReceiveValue_Ljava_lang_Object_Handler:Android.Webkit.IValueCallbackInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("BomNuoc.Droid.CustomRenderers.ZoomWebViewRenderer_Droid+JavascriptCallback, BomNuoc.Android", ZoomWebViewRenderer_Droid_JavascriptCallback.class, __md_methods);
	}


	public ZoomWebViewRenderer_Droid_JavascriptCallback ()
	{
		super ();
		if (getClass () == ZoomWebViewRenderer_Droid_JavascriptCallback.class)
			mono.android.TypeManager.Activate ("BomNuoc.Droid.CustomRenderers.ZoomWebViewRenderer_Droid+JavascriptCallback, BomNuoc.Android", "", this, new java.lang.Object[] {  });
	}


	public void onReceiveValue (java.lang.Object p0)
	{
		n_onReceiveValue (p0);
	}

	private native void n_onReceiveValue (java.lang.Object p0);

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
