using Microsoft.Win32;

namespace MAUIForm;

public partial class MainPage : ContentPage
{
	public List<Country> Countries = null!;
	public MainPage()
	{
		InitializeComponent();
		Countries  = new List<Country>();
		Countries.Add(new Country() {Name = "日本", Info = "が好き"});
		Countries.Add(new Country() {Name = "米国", Info = "が好き"});
		Countries.Add(new Country() {Name = "英国", Info = "が好き"});
		Countries.Add(new Country() {Name = "中国", Info = "が嫌い"});
		Countries.Add(new Country() {Name = "韓国", Info = "が大嫌い"});
		lstCountries.ItemsSource = Countries;
	}
	public void btnClicked(object? sender, EventArgs e) {
		lblHello.Text = $"こんにちは {txtName.Text} さん!!";
	}
	public async void txtName_UnFocused(object? sender, EventArgs e) {
		if (txtName.IsSoftInputShowing()) {
			await txtName.HideSoftInputAsync(CancellationToken.None);
		}
	}
	public void OnChangeCountry(object? sender , EventArgs e) {
		lblInfo.Text = ((Country)lstCountries.SelectedItem).Info;
	}
	public void OnSliderChanged(object? sender, ValueChangedEventArgs e) {
		Slider sld = (Slider)sender!;
		byte r = (byte)slR.Value;
		byte g = (byte)slG.Value;
		byte b = (byte)slB.Value;
		lblRVal.Text = r.ToString("x2");
		lblGVal.Text = g.ToString("x2");
		lblBVal.Text = b.ToString("x2");
		Color col = Color.FromRgb(r, g, b);
		lblColoredText.TextColor = col;
	}
}
public class Country {
	public string Name { get; set; } = null!;
	public string Info { get; set; } = null!;
}

