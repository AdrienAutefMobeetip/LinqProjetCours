using LinqProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace LinqProject.Services
{
    public class EtudiantService
    {
        private List<Etudiant>? etudiants;

        public EtudiantService()
        {
            LoadData();
        }

        private void LoadData()
        {
            var jsonData = File.ReadAllText("Data/etudiants.json");
            etudiants = JsonConvert.DeserializeObject<List<Etudiant>>(jsonData) ?? new List<Etudiant>();

            var xmlData = XDocument.Load("Data/etudiants.xml");
            var etudiantsFromXml = xmlData.Descendants("Etudiant").Select(x => new Etudiant
            {
                Id = int.Parse(x.Element("Id").Value),
                Nom = x.Element("Nom").Value,
                Prenom = x.Element("Prenom").Value,
                Age = int.Parse(x.Element("Age").Value),
                Email = x.Element("Email").Value
            });
            etudiants.AddRange(etudiantsFromXml);
        }

        public void ConvertJsonToXml()
        {
            if (etudiants == null) return;

            var xml = new XElement("Etudiants",
                etudiants.Select(e => new XElement("Etudiant",
                    new XElement("Id", e.Id),
                    new XElement("Nom", e.Nom),
                    new XElement("Prenom", e.Prenom),
                    new XElement("Age", e.Age),
                    new XElement("Email", e.Email)
                ))
            );
            xml.Save("Data/etudiants_from_json.xml");
        }

        public List<Etudiant> Recherche(string query)
        {
            return etudiants?.Where(e => e.Nom.Contains(query) || e.Prenom.Contains(query) || e.Email.Contains(query)).ToList() ?? new List<Etudiant>();
        }

        public List<Etudiant> FiltrerParAge(int ageMinimum)
        {
            return etudiants?.Where(e => e.Age >= ageMinimum).ToList() ?? new List<Etudiant>();
        }

        public List<Etudiant> TrierParNom()
        {
            return etudiants?.OrderBy(e => e.Nom).ToList() ?? new List<Etudiant>();
        }
    }
}
