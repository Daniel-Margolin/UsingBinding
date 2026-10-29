using System.Collections.ObjectModel;
using UsingBinding.Models;

namespace UsingBinding.Views;

public partial class MuscleList : ContentPage
{
    public ObservableCollection<Muscle> Muscles { get; set; }

    private Muscle? selectedMuscle;

    public Muscle? SelectedMuscle
    {
        get => selectedMuscle;
        set
        {
            if (selectedMuscle != value)
            {
                selectedMuscle = value;
                OnPropertyChanged(nameof(SelectedMuscle));
            }
        }
    }

    public MuscleList()
    {
        InitializeComponent();

        Muscles = new ObservableCollection<Muscle>
        {
            new Muscle { Name = "Biceps", BodyPart = "Arms" },
            new Muscle { Name = "Triceps", BodyPart = "Arms" },
            new Muscle { Name = "Pectorals", BodyPart = "Chest" },
            new Muscle { Name = "Quadriceps", BodyPart = "Legs" },
            new Muscle { Name = "Latissimus Dorsi", BodyPart = "Back" }
        };

        BindingContext = this;
    }

    private async void OnAddMuscleClicked(object sender, EventArgs e)
    {
        Muscle newMuscle = new Muscle
        {
            Name = "New Muscle",
            BodyPart = "Unknown"
        };

        Muscles.Add(newMuscle);
        SelectedMuscle = newMuscle;

        await DisplayAlert(
            "Success",
            "Muscle added successfully.",
            "OK");
    }

    private async void OnSaveChangesClicked(object sender, EventArgs e)
    {
        if (SelectedMuscle == null)
        {
            await DisplayAlert("Error", "Select a muscle first.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(SelectedMuscle.Name) ||
            string.IsNullOrWhiteSpace(SelectedMuscle.BodyPart))
        {
            await DisplayAlert(
                "Error",
                "Both fields must contain a value.",
                "OK");

            return;
        }

        await DisplayAlert(
            "Success",
            "Muscle details are valid.",
            "OK");
    }

    private async void OnDeleteMuscleClicked(object sender, EventArgs e)
    {
        if (SelectedMuscle == null)
        {
            await DisplayAlert("Error", "Select a muscle first.", "OK");
            return;
        }

        bool confirm = await DisplayAlert(
            "Delete Muscle",
            $"Delete {SelectedMuscle.Name}?",
            "Yes",
            "No");

        if (confirm)
        {
            Muscles.Remove(SelectedMuscle);
            SelectedMuscle = null;
        }
    }

    private void OnClearSelectionClicked(object sender, EventArgs e)
    {
        SelectedMuscle = null;
    }
}