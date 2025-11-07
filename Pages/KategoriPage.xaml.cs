using System;
using System.Collections.Generic;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;
using HabitTracker.Models;
namespace HabitTracker;

public partial class KategoriPage : ContentPage
{
    public string Kategori { get; set; }
    List<Vana> vanor = new List<Vana>();

    public KategoriPage(string kategori)
    {
        InitializeComponent();
        Kategori = kategori;
        KategoriLabel.Text = kategori;
        vanaLista.ItemsSource = vanor;

        LaddaVanor();
    }
    private void SparaVanor()
    {
        string json = JsonConvert.SerializeObject(vanor);
        Preferences.Set($"Vanor_{Kategori}", json);
    }
    private void LaddaVanor()
    {
        string sparat = Preferences.Get($"Vanor_{Kategori}", "");
        if (!string.IsNullOrWhiteSpace(sparat))
        {
            vanor = JsonConvert.DeserializeObject<List<Vana>>(sparat);
            vanaLista.ItemsSource = null;
            vanaLista.ItemsSource = vanor;
        }
    }

    private async void OnLaggTillVanaClicked(object sender, EventArgs e)
    {
        string namn = await DisplayPromptAsync("Ny vana", $"Vad heter din {Kategori}-vana?");
        if (!string.IsNullOrWhiteSpace(namn))
        {
            vanor.Add(new Vana { Name = namn, Kategori = Kategori });
            vanaLista.ItemsSource = null;
            vanaLista.ItemsSource = vanor;
            SparaVanor();
        }
    }

    private async void OnMarkeraGjortClicked(object sender, EventArgs e)
    {
        if (sender is Button knapp && knapp.BindingContext is Vana vana)
        {
            vana.MarkeraGjort();
            vanaLista.ItemsSource = null;
            vanaLista.ItemsSource = vanor;
            SparaVanor();

            await DisplayAlert("Motivation", vana.Motivation(), "OK");
        }
    }
    private async void OnTaBortVanaClicked(object sender, EventArgs e)
    {
        if (sender is Button knapp && knapp.BindingContext is Vana vana)
        {
            bool confirm = await DisplayAlert("Ta bort vana", $"Vill du ta bort vanan '{vana.Name}'?", "Ja", "Nej");
            if (confirm)
            {
                vanor.Remove(vana);
                vanaLista.ItemsSource = null;
                vanaLista.ItemsSource = vanor;

                SparaVanor();
            }
        }
    }
    private async void OnTillbakaClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}
