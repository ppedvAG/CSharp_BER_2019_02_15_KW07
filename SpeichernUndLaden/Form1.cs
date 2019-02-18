using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeichernUndLaden
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Methode zum Speichern einer Textdatei (vgl. auch btnLoad_Click())
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();

            saveDialog.FileName = "gespeicherteStrings.txt";
            saveDialog.InitialDirectory = "C:\\";
            saveDialog.Filter = "Textdatei|*.txt|String|*.string|Alle Dateien|*.*";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = null;

                try
                {
                    sw = new StreamWriter(saveDialog.FileName);

                    //StreamWriter schreibt einen String in die Datei
                    sw.WriteLine(tbxInput.Text);

                    MessageBox.Show("Speichern erfolgreich");
                }
                catch
                {
                    MessageBox.Show("Speichern fehlgeschlagen");
                }
                finally
                {
                    //if (sw != null)
                    //    sw.Close();

                    sw?.Close();
                }
            }
        }

        //Methode zum Laden einer Textdatei
        private void btnLoad_Click(object sender, EventArgs e)
        {
            //Instanzierung eines Open-Dialogfensters 
            OpenFileDialog openDialog = new OpenFileDialog();

            //Einstellung diverser Parameter des Dialogfensters
            ///Standart-Dateiname
            openDialog.FileName = "gespeicherteStrings.txt";
            ///Standart-Ordner (kann z.B. ein Pfad als String sein oder (wie hier) ein Windows-'SpecialFolder')
            openDialog.InitialDirectory = "C:\\";
            ///Übergabe des Windows-Arbeitsplatzes als GUID
            openDialog.InitialDirectory = "::{20d04fe0-3aea-1069-a2d8-08002b30309d}";
            ///Mögliche Dateiformate
            openDialog.Filter = "Textdatei|*.txt|Stringdatei|*.string|Alle Dateien|*.*";

            //Öffnen des Dialogfensters und Überprüfung der Benutzerwahl
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = null;

                try
                {
                    //Deklarierung und Null-Initialisierung einer Streamreader-Variablen
                    sr = new StreamReader(openDialog.FileName);

                    //Löschen des Inhalts der Textbox
                    tbxInput.Clear();

                    //Schleife, welche über die geöffnete Datei läuft
                    while (!sr.EndOfStream)
                    {
                        //Hinzufügen der aktuell betrachteten Zeile in der Datei zu der Textbox
                        tbxInput.Text += sr.ReadLine() + "\r\n";
                    }

                    //Erfolgsmeldung für User
                    MessageBox.Show("Laden erfolgreich");
                }
                catch
                {
                    //Misserfolgsmeldung für User bei Aufkommen einer Exception
                    MessageBox.Show("Laden fehlgeschlagen");
                }
                finally
                {
                    //Schließen der Datei innerhalb des Finally-Blocks, damit andere Programme auf die Datei zugreifen können (? = Nullprüfung des vorhergehenden Bezeichners)
                    sr?.Close();
                }
            }
        }
    }
}
