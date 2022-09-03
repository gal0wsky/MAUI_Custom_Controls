package crc64807bc38198abafe2;


public class CustomTimePickerDialog
	extends android.app.TimePickerDialog
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTimeChanged:(Landroid/widget/TimePicker;II)V:GetOnTimeChanged_Landroid_widget_TimePicker_IIHandler\n" +
			"n_onClick:(Landroid/content/DialogInterface;I)V:GetOnClick_Landroid_content_DialogInterface_IHandler\n" +
			"";
		mono.android.Runtime.register ("MAUI_Custom_Controls.CustomControls.CustomTimePickerDialog, MAUI_Custom_Controls", CustomTimePickerDialog.class, __md_methods);
	}


	public CustomTimePickerDialog (android.content.Context p0, android.app.TimePickerDialog.OnTimeSetListener p1, int p2, int p3, boolean p4)
	{
		super (p0, p1, p2, p3, p4);
		if (getClass () == CustomTimePickerDialog.class)
			mono.android.TypeManager.Activate ("MAUI_Custom_Controls.CustomControls.CustomTimePickerDialog, MAUI_Custom_Controls", "Android.Content.Context, Mono.Android:Android.App.TimePickerDialog+IOnTimeSetListener, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib:System.Boolean, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3, p4 });
	}


	public CustomTimePickerDialog (android.content.Context p0, int p1, android.app.TimePickerDialog.OnTimeSetListener p2, int p3, int p4, boolean p5)
	{
		super (p0, p1, p2, p3, p4, p5);
		if (getClass () == CustomTimePickerDialog.class)
			mono.android.TypeManager.Activate ("MAUI_Custom_Controls.CustomControls.CustomTimePickerDialog, MAUI_Custom_Controls", "Android.Content.Context, Mono.Android:System.Int32, System.Private.CoreLib:Android.App.TimePickerDialog+IOnTimeSetListener, Mono.Android:System.Int32, System.Private.CoreLib:System.Int32, System.Private.CoreLib:System.Boolean, System.Private.CoreLib", this, new java.lang.Object[] { p0, p1, p2, p3, p4, p5 });
	}


	public void onTimeChanged (android.widget.TimePicker p0, int p1, int p2)
	{
		n_onTimeChanged (p0, p1, p2);
	}

	private native void n_onTimeChanged (android.widget.TimePicker p0, int p1, int p2);


	public void onClick (android.content.DialogInterface p0, int p1)
	{
		n_onClick (p0, p1);
	}

	private native void n_onClick (android.content.DialogInterface p0, int p1);

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
