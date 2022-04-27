using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Opt3000.Negocio
{
    public class FuncionesBasicas
    {
        #region PATRON SINGLENTON

        private static FuncionesBasicas generico = null;
        private FuncionesBasicas() { }

        public static FuncionesBasicas getInstance()
        {
            if (generico == null)
            {
                generico = new FuncionesBasicas();
            }
            return generico;
        }

        #endregion

        public void SoloNumeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    MessageBox.Show("Caracter invalido para el control!!! :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void SaltarConEnter(KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
            if (e.KeyCode.Equals(Keys.Enter))
                SendKeys.Send("{TAB}");
        }

        public bool ValidaEmail(string email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ValidaCaracterEsfera(KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^*[0-9,N,n,\.\-\+\ ]+$");

            if (regex.IsMatch(e.KeyChar.ToString()) || e.KeyChar.ToString() == "\b")
            {
                return true;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Caracter invalido para el control!!! :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ValidaCaracter(KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^*[0-9,\.\-\+]+$");
            if (regex.IsMatch(e.KeyChar.ToString()) || e.KeyChar.ToString() == "\b")
            {
                return true;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Caracter invalido para el control!!! :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ValidaSlach(KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^*[0-9,\/]+$");
            if (regex.IsMatch(e.KeyChar.ToString()) || e.KeyChar.ToString() == "\b")
            {
                return true;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Caracter invalido para el control!!! :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool ValidaN(KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^*[0-9,\.\-\+]+$");
            if (regex.IsMatch(e.KeyChar.ToString()) || e.KeyChar.ToString() == "\b")
            {
                e.Handled = false;
                return true;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Caracter invalido para el control!!! :(", "OPT3000", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool FormatoControles(string valor)
        {
            String expresion;
            //expresion = @"^*[(0-9)+N\/\.\-\+]+$";
            expresion = @"[+-]+\d+[.]+\d+$";
            //expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(valor, expresion))
            {
                if (Regex.Replace(valor, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool ValidaIdentificacion(string identificacion)
        {
            bool estado = false;
            char[] valced = new char[13];
            int provincia;
            if (identificacion.Length >= 10)
            {
                valced = identificacion.Trim().ToCharArray();
                provincia = int.Parse((valced[0].ToString() + valced[1].ToString()));
                if (provincia > 0 && provincia < 25)
                {
                    if (int.Parse(valced[2].ToString()) < 6)
                    {
                        estado = VerificaCedula(valced);
                    }
                    else if (int.Parse(valced[2].ToString()) == 6)
                    {
                        estado = VerificaSectorPublico(valced);
                    }
                    else if (int.Parse(valced[2].ToString()) == 9)
                    {

                        estado = VerificaPersonaJuridica(valced);
                    }
                }
            }
            return estado;
        }

        private bool VerificaCedula(char[] validarCedula)
        {
            int aux = 0, par = 0, impar = 0, verifi;
            for (int i = 0; i < 9; i += 2)
            {
                aux = 2 * int.Parse(validarCedula[i].ToString());
                if (aux > 9)
                    aux -= 9;
                par += aux;
            }
            for (int i = 1; i < 9; i += 2)
            {
                impar += int.Parse(validarCedula[i].ToString());
            }

            aux = par + impar;
            if (aux % 10 != 0)
            {
                verifi = 10 - (aux % 10);
            }
            else
                verifi = 0;
            if (verifi == int.Parse(validarCedula[9].ToString()))
                return true;
            else
                return false;
        }

        private bool VerificaPersonaJuridica(char[] validarCedula)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[9] { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                for (int i = 0; i < 9; i++)
                {
                    prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                    aux += prod;
                }
                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(validarCedula[9].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool VerificaSectorPublico(char[] validarCedula)
        {
            int aux = 0, prod, veri;
            veri = int.Parse(validarCedula[9].ToString()) + int.Parse(validarCedula[10].ToString()) + int.Parse(validarCedula[11].ToString()) + int.Parse(validarCedula[12].ToString());
            if (veri > 0)
            {
                int[] coeficiente = new int[8] { 3, 2, 7, 6, 5, 4, 3, 2 };

                for (int i = 0; i < 8; i++)
                {
                    prod = int.Parse(validarCedula[i].ToString()) * coeficiente[i];
                    aux += prod;
                }

                if (aux % 11 == 0)
                {
                    veri = 0;
                }
                else if (aux % 11 == 1)
                {
                    return false;
                }
                else
                {
                    aux = aux % 11;
                    veri = 11 - aux;
                }

                if (veri == int.Parse(validarCedula[8].ToString()))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public int CalculaEdad(DateTime fechaNacido)
        {
            DateTime now = DateTime.Today;
            int edad = DateTime.Today.Year - fechaNacido.Year;

            if (DateTime.Today < fechaNacido.AddYears(edad))
                return --edad;
            else
                return edad;
        }

        public void BorrarCampos(Panel control)
        {
            foreach (var txt in control.Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
            }
        }

        public Boolean EnviaEmailOutlook(string mailPaciente, string mailDr, string mailSubject, string mailContent)
        {
            try
            {
                var oApp = new Outlook.Application();

                Outlook.NameSpace ns = oApp.GetNamespace("MAPI");
                var f = ns.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

                System.Threading.Thread.Sleep(1000);

                var mailItem = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                mailItem.Subject = mailSubject;
                mailItem.HTMLBody = mailContent;
                mailItem.To = mailPaciente;
                mailItem.CC = mailDr;
                mailItem.Send();

            }
            catch
            {
                return false;
            }

            return true;
        }

        public Boolean creaCitaOutlook(Outlook._Application olApp, string adicionales, string consultorio, string paciente, DateTime dt)
        {
            try
            {
                // usar el objeto de outlook para crear el recordatorio
                Outlook._AppointmentItem apt = (Outlook._AppointmentItem)
                olApp.CreateItem(Outlook.OlItemType.olAppointmentItem);
                // algunas propiedades
                apt.Subject = paciente;
                apt.Body = adicionales;
                apt.Start = dt;
                apt.End = dt.AddHours(0.5);

                //apt.ReminderMinutesBeforeStart = 24 * 60 * 7 * 1; // una semana antes
                apt.ReminderMinutesBeforeStart = 30;

                // Hacer que aparezca con negrita en el calendario!
                apt.BusyStatus = Outlook.OlBusyStatus.olBusy;

                apt.AllDayEvent = false;
                apt.Location = consultorio;

                apt.Save();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Boolean CerrarFormulario(string formulario)
        {
            if (MessageBox.Show(formulario + " se cerrara ¿DESEA CONTINUAR? :(", "OPT3000", MessageBoxButtons.OKCancel) == DialogResult.OK)
                return true;
            else
                return false;
        }

        public void OnlyNumberDecimal(KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            e.Handled = !(char.IsDigit(e.KeyChar)
                    || e.KeyChar == (char)Keys.Back
                    || e.KeyChar == (char)Keys.M
                    || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator);
        }

        public string ClaveAccesoSRI(string fecha, string clave, string tipoEmision)
        {
            try
            {
                string[] split = fecha.Split('/');
                clave = split[2].Substring(0, 4) + split[1] + split[0] + clave + clave.Substring(0, 8) + tipoEmision;
                int[] cadena1 = { 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                char[] arrayClave = clave.ToCharArray();
                int suma = 0;
                for (int i = 0; i < clave.Length; i++)
                {
                    suma += cadena1[i] * Convert.ToInt16(arrayClave[i]);
                }
                int mod = suma % 11;
                mod = 11 - mod;
                if (mod == 11)
                    mod = 0;
                clave += Convert.ToString(mod);

                return clave;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean TipoCaracter(KeyPressEventArgs e)
        {
            int i = 0;
            string s = e.KeyChar.ToString();
            bool result = int.TryParse(s, out i);
            return result;
        }
    }
}
