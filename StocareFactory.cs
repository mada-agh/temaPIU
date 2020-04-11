using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NivelAccesDate1;
using System.Configuration;
using NivelAccesDate2;

namespace Biblioteca
{
    public static class StocareFactory
    {
        private const string FORMAT_SALVARE = "FormatSalvare";
        private const string NUME_FISIER1 = "NumeFisier1";
        private const string NUME_FISIER2 = "NumeFisier2";
        public static IStocareData1 GetAdministratorStocare1() //carti
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisier = ConfigurationManager.AppSettings[NUME_FISIER1];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    //case "bin":
                        //return new AdministrareStudenti_FisierBinar(numeFisier + "." + formatSalvare);
                    case "txt":
                        return new AdministrareCarti_FisierText(numeFisier + "." + formatSalvare);
                }
            }

            return null;
        }
        public static IStocareData2 GetAdministratorStocare2() //cititori
        {
            var formatSalvare = ConfigurationManager.AppSettings[FORMAT_SALVARE];
            var numeFisier = ConfigurationManager.AppSettings[NUME_FISIER2];
            if (formatSalvare != null)
            {
                switch (formatSalvare)
                {
                    default:
                    //case "bin":
                    //return new AdministrareStudenti_FisierBinar(numeFisier + "." + formatSalvare);
                    case "txt":
                        return new AdministrareCititori_FisierText(numeFisier + "." + formatSalvare);
                }
            }

            return null;
        }
    }
}
