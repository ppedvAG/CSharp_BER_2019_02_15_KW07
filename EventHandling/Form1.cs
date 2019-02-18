using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventHandling
{
    //PARTIAL besagt, dass die Klasse hier nicht vollständig dargestellt wird. Der Rest befindet sich in einem
    ///anderen Dokument. Jedes Form erbt von der Klasse FORM, welche sämtliche Funktionen eines Fensters zur Verfügung stellt
    public partial class Form1 : Form
    {
        //Properties des Forms zum Abspeichern der Startpositionen der Buttons (Lab09)
        public int LeftStart { get; set; }
        public int RightStart { get; set; }

        //Konstruktor des Forms (wird bei Aufruf des Fensters aufgerufen)
        public Form1()
        {
            //Mit dieser Methode werden die Designerseitig gebauten Elemente gezeichnet
            InitializeComponent();

            //EVENTs sind spezielle Delegates, welche nicht per Zuweisung überschrieben werden können. Methode müssen das Event per += abbonieren und
            ///per -= deabbonieren. Tritt ein Event auf (z.B. wenn ein Button geklickt wird) werden alle Methoden ausgeführt, welche dieses Event
            ///abboniert haben
            btnKlickMich.Click += btnKlickMich_Click2;

            //Speichern der Startpositionen der Buttons (Lab09)
            this.LeftStart = btnLeft.Left;
            this.RightStart = btnRight.Left;

            //Abonieren der drei Click-Methoden durch das Click-Event der dritten Buttons (Lab09)
            btnStart.Click += btnLeft_Click;
            btnStart.Click += btnRight_Click;
            btnStart.Click += btnStart_Click;

        }

        //Click-Methoden (oder andere Event-Methoden) der einzelnen Buttons
        private void btnKlickMich_Click(object sender, EventArgs e)
        {
            btnKlickMich.BackColor = Color.LightPink;
        }

        private void btnKlickMich_MouseEnter(object sender, EventArgs e)
        {
            btnKlickMich.Left += 20;
        }

        private void btnKlickMich_Click2(object sender, EventArgs e)
        {
            this.Text = "Du hast den Button angeklickt";
        }

        //Start/Stop des Timers
        private void button1_Click(object sender, EventArgs e)
        {
            if (!timer1.Enabled)
                timer1.Start();
            else
                timer1.Stop();
        }

        //Öffnen eines weiteren Fensters
        private void neuesFensterÖffnenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 neuesFenster = new Form1();

            neuesFenster.ShowDialog();
        }

        private void beendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Fenster schließen
            this.Close();
            //Programm beenden
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Aufruf einer MessageBox und Abfrage der Wahl des Benutzers
            if (MessageBox.Show("Geht es dir gut?", "Befindlichkeit", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                MessageBox.Show("Aber nicht mehr lange...");
            }
            else
                MessageBox.Show("Das tut mir Leid.");
        }

        //Methoden wurden im Designer von den Click-Events der Buttons btnLeft und btnRight abboniert (Lab09)
        private void btnLeft_Click(object sender, EventArgs e)
        {
            //Bewegt des Buttons um 10 Pixel nach rechts
            btnLeft.Left += 10;
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            //Bewegt des Buttons um 10 Pixel nach links
            btnRight.Left -= 10;
        }

        //Methode wird im Konstruktor durch das Click-Event des Buttons btnStart abboniert
        private void btnStart_Click(object sender, EventArgs e)
        {
            //Test, ob Kollision vorhanden
            if (btnLeft.Right >= btnRight.Left)
                //Aufruf einer MessageBox, mit Abfrage, ob der Button 'Ja' geklickt wurde
                if (MessageBox.Show("Die Buttons berühren sich.\nZurücksetzen?", "Kollision", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    //Zurücksetzen der Buttons auf ihre Startposition
                    btnLeft.Left = this.LeftStart;
                    btnRight.Left = this.RightStart;
                }
        }
    }
}
