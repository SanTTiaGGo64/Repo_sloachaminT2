using Microsoft.Maui.Controls;
namespace sloachaminT2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            limpiar();
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            try
            {
                string NombreEst = (string)pckEstudiantes.SelectedItem;

                if (pckEstudiantes.SelectedIndex == -1)
                {
                    DisplayAlert("AVISO", "Debe seleccionar un alumno.", "ok");
                }
                else if (txtNotaSeguimiento.Text == null || txtExamen.Text == null || txtNotaSeguimiento2.Text == null || txtExamen2.Text == null)
                {
                    DisplayAlert("AVISO", "Un campo de notas se encuentra vacio.", "ok");
                }
                else if (txtNotaSeguimiento.Text.Contains('.') || txtExamen.Text.Contains(".") || txtNotaSeguimiento2.Text.Contains(".") || txtExamen2.Text.Contains("."))
                {
                    DisplayAlert("AVISO", "utilizar signo coma para decimales ➜ ','", "ok");
                }
                else if (Convert.ToDecimal(txtNotaSeguimiento.Text) > 10)
                {
                    DisplayAlert("AVISO", "Nota de seguimiento no puede ser mayor a 10.", "ok");
                }
                else if (Convert.ToDecimal(txtExamen.Text) > 10)
                {
                    DisplayAlert("AVISO", "Nota de examen no puede ser mayor a 10.", "ok");
                }
                else if (Convert.ToDecimal(txtNotaSeguimiento2.Text) > 10)
                {
                    DisplayAlert("AVISO", "Nota de seguimiento 2 no puede ser mayor a 10.", "ok");
                }
                else if (Convert.ToDecimal(txtExamen2.Text) > 10)
                {
                    DisplayAlert("AVISO", "Nota de examen 2 no puede ser mayor a 10.", "ok");
                }
                else
                {
                    //PArcial 1
                    decimal NotaSeg = Convert.ToDecimal(txtNotaSeguimiento.Text);
                    decimal NotaFinalSeg = NotaSeg * 0.3m;

                    decimal NotaExamen = Convert.ToDecimal(txtExamen.Text);
                    decimal NotaFinalExamen = NotaExamen * 0.2m;

                    decimal NotaPar1 = NotaFinalSeg + NotaFinalExamen;

                    //PArcial 2
                    decimal NotaSeg2 = Convert.ToDecimal(txtNotaSeguimiento2.Text);
                    decimal NotaFinalSeg2 = NotaSeg2 * 0.3m;

                    decimal NotaExamen2 = Convert.ToDecimal(txtExamen2.Text);
                    decimal NotaFinalExamen2 = NotaExamen2 * 0.2m;

                    decimal NotaPar2 = NotaFinalSeg2 + NotaFinalExamen2;

                    //NotaExame final
                    decimal NotaFinal = NotaPar1 + NotaPar2;

                    //Fecha
                    DateTime dpFechaReg = dpFechaRegistro.Date;
                    string strFecha = dpFechaReg.ToString("MM/dd/yyyy"); // Formato personalizado


                    //Controles estado
                    string strEstado = string.Empty;

                    if (NotaFinal >= 7)
                    {
                        strEstado = "El estudiante se encuentra APROBADO";
                    }
                    else if (NotaFinal >= 5 && NotaFinal <= 6.9m)
                    {
                        strEstado = "El estudiante debe tomar el EXAMEN COMPLEMENTARIO";
                    }
                    else if (NotaFinal < 5)
                    {
                        strEstado = "El estudiante se encuentra REPROBADO";
                    }

                    string selectedItem = (string)pckEstudiantes.SelectedItem;
                    DisplayAlert("RESULTADO: ", "Estudiante: " + NombreEst + "\n\nFecha: " + strFecha + "\n\nNota primer parcial: " + NotaPar1 + "\n\nNota segundo parcial: " + NotaPar2 + "\n\nNota Final: " + NotaFinal + "\n\n" + strEstado, "ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("RESULTADO: ", ex.Message, "ok");
            }
        }
        private void btnLimpiar_Clicked(object sender, EventArgs e)
        {
            limpiar();
        }
        public void limpiar()
        {
            dpFechaRegistro.Date = DateTime.Today;
            pckEstudiantes.SelectedIndex = -1;
            txtNotaSeguimiento.Text = "0";
            txtExamen.Text = "0";
            txtNotaSeguimiento2.Text = "0";
            txtExamen2.Text = "0";
        }
    }
}
