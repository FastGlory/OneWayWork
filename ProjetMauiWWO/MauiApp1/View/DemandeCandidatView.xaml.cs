namespace MauiApp1.View;

public partial class DemandeCandidatView : ContentPage
{
	public DemandeCandidatView()
	{
		InitializeComponent();
	}

	private void UploadDocBtn(object sender, EventArgs e)
	{
		var newFilePicker = FilePicker.PickAsync(new PickOptions
		{
			FileTypes = FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>{

			})
		});
	}


}