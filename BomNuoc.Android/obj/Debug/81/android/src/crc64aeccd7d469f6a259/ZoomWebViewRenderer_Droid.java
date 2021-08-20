package crc64aeccd7d469f6a259;


public class ZoomWebViewRenderer_Droid
	extends crc643f46942d9dd1fff9.WebViewRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("BomNuoc.Droid.CustomRenderers.ZoomWebViewRenderer_Droid, BomNuoc.Android", ZoomWebViewRenderer_Droid.class, __md_methods);
	}


	public ZoomWebViewRenderer_Droid (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ZoomWebViewRenderer_Droid.class)
			mono.android.TypeManager.Activate ("BomNuoc.Droid.CustomRenderers.ZoomWebViewRenderer_Droid, BomNuoc.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ZoomWebViewRenderer_Droid (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ZoomWebViewRenderer_Droid.class)
			mono.android.TypeManager.Activate ("BomNuoc.Droid.CustomRenderers.ZoomWebViewRenderer_Droid, BomNuoc.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ZoomWebViewRenderer_Droid (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ZoomWebViewRenderer_Droid.class)
			mono.android.TypeManager.Activate ("BomNuoc.Droid.CustomRenderers.ZoomWebViewRenderer_Droid, BomNuoc.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
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
