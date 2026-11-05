using rtoapantaTallerS5.Models;

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
    }

    private void btnMostrar_Cliecked(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        List<Persona> personas = App._personRepository.GetAllPerson();
        listaPersonas.ItemsSource = personas;
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        if(string.IsNullOrEmpty(txtId.Text))
        {
            lblMessage.Text = "El ID es requerido";
            return;
        }
        App._personRepository.UpdatePerson(int.Parse(txtId.Text), txtNombre.Text);
        lblMessage.Text = App._personRepository.Message;
    }

    private void btnDelete_Clicked(object sender, EventArgs e)
    {
        lblMessage.Text = string.Empty;
        if(string.IsNullOrEmpty(txtId.Text))
        {
            lblMessage.Text = "El ID es requerido";
            return;
        }
        App._personRepository.DeletePerson(int.Parse(txtId.Text));
        lblMessage.Text = App._personRepository.Message;
    }
}