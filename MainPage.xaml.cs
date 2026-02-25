using Microsoft.Maui.Controls;

namespace MD_BMI_Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCalculateClicked(object sender, EventArgs e)
        {
            if (!double.TryParse(HeightEntry.Text, out double heightCm) || heightCm <= 0)
            {
                DisplayAlert("Invalid Input", "Please enter a valid height in cm.", "OK");
                return;
            }

            if (!double.TryParse(WeightEntry.Text, out double weightKg) || weightKg <= 0)
            {
                DisplayAlert("Invalid Input", "Please enter a valid weight in kg.", "OK");
                return;
            }

            double heightM = heightCm / 100.0;
            double bmi = weightKg / (heightM * heightM);

            BmiValueLabel.Text = bmi.ToString("F1");

            string category;
            Color badgeColor;

            if (bmi < 18.5)
            {
                category = "Underweight";
                badgeColor = Color.FromArgb("#42A5F5");
            }
            else if (bmi < 25.0)
            {
                category = "Normal Weight";
                badgeColor = Color.FromArgb("#66BB6A");
            }
            else if (bmi < 30.0)
            {
                category = "Overweight";
                badgeColor = Color.FromArgb("#FFA726");
            }
            else
            {
                category = "Obese";
                badgeColor = Color.FromArgb("#EF5350");
            }

            CategoryLabel.Text = category;
            CategoryBadge.BackgroundColor = badgeColor;

            ResultCard.IsVisible = true;
            ResetButton.IsVisible = true;
        }

        private void OnResetClicked(object sender, EventArgs e)
        {
            HeightEntry.Text = string.Empty;
            WeightEntry.Text = string.Empty;
            ResultCard.IsVisible = false;
            ResetButton.IsVisible = false;
        }
    }
}