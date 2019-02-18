using Fahrzeugpark;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Json ist eine Serialisierungs-Methode, welche über den NuGet-Marketspace installiert und dem Projekt hinzugefügt wurde
using Newtonsoft.Json;
using System.IO;

namespace Serialisierung
{
    public partial class Form1 : Form
    {
        //Properties
        public List<Fahrzeug> FahrzeugListe { get; set; }
        public Random generator { get; set; }

        public Form1()
        {
            InitializeComponent();

            //Initialisierung der Properties
            this.FahrzeugListe = new List<Fahrzeug>();
            this.generator = new Random();
        }

        //Click-Methoden der Buttons
        private void btnNew_Click(object sender, EventArgs e)
        {
            ErstelleNeuesFz();
            ZeigeFz();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            LöscheFz();
            ZeigeFz();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SpeichereFz();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LadeFz();
            ZeigeFz();
        }

        //Methode zur Darstellung der Fahrzeuge aus der Liste in der ListBox der GUI
        private void ZeigeFz()
        {
            //Löschen der aktuellen ListBox-Inhalte
            lbxFahrzeuge.Items.Clear();

            //Hinzufügen der Name der Fahrzeuge aus der Fahrzeugliste in die Listbox
            foreach (var item in this.FahrzeugListe)
            {
                lbxFahrzeuge.Items.Add(item.Name);
            }
        }

        //Methode zur zufälligen Erstellung von Fahrzeugen
        private void ErstelleNeuesFz()
        {
            switch (generator.Next(1, 4))
            {
                case 1:
                    this.FahrzeugListe.Add(new Flugzeug($"Boing", 800, 3600000, 9999));
                    break;
                case 2:
                    this.FahrzeugListe.Add(new Schiff($"Titanic", 40, 3500000, Schiff.SchiffsTreibstoff.Dampf));
                    break;
                case 3:
                    this.FahrzeugListe.Add(PKW.ErzeugeZufälligenPKW());
                    break;
            }
        }

        //Methode zum Löschen von Fahrzeugen
        private void LöscheFz()
        {
            //Iteration über die ListBox
            for (int i = lbxFahrzeuge.Items.Count - 1; i >= 0; i--)
            {
                //Überprüfung, ob der aktuelle Eintrag vom Benutzer ausgewählt wurde
                if (lbxFahrzeuge.GetSelected(i))
                {
                    //Löschung des gewählten Eintrags in der Fahrzeugliste
                    this.FahrzeugListe.RemoveAt(i);
                }
            }
        }

        //Methode zum Abspeichern von Fahrzeugen (vgl. auch LadeFz())
        private void SpeichereFz()
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter("gespeicherteFzs.txt");

                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;

                //Iteration über die Fahrzeugliste
                foreach (var item in FahrzeugListe)
                {
                    string fzAlsString = JsonConvert.SerializeObject(item, settings);
                    sw.WriteLine(fzAlsString);
                }

                MessageBox.Show("Speichern erfolgreich");
            }
            catch
            {
                MessageBox.Show("Speichern fehlgeschlagen");
            }
            finally
            {
                sw?.Close();
            }
        }

        //Methode zum Laden einer 'Fahrzeug'-Datei (vgl. auch SpeichernUndLaden.Form1.btnLoad_Click())
        private void LadeFz()
        {
            StreamReader sr = null;

            try
            {
                sr = new StreamReader("gespeicherteFzs.txt");

                //Mittels der TypeNameHandling-Property des JsonSerializerSettings-Objekts kann dem Serialisierer aufgegeben werden, dass er den expliziten Objekt-Type der 
                //zu ladenden/speichernden Objekte mit abspeichert
                JsonSerializerSettings settings = new JsonSerializerSettings();
                settings.TypeNameHandling = TypeNameHandling.Objects;

                this.FahrzeugListe.Clear();

                while (!sr.EndOfStream)
                {
                    //Lesen einer Textzeile aus der Datei / Umwandlung der Textzeile in ein Fahrzeug (Beachte die Übergabe des Settings-Objekts) / Hinzufügen des Fahrzeugs zur Liste
                    this.FahrzeugListe.Add(JsonConvert.DeserializeObject<Fahrzeug>(sr.ReadLine(), settings));
                }

                MessageBox.Show("Laden erfolgreich");
            }
            catch
            {
                MessageBox.Show("Laden fehlgeschlagen");
            }
            finally
            {
                sr?.Close();
            }
        }
    }
}
