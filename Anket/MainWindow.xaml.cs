using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Anket;

public partial class MainWindow : Window
{
    public User _user;
    string? dateGender;
    public MainWindow()
    {
        InitializeComponent();
    }


    private void btnLoad_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            string fileName = $"{txtBoxLoad}.json";
            string text = File.ReadAllText(fileName);
            var json = JsonSerializer.Deserialize<User>(text);

            txtBoxFatherName.Text = json.FatherName;
            txtBoxName.Text = json.Name;
            txtBoxSurname.Text = json.Surname;
            txtBoxCountry.Text = json.Country;
            txtBoxCity.Text = json.City;
            if (rbMale.Content.ToString() == json.Gender) rbMale.IsChecked = true;
            else rbFemale.IsChecked = true;
            Calendar.Text = json.Brithday.ToString();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Not Found User");
        }
    
        
    }

    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            _user = new(){
                FatherName = txtBoxFatherName.Text,
                Name = txtBoxName.Text,
                Surname = txtBoxSurname.Text,
                Country = txtBoxCountry.Text,
                City = txtBoxCity.Text,
                Phone = txtBoxPhone.Text,
                Gender = dateGender,
                Brithday = Calendar.ToString(),
            };

            string fileName = $"{txtBoxName}.json";
            string json = JsonSerializer.Serialize(_user);
            File.WriteAllText(fileName, json);
            MessageBox.Show("Saveing User");
        }
        catch (Exception ex)
        {

            MessageBox.Show("Eror Var");
        }
    }

    private void RadioButton_Checked(object sender, RoutedEventArgs e)
    {
        if(sender is RadioButton rb)
        {
            if (rb.Content.ToString() == "Male") dateGender = "Male";
            if (rb.Content.ToString() == "Female") dateGender = "Female";
        }
    }
}
