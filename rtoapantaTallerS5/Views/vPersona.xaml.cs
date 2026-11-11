using rtoapantaTallerS5.Models;
using System.Linq;

namespace rtoapantaTallerS5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btn_Agregar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        App._personRepository.AddNewPerson(txtNombre.Text);
        lblMessage.Text = App._personRepository.Message;
        RecargarGrid();
        LimpiarFormulario();
    }

    private void btnMostrar_Cliecked(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        RecargarGrid();
    }

    private void RecargarGrid()
    {
        List<Persona> personas = App._personRepository.GetAllPerson();
        listaPersonas.ItemsSource = personas;
    }

    private void listaPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is not Persona persona)
            return;

        txtId.Text = persona.Id.ToString();
        txtNombre.Text = persona.Name;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        if (!int.TryParse(txtId.Text, out int id))
        {
            lblMessage.Text = "El ID es requerido";
            return;
        }
        App._personRepository.UpdatePerson(id, txtNombre.Text);
        lblMessage.Text = App._personRepository.Message;
        RecargarGrid();
        LimpiarFormulario();
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        if (!int.TryParse(txtId.Text, out int id))
        {
            lblMessage.Text = "El ID es requerido";
            return;
        }
        App._personRepository.DeletePerson(id);
        lblMessage.Text = App._personRepository.Message;
        RecargarGrid();
        LimpiarFormulario();
    }

    private void LimpiarFormulario()
    {
        listaPersonas.SelectedItem = null;
        txtId.Text = string.Empty;
        txtNombre.Text = string.Empty;
    }
}