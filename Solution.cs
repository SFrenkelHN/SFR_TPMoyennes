using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPMoyennes;

namespace TPMoyennes
{
    class Classe
    {
        // Declaration des variables
        public string nomClasse;
        //public string[] matieres = new string[10]; //10 matieres max par classe
        //public Eleve[] eleves = new Eleve[30];  //Une classe acceuille 30 eleves max
        public List<Eleve> eleves = new List<Eleve>();
        public List<string> matieres = new List<string>();
       

        public Classe(string nomClasse)
        {
            this.nomClasse = nomClasse;
            /*
            if (matieres.Length > 10)
            //{
                Array.Resize(ref matieres, 10);
            }
            this.matieres = matieres;
            if (eleves.Length > 30)
            {
                Array.Resize(ref eleves, 30);
            }
            this.eleves = eleves;
            */
        }

        // Declaration des fonctions ajouter((Nom,prenon);matieres;Notes)
        public void ajouterEleve(string prenom, string nom)
        {
            Eleve nouvelEleve = new Eleve(prenom, nom);
            eleves.Add(nouvelEleve);
        }

        public void ajouterMatiere(string nomMatiere)
        {
            matieres.Add(nomMatiere);
        }

        public float Moyenne()
        {
            float sommeDesMoyennes = 0.0f;
            foreach (Eleve eleve in eleves)
            {
                sommeDesMoyennes += eleve.Moyenne();
            }
            return sommeDesMoyennes / eleves.Count;
        }

        //Calcul de la moyenne Classe par matiere
        public float Moyenne(int indexMatiere)
        {
            float sommeDesNotes = 0.0f;
            foreach (Eleve eleve in eleves)
            {
                foreach (Note note in eleve.notes)
                {
                    if (note.matiere == indexMatiere)
                    {
                        sommeDesNotes += note.note;
                        break;
                    }
                }
            }
            return sommeDesNotes / eleves.Count;
        }
    }

    class Eleve
    {
        public string nom;
        public string prenom;
        // ex: Eleves[8(Eleve nb8)] = notes[1(Matiere),12(note)] 
        // ex: Eleves[8(Eleve nb8)] = notes[1(Matiere),7(note)] 
        //public Note[] notes = new Note[200];
        public List<Note> notes = new List<Note>();

        public Eleve(string prenom, string nom)
        {
            this.prenom = prenom;
            this.nom = nom;
            /*
            if (notes.Length > 200)
            {
                Array.Resize(ref notes, 200);
            }
            */
        }

        public void ajouterNote(int matiere, float note)
        {
            /*
            if (nombreDeNotes < 200)
            {
                notes[nombreDeNotes] = new Note(matiere, note);
                nombreDeNotes++;
            }
            */
            Note nouvelleNote = new Note(matiere, note);
            notes.Add(nouvelleNote);
        }

        public float Moyenne()
        {
            float sommeDesNotes = 0.0f;
            foreach (Note note in notes)
            {
                sommeDesNotes += note.note;
            }
            return sommeDesNotes / notes.Count;
        }

        public float Moyenne(int indexMatiere)
        {
            float sommeDesNotes = 0.0f;
            int nombreDeNotes = 0;
            foreach (Note note in notes)
            {
                if (note.matiere == indexMatiere)
                {
                    sommeDesNotes += note.note;
                    nombreDeNotes++;
                }
            }
            if (nombreDeNotes == 0)
            {
                return 0.0f;
            }
            else
            {
                return sommeDesNotes / nombreDeNotes;
            }
        }
    }
}